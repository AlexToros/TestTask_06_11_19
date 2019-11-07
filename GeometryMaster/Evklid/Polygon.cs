using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryMaster.Evklid
{
    /// <summary>
    /// Фигура, образующаяся соединением нескольких вершин
    /// </summary>
    public class Polygon : FlatFigure
    {
        protected Point[] points;

        /// <summary>
        /// Фигура, создаваемая с помощью последовательности точек
        /// </summary>
        /// <param name="points">Минимум 3 точки в последовательности</param>
        public Polygon(IEnumerable<Point> points) : this(points.ToArray()) { }
        /// <summary>
        /// Фигура, создаваемая набором точек
        /// </summary>
        /// <param name="points">Минимум три точки</param>
        public Polygon(params Point[] points)
        {
            if (points.Length < 3)
                throw new ArgumentException("Фигура должна иметь минимум три вершины");
            this.points = points;
        }

        /// <summary>
        /// Вычисление площади на основе метода Гаусса 
        /// </summary>
        public override double GetArea() => points.GaussMethod();
    }
}
