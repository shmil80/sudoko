using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudoku
{
    class SudokuMushlam : Sudoku
    {
        public SudokuMushlam(Mispar[] yedouim)
            : base
                (yedouim, true, true)
        {
            for (int i = 0; i < 50; i++)
            {
                bne_rand();
                if (mushlamTov)
                    return;
                bne_yadoua(yedouim);
            }
        }
        void bne_rand()
        {
            Random rand = new Random();

            for (int i = 0; i < rank2; i++)
            {
                Mispar m = lo_yeduim.ElementAtOrDefault(0);
                if (m == null) return;
                Pshane(m.index, m.shayah[rand.Next(m.shayah.Count)], true);
            }
        }
        IEnumerable<Mispar> lo_yeduim
        {
            get
            {
                return from mispar in mishbetsotall
                       where mispar.Value == null
                       where mispar.shayah.Count > 1
                       orderby mispar.shayah.Count
                       select mispar;
            }
        }

    }
}
