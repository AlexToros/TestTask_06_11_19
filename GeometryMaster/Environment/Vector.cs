using System;
using static System.Math;
using System.Collections.Generic;
using System.Text;

namespace GeometryMaster
{
    public struct Vector
    {
        private Point start;
        private Point end;

        public double X { get => end.X - start.X; }
        public double Y { get => end.Y - start.Y; }
        public double Length { get => Sqrt(X * X + Y * Y); }

        public Vector(Point From, Point To)
        {
            start = From;
            end = To;
        }

        public double AngleBetween(Vector vector) => Acos(this * vector / (Length * vector.Length));

        public static double operator *(Vector v1, Vector v2) => v1.X * v2.X + v1.Y * v2.Y;

    }
}
