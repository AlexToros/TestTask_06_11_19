using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryMaster.Evklid
{
    public class Circle : Ellipse
    {
        public Circle(double radius) : base(radius, radius) { }
    }
}
