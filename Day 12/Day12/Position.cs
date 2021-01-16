using System;
using System.Collections.Generic;
using System.Text;

namespace Day12
{
    class Position
    {
        public int NorthSouth { get; set; }
        public int EastWest { get; set; }

        public Position(int northSouth, int eastWest) 
        {
            NorthSouth = northSouth;
            EastWest = eastWest;
        }

        public int getManhattanDistance()
        {
            return (Math.Abs(EastWest) + Math.Abs(NorthSouth));
        }

        public void AddValues(int northSouthToAdd, int eastWestToAdd)
        {
            NorthSouth += northSouthToAdd;
            EastWest += eastWestToAdd;
        }
    }
}
