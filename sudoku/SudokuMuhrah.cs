using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudoku
{
    class SudokuMuhrah : Sudoku
    {
        public bool hitsliah;
        public SudokuMuhrah(int amount)
            : base(new SudokuMushlam(null).ToArray(), true, false)
        {
            hitsliah=mehak(amount);
        }

        private bool mehak(int amount)
        {
            int mone = 0;
            if (amount >= rank2)
                amount = rank2 - 1;
            Random rand = new Random();
            bool[] hayavim = new bool[rank2];
            for (int i = 0; i < amount; i++)
            {
                Misparpashut[] yeduim = yeduim_ahshav;
                int start=rand.Next(yeduim.Length);
                for (int j = 0; j <= yeduim.Length; j++)
                {
                    mone++;
                    if (j == yeduim.Length)
                        return false;
                    Misparpashut old = yeduim.ElementAt((start + j) % yeduim.Length);
                    if (hayavim[old.index])
                        continue;
                    int value = (int)old.Value;
                    Pshane(old.index, null, true);
                    if (yesh_rak_efsharut_1())
                        break;
                    hayavim[old.index] = true;
                    Pshane(old.index, value, true);
                }
            }
            return true;
        }

        private bool yesh_rak_efsharut_1()
        {
            //Mispar[] base_yeduim = yeduim_ahshav;
            foreach (Mispar m in from mispar in mishbetsotall
                                 where mispar.Value == null
                                 where mispar.shayah.Count != 1
                                 select mispar)
            {

                //for (int i = 0; i < m.shayah.Count; i++)
                //{
                //    List<Mispar> yeduim = new List<Mispar>(base_yeduim);
                //    yeduim.Add(new Mispar(null, m.index) { mValue = new Value(m.shayah[i], null) });
                //    if (!new SudokuMushlam(yeduim.ToArray()).mushlamTov)
                //        batel_shayah_mishbetset(m, m.shayah[i]);
                //    if (m.shayah.Count == 1)
                //        break;

                //}
                //if (m.shayah.Count != 1)
                    return false;
            }
            return true;
        }
    }
}
