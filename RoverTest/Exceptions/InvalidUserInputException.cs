using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest.Exceptions
{
    public class InvalidUserInputException : Exception
    {
        public InvalidUserInputException(string message) : base(message)
        {

        }
    }
}
