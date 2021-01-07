using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace Day8
{
    internal class Instruction
    {
        public InstructionType Type { get; set; }
        public int Value { get; }
        public bool Executed { get; set; }

        public Instruction(string line)
        {
            string[] input = line.Split(' ');

            Type = new InstructionType(input[0]);
            Value = int.Parse(input[1]);
            Executed = false;
        }

        public Instruction(InstructionType type, int value)
        {
            Type = type;
            Value = value;
            Executed = false;
        }

    }
}
