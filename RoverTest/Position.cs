using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest
{
    public class Position : Tuple<int, int>, IComparable<Position>
    {
        public int X { get { return Item1; } }
        public int Y { get { return Item2; } }

        public Position(int x, int y) : base(x, y)
        {
        }

        public int CompareTo(Position other)
        {
            if (X == other.X && Y == other.Y)
                return 0;

            return -1;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public Position Right { get { return new Position(X + 1, Y); } }

        public Position Left { get { return new Position(X - 1, Y); } }

        public Position Up { get { return new Position(X, Y + 1); } }

        public Position Down { get { return new Position(X, Y - 1); } }
    }
}
