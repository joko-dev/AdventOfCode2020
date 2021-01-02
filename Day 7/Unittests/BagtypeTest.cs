using NUnit.Framework;
using Day7;

namespace Unittests
{
    public class BagtypeTest
    {
        [Test]
        public void BagtypeAddWithContainments()
        {
            BagType bag = new BagType("light red bags contain 1 bright white bag, 2 muted yellow bags.");
            Assert.True(bag.Color.Equals(new BagColorType("light red")));
            Assert.True(bag.ContainsColor(new BagColorType("bright white")));
            Assert.True(bag.ContainsColor(new BagColorType("muted yellow")));
        }

        [Test]
        public void BagtypeAddWithoutContainments()
        {
            BagType bag = new BagType("dotted black bags contain no other bags.");
            Assert.True(bag.Color.Equals(new BagColorType("dotted black")));
            Assert.True(bag.IsEmpty());
        }
    }
}