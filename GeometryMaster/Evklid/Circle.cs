using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryMaster.Evklid
{
    public class Circle : Ellipse
    {
        /// <summary>
        /// Круг
        /// </summary>
        /// <param name="radius">Радиус</param>
        public Circle(double radius) : base(radius, radius) { }
    }
}
