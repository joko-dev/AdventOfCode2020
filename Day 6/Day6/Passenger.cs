using System;
using System.Collections.Generic;
using System.Text;

namespace Day6
{
    class Passenger
    {
        public List<char> QuestionsAnswered{ get; }

        public Passenger(string answers)
        {
            QuestionsAnswered = new List<char>();

            foreach(char q in answers)
            {
                QuestionsAnswered.Add(q);
            }
        }
    }
}
