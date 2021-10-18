using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace sudoku
{
    public class Sudoku : IEnumerable<Mispar>
    {
        #region members
        private static int Pranksquare = 3;
        public static int rank = Pranksquare * Pranksquare, rank2 = rank * rank;
        public static int ranksquare
        {
            get { return Pranksquare; }
            set { Pranksquare = value; rank = value * value; rank2 = rank * rank; }
        }
        Mispar[][] mishbetsotXY, mishbetsotYX, mishbetsotS;
        protected Mispar[] mishbetsotall;
        Value[][] valuesYV, valuesXV, valuesSV;
        bool  bdok_hakol, yasem_bdika;
        bool yesh_taouyot;
        public Mispar this[int index]
        { get { return mishbetsotall[index]; } }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return mishbetsotall.GetEnumerator();
        }
        IEnumerator<Mispar> IEnumerable<Mispar>.GetEnumerator()
        {
            return mishbetsotall.OfType<Mispar>().GetEnumerator();
        }
        #endregion

        #region contructor
        public Sudoku(Misparpashut[] yedouim, bool bdok_hakol, bool yasem_bdika)
        {
            this.bdok_hakol = bdok_hakol;
            this.yasem_bdika = yasem_bdika;
            mishbetsotXY = new Mispar[rank][];
            mishbetsotYX = new Mispar[rank][];
            mishbetsotS = new Mispar[rank][];
            mishbetsotall = new Mispar[rank2];

            valuesYV = new Value[rank][];
            valuesXV = new Value[rank][];
            valuesSV = new Value[rank][];
            for (int i = 0; i < rank; i++)
            {
                mishbetsotXY[i] = new Mispar[rank];
                mishbetsotYX[i] = new Mispar[rank];
                mishbetsotS[i] = new Mispar[rank];
                valuesYV[i] = new Value[rank];
                valuesXV[i] = new Value[rank];
                valuesSV[i] = new Value[rank];
            }
            for (int y = 0; y < rank; y++)
                for (int x = 0; x < rank; x++)
                {
                    mishbetsotXY[x][y] = new Mispar(this, x, y);
                    mishbetsotYX[y][x] = mishbetsotXY[x][y];
                    mishbetsotS
                        [(y / ranksquare) * ranksquare + x / ranksquare]
                        [(y % ranksquare) * ranksquare + x % ranksquare] = mishbetsotXY[x][y];
                    mishbetsotall[x + y * rank] = mishbetsotXY[x][y];
                    valuesYV[x][y] = new Value(y + 1, sug_meda.Y, x);
                    valuesXV[x][y] = new Value(y + 1, sug_meda.X, x);
                    valuesSV[x][y] = new Value(y + 1, sug_meda.mishbetset, x);
                }
            bne_yadoua(yedouim);

        }
        private void hakol_shayah()
        {
            for (int x = 0; x < rank; x++)
                for (int y = 0; y < rank; y++)
                {
                    mishbetsotXY[x][y].shayahAll();
                    valuesYV[x][y].shayahAll();
                    valuesXV[x][y].shayahAll();
                    valuesSV[x][y].shayahAll();
                }
        }
        #endregion

        #region bniya

        protected void bne_yadoua(Misparpashut[] yedouim)
        {
            foreach (Mispar m in mishbetsotall)
                mehak(m.index, false);
            hakol_shayah();
            if(yedouim!=null)
                foreach (Misparpashut m in yedouim)
                    if (m.Value != null)
                    Pshane(m.index, m.Value, false);
            //yesh_taouyot = Taouyot().Any();
            bdika_mehadash();
        }
        public Misparpashut[] yeduim_ahshav
        {
            get
            {
                return (from mispar in mishbetsotall
                        where mispar.Value != null
                        select new Misparpashut() { Value = mispar.Value, index = mispar.index }).ToArray();
            }
        }

        #endregion

        #region shinuy

        internal void Pshane(int index, int? shinuy, bool bdok, bool yisum = true)
        { 
            Mispar m = mishbetsotall[index];
            int? old = m.Value;
            if (old != null)
                mehak(index, bdok);
            if (shinuy != null)
            {
                shane(index, shinuy.Value, false, yisum);
                if (bdok )
                {
                    yesh_taouyot=Taouyot().Any();
                    Misparpashut[] Yeduim_berega_ze = yeduim_ahshav;
                    Bdok(mishbetsotall[index], shinuy.Value);
                    if (!yesh_taouyot && Taouyot().Any())
                    {
                        yesh_taouyot = true;
                        bne_yadoua(Yeduim_berega_ze);
                    }
                }
            }
        }
        void mehak(int index, bool bdok)
        {
            Mispar m = mishbetsotall[index];
            int? old = m.Value;
            if (old != null)
            {
                valuesYV[(int)old - 1][m.Y].batel_parent();
                valuesXV[(int)old - 1][m.X].batel_parent();
                valuesSV[(int)old - 1][m.mishbetset].batel_parent();
            }
            m.Value = null;
            if (bdok)
                bdika_mehadash();
        }
        void shane(int index, int shinuy, bool bdok,bool yisum)
        {
            Mispar m = mishbetsotall[index];

            int? old = m.Value;
            if (yisum)
            {
                m.Value = shinuy;
                batel_shayh_Minivhar(m);
            }
            else
            {
                m.shayah.Clear();
                m.shayah.Add(shinuy);
            }
            valuesSV[m.mishbetset][shinuy - 1].tfos();
            valuesYV[m.Y][shinuy - 1].tfos();
            valuesXV[m.X][shinuy - 1].tfos();
            if (bdok)
                Bdok(m,shinuy);
        }
        #endregion

        #region bdikot

        enum bditot { batel_shayah, doresh_many };

        void Bdok(Mispar m,int value)
        {
            requestMishbetset(m.X, m.Y, m.mishbetset, bditot.batel_shayah, value);
            if (bdok_hakol && !yesh_taouyot)
                requestValue(m, bditot.batel_shayah, value);
        }
        void batel_shayh_Minivhar(Mispar m)
        {
            m.shayah.Clear();
            valuesSV[m.mishbetset][(int)m.Value-1].shayah.Clear();
            valuesXV[m.X][(int)m.Value - 1].shayah.Clear();
            valuesYV[m.Y][(int)m.Value - 1].shayah.Clear();
        }
        public void bdika_mehadash()
        {
            hakol_shayah();
            foreach (Mispar m in mishbetsotall)
                if (m.Value != null)
                    batel_shayh_Minivhar(m);
            foreach (Mispar m in mishbetsotall)
                foreach (int i in m.lo_shayah)
                    batel_shayah_mishbetset(m, i, false);
            foreach (Mispar m in mishbetsotall)
                if (m.Value != null)
                    Bdok(m, (int)m.Value);
        }

        #region bdikot value
        void requestValue(Mispar New, bditot sug, int value)
        {
            for (int q = 0; q < 3; q++)
            {
                Value[] query = null;
                int index = -1;
                switch (q)
                {
                    case 0: query = valuesSV[New.mishbetset]; index = New.indexMishbetset; break;
                    case 1: query = valuesXV[New.X]; index = New.Y; break;
                    case 2: query = valuesYV[New.Y]; index = New.X; break;
                }
                switch (sug)
                {
                    case bditot.batel_shayah: batel_shayah_value(query, index); break;
                    case bditot.doresh_many: value_doresh_many(query); break;
                }
            }
        }

        private void batel_shayah_value(Value[] query, int index)
        {
            foreach (Value V in query)
                batel_shayah_value(V, index);
        }
        private void batel_shayah_value(Value V, int index)
        {
            if (!V.tafus && V.RemoveShayah(index))
            {
                Value_doresh1(V);
                batel_shayah_mishbetset(mishbetsotall[V.metsaindex(index)], V,false);
                requestValue(mishbetsotall[V.metsaindex(index)], bditot.doresh_many, V);
            }
        }


        private bool Value_doresh1(Value V)
        {
            if (V.shayah.Count == 1)
            {
                int index = -1;
                if (V.X != null)
                    index = indexXY(V.X, V.shayah[0]);
                else if (V.Y != null)
                    index = indexXY(V.shayah[0], V.Y);
                else
                    index = indexMihsbetset(V.mishbetset, V.shayah[0]);
                if (mishbetsotall[index].Value == null&&mishbetsotall[index].shayah.Count!=1)
                    shane(index, V, true, yasem_bdika && !yesh_taouyot);
                return true;
            }
            return false;
        }

        public static int indexMihsbetset(int? mishbetset, int index)
        {
            return indexXY((mishbetset % ranksquare) * ranksquare + index % ranksquare, (mishbetset / ranksquare) * ranksquare + index / ranksquare);
        }

        public static int indexXY(int? X, int? Y)
        {
            return (int)(Y * rank + X);
        }
        private void value_doresh_many(Value[] query)
        {
            var request = (from mispar in query
                           where !mispar.tafus
                           select mispar).ToArray();
            foreach (Value V in request)
                if (Value_doresh1(V))
                    return;
            for (int i = 0; i < request.Length; i++)
            {
                if (request[i].shayah.Count > rank - 2)
                    continue;
                var request1 = (from V1 in request.Skip(i)
                                where V1.shayahEquals(request[i])
                                select V1).ToArray();
                if (request1.Length < 2 || request1.Length == request.Length || request1.Length != request1[0].shayah.Count)
                    continue;
                var requedt2 = (from mispar in request
                                where !request1.Contains(mispar)
                                select mispar).ToArray();
                for (int j = 0; j < request1[0].shayah.Count; j++)
                    batel_shayah_value(requedt2, request1[0].shayah[j]);
            }
        }
        #endregion

        #region bdikot mishbetset
        void requestMishbetset(int X, int Y, int mishbetset, bditot sug, int value)
        {
            for (int q = 0; q < 3; q++)
            {
                Mispar[] query = null;
                switch (q)
                {
                    case 0: query = mishbetsotXY[X];  break;
                    case 1: query = mishbetsotYX[Y]; break;
                    case 2: query = mishbetsotS[mishbetset]; break;
                }
                switch (sug)
                {
                    case bditot.batel_shayah:
                            batel_shayah_mishbetset(query, value);
                        break;
                    case bditot.doresh_many: mishbetset_doreshet_many(query); break;
                }
            }
        }
        private void batel_shayah_mishbetset(Mispar[] query, int value)
        {
            foreach (Mispar m in query)
                batel_shayah_mishbetset(m, value,false);
        }
        public void batel_shayah_mishbetset_hitsoni(Mispar m, int value)
        {
            batel_shayah_mishbetset(m, value, true);
        }
        internal void hahzer_shayah_mishbetset_hitsoni(Mispar m, int value)
        {
            m.RemoveLoShayah(value);
            Pshane(m.index, m.Value, true);
        }
        protected void batel_shayah_mishbetset(Mispar m, int value, bool hitsoni)
        {
            if (m.Value != null || m.shayah.Count == 1)
                return;
            if (m.RemoveShayah(value, hitsoni))
            {
                mishbetset_doreshet1(m);
                if (!bdok_hakol || yesh_taouyot)
                    return;
                requestMishbetset(m.X, m.Y, m.mishbetset, bditot.doresh_many, value);

                batel_shayah_value(valuesSV[m.mishbetset][value - 1], m.indexMishbetset);
                batel_shayah_value(valuesXV[m.X][value - 1], m.Y);
                batel_shayah_value(valuesYV[m.Y][value - 1], m.X);
            }
        }

        private void mishbetset_doreshet_many(Mispar[] query)
        {
            var request = (from mispar in query
                           where mispar.Value == null
                           select mispar).ToArray();
            foreach (Mispar m in request)
                if (mishbetset_doreshet1(m))
                    return;
            for (int i = 0; i < request.Length;i++ )
                
            {
                if (request[i].shayah.Count > rank - 2)
                    continue;
                var request1 = (from m1 in request.Skip(i)
                                where m1.shayahEquals(request[i])
                                select m1).ToArray();
                if (request1.Length < 2 || request1.Length == request.Length || request1.Length != request1[0].shayah.Count)
                    continue;
                var requedt2=(from mispar in request
                                     where !request1.Contains(mispar)
                                     select mispar).ToArray();
                for (int j=0; j < request1[0].shayah.Count; j++)
                    batel_shayah_mishbetset(requedt2, request1[0].shayah[j]);
            }
        }

        private bool mishbetset_doreshet1(Mispar m)
        {
            if (m.yashrak1)
            {
                if (bdok_hakol || yasem_bdika)
                    shane(m.index, m.shayah[0], true, yasem_bdika && !yesh_taouyot);
                return true;
            }
            return false;
        }
        #endregion


        #endregion

        #region taouyot
        public bool mushlam
        { get { return !this.Any(m => m.Value == null); } }

        public bool mushlamTov
        { get { return mushlam && !Taouyot().Any(); } }
        public IEnumerable<Mispar> Taouyot()
        {
            return from mispar in mishbetsotall
                   from mispar2 in mishbetsotall
                   where mispar2.X == mispar.X || mispar2.Y == mispar.Y || mispar2.mishbetset == mispar.mishbetset
                   where mispar2 != mispar
                   where mispar2.Value != null
                   where mispar.Value != null
                   where (int)mispar2.Value == mispar.Value
                   select mispar2;
        }

        #endregion
        List<string> afiche
        {
            get
            {
                List<string> result = new List<string>();
                foreach (var s in mishbetsotYX)
                {
                    string S = "";
                    foreach (var ss in s)
                        S += ss + ",";
                    result.Add(S);
                }
                return result;
            }
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < rank; i++)
            {
                if (i != 0)
                    s.Append("\n");
                for (int j = 0; j < rank; j++)
                {
                    if (j != 0)
                        s.Append("\t");
                    s.Append(mishbetsotYX[i][j].ToString());
                }
            }
            return s.ToString();
        }

    }
}
