using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest.Exceptions
{
    class InvalidConnectionException : Exception
    {
        public InvalidConnectionException() : base("Could not establish connection.")
        {

        }
    }
}
