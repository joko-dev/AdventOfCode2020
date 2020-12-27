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
            Console.WriteLine("Seat file:");

            string filepath = Console.ReadLine();

            Console.WriteLine("Highest Seat: {0}", getHighestSeatID(getListSeats(filepath)));
            Console.WriteLine("My Seat: {0}", getMySeatID(getListSeats(filepath)));
        }

        private static int getHighestSeatID(List<Seat> seats)
        {
            seats.Sort();
            Seat seat = seats.Last();

            return seat.SeatID;
        }

        private static int getMySeatID(List<Seat> seats)
        {
            int mySeatID = 0;
            int idx = 0;

            seats.Sort();

            while ((idx < seats.Count()) && (mySeatID == 0))
            {
                if(seats[idx].SeatID + 1 != seats[idx + 1].SeatID)
                {
                    mySeatID = seats[idx].SeatID + 1;
                }

                idx++;
            }

            return mySeatID;
        }

        private static List<Seat> getListSeats(string filepath)
        {
            string line;
            List<Seat> seats = new List<Seat>();
            StreamReader file = File.OpenText(filepath);

            while ((line = file.ReadLine()) != null)
            {
                seats.Add(new Seat(line));
            }

            return seats;
        }
    }
}
