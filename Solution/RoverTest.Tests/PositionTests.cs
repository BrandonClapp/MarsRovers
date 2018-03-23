using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverTest.Tests
{
    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        public void PositionUpCalculatedCorrectly()
        {
            var pos = new Position(2, 5);
            var up = new Position(2, 6);

            var actual = pos.Up;

            Assert.AreEqual(up.X, actual.X);
            Assert.AreEqual(up.Y, actual.Y);
        }

        [TestMethod]
        public void PositionDownCalculatedCorrectly()
        {
            var pos = new Position(2, 5);
            var down = new Position(2, 4);

            var actual = pos.Down;

            Assert.AreEqual(down.X, actual.X);
            Assert.AreEqual(down.Y, actual.Y);
        }

        [TestMethod]
        public void PositionLeftCalculatedCorrectly()
        {
            var pos = new Position(2, 5);
            var left = new Position(1, 5);

            var actual = pos.Left;

            Assert.AreEqual(left.X, actual.X);
            Assert.AreEqual(left.Y, actual.Y);
        }

        [TestMethod]
        public void PositionRightCalculatedCorrectly()
        {
            var pos = new Position(2, 5);
            var right = new Position(3, 5);

            var actual = pos.Right;

            Assert.AreEqual(right.X, actual.X);
            Assert.AreEqual(right.Y, actual.Y);
        }
    }
}
