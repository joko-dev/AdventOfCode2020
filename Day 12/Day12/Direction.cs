using System;
using System.Collections.Generic;
using System.Text;

namespace Day12
{
    class Direction
    {

        public const char NORTH = 'N';
        public const char SOUTH = 'S';
        public const char EAST = 'E';
        public const char WEST = 'W';
        public const char LEFT = 'L';
        public const char RIGHT = 'R';
        public const char FORWARDS = 'F';
        
        public char Action { get; }
        public int Value { get; }

        public Direction(string line)
        {
            Action = line[0];
            Value = Int32.Parse(line.Substring(1));
        }

        public Direction(char action, int value)
        {
            Action = action;
            Value = value;
        }
    }
}
