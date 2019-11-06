using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryMaster.Evklid
{
    public class Ellipse : FlatFigure
    {
        public double BigSubAxis { get; set; }
        public double SmallSubAxis { get; set; }

        /// <summary>
        /// Эллипс
        /// </summary>
        /// <param name="bigSubAxis">Большая полуось</param>
        /// <param name="smallSubAxis">Малая полуось</param>
        public Ellipse(double bigSubAxis, double smallSubAxis)
        {
            BigSubAxis = bigSubAxis;
            SmallSubAxis = smallSubAxis;
        }

        /// <summary>
        /// Вычисление площади
        /// </summary>
        public override double GetArea() => Math.PI * BigSubAxis * SmallSubAxis;
    }
}
