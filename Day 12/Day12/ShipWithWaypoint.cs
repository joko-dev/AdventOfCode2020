using System;
using System.Collections.Generic;
using System.Text;

namespace Day12
{
    class ShipWithWaypoint
    {
        public Position Position { get; set; }
        public Position Waypoint { get; set; }

        public ShipWithWaypoint(int northSouth, int eastWest, int northSouthWaypoint, int eastWestWaypoint)
        {
            Position = new Position(northSouth, eastWest);
            Waypoint = new Position(northSouthWaypoint, eastWestWaypoint);
        }

        public void Move(Direction direction)
        {
            switch (direction.Action)
            {
                case Direction.EAST:
                    Waypoint.AddValues(0, direction.Value);
                    break;
                case Direction.WEST:
                    Waypoint.AddValues(0, -direction.Value);
                    break;
                case Direction.NORTH:
                    Waypoint.AddValues(direction.Value,0);
                    break;
                case Direction.SOUTH:
                    Waypoint.AddValues(-direction.Value, 0);
                    break;
                case Direction.FORWARDS:
                    Position.AddValues(direction.Value * Waypoint.NorthSouth, direction.Value * Waypoint.EastWest);
                    break;
                case Direction.LEFT:
                case Direction.RIGHT:
                    ChangeWaypointDirection(direction);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }
        }

        private void ChangeWaypointDirection(Direction direction)
        {

            if (direction.Action == Direction.LEFT)
            {
                int tempNorthSouth = Waypoint.EastWest;
                int tempEastWest = -Waypoint.NorthSouth;
                Waypoint.NorthSouth = tempNorthSouth;
                Waypoint.EastWest = tempEastWest;
            }
            else if (direction.Action == Direction.RIGHT)
            {
                int tempNorthSouth = -Waypoint.EastWest;
                int tempEastWest = Waypoint.NorthSouth;
                Waypoint.NorthSouth = tempNorthSouth;
                Waypoint.EastWest = tempEastWest;
            }

            Direction tempDirection = new Direction(direction.Action, direction.Value - 90); 
            if(tempDirection.Value > 0)
            {
                ChangeWaypointDirection(tempDirection);
            }
        }
    }
}
