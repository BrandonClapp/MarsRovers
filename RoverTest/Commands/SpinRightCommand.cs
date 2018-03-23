using RoverTest.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest.Commands
{
    public class SpinRightCommand : ICommand
    {
        public CommandResult Execute(Position currentPos, Directions currentDir)
        {
            var newDirection = Directions.Unknown;

            switch (currentDir)
            {
                case Directions.Up:
                    newDirection = Directions.Right;
                    break;
                case Directions.Left:
                    newDirection = Directions.Up;
                    break;
                case Directions.Down:
                    newDirection = Directions.Left;
                    break;
                case Directions.Right:
                    newDirection = Directions.Down;
                    break;
            }

            return new CommandResult(currentPos, newDirection);
        }
    }
}
