using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryMaster.Evklid
{
    public class Polygon : FlatFigure
    {
        protected Point[] points;

        public Polygon(IEnumerable<Point> points) : this(points.ToArray()) { }

        public Polygon(params Point[] points)
        {
            if (points.Length < 3)
                throw new ArgumentException("Фигура должна иметь минимум три вершины");
            this.points = points;
        }

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
