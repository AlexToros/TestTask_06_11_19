using System;
using System.Linq;
namespace GeometryMaster
{
    /// <summary>
    /// Расширение для округления double
    /// </summary>
    internal static class MathExtensions
    {
        internal const int ROUND_PIVOT = 10;
        internal static double Round(this double value) => Math.Round(value, ROUND_PIVOT);

        /// <summary>
        /// Метод, реализующий вычисление площади для фигур, построенных по точкам, независящий от типа фигуры
        /// https://ru.wikipedia.org/wiki/%D0%A4%D0%BE%D1%80%D0%BC%D1%83%D0%BB%D0%B0_%D0%BF%D0%BB%D0%BE%D1%89%D0%B0%D0%B4%D0%B8_%D0%93%D0%B0%D1%83%D1%81%D1%81%D0%B0
        /// </summary>
        /// <param name="points">Массив точек</param>
        internal static double GaussMethod(this Point[] points)
        {
            Func<int, int, int> getLeftIndex = (current, max) => current - 1 < 0 ? max - 1 : current - 1;
            Func<int, int, int> getRightIndex = (current, max) => (current + 1) % max;

            return 0.5 * Math.Abs(points
                .Select((p, i) => new
                {
                    p.X,
                    Y1 = points[getLeftIndex(i, points.Length)].Y,
                    Y2 = points[getRightIndex(i, points.Length)].Y
                })
                .Sum(p => p.X * (p.Y1 - p.Y2)));
        }
    }
}
