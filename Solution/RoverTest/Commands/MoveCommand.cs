using RoverTest.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest.Commands
{
    public class MoveCommand : ICommand
    {
        public CommandResult Execute(Position currentPos, Directions currentDir)
        {
            Position pos = new Position(-1, -1);

            switch (currentDir)
            {
                case Directions.Up:
                    pos = currentPos.Up;
                    break;

                case Directions.Down:
                    pos = currentPos.Down;
                    break;

                case Directions.Left:
                    pos = currentPos.Left;
                    break;

                case Directions.Right:
                    pos = currentPos.Right;
                    break;
            }

            return new CommandResult(pos, currentDir);
        }
    }
}
