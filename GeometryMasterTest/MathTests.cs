﻿using NUnit.Framework;
using GeometryMaster.Evklid;
using GeometryMaster;
using System;

namespace Tests
{
    public class MathTests
    {
        const double epsilon = 1e-10;
        private Point p_0_0;
        private Point p_1_0;
        private Point p_0_1;
        private Point p_1_1;
        [SetUp]
        public void Setup()
        {
            p_0_0 = new Point(0, 0);
            p_0_1 = new Point(0, 1);
            p_1_1 = new Point(1, 1);
            p_1_0 = new Point(1, 0);
        }

        [Test]
        public void AreaTestByGaussMethod()
        {
            var square = new Polygon(p_0_0, p_0_1, p_1_1, p_1_0);
            var triangle = new Triangle(p_0_0, p_0_1, p_1_1);
            var circle = new Circle(2);

            Assert.AreEqual(1, square.GetArea(), epsilon, "Площадь единичного квадрата не соответствует единице");
            Assert.AreEqual(0.5, triangle.GetArea(), epsilon, "Площадь треугольника неверна");
            Assert.AreEqual(Math.PI * 4, circle.GetArea(), epsilon, "Площадь круга неверна");
        }

        [Test]
        public void ScalarMultiplicationTest()
        {
            var vector1 = new Vector(p_0_0, p_0_1);
            var vector2 = new Vector(p_0_0, p_1_0);
            var vector3 = new Vector(p_0_0, p_1_1);
            
            Assert.AreEqual(0, vector1 * vector2, epsilon, "Скалярное произведение единичных ортогональных векторов не равно нулю");
            Assert.AreEqual(vector2.Length, vector2 * vector3, epsilon, "Скалярное произведение неправильно считает проекцию");
        }

        [Test]
        public void AngleTest()
        {
            var vector1 = new Vector(p_0_0, p_0_1);
            var vector2 = new Vector(p_0_0, p_1_0);
            var vector3 = new Vector(p_0_0, p_1_1);

            var HalfPI_expected = Math.PI / 2;
            var QuoterPI_expected = Math.PI / 4;
                       
            Assert.AreEqual(HalfPI_expected, vector1.AngleBetween(vector2), epsilon, "Неверно считает угол 90 градусов");
            Assert.AreEqual(QuoterPI_expected, vector1.AngleBetween(vector3), epsilon, "Неверно считает угол 45 градусов");
            Assert.AreEqual(vector1.AngleBetween(vector3), vector3.AngleBetween(vector1), epsilon, "Вычисление угла не коммутативно");
        }

        [Test]
        public void TriangleTypeTest()
        {
            Assert.AreEqual(TriangleType.Equilateral, (new Triangle(10, 10, Math.PI / 3)).Type, "Не определяется равносторонний треугольник");
            Assert.AreEqual(TriangleType.Isosceles, (new Triangle(10, 10, Math.PI / 5)).Type, "Не определяется равнобедренный треугольник");
            Assert.AreEqual(TriangleType.Rectangular, (new Triangle(10, 12, Math.PI / 2)).Type, "Не определяется прямоугольный треугольник");
            Assert.AreEqual(TriangleType.Common, (new Triangle(10, 9, Math.PI / 10)).Type, "Не определяется обычный треугольник");
        }
    }
}
