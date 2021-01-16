using System;
using System.Collections.Generic;
using System.IO;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            Position currentPosition = new Position(0, 0, Direction.EAST);

            Console.WriteLine("Dirextion list:");
            string filepath = Console.ReadLine();
            List<Direction> directions = GetDirectionPath(filepath);

            foreach (Direction direction in directions)
            {
                currentPosition.Move(direction);
            }

            Console.WriteLine("Manhatten distance: {0}", currentPosition.getManhattanDistance());
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
