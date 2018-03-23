using RoverTest.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest.Commands
{
    public class CommandResult
    {
        public Position Position { get; }
        public Directions Direction { get; }

        public CommandResult(Position pos, Directions dir)
        {
            Position = pos;
            Direction = dir;
        }
    }
}
