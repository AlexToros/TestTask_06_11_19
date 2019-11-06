using System;
using static System.Math;
using System.Collections.Generic;
using System.Text;

namespace GeometryMaster
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point point) => Sqrt(Pow(X - point.X, 2) + Pow(Y - point.Y, 2));

        public double AngleBetween(Point A, Point B)
        {
            var vec1 = new Vector(this, A);
            var vec2 = new Vector(this, B);

            return vec1.AngleBetween(vec2);
        }
    }
}
