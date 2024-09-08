using System;
using AreaCalculator.Models;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace AreaCalculator.UnitTests;

[TestFixture]
internal class CircleTests
{

    [Test]
    public void TestInvalidCircle()
    {
        var r = -1;
        var ex = ClassicAssert.Throws<ArgumentException>(() => new Circle(r));
        ClassicAssert.AreEqual(ex.Message, $"Radius must be positive value but was: {r}");
    }

    [Test]
    public void TestEmptyCircle()
    {
        var r = 0;
        var circle = new Circle(r);
        ClassicAssert.AreEqual(0, circle.GetArea());
    }

    [Test]
    public void TestGetArea()
    {
        var rand = new Random();
        for(int i = 0; i < 1000; i++)
        {
            var a = rand.Next() * rand.NextDouble();
            var circle = new Circle(a);
            ClassicAssert.AreEqual(Math.PI * a * a, circle.GetArea(), double.Epsilon);
        }
    }
}
