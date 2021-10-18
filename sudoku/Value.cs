using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudoku
{
    public enum sug_meda{X,Y,mishbetset}
    public class Value
    {
        sug_meda sug;
        public readonly int? X;
        public readonly int? Y;
        public readonly int? mishbetset;
        readonly int num;
        public Value(int num,sug_meda sug,int yadoua)
        {
        this.num=num;
        this.sug = sug;
            switch(sug)
            {
                case sug_meda.mishbetset:mishbetset=yadoua;break;
                case sug_meda.X:X=yadoua;break;
                case sug_meda.Y:Y=yadoua;break;
            }
        }
        public static implicit operator int(Value v)
        {
            return v.num;
        }
        public static explicit operator int?(Value v)
        {
            return v==null?null:(int?) v.num;
        }
        public bool tafus { get; private set; }
        public void tfos()
        {
            tafus=true;
            shayah.Clear();
        }
        internal void batel_parent()
        {
            tafus = false;
        }

        public List<int> shayah = new List<int>();
        public void shayahAll()
        {
            tafus = false;
            shayah.Clear();
            for (int i = 0; i < Sudoku.rank; i++)
                shayah.Add(i);
        }


        internal bool RemoveShayah(int indexYadoua)
        {
           return shayah.Remove(indexYadoua);
        }
        //static string[] gimatria = { "א", "ב", "ג", "ד", "ה", "ו", "ז", "ח", "ט","י" };
        public override string ToString()
        {
            //return gimatria[num];
            return num.ToString();
        }

        internal int metsaindex(int index)
        {
            switch (sug)
            {
                case sug_meda.X: return Sudoku.indexXY(X, index);
                case sug_meda.Y: return Sudoku.indexXY(index, Y);
                default: return Sudoku.indexMihsbetset(mishbetset, index);
            }
        }

        internal bool shayahEquals(Value other)
        {
            if (shayah.Count != other.shayah.Count)
                return false;
            for (int i = 0; i < shayah.Count; i++)
                if (shayah[i] != other.shayah[i])
                    return false;
            return true;
        }
    }
}
