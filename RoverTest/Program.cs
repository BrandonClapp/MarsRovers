using RoverTest.Commands;
using System;

namespace RoverTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assumptions:

            // 1) Rovers are not allowed to travel outside of the map boundaries.

            // 2) Rovers are not allowed to drive through each other.

            // 3) The number of rovers is not specified. I will assume that the program
            //    will run until an option is selected indicating that no more are to be added.

            // 4) Commands (i.e. L, R, M) and directions (N, S, E, W) are case in-sensitive.

            // 5) It seems as if the instructions suggest that upon entering an input for each
            //    rover that they are "spawned" at that location, so I have placed new rovers at
            //    the input position. Alternatively, you could pre-populate the map with rovers and
            //    only allow successful connections if a rover existed at the input location.

            var mapInput = UI.GetMapCoordinates();
            var map = new Map(mapInput.X, mapInput.Y);

            // Handles connections for all controller objects.
            using (var client = new CommandClient())
            {
                var running = true;
                while (running)
                {
                    var conn = UI.GetConnectionInput(validation: map.IsOnMap);
                    var ctrl = client.Connect(conn, map);

                    UI.Info($"Satellite uplink enabled. Communication established with rover {ctrl.Id}");

                    var commands = UI.GetMovementPlan(ctrl.Id);

                    ctrl.Execute(commands);

                    UI.Info("Movement plan complete.");
                    UI.Info($"Rover {ctrl.Id} destination: {ctrl.Position}");
                    UI.Break();

                    running = UI.KeepGoing();
                }
            }

            UI.Break();
            UI.Info("Done");
        }
    }
}
