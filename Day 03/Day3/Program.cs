using System;
using System.Diagnostics;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File with tree map:");
            string filepath = Console.ReadLine();

            TreeMap map = new TreeMap(filepath);

            Console.WriteLine("Tree count: {0}", getTreeCount(map, 2, 1));
            Console.WriteLine("Tree Multiplier: {0}", getTreeCount(map, 1, 1)
                                                        * getTreeCount(map, 1, 3)
                                                        * getTreeCount(map, 1, 5)
                                                        * getTreeCount(map, 1, 7)
                                                        * getTreeCount(map, 2, 1));
        }

        private static int getTreeCount(TreeMap map, int down, int right)
        {
            int count = 0;
            map.ResetStartingPoint();
            while (map.TraverseMap(down, right))
            {
                if (map.IsCurrentPositionATree())
                {
                    count++;
                }
            }

            return count;
        }
    }
}
