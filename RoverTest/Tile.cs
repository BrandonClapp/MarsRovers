using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest
{
    public class Tile
    {
        public Guid? OccupantId { get; set; } = null;
        public bool IsOccupied { get { return OccupantId != null; } }
        public Position Position { get; set; }

        public Tile(int x, int y)
        {
            Position = new Position(x, y);
        }

        public void SetOccupant(Guid guid)
        {
            OccupantId = guid;
        }

        public void RemoveOccupant()
        {
            OccupantId = null;
        }

        
    }
}
