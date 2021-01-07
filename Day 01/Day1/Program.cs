using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath;
            List<int> numberList;
            int summand1;
            int summand2;
            int summand3;

            Console.WriteLine("File with Numbers:");
            filepath = Console.ReadLine();
            numberList = getNumberList(filepath);

            find2020Summands(numberList, out summand1, out summand2);
            Console.WriteLine("Output: {0} + {1} = {2}", summand1, summand2, summand1 * summand2);

            find2020Summands(numberList, out summand1, out summand2, out summand3);
            Console.WriteLine("Output: {0} + {1} + {2} = {3}", summand1, summand2, summand3, summand1 * summand2 * summand3);
        }

        static List<int> getNumberList(string filepath)
        {
            List<int> numbers = new List<int>();
            StreamReader file = File.OpenText(filepath);

            string line;
            while((line = file.ReadLine()) != null)
            {
                numbers.Add(Int32.Parse(line));
            }

            return numbers;
        }

        static void find2020Summands(List<int> numbers, out int summand1, out int summand2)
        {
            summand1 = 0;
            summand2 = 0;

            foreach (int val in numbers)
            {
                foreach(int val2 in numbers)
                {
                    if (val + val2 == 2020)
                    {
                        summand1 = val;
                        summand2 = val2;

                        return;
                    }
                }
            }
        }

        static void find2020Summands(List<int> numbers, out int summand1, out int summand2, out int summand3)
        {
            summand1 = 0;
            summand2 = 0;
            summand3 = 0;

            foreach (int val in numbers)
            {
                foreach (int val2 in numbers)
                {
                    foreach (int val3 in numbers)
                    {

                        if (val + val2 + val3 == 2020)
                        {
                            summand1 = val;
                            summand2 = val2;
                            summand3 = val3;

                            return;
                        }
                    }
                }
            }
        }
    }
}

