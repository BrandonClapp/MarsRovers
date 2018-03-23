using RoverTest.Commands;
using RoverTest.Enums;
using RoverTest.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RoverTest
{
    public class RoverController : IController
    {
        public Guid Id { get; private set; }
        public Directions Forward { get; set; }
        public Position Position { get; set; }
        public Map Environment { get; set; }

        /// <summary>
        /// Construct a new rover at a particular spawn position and
        /// facing direction.
        /// </summary>
        /// <param name="location">The initial tile on the map on which to spawn on.</param>
        /// <param name="dir">The initial direction for the rover to be facing.</param>
        public RoverController(Position initialPosition, Directions dir, Map env)
        {
            Id = Guid.NewGuid();
            Position = initialPosition;
            Forward = dir;
            Environment = env;
            Environment.SetOccupant(Position, Id);
        }

        public void Execute(Queue<ICommand> commands)
        {
            while (commands.Count > 0)
            {
                Thread.Sleep(1000);
                var cmd = commands.Dequeue();
                var result = cmd.Execute(Position, Forward);

                var onMap = Environment.IsOnMap(result.Position.X, result.Position.Y);
                var available = Environment.IsSelfOrVacant(Id, result.Position.X, result.Position.Y);

                if (onMap && available)
                {
                    Move(new Position(result.Position.X, result.Position.Y));
                    Rotate(result.Direction);
                }
                else
                {
                    UI.Info($"Destination {result.Position} is either not on the map " +
                        $"or is currently occupied.");
                }
            }
        }

        private void Move(Position destination)
        {
            var from = Position;
            var to = destination;

            if(from.CompareTo(to) != 0) // different points
            {
                var success = Environment.Move(Id, from, to);
                if (success)
                {
                    Position = to;
                    UI.Info($"Moved to {to}");
                }
                else
                {
                    UI.Info($"Could not move from {from} to {to}");
                }

            }
            
        }

        private void Rotate(Directions dir)
        {
            if (Forward != dir)
            {
                Forward = dir;
                UI.Info($"Turned: Now facing {dir}");
            }
            
        }
    }
}
