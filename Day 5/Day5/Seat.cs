using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day5
{
    public class Seat : IComparable<Seat>
    {
        private int row;
        private int column;
        public int SeatID { get { return row * 8 + column; } }
        public Seat(string line)
        {
            row = decodeBitmask(line.Substring(0,7), 'F', 'B');
            column = decodeBitmask(line.Substring(7, 3), 'L', 'R');
        }

        private int decodeBitmask(string bitmask, char lowerHalf, char upperHalf)
        {
            int minValue = 0;
            int maxValue = (int) Math.Pow(2, bitmask.Length);
            string bitmasktemp = bitmask;
            List<int> values = Enumerable.Range(minValue, maxValue).ToList();

            while(bitmasktemp.Length > 0)
            {
                char firstChar = bitmasktemp[0];

                if (firstChar == lowerHalf)
                {
                    values.RemoveRange(values.Count() / 2, values.Count() / 2);
                }
                else if (firstChar == upperHalf)
                {
                    values.RemoveRange(0, values.Count() / 2);
                }

                bitmasktemp = bitmasktemp.Remove(0, 1);
            }

            return values[0];
        }

        public int CompareTo(Seat obj)
        {
            return this.SeatID - obj.SeatID;
        }
    }
}
