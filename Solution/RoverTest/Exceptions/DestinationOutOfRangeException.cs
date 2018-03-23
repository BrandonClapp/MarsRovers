using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest.Exceptions
{
    /// <summary>
    /// Indicator occuring when a movement is attempted that is
    /// not permitted by the map constraints.
    /// </summary>
    public class DestinationOutOfRangeException : Exception
    {
        public DestinationOutOfRangeException(int x, int y)
            : base ($"The destination ({x}, {y}) is outside of map constraints.")
        {
            
        }
    }
}
