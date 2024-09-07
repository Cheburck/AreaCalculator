using System;
using AreaCalculator.Models;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace AreaCalculator.UnitTests;

[TestFixture]
public class CircleTests
{
    [Test]
    public void TestCircleArea()
    {
        int a = 100;
        var circle = new Circle(a);
        ClassicAssert.AreEqual(0, circle.GetArea());
    }
}
