using System;
using System.Collections.Generic;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File with password + policies");
            string filepath = Console.ReadLine();

            List<PasswordPolicy> passwords = getPasswords(filepath);

            Console.WriteLine("Valid Passwords old policy: {0}", getCountValidPasswordsOld(passwords));
            Console.WriteLine("Valid Passwords new policy: {0}", getCountValidPasswordsNew(passwords));

        }

        private static int getCountValidPasswordsOld(List<PasswordPolicy> passwords)
        {
            int valid = 0;

            foreach(PasswordPolicy password in passwords)
            {
                if (password.IsValidOld()) { valid++; }
            }

            return valid;
        }

        private static int getCountValidPasswordsNew(List<PasswordPolicy> passwords)
        {
            int valid = 0;

            foreach (PasswordPolicy password in passwords)
            {
                if (password.IsValidNew()) { valid++; }
            }

            return valid;
        }

        private static List<PasswordPolicy> getPasswords(string filepath)
        {
            List<PasswordPolicy> list = new List<PasswordPolicy>();
            StreamReader file = File.OpenText(filepath);

            string line;
            while ((line = file.ReadLine()) != null)
            {
                list.Add(new PasswordPolicy(line));
            }

            return list;
        }
    }
}
