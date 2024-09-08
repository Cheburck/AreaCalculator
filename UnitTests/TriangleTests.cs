using System;
using AreaCalculator.Models;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace AreaCalculator.UnitTests;

[TestFixture]
internal class TriangleTests
{
    [TestCase(-2, 1, 1)]
    [TestCase(1, -4.3, 5)]
    [TestCase(4, 3, -7)]
    [TestCase(1, 2, 4)]
    [TestCase(6, 2, 1)]
    [TestCase(2.5, 5.5, 2.5)]
    public void TestInvalidTriangle(double a, double b, double c)
    {
        var ex = ClassicAssert.Throws<ArgumentException>(() => new Triangle(a, b, c));
        ClassicAssert.AreEqual(ex.Message, "All sides must be positive. Any side must be less then two other sides\n"
                + $"But was : {a}, {b}, {c}");
    }

    [TestCase(0, 0, 0, true)]
    [TestCase(3, 4, 5, true)]
    [TestCase(10, 6, 8, true)]
    [TestCase(2.5, 2.5, 3.5355339059327376220042218105242, true)]
    [TestCase(3, 3, 3, false)]
    [TestCase(2.9, 5, 5, false)]
    public void TestRightAngled(double a, double b, double c, bool expected)
    {
        var triangle = new Triangle(a, b, c);
        ClassicAssert.AreEqual(expected, triangle.IsRightAngled());
    }

    [TestCase(0, 0, 0, 0)]
    [TestCase(3, 4, 5, 6)]
    [TestCase(2.5, 2.5, 3.5355339059327376220042218105242, 3.125)]
    [TestCase(10, 8, 6, 24)]
    [TestCase(6, 5, 5, 12)]
    [TestCase(2.4, 7.63, 6.5, 7.370800467003227)]
    public void TestGetArea(double a, double b, double c, double area)
    {
        var triangle = new Triangle(a, b, c);
        ClassicAssert.AreEqual(area, triangle.GetArea(), 1e-10);
    }
}
