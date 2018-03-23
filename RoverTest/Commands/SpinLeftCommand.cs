using RoverTest.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest.Commands
{
    public class SpinLeftCommand : ICommand
    {
        public CommandResult Execute(Position currentPos, Directions currentDir)
        {
            var newDirection = Directions.Unknown;

            switch (currentDir)
            {
                case Directions.Up:
                    newDirection = Directions.Left;
                    break;
                case Directions.Left:
                    newDirection = Directions.Down;
                    break;
                case Directions.Down:
                    newDirection = Directions.Right;
                    break;
                case Directions.Right:
                    newDirection = Directions.Up;
                    break;
            }

            return new CommandResult(currentPos, newDirection);
        }
    }
}
