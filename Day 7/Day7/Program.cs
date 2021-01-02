using System;
using System.Collections.Generic;
using System.IO;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bag file:");

            string filepath = Console.ReadLine();
            List<BagColorType> colorsProcessed = new List<BagColorType>();

            Console.WriteLine("At least one shiny gold bag: {0}", countBagsForColor(getBagTypeList(filepath), new BagColorType("shiny gold"), colorsProcessed));
            Console.WriteLine("Bags inside shiny gold bag: {0}", countBagsInsideBagCount(getBagTypeList(filepath), new BagColorType("shiny gold")));
        }

        private static int countBagsForColor(List<BagType> bagTypeList, BagColorType bagColorTypeToSearch, List<BagColorType> colorsProcessed)
        {
            int count = 0;

            foreach (BagType bagType in bagTypeList)
            {
                if (bagType.ContainsColor(bagColorTypeToSearch) && !colorsProcessed.Contains(bagType.Color))
                {
                    count++;
                    colorsProcessed.Add(bagType.Color);
                    count += countBagsForColor(bagTypeList, bagType.Color, colorsProcessed);
                }
            }

            return count;
        }

        private static int countBagsInsideBagCount(List<BagType> bagTypeList, BagColorType bagColorTypeToSearch)
        {
            int count = 0;

            foreach (BagType bagType in bagTypeList)
            {
                if (bagType.Color.Equals(bagColorTypeToSearch))
                {
                    foreach (Tuple<int, BagColorType> bag in bagType.ContainableBagColors)
                    {
                        count += bag.Item1 * ( 1 + countBagsInsideBagCount(bagTypeList, bag.Item2));
                    }
                    
                }
            }

            return count;
        }

        private static List<BagType> getBagTypeList(string filepath)
        {
            List<BagType> bagTypeList = new List<BagType>();
            string fileInput = File.ReadAllText(filepath);

            fileInput = fileInput.Replace("\r\n", "\n");

            string[] bagTypes = fileInput.Split("\n");
            foreach (string bagType in bagTypes)
            {
                if(!String.IsNullOrEmpty(bagType))
                {
                    bagTypeList.Add(new BagType(bagType));
                }
            }

            return bagTypeList;
        }
    }
}
