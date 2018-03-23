using RoverTest.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest.Commands
{
    public interface IController
    {
        Guid Id { get; }
        Position Position { get; set; }
        Directions Forward { get; set; }

        Map Environment { get; set; }

        void Execute(Queue<ICommand> commands);
    }
}
