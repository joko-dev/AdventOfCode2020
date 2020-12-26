using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2
{
    internal class PasswordPolicy
    {
        public int minOccur { get; set; }
        public int maxOccur { get; set; }
        public char letter { get; set; }
        public string password { get; set; }

        public PasswordPolicy(string line)
        {
            string[] elements = line.Split(" ");
            string[] occurance = elements[0].Split("-");

            minOccur = Int32.Parse(occurance[0]);
            maxOccur = Int32.Parse(occurance[1]);

            letter = elements[1][0];
            password = elements[2];
        }

        public override string ToString()
        {
            return String.Format("{0}-{1} {2}: {3}", minOccur, maxOccur, letter, password);
        }

        public bool IsValidOld()
        {
            int count = password.ToCharArray().Count(c => c == letter);

            return (count >= minOccur & count <= maxOccur);
        }

        public bool IsValidNew()
        {
            bool valid;
            
            valid = ((password[minOccur-1] == letter) ^ (password[maxOccur-1] == letter));

            return valid;
        }
    }
}
