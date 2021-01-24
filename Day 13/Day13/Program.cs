using System;
using System.Collections.Generic;
using System.IO;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            int earliestTimestamp;
            int departureTimestamp;
            int usedBusID;
            List<int> busIDs;

            Console.WriteLine("Bus departure file:");
            string filepath = Console.ReadLine(); 

            getPuzzleInput(filepath, out earliestTimestamp, out busIDs);
            getDepartureEarliestBus(busIDs, earliestTimestamp, out usedBusID, out departureTimestamp);
            
            Console.WriteLine("bus ID ({0}) * waited minutes ({1} - {2}): {3}", usedBusID, departureTimestamp, earliestTimestamp, usedBusID * (departureTimestamp - earliestTimestamp));
            Console.WriteLine("earliest timestamp for restriction: {0}", getEarlistTimestampForRestriction(busIDs));
        }

        private static void getDepartureEarliestBus(List<int> busIDs, int earliestTimestamp, out int earliestBusID, out int earliestDepartureTimestamp)
        {
            int usedBusDepartureTimestamp = 0;
            int usedBusID = 0;
            foreach (int busID in busIDs)
            {
                if (busID > 0)
                {
                    // Int-Division retrieves rounded quotient
                    int busArrivalTimestamp = (earliestTimestamp / busID) * busID;
                    int busDepartureTimestamp = busArrivalTimestamp + busID;
                    if (usedBusDepartureTimestamp == 0 | usedBusDepartureTimestamp > busDepartureTimestamp)
                    {
                        usedBusDepartureTimestamp = busDepartureTimestamp;
                        usedBusID = busID;
                    }
                }
            }

            earliestBusID = usedBusID;
            earliestDepartureTimestamp = usedBusDepartureTimestamp;
        }

        /* Brute-force-method does work for the given sample, but is way too slow for the real puzzle inputs
         * private static Int64 getEarlistTimestampForRestrictionBruteForce(List<int> busIDs)
        {
            Int64 earliestTimestamp = 0;
            bool loop = true;

            while (loop)
            {
                earliestTimestamp += busIDs[0];
                if(earliestTimestamp % busIDs[0] == 0)
                {
                    for(int i = 1; i < busIDs.Count; i++)
                    {
                        if(busIDs[i] > 0)
                        {
                            if ((earliestTimestamp + i) % busIDs[i] != 0)
                            {
                                break;
                            }
                            else if(i == busIDs.Count - 1)
                            {
                                loop = false;
                            }
                        }
                    }
                }
            }

            return earliestTimestamp;
        }*/

        private static Int64 getEarlistTimestampForRestriction(List<int> busIDs)
        {
            Int64 earliestTimestamp = 0;
            Int64 toAdd = busIDs[0];
            int beginningIndex = 1;
            bool loop = true;

            /* All bus-numbers are prime. Therefore subsequent patterns repeat every PRODUCT[busIDs] steps.
             * Idea for prime-numbers taken from: https://dev.to/rpalo/advent-of-code-2020-solution-megathread-day-13-shuttle-search-313f
             */

            while (loop)
            {
                earliestTimestamp += toAdd;
                if (earliestTimestamp % busIDs[0] == 0)
                {
                    for (int i = beginningIndex; i < busIDs.Count; i++)
                    {
                        if (busIDs[i] > 0)
                        {
                            if ((earliestTimestamp + i) % busIDs[i] == 0)
                            {
                                beginningIndex = i + 1;
                                toAdd = toAdd * busIDs[i];
                                if (i == busIDs.Count - 1)
                                {
                                    loop = false;
                                }
                            }
                            else
                            {
                                break;
                            }
                            
                        }
                    }
                }
            }

            return earliestTimestamp;
        }

        private static void getPuzzleInput(string filepath, out int earliestTimestamp, out List<int> busIDs)
        {
            busIDs = new List<int>();
            string fileInput = File.ReadAllText(filepath);

            fileInput = fileInput.Replace("\r\n", "\n");
            string[] lines = fileInput.Split("\n");

            earliestTimestamp = Int32.Parse(lines[0]);

            string[] busIDList = lines[1].Split(",");
            foreach(string busID in busIDList)
            {
                if (busID != "x")
                {
                    busIDs.Add(Int32.Parse(busID));
                }
                else
                {
                    busIDs.Add(0);
                }
            }
        }
    }

}
