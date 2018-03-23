using RoverTest.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest
{
    public interface IConnection
    {
        ConnectionTypes Entity { get; }
        Position InitialPosition { get; }
        Directions Direction { get; }
    }
}
