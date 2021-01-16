using System;
using System.Collections.Generic;
using System.Text;

namespace Day12
{
    class Position
    {
        private int northSouth;
        private int eastWest;
        private char currentlyFacing;
        private Position waypoint;

        public char CurrentlyFacing { get => currentlyFacing; }
        public int NorthSouth { get => northSouth; }
        public int EastWest { get => eastWest; }

        public Position(int northSouth, int eastWest, char currentlyFacing) : this(northSouth, eastWest, currentlyFacing, 0, 0)
        {
            this.northSouth = northSouth;
            this.eastWest = eastWest;
            this.currentlyFacing = currentlyFacing;
        }

        public Position(int northSouth, int eastWest, char currentlyFacing, int northSouthWaypoint, int eastWestWaypoint)
        {
            this.northSouth = northSouth;
            this.eastWest = eastWest;
            this.currentlyFacing = currentlyFacing;
            if (northSouthWaypoint > 0 && eastWestWaypoint > 0)
            {
                waypoint = new Position(northSouthWaypoint, eastWestWaypoint, ' ');
            }
        }

        internal int getManhattanDistance()
        {
            return (Math.Abs(eastWest) + Math.Abs(northSouth));
        }

        public void Move(Direction direction)
        {
            switch (direction.Action)
            {
                case Direction.EAST:
                    eastWest = eastWest + direction.Value;
                    break;
                case Direction.WEST:
                    eastWest = eastWest - direction.Value;
                    break;
                case Direction.NORTH:
                    northSouth = northSouth + direction.Value;
                    break;
                case Direction.SOUTH:
                    northSouth = northSouth - direction.Value;
                    break;
                case Direction.FORWARDS:
                    Move(new Direction(CurrentlyFacing, direction.Value));
                    break;
                case Direction.LEFT:
                case Direction.RIGHT:
                    ChangeDirection(direction);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }
        }

        private void ChangeDirection(Direction direction)
        {
            switch (CurrentlyFacing)
            {
                case Direction.EAST:
                    if(direction.Action == Direction.RIGHT)
                    {
                        switch (direction.Value)
                        {
                            case 90:
                                currentlyFacing = Direction.SOUTH;
                                break;
                            case 180:
                                currentlyFacing = Direction.WEST;
                                break;
                            case 270:
                                currentlyFacing = Direction.NORTH;
                                break;
                        }
                    }
                    else if (direction.Action == Direction.LEFT)
                    {
                        switch (direction.Value)
                        {
                            case 90:
                                currentlyFacing = Direction.NORTH;
                                break;
                            case 180:
                                currentlyFacing = Direction.WEST;
                                break;
                            case 270:
                                currentlyFacing = Direction.SOUTH;
                                break;
                        }
                    }
                    break;
                case Direction.WEST:
                    if (direction.Action == Direction.RIGHT)
                    {
                        switch (direction.Value)
                        {
                            case 90:
                                currentlyFacing = Direction.NORTH;
                                break;
                            case 180:
                                currentlyFacing = Direction.EAST;
                                break;
                            case 270:
                                currentlyFacing = Direction.SOUTH;
                                break;
                        }
                    }
                    else if (direction.Action == Direction.LEFT)
                    {
                        switch (direction.Value)
                        {
                            case 90:
                                currentlyFacing = Direction.SOUTH;
                                break;
                            case 180:
                                currentlyFacing = Direction.EAST;
                                break;
                            case 270:
                                currentlyFacing = Direction.NORTH;
                                break;
                        }
                    }
                    break;
                case Direction.NORTH:
                    if (direction.Action == Direction.RIGHT)
                    {
                        switch (direction.Value)
                        {
                            case 90:
                                currentlyFacing = Direction.EAST;
                                break;
                            case 180:
                                currentlyFacing = Direction.SOUTH;
                                break;
                            case 270:
                                currentlyFacing = Direction.WEST;
                                break;
                        }
                    }
                    else if (direction.Action == Direction.LEFT)
                    {
                        switch (direction.Value)
                        {
                            case 90:
                                currentlyFacing = Direction.WEST;
                                break;
                            case 180:
                                currentlyFacing = Direction.SOUTH;
                                break;
                            case 270:
                                currentlyFacing = Direction.EAST;
                                break;
                        }
                    }
                    break;
                case Direction.SOUTH:
                    if (direction.Action == Direction.RIGHT)
                    {
                        switch (direction.Value)
                        {
                            case 90:
                                currentlyFacing = Direction.WEST;
                                break;
                            case 180:
                                currentlyFacing = Direction.NORTH;
                                break;
                            case 270:
                                currentlyFacing = Direction.EAST;
                                break;
                        }
                    }
                    else if (direction.Action == Direction.LEFT)
                    {
                        switch (direction.Value)
                        {
                            case 90:
                                currentlyFacing = Direction.EAST;
                                break;
                            case 180:
                                currentlyFacing = Direction.NORTH;
                                break;
                            case 270:
                                currentlyFacing = Direction.WEST;
                                break;
                        }
                    }
                    break;
            }
        }
    }
}
