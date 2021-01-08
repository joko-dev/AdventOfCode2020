using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day11
{
    class Program
    {
        private static char OCC = '#';
        private static char EMPTY = 'L';
        private static char FLOOR = '.';

        static void Main(string[] args)
        {
            Console.WriteLine("Seat plan:");
            string filepath = Console.ReadLine();
            List<string> seatMatrix = getSeatMatrix(filepath);

            Console.WriteLine("Seats occupied adjacent: {0}", getSeatsOccupied(getFinalSeatMatrix(seatMatrix, true)));
            Console.WriteLine("Seats occupied first: {0}", getSeatsOccupied(getFinalSeatMatrix(seatMatrix, false)));
        }

        private static List<string> getFinalSeatMatrix(List<string> seatMatrix, bool adjacentSeats)
        {
            bool changed = true;
            List<string> newSeatMatrix = new List<string>(seatMatrix);
            

            while (changed)
            {
                changed = false;
                List<string> oldSeatMatrix = new List<string>(newSeatMatrix);

                for (int y = 0; y < oldSeatMatrix.Count; y++ )
                {
                    string seatLine = oldSeatMatrix[y];
                    for (int x = 0; x < seatLine.Length; x++)
                    {
                        char newSeat = getNewSeatType(oldSeatMatrix, x, y, adjacentSeats);
                        seatLine = seatLine.Remove(x, 1).Insert(x, newSeat.ToString());
                    }

                    changed = changed | (seatLine != oldSeatMatrix[y]);
                    newSeatMatrix[y] = seatLine;
                }
            }

            return newSeatMatrix;
        }

        private static char getNewSeatType(List<string> seatMatrix, int x, int y, bool adjacentSeats)
        {
            char currentSeat = seatMatrix[y][x];
            char newSeatType = currentSeat;
            int toleranceSeats = adjacentSeats ? 4 : 5;

            if (currentSeat == EMPTY && countOccupiedAdjacent(seatMatrix, x, y, adjacentSeats) == 0)
            {
                newSeatType = OCC;
            }
            else if (currentSeat == OCC && countOccupiedAdjacent(seatMatrix, x, y, adjacentSeats) >= toleranceSeats)
            {
                newSeatType = EMPTY;
            }
 
            return newSeatType;
        }

        private static int countOccupiedAdjacent(List<string> seatMatrix, int x, int y, bool adjacentSeats)
        {
            int count = 0;

            count = isNextSeatOccupied(seatMatrix, x, y, -1, -1, adjacentSeats) ? count + 1 : count;
            count = isNextSeatOccupied(seatMatrix, x, y, 0, -1, adjacentSeats) ? count + 1 : count;
            count = isNextSeatOccupied(seatMatrix, x, y, 1, -1, adjacentSeats) ? count + 1 : count;
            count = isNextSeatOccupied(seatMatrix, x, y, -1, 0, adjacentSeats) ? count + 1 : count;
            count = isNextSeatOccupied(seatMatrix, x, y, 1, 0, adjacentSeats) ? count + 1: count;
            count = isNextSeatOccupied(seatMatrix, x, y, -1, 1, adjacentSeats) ? count + 1: count;
            count = isNextSeatOccupied(seatMatrix, x, y, 0, 1, adjacentSeats) ? count + 1: count;
            count = isNextSeatOccupied(seatMatrix, x, y, 1, 1, adjacentSeats) ? count + 1: count;

            return count;
        }

        private static bool isNextSeatOccupied(List<string> seatMatrix, int x, int y, int xToAdd, int yToAdd, bool adjacentSeats)
        {
            bool occupied = false;
            bool searchNextSeat = true;
            string seatLine;
            int newX = x;
            int newY = y;

            while (searchNextSeat)
            {
                newX = newX + xToAdd;
                newY = newY + yToAdd;

                if(newY >= 0 && newY < seatMatrix.Count)
                {
                    seatLine = seatMatrix[newY];
                    if (newX >= 0 && newX < seatLine.Length)
                    {
                        seatLine = seatMatrix[newY];
                        if (seatLine[newX] == OCC)
                        {
                            occupied = true;
                            searchNextSeat = false;
                        }
                        else if (seatLine[newX] == EMPTY)
                        {
                            occupied = false;
                            searchNextSeat = false;
                        }
                    }
                    else
                    {
                        searchNextSeat = false;
                    }
                }
                else
                {
                    searchNextSeat = false;
                }

                if (adjacentSeats)
                {
                    searchNextSeat = false;
                }
            }

            return occupied;
        }

        private static int getSeatsOccupied(List<string> seats)
        {
            int occupied = 0;

            foreach (string seatLine in seats)
            {
                foreach(char seat in seatLine)
                {
                    if (seat == OCC)
                    {
                        occupied++;
                    }
                }
            }

            return occupied;
        }

        private static List<string> getSeatMatrix(string filepath)
        {
            List<string> seats = new List<string>();
            string fileInput = File.ReadAllText(filepath);

            fileInput = fileInput.Replace("\r\n", "\n");

            string[] lines = fileInput.Split("\n");
            foreach (string seat in lines)
            {
                seats.Add(seat);
            }

            return seats;
        }
    }
}
