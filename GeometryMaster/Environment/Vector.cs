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

        /// <summary>
        /// Координата X
        /// </summary>
        public double X { get => end.X - start.X; }
        /// <summary>
        /// Координата Y
        /// </summary>
        public double Y { get => end.Y - start.Y; }

        /// <summary>
        /// Модуль вектора
        /// </summary>
        public double Length { get => Sqrt(X * X + Y * Y); }

        public Vector(Point From, Point To)
        {
            start = From;
            end = To;
        }

        /// <summary>
        /// Угол, образующийся между текцщим и передаваемым вектором
        /// </summary>
        /// <param name="vector">Примыкающий вектор</param>
        /// <returns>Угол в радианах</returns>
        public double AngleBetween(Vector vector) => Acos(this * vector / (Length * vector.Length));

        /// <summary>
        /// Скалярное произведение двух векторов
        /// </summary>
        public static double operator *(Vector v1, Vector v2) => v1.X * v2.X + v1.Y * v2.Y;

    }
}
