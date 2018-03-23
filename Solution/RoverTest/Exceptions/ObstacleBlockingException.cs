using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest.Exceptions
{
    /// <summary>
    /// Indicator occuring when a movement is attempting
    /// that would result in a collision with another obstacle
    /// on the map.
    /// </summary>
    public class ObstacleBlockingException : Exception
    {
        public ObstacleBlockingException(int destX, int destY) 
            :base ($"Unable to move to destination ({destX}, {destY}), " +
                 $"as it would result in collision.")
        {

        }
    }
}
