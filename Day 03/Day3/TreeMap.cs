using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day3
{
    class TreeMap
    {
        private List<TreeLine> treeMap;
        private int currentPositionX;
        private int currentPositionY;

        public TreeMap(string filepath)
        {
            ResetStartingPoint();
            this.treeMap = InitializeTreeMap(filepath);
        }

        private List<TreeLine> InitializeTreeMap(string filepath)
        {
            List<TreeLine> map = new List<TreeLine>();
            StreamReader file = File.OpenText(filepath);

            string line;
            while ((line = file.ReadLine()) != null)
            {
                map.Add(new TreeLine(line));
            }

            return map;
        }

        public void ResetStartingPoint()
        {
            this.currentPositionX = 0;
            this.currentPositionY = 0;
        }
        public bool TraverseMap(int down, int right)
        {
            bool traversePossible = false;
            
            if ((currentPositionY + down < treeMap.Count)) 
            {
                int length = treeMap[down].Length();

                if (currentPositionX + right >= length)
                {
                    currentPositionX = currentPositionX + right - length;
                }
                else{
                    currentPositionX += right;
                }

                currentPositionY += down;

                traversePossible = true;
            }

            return traversePossible;
        }

        internal string GetCurrentTreeLine()
        {
            string treeLine = treeMap[currentPositionY].ToString();

            StringBuilder sb = new StringBuilder(treeLine);
            sb[currentPositionX] = 'o';
            treeLine = sb.ToString();

            return treeLine;
        }

        public bool IsCurrentPositionATree()
        {
            return (treeMap[currentPositionY].IsTree(currentPositionX));
        }
    }
}
