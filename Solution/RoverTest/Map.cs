using RoverTest.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RoverTest
{
    /// <summary>
    /// Represents quadrant 1 of a cartesian coordinate system.
    /// </summary>
    public class Map
    {
        private List<Tile> _tiles = new List<Tile>();
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            for (var x = 0; x <= width; x++)
            {
                for (var y = 0; y <= height; y++)
                {
                    _tiles.Add(new Tile(x, y));
                }
            }
        }

        public bool IsOnMap(int x, int y)
        {
            return _tiles.Exists((t) =>
            {
                return t.Position.X == x && t.Position.Y == y;
            });
        }

        public bool IsSelfOrVacant(Guid id, int x, int y)
        {
            var target = _tiles.Find(t => t.Position.X == x && t.Position.Y == y);

            if (target == null)
                return false;

            return target.OccupantId == id || target.OccupantId == null;
        }

        public bool Move(Guid id, Position from, Position to)
        {
            var source = _tiles.Find(
                t => t.OccupantId == id && t.Position.X == from.Item1 && t.Position.Y == from.Item2
            );

            var dest = _tiles.Find(
                t => t.Position.X == to.Item1 && t.Position.Y == to.Item2 // && not occupied?
            );

            if (source == null || dest == null)
                return false;

            source.OccupantId = null;
            dest.OccupantId = id;
            return true;
        }

        public void SetOccupant(Position at, Guid id)
        {
            var tile = _tiles.Find(t => t.Position.X == at.X && t.Position.Y == at.Y);
            tile.OccupantId = id;
        }

        // [ 0,6 | 1,6 | 2,6 | 3,6 | 4,6 | 5,6 ]
        // [ 0,5 | 1,5 | 2,5 | 3,5 | 4,5 | 5,5 ]
        // [ 0,4 | 1,4 | 2,4 | 3,4 | 4,4 | 5,4 ]
        // [ 0,3 | 1,3 | 2,3 | 3,3 | 4,3 | 5,3 ]
        // [ 0,2 | 1,2 | 2,2 | 3,2 | 4,2 | 5,2 ]
        // [ 0,1 | 1,1 | 2,1 | 3,1 | 4,1 | 5,1 ]
        // [ 0,0 | 1,0 | 2,0 | 3,0 | 4,0 | 5,0 ]
    }
}
