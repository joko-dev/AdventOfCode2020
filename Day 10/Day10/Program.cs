using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jolt file:");
            string filepath = Console.ReadLine();
            List<int> numbers = getNumberList(filepath);
           

            Console.WriteLine("1-jolt-diff * 3-jolt-diff: {0}", getJoltDiffSum(getNumberList(filepath)));
            Console.WriteLine("Waycount: {0}", getWaycount(getNumberList(filepath)));
        }

        private static int getJoltDiffSum(List<int> numbers)
        {
            int diff = 0;
            int sumDiff1 = 0;
            int sumDiff3 = 0;

            // charging outlet
            numbers.Add(0);
            // own device
            numbers.Add(numbers.Max() + 3);
            numbers.Sort();

            for (int i = 1; i < numbers.Count; i++)
            {
                diff = numbers[i] - numbers[i - 1];
                if (diff == 1)
                {
                    sumDiff1++;
                }
                else if (diff == 3)
                {
                    sumDiff3++;
                }
            }

            return (sumDiff1 * sumDiff3);
        }

        private static Int64 getWaycount(List<int> numbers)
        {
            Int64 count = 0;
            Dictionary<int, Int64> waycounts = new Dictionary<int, Int64>();

            // own device
            numbers.Add(numbers.Max() + 3);
            numbers.Sort();
            waycounts.Add(0, 1);

            // remember for each value, how many waycounts each 1/2/3-predecessors are available
            // the last elements cotains all possible ways
            foreach (int number in numbers)
            {
                waycounts.Add(number, waycounts.GetValueOrDefault(number - 3, 0) + waycounts.GetValueOrDefault(number - 2, 0) + waycounts.GetValueOrDefault(number - 1, 0));
            }

            count = waycounts.GetValueOrDefault(numbers[numbers.Count - 1]);

            return count;
        }

        private static List<int> getNumberList(string filepath)
        {
            List<int> numberList = new List<int>();
            string fileInput = File.ReadAllText(filepath);

            fileInput = fileInput.Replace("\r\n", "\n");

            string[] numbers = fileInput.Split("\n");
            foreach (string number in numbers)
            {
                if (!String.IsNullOrEmpty(number))
                {
                    numberList.Add(int.Parse(number));
                }
            }

            return numberList;
        }
    }
}
