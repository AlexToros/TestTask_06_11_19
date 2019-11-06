using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryMaster
{
    /// <summary>
    /// Абстрактное представление фигуры
    /// </summary>
    public abstract class Figure : IAreable
    {
        public abstract double GetArea();
    }
}
