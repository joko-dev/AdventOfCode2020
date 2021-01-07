using Day6;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Answer file:");

            string filepath = Console.ReadLine();

            Console.WriteLine("Sum answer counts anyone: {0}", getAnswerCountAnyone(getPassengerGroupList(filepath)));
            Console.WriteLine("Sum answer counts everyone: {0}", getAnswerCountEveryone(getPassengerGroupList(filepath)));
        }


        private static int getAnswerCountAnyone(List<PassengerGroup> groups)
        {
            int answerCount = 0;

            foreach (PassengerGroup group in groups)
            {
                answerCount += group.getAnsweredQuestionsAnyone();
            }

            return answerCount;
        }

        private static int getAnswerCountEveryone(List<PassengerGroup> groups)
        {
            int answerCount = 0;

            foreach (PassengerGroup group in groups)
            {
                answerCount += group.getAnsweredQuestionsEveryone();
            }

            return answerCount;
        }

        private static List<PassengerGroup> getPassengerGroupList(string filepath)
        {
            List<PassengerGroup> groupList = new List<PassengerGroup>();
            string fileInput = File.ReadAllText(filepath);

            fileInput = fileInput.Replace("\r\n", "\n");

            string[] groups = fileInput.Split("\n\n");
            foreach (string group in groups)
            {
                groupList.Add(new PassengerGroup(group));
            }

            return groupList;
        }
    }
}
