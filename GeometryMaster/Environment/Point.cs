using System;
using static System.Math;
using System.Collections.Generic;
using System.Text;

namespace GeometryMaster
{
    /// <summary>
    /// Представление точки
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// Координата X
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Координата Y
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Создание экземпляра точки
        /// </summary>
        /// <param name="x">Координата по X</param>
        /// <param name="y">Координата по Y</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Расстояние до точки
        /// </summary>
        /// <param name="point">Точка, до которой считается расстояние</param>
        public double DistanceTo(Point point) => Sqrt(Pow(X - point.X, 2) + Pow(Y - point.Y, 2));

        /// <summary>
        /// Угол между двумя отрезками, образующимися из трех точек. Данная точка - общая для двух отрезков
        /// </summary>
        /// <param name="A">Конец первого отрезка</param>
        /// <param name="B">Конец второго отрезка</param>
        /// <returns>Угол в радианах</returns>
        public double AngleBetween(Point A, Point B)
        {
            var vec1 = new Vector(this, A);
            var vec2 = new Vector(this, B);

            return vec1.AngleBetween(vec2);
        }
    }
}
