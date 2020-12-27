using NUnit.Framework;
using Day4;

namespace Day4
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string test = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd\nbyr:1937 iyr:2017 cid:147 hgt:183cm";
            Passport passport = new Passport(test);

            Assert.True(passport.IsValid());
        }

        [Test]
        public void Test2()
        {
            string test = "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884\nhcl:#cfa07d byr:1929";
            Passport passport = new Passport(test);

            Assert.False(passport.IsValid());
        }

        [Test]
        public void Test3()
        {
            string test = "hcl:#ae17e1 iyr:2013\neyr:2024\necl:brn pid:760753108 byr:1931\nhgt:179cm";
            Passport passport = new Passport(test);

            Assert.True(passport.IsValid());
        }

        [Test]
        public void Test4()
        {
            string test = "hcl:#cfa07d eyr:2025 pid:166559648\niyr:2011 ecl:brn hgt:59in";
            Passport passport = new Passport(test);

            Assert.False(passport.IsValid());
        }
    }
}