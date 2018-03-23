using RoverTest.Commands;
using RoverTest.Enums;
using RoverTest.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverTest
{
    /// <summary>
    /// Gathers incoming user data and converts plain text commands
    /// into meaningful data.
    /// </summary>
    public static class UI
    {
        public static Position GetMapCoordinates()
        {
            var answer = Ask("Enter Graph Upper Right Coordinate");

            var coords = new Position(-1, -1);
            try
            {
                coords = ParseMapCoordinateInput(answer);
            }
            catch (InvalidUserInputException ex)
            {
                Info(ex.Message);
                return GetMapCoordinates();
            }

            return coords;
        }

        /// <summary>
        /// Parse a user input for constructing the map.
        /// </summary>
        /// <param name="input">User input string</param>
        /// <returns>
        /// Tuple containing X and Y coordinates of the upper-right map coordinate.
        /// Item1 is the X coordinate. Item2 is the Y coordinate.
        /// </returns>
        public static Position ParseMapCoordinateInput(string input)
        {
            var parts = input.Split(" ")
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .ToArray();

            if (parts.Length != 2)
                throw new InvalidUserInputException(
                    "Input should be space delimited and only contain 2 parts. (i.e. 4 5)"
                );

            var canParseX = int.TryParse(parts[0].Trim(), out var x);
            var canParseY = int.TryParse(parts[1].Trim(), out var y);

            if (!canParseX || !canParseY)
                throw new InvalidUserInputException(
                    "Input parts must only contain numbers. (i.e. 4 5)"
                );

            return new Position(x, y);
        }

        public static IConnection GetConnectionInput(Func<int, int, bool> validation)
        {
            var input = Ask("Enter Rover Position");

            IConnection connInfo;

            try
            {
                connInfo = ParseConnectionInput(input);

                if (!validation(connInfo.InitialPosition.Item1, connInfo.InitialPosition.Item2))
                    throw new InvalidUserInputException("Connection location was not on the map.");

            }
            catch (InvalidUserInputException ex)
            {
                Info(ex.Message);
                return GetConnectionInput(validation);
            }

            return connInfo;
        }

        public static IConnection ParseConnectionInput(string input)
        {
            var parts = input.Split(" ")
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .ToArray();

            if (parts.Length != 3)
                throw new InvalidUserInputException(
                    "Input should be space delimited and contain 3 parts. (i.e. 4 5 N)"
                );

            var canParseX = int.TryParse(parts[0], out var x);
            var canParseY = int.TryParse(parts[1], out var y);

            if (!canParseX || !canParseY)
                throw new InvalidUserInputException(
                    "First 2 inputs must be numbers. (i.e. 4 5 N)"
                );

            var validDirections = new List<string>() { "n", "s", "e", "w" };

            var dir = parts[2].ToLower();

            if (!validDirections.Contains(dir))
            {
                throw new InvalidUserInputException(
                    "Direction must be N, S, E, or W. (i.e. 4 5 N)"
                );
            }

            Directions facing = Directions.Unknown;
            switch (dir)
            {
                case "n":
                    facing = Directions.Up;
                    break;
                case "s":
                    facing = Directions.Down;
                    break;
                case "e":
                    facing = Directions.Right;
                    break;
                case "w":
                    facing = Directions.Left;
                    break;
            }

            if (facing == Directions.Unknown)
                throw new InvalidUserInputException("Cannot detect proper facing direction.");

            return new RoverConnection(new Position(x, y), facing);
        }

        public static Queue<ICommand> GetMovementPlan(Guid id)
        {
            var input = Ask($"Rover {id} - Enter Movement Plan");

            try
            {
                return ParseMovementPlan(input);
            }
            catch (InvalidUserInputException ex)
            {
                Info(ex.Message);
                return GetMovementPlan(id);
            }
        }

        public static Queue<ICommand> ParseMovementPlan(string input)
        {
            var lowerInput = input.Trim().ToLower();
            var validCommands = new List<char> { 'l', 'r', 'm' };

            var invalidChars = lowerInput.Except(validCommands);

            if (invalidChars.Count() > 0)
                throw new InvalidUserInputException(
                    "Commands may only contain L, R, and M. (i.e. LRMLRM)"
                );

            var commands = new Queue<ICommand>();

            foreach (var c in lowerInput)
            {
                switch (c)
                {
                    case 'l':
                        commands.Enqueue(new SpinLeftCommand());
                        break;
                    case 'r':
                        commands.Enqueue(new SpinRightCommand());
                        break;
                    case 'm':
                        commands.Enqueue(new MoveCommand());
                        break;
                }
            }

            return commands;
        }

        public static bool KeepGoing()
        {
            var input = Ask("Keep going? Y/n");
            var answer = input.Trim();

            if (answer != "Y" && answer != "n")
            {
                Info("Incorrect input. Try again.");
                return KeepGoing();
            }

            if (answer == "Y")
                return true;

            if (answer == "n")
                return false;

            return false;
        }

        public static void Info(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }

        public static void Break()
        {
            Console.WriteLine("--------------------------");
        }

        private static string Ask(string question)
        {
            Console.Write($"{question}: ");
            var answer = Console.ReadLine();
            return answer;
        }
    }
}
