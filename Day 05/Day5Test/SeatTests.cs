using NUnit.Framework;
using Day5;

namespace Day5Test
{
    public class SeatTests
    {
       
        [Test]
        [TestCase("FBFBBFFRLR", 357)]
        [TestCase("BFFFBBFRRR", 567)]
        [TestCase("FFFBBBFRRR", 119)]
        [TestCase("BBFFBBFRLL", 820)]
        public void testSeatId(string line, int id)
        {
            Seat seat = new Seat(line);

           Assert.True(seat.SeatID == id);
        }
    }
}