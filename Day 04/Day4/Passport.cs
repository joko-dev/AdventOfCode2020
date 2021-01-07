using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4
{
    public class Passport
    {
        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public string cid { get; set; }

        public Passport(string values)
        {
            values = values.Replace("\r\n", " ");
            values = values.Replace("\n", " ");
            values = values.Replace(" ", " ");

            string[] items = values.Split(" ");

            foreach (string item in items)
            {
                if(item.StartsWith("byr")) { byr = extractValue(item); }
                else if (item.StartsWith("iyr")) { iyr = extractValue(item); }
                else if (item.StartsWith("eyr")) { eyr = extractValue(item); }
                else if (item.StartsWith("hgt")) { hgt = extractValue(item); }
                else if (item.StartsWith("hcl")) { hcl = extractValue(item); }
                else if (item.StartsWith("ecl")) { ecl = extractValue(item); }
                else if (item.StartsWith("pid")) { pid = extractValue(item); }
                else if (item.StartsWith("cid")) { cid = extractValue(item); }
            }
        }

        private string extractValue(string toParse)
        {
            string[] values = toParse.Split(":");
            return values[1];
        }

        public bool IsValid()
        {
            bool ret = validateByr();
            ret = ret && validateIyr();
            ret = ret && validateEyr();
            ret = ret && validateHgt();
            ret = ret && validateHcl();
            ret = ret && validateEcl();
            ret = ret && validatePid();

            return ret;
        }

        public bool validateByr()
        {
            try
            {
                int year = Int32.Parse(byr);

                return (year >= 1920) && (year <= 2002);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool validateIyr()
        {
            try
            {
                int year = Int32.Parse(iyr);

                return (year >= 2010) && (year <= 2020);
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool validateEyr()
        {
            try
            {
                int year = Int32.Parse(eyr);

                return (year >= 2020) && (year <= 2030);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool validateHgt()
        {
            bool ret = false;
            int height = 0;

            if(!String.IsNullOrEmpty(hgt))
            {
                try
                {
                    
                    if (hgt.EndsWith("cm"))
                    {
                        height = Int32.Parse(hgt.Substring(0, 3));
                        ret = (height >= 150) && (height <= 193);
                    }
                    else if (hgt.EndsWith("in"))
                    {
                        height = Int32.Parse(hgt.Substring(0, 2));
                        ret = (height >= 59) && (height <= 76);
                    }
                }
                catch (Exception e)
                {
                }
            }
            
            return ret;
        }
        public bool validateHcl()
        {
            bool ret = false;
            if(!String.IsNullOrEmpty(hcl))
            {
                ret = Regex.IsMatch(hcl, "^#[a-fA-F0-9]{6}$");
            }

            return ret;
        }
        public bool validateEcl()
        {
            bool ret = String.Equals(ecl,"amb");
            ret = ret || String.Equals(ecl, "blu");
            ret = ret || String.Equals(ecl, "brn");
            ret = ret || String.Equals(ecl, "gry");
            ret = ret || String.Equals(ecl, "grn");
            ret = ret || String.Equals(ecl, "hzl");
            ret = ret || String.Equals(ecl, "oth");
            return ret;
        }
        public bool validatePid()
        {
            bool ret = false;

            if (!String.IsNullOrEmpty(pid))
            {
                ret = Regex.IsMatch(pid, "^[0-9]{9}$");
            }

            return ret;
        }
    }
}
