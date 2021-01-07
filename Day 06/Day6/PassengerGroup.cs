using System;
using System.Collections.Generic;
using System.Text;

namespace Day6
{
    class PassengerGroup
    {
        private List<Passenger> passengers = new List<Passenger>();

        internal PassengerGroup(string groupAnswers)
        {
            groupAnswers = groupAnswers.Replace("\r\n", "\n");
            string[] personAnswers = groupAnswers.Split("\n");
            foreach (string personAnswer in personAnswers)
            {
                passengers.Add(new Passenger(personAnswer));
            }
        }

        internal int getAnsweredQuestionsAnyone()
        {
            List<char> answeredQuestions = new List<char>();

            foreach(Passenger passenger in passengers)
            {
                List<char> passengerAnsweredQuestions = passenger.QuestionsAnswered;

                foreach(char question in passengerAnsweredQuestions)
                {
                    if (!answeredQuestions.Contains(question))
                    {
                        answeredQuestions.Add(question);
                    }
                }
            }

            return answeredQuestions.Count;
        }

        internal int getAnsweredQuestionsEveryone()
        {
            List<char> answeredQuestions = new List<char>();
            List<Passenger> tempPassengers = new List<Passenger>(passengers);

            // first passenger used for initialization
            List<char> passengerAnsweredQuestions = tempPassengers[0].QuestionsAnswered;
            foreach (char question in passengerAnsweredQuestions)
            {
                answeredQuestions.Add(question);
            }

            // all other passengers only 
            tempPassengers.RemoveAt(0);
            foreach (Passenger passenger in tempPassengers)
            {
                passengerAnsweredQuestions = passenger.QuestionsAnswered;

                foreach (char question in passengerAnsweredQuestions)
                {
                    if (!answeredQuestions.Contains(question))
                    {
                        answeredQuestions.Remove(question);
                    }
                }


                List<char> tempAnsweredQuestions = new List<char>(answeredQuestions);
                foreach (char question in answeredQuestions)
                {
                    if (!passengerAnsweredQuestions.Contains(question))
                    {
                        tempAnsweredQuestions.Remove(question);
                    }
                }
                answeredQuestions = tempAnsweredQuestions;

            }

            return answeredQuestions.Count;
        }
    }
}
