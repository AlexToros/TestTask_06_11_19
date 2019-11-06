using System;
using static System.Math;
using System.Collections.Generic;
using System.Text;

namespace GeometryMaster.Evklid
{
    public enum TriangleType
    {
        Common,
        Equilateral,
        Rectangular,
        Isosceles
    }
    public class Triangle : Polygon
    {
        private TriangleType? type;

        public TriangleType Type
        {
            get
            {
                if (!type.HasValue)
                {
                    var distances = new double[] { points[0].DistanceTo(points[1]), points[1].DistanceTo(points[2]), points[2].DistanceTo(points[0]) };
                    Array.Sort(distances);
                    if ((distances[2] * distances[2]).Round() == (distances[1] * distances[1] + distances[0] * distances[0]).Round())
                        type = TriangleType.Rectangular;
                    else if (distances[0].Round() == distances[1].Round() && distances[1].Round() == distances[2].Round())
                        type = TriangleType.Equilateral;
                    else if (distances[0].Round() == distances[1].Round() || distances[1].Round() == distances[2].Round() || distances[2].Round() == distances[0].Round())
                        type = TriangleType.Isosceles;
                    else
                        type = TriangleType.Common;
                }
                return type.Value;
            }
        }

        public Triangle(Point A, Point B, Point C) : base(A, B, C) { }
        public Triangle(double SideOne, double SideTwo, double BetweenAngle) :
            this(new Point(0, 0), new Point(0, SideOne),
                new Point(Sin(BetweenAngle) * SideTwo, Cos(BetweenAngle) * SideTwo))
        { }
    }
}
