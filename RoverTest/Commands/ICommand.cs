using RoverTest.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest.Commands
{
    public interface ICommand
    {
        CommandResult Execute(Position currentPos, Directions currentDir);
    }
}
