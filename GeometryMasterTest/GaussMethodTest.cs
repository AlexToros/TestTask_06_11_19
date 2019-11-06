using NUnit.Framework;
using GeometryMaster.Evklid;
using GeometryMaster;
using System;

namespace Tests
{
    public class GaussMethod
    {
        private Polygon square;
        [SetUp]
        public void Setup()
        {
            square = new Polygon(new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 0));
        }

        [Test]
        public void AreaTest()
        {
            Assert.IsTrue(DoubleEquals(1, square.GetArea()));
        }

        private bool DoubleEquals(double first, double second)
        {
            return Math.Abs(first - second) < 0.0001;
        }
    }
}
