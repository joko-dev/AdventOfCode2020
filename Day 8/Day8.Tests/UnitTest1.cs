using NUnit.Framework;
using Day8;

namespace Day8Test
{
    public class Tests
    {
        [Test]
        public void TestAcc()
        {
            Instruction instruction = new Instruction("acc -99");
            Assert.True(instruction.Type.Equals(InstructionType.acc));
            Assert.True(instruction.Value == -99);
        }
    }
}