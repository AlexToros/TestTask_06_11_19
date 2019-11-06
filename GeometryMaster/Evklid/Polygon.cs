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

        // https://ru.wikipedia.org/wiki/%D0%A4%D0%BE%D1%80%D0%BC%D1%83%D0%BB%D0%B0_%D0%BF%D0%BB%D0%BE%D1%89%D0%B0%D0%B4%D0%B8_%D0%93%D0%B0%D1%83%D1%81%D1%81%D0%B0
        /// <summary>
        /// Вычисление площади на основе метода Гаусса 
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            Func<int, int, int> getLeftIndex = (current, max) => current - 1 < 0 ? max - 1 : current - 1;
            Func<int, int, int> getRightIndex = (current, max) => (current + 1) % max;

            return 0.5 * points
                .Select((p, i) => new {
                    p.X,
                    Y1 = points[getLeftIndex(i, points.Length)].Y,
                    Y2 = points[getRightIndex(i, points.Length)].Y
                })
                .Sum(p => p.X * (p.Y1 - p.Y2));
        }
    }
}
