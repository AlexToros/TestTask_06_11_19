using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryMaster.Evklid
{
    public class Ellipse : FlatFigure
    {
        public double BigSubAxis { get; set; }
        public double SmallSubAxis { get; set; }

        public Ellipse(double bigSubAxis, double smallSubAxis)
        {
            BigSubAxis = bigSubAxis;
            SmallSubAxis = smallSubAxis;
        }

        public override double GetArea() => Math.PI * BigSubAxis * SmallSubAxis;
    }
}
