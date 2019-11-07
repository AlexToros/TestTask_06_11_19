using System;
using static System.Math;
using System.Collections.Generic;
using System.Text;

namespace GeometryMaster.Evklid
{
    [Flags]
    public enum TriangleType
    {
        /// <summary>
        /// Общий
        /// </summary>
        Common = 0,
        /// <summary>
        /// Равносторонний
        /// </summary>
        Equilateral = 1,
        /// <summary>
        /// Равнобедренный
        /// </summary>
        Isosceles = 2,
        /// <summary>
        /// Прямоугольный
        /// </summary>
        Rectangular = 4,
        /// <summary>
        /// Остроугольный
        /// </summary>
        Acute = 8,
        /// <summary>
        /// Тупоугольный
        /// </summary>
        Obtuse = 16,
    }
    public class Triangle : Polygon
    {
        private TriangleType? type;

        /// <summary>
        /// Тип треугольника
        /// </summary>
        public TriangleType Type
        {
            get
            {
                if (!type.HasValue)
                {
                    type = TriangleType.Common;
                    var distances = new double[] { points[0].DistanceTo(points[1]), points[1].DistanceTo(points[2]), points[2].DistanceTo(points[0]) };
                    Array.Sort(distances);
                    var maxSizeSquare = (distances[2] * distances[2]).Round();
                    var otherSizeSumSquare = (distances[1] * distances[1] + distances[0] * distances[0]).Round();
                    var sideOne = distances[0].Round();
                    var sideTwo = distances[1].Round();
                    var sideThree = distances[2].Round();

                    if (maxSizeSquare == otherSizeSumSquare)
                        type |= TriangleType.Rectangular;
                    else if (maxSizeSquare > otherSizeSumSquare)
                        type |= TriangleType.Obtuse;
                    else
                        type |= TriangleType.Acute;

                    if (sideOne == sideTwo && sideTwo == sideThree)
                        type |= TriangleType.Equilateral;
                    else if (sideOne == sideTwo || sideTwo == sideThree || sideThree == sideOne)
                        type |= TriangleType.Isosceles;
                }
                return type.Value;
            }
        }

        /// <summary>
        /// Треугольник, заданный с помощью трех точек
        /// </summary>
        public Triangle(Point A, Point B, Point C) : base(A, B, C) { }
        /// <summary>
        /// Треугольник, заданный с помощью двух сторон и угла между ними
        /// </summary>
        /// <param name="BetweenAngle">Угол между двумя сторонами (в радианах)</param>
        public Triangle(double SideOne, double SideTwo, double BetweenAngle) :
            this(new Point(0, 0), new Point(0, SideOne),
                new Point(Sin(BetweenAngle) * SideTwo, Cos(BetweenAngle) * SideTwo))
        { }
    }
}
