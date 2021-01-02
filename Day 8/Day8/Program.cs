using System;
using System.Collections.Generic;
using System.IO;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bag file:");

            string filepath = Console.ReadLine();

            Console.WriteLine("Accumulator value at endless loop: {0}", countAccValueAtLoop(getInstructionList(filepath)));
            Console.WriteLine("Accumulator value without endless loop: {0}", countAccValueWithoutLoop(getInstructionList(filepath)));
        }

        private static int countAccValueAtLoop(List<Instruction> instructionList)
        {
            bool isEndlessLoop;
            return countAccValue(instructionList, out isEndlessLoop);
        }

        private static int countAccValueWithoutLoop(List<Instruction> instructionList)
        {
            int acc = 0;
            bool isEndlessLoop;
            List<Instruction> tempInstructionList = new List<Instruction>();

            for (int i = 0; i < instructionList.Count; i++)
            {
                tempInstructionList.Clear();

                if (instructionList[i].Type == InstructionType.nop)
                {
                    tempInstructionList = new List<Instruction>(instructionList);
                    tempInstructionList[i] = new Instruction(InstructionType.jmp, instructionList[i].Value);

                }
                else if (instructionList[i].Type == InstructionType.jmp)
                {
                    tempInstructionList = new List<Instruction>(instructionList);
                    tempInstructionList[i] = new Instruction(InstructionType.nop, instructionList[i].Value);

                }

                if (tempInstructionList.Count > 0)
                {
                    acc = countAccValue(tempInstructionList, out isEndlessLoop);
                    if (!isEndlessLoop)
                    {
                        break;
                    }
                }
            }

            return acc;
        }

        private static int countAccValue(List<Instruction> instructionList, out bool isEndlessLoop)
        {
            int acc = 0;
            int instructionIndex = 0;
            resetInstructionList(instructionList);
            Instruction currentInstruction = instructionList[instructionIndex];

            while (currentInstruction != null && !currentInstruction.Executed)
            {
                if (currentInstruction.Type == InstructionType.acc)
                {
                    acc += currentInstruction.Value;
                    instructionIndex++;
                }
                else if (currentInstruction.Type == InstructionType.jmp)
                {
                    instructionIndex += currentInstruction.Value;
                }
                else if (currentInstruction.Type == InstructionType.nop)
                {
                    instructionIndex++;
                }
                currentInstruction.Executed = true;

                if (instructionIndex < instructionList.Count)
                {
                    currentInstruction = instructionList[instructionIndex];
                }
                else
                {
                    currentInstruction = null;
                }
                
            }
            isEndlessLoop = (currentInstruction != null);
            return acc;
        }

        private static void resetInstructionList(List<Instruction> instructionList)
        {
            foreach (Instruction instruction in instructionList) 
            {
                instruction.Executed = false;
            }
        }

        private static List<Instruction> getInstructionList(string filepath)
        {
            List<Instruction> instructionList = new List<Instruction>();
            string fileInput = File.ReadAllText(filepath);

            fileInput = fileInput.Replace("\r\n", "\n");

            string[] instructions = fileInput.Split("\n");
            foreach (string instruction in instructions)
            {
                if (!String.IsNullOrEmpty(instruction))
                {
                    instructionList.Add(new Instruction(instruction));
                }
            }

            return instructionList;
        }
    }
}
