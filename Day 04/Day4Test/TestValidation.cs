using System;
using Day4;
using NUnit.Framework;

namespace Day4Test
{
    public class TestValidation
    {
        [Test]
        public void byrValid()
        {
            Passport passport = new Passport("byr:2002");

            Assert.True(passport.validateByr());
        }

        [Test]
        public void byrInvalid()
        {
            Passport passport = new Passport("byr:2003");

            Assert.False(passport.validateByr());
        }

        [Test]
        [TestCase("hgt:60in")]
        [TestCase("hgt:190cm")]
        public void hgtValid(string hgt)
        {
            Passport passport = new Passport(hgt);

            Assert.True(passport.validateHgt());
        }

        [Test]
        [TestCase("hgt:190in")]
        [TestCase("hgt:190")]
        public void hgtInvalid(string hgt)
        {
            Passport passport = new Passport(hgt);

            Assert.False(passport.validateHgt());
        }

        [Test]
        [TestCase("hcl:#123abc")]
        public void hclValid(string hcl)
        {
            Passport passport = new Passport(hcl);

            Assert.True(passport.validateHcl());
        }

        [Test]
        [TestCase("hcl:#123abz")]
        [TestCase("hcl:123abc")]
        public void hclInvalid(string hcl)
        {
            Passport passport = new Passport(hcl);

            Assert.False(passport.validateHcl());
        }

        [Test]
        [TestCase("ecl:brn")]
        public void eclValid(string ecl)
        {
            Passport passport = new Passport(ecl);

            Assert.True(passport.validateEcl());
        }

        [Test]
        [TestCase("ecl:wat")]
        public void eclInvalid(string ecl)
        {
            Passport passport = new Passport(ecl);

            Assert.False(passport.validateEcl());
        }

        [Test]
        [TestCase("pid:000000001")]
        public void pidValid(string pid)
        {
            Passport passport = new Passport(pid);

            Assert.True(passport.validatePid());
        }

        [Test]
        [TestCase("pid:0123456789")]
        [TestCase("pid:012345")]
        public void pidInvalid(string pid)
        {
            Passport passport = new Passport(pid);

            Assert.False(passport.validatePid());
        }
    }
}
