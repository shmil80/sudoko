using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudoku
{
    public class Mispar:Misparpashut
    {
        public readonly int X, Y, mishbetset,indexMishbetset;

        public bool yashrak1 { get { return shayah.Count == 1; } }

        Sudoku parent;
        public List<int> shayah = new List<int>();
        public List<int> lo_shayah = new List<int>();
        public Mispar(Sudoku parent, int index)
        {
            this.index = index;
            this.parent = parent;
        }
        public Mispar(Sudoku parent, int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            index = X + Y * Sudoku.rank;
            mishbetset = X / Sudoku.ranksquare + (Y / Sudoku.ranksquare) * Sudoku.ranksquare;
            indexMishbetset = X % Sudoku.ranksquare + (Y % Sudoku.ranksquare) * Sudoku.ranksquare;
            this.parent = parent;
        }
        public void shayahAll()
        {
            shayah.Clear();
            for (int i = 0; i < Sudoku.rank; i++)
                    shayah.Add(i + 1);
        }

        internal bool RemoveShayah(int item,bool hitsoni)
        {
            if(hitsoni&&!lo_shayah.Contains(item))
                lo_shayah.Add(item);
            return shayah.Remove(item);
        }
        internal void RemoveLoShayah(int item)
        {
             lo_shayah.Remove(item);
        }
        public override string ToString()
        {
            return Value==null?" ":Value.ToString();
        }

        //internal bool shayahContainsYoter(params int[] values)
        //{
        //    if (values.Length > shayah.Count) 
        //        return false;
        //    return values.All(i => shayah.Contains(i));
        //}


        internal bool shayahEquals(Mispar other)
        {
            if(shayah.Count!=other.shayah.Count)
                return false;
            for (int i = 0; i < shayah.Count; i++)
                if (shayah[i] != other.shayah[i])
                    return false;
            return true;
        }

    }
}
