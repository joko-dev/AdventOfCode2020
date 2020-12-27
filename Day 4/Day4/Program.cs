using System;
using System.Collections.Generic;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Passport file:");

            string filepath = Console.ReadLine();

            Console.WriteLine("Valid passports: {0}", getValidPassports(getListPassports(filepath)));
        }

        private static int getValidPassports(List<Passport> passports)
        {
            int count = 0;
            foreach( Passport passport in passports)
            {
                if (passport.IsValid())
                {
                    count++;
                }
            }

            return count;
        }

        private static List<Passport> getListPassports(string filepath)
        {
            List<Passport> passports = new List<Passport>();
            StreamReader file = File.OpenText(filepath);
            string input = file.ReadToEnd();

            //Sanitize
            input = input.Replace("\r\n", "\n");
            string[]  lines = input.Split("\n\n");
            
            foreach (string line in lines)
            {
                passports.Add(new Passport(line));
            }

            return passports;
        }
    }
}
