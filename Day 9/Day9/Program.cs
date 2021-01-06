using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number file:");
            string filepath = Console.ReadLine();

            Console.WriteLine("Preamble:");
            int preamble = Int32.Parse(Console.ReadLine());

            Int64 firstNumberWithoutSum = getFirstNumberWithoutSum(getNumberList(filepath), preamble);

            Console.WriteLine("First number without sum: {0}", firstNumberWithoutSum);
            Console.WriteLine("Sum of smallest and largest number in encryption weakness: {0}", getSumEncryptionWeakness(getNumberList(filepath), firstNumberWithoutSum));
        }

        private static Int64 getSumEncryptionWeakness(List<long> numbers, Int64 firstNumberWithoutSum)
        {
            List<Int64> toSum = new List<Int64>();

            for(int i = 0; i < numbers.Count; i++)
            {
                toSum.Clear();
                
                for (int j = i; j < numbers.Count; j++)
                {
                    toSum.Add(numbers[j]);
                    if(toSum.Sum() == firstNumberWithoutSum)
                    {
                        return (toSum.Min() + toSum.Max());
                    }
                    else if(toSum.Sum() > firstNumberWithoutSum)
                    {
                        break;
                    }
                }
            }

            return 0;
        }

        private static Int64 getFirstNumberWithoutSum(List<Int64> numbers, int preamble)
        {
            Int64 numberWithoutSum = 0;

            for (int i = preamble; i < numbers.Count; i++)
            {
                List<Int64> lastElements = numbers.GetRange(i - preamble, preamble);
                if (!isSumInList(lastElements, numbers[i]))
                {
                    numberWithoutSum = numbers[i];
                    break;
                }
            }

            return numberWithoutSum;
        }

        private static bool isSumInList(List<Int64> lastElements, Int64 sum)
        {
            for(int i = 0; i < lastElements.Count - 1; i++)
            {
                for(int j = i + 1; j < lastElements.Count; j++)
                {
                    if(lastElements[i] + lastElements[j] == sum)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static List<Int64> getNumberList(string filepath)
        {
            List<Int64> numberList = new List<Int64>();
            string fileInput = File.ReadAllText(filepath);

            fileInput = fileInput.Replace("\r\n", "\n");

            string[] numbers = fileInput.Split("\n");
            foreach (string number in numbers)
            {
                if (!String.IsNullOrEmpty(number))
                {
                    numberList.Add(Int64.Parse(number));
                }
            }

            return numberList;
        }
    }
}
