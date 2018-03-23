using RoverTest.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest
{
    public class RoverConnection : IConnection
    {
        public ConnectionTypes Entity { get; } = ConnectionTypes.Rover;
        public Position InitialPosition { get; }
        public Directions Direction { get; }

        public RoverConnection(Position initialPos, Directions direction)
        {
            InitialPosition = initialPos;
            Direction = direction;
        }
    }
}
