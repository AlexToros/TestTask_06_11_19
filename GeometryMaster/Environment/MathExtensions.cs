using System;
namespace GeometryMaster
{
    internal static class MathExtensions
    {
        internal const int ROUND_PIVOT = 10;
        internal static double Round(this double value) => Math.Round(value, ROUND_PIVOT);
    }
}
