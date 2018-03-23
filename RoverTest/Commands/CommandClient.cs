using RoverTest.Enums;
using RoverTest.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverTest.Commands
{
    /// <summary>
    /// Serves as a factory for creating, storing, and retreiving multiple controllers.
    /// </summary>
    public class CommandClient : IDisposable
    {
        List<IController> _connections = new List<IController>();

        public IController Connect(IConnection connection, Map map)
        {
            // connection pooling to reconnect to previously used connections.
            var existngConn = _connections
                .Find(c => c.Position.CompareTo(connection.InitialPosition) == 0);

            if (existngConn != null)
                return existngConn;

            var x = connection.InitialPosition.X;
            var y = connection.InitialPosition.Y;
            var dir = connection.Direction;

            IController ctrl;

            switch (connection.Entity)
            {
                case ConnectionTypes.Rover:
                    ctrl = new RoverController(new Position(x, y), dir, map);
                    _connections.Add(ctrl);
                    break;
                default:
                    throw new InvalidConnectionException();
            }

            return ctrl;
        }

        public void Dispose()
        {
            // assuming that this was actually more involved...
            _connections = null;
        }

        public IController GetController(Guid id)
        {
            return _connections.FirstOrDefault(c => c.Id == id);
        }

    }
}
