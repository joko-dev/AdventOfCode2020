using System;
using System.Collections.Generic;
using System.IO;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            Ship ship = new Ship(0, 0, Direction.EAST);
            ShipWithWaypoint shipWithWaypoint = new ShipWithWaypoint(0,0,1,10);

            Console.WriteLine("Dirextion list:");
            string filepath = Console.ReadLine();
            List<Direction> directions = GetDirectionPath(filepath);

            foreach (Direction direction in directions)
            {
                ship.Move(direction);
                shipWithWaypoint.Move(direction);
            }

            Console.WriteLine("Manhatten distance: {0}", ship.Position.getManhattanDistance());
            Console.WriteLine("Manhatten distance with waypoints: {0}", shipWithWaypoint.Position.getManhattanDistance());
        }

        private static List<Direction> GetDirectionPath(string filepath)
        {
            List<Direction> directions = new List<Direction>();

            string fileInput = File.ReadAllText(filepath);

            fileInput = fileInput.Replace("\r\n", "\n");

            string[] lines = fileInput.Split("\n");
            foreach (string line in lines)
            {
                directions.Add(new Direction(line));
            }

            return directions;
        }
    }

}
