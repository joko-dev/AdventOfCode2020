using System;
using System.Collections.Generic;
using System.Text;

namespace Day12
{
    class Ship
    {
        private char currentlyFacing;
        public Position Position { get; set; }

        public char CurrentlyFacing { get => currentlyFacing; }

        public Ship(int northSouth, int eastWest, char currentlyFacing)
        {
            Position = new Position(northSouth, eastWest);
            this.currentlyFacing = currentlyFacing;
        }

        public void Move(Direction direction)
        {
            switch (direction.Action)
            {
                case Direction.EAST:
                    Position.AddValues(0, direction.Value);
                    break;
                case Direction.WEST:
                    Position.AddValues(0, -direction.Value);
                    break;
                case Direction.NORTH:
                    Position.AddValues(direction.Value,0);
                    break;
                case Direction.SOUTH:
                    Position.AddValues(-direction.Value, 0);
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
