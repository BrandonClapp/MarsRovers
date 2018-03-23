using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoverTest.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest.Tests
{
    [TestClass]
    public class InputManagerTests
    {
        [TestMethod]
        public void ParseMapCoordinateInput_CorrectFormat()
        {
            var upperRight = UI.ParseMapCoordinateInput("5 4");

            var x = upperRight.Item1;
            var y = upperRight.Item2;

            Assert.AreEqual(x, 5);
            Assert.AreEqual(y, 4);
        }

        [TestMethod]
        public void ParseMapCoordinateInput_NotEnoughParts()
        {
            AssertThrowsInvalidUserInputException("5");
        }

        [TestMethod]
        public void ParseMapCoordinateInput_TooManyParts()
        {
            AssertThrowsInvalidUserInputException("5 6 7");
        }

        [TestMethod]
        public void ParseMapCoordinateInput_XNotNumberParsable()
        {
            AssertThrowsInvalidUserInputException("one 2");
        }

        [TestMethod]
        public void ParseMapCoordinateInput_YNotNumberParsable()
        {
            AssertThrowsInvalidUserInputException("1 two");
        }

        [TestMethod]
        public void ParseMapCoordinateInput_NeitherNumberParsable()
        {
            AssertThrowsInvalidUserInputException("one two");
        }

        private void AssertThrowsInvalidUserInputException(string input)
        {
            try
            {
                var upperRight = UI.ParseMapCoordinateInput(input);
            }
            catch (InvalidUserInputException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidUserInputException));
                return;
            }

            Assert.IsTrue(false);
        }
    }
}
