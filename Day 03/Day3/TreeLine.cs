using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    class TreeLine
    {
        private string treeline;

        const char tree = '#';


        public TreeLine(string treeline)
        {
            this.treeline = treeline;
        }

        public override string ToString()
        {
            return treeline;
        }

        public bool IsTree(int position)
        {
            return (treeline[position] == tree);
        }

        public int Length()
        {
            return treeline.Length;
        }
    }
}
