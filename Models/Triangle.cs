using AreaCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Models;

public class Triangle : IArea
{
    public readonly double A;
    public readonly double B;
    public readonly double C;

    private bool? isRightAngled;
    public Triangle(double a, double b, double c)
    {
        if(!IsTriangle(a, b, c))
            throw new ArgumentException("All sides must be positive. Any side must be less then two other sides\n" 
                +$"Sides : {a}, {b}, {c}");

        A = a;
        B = b;
        C = c;
    }

    public double GetArea()
    {
        //  Heron's formula
        var p = (A  + B + C) / 2;
        var area = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        return area;
    }

    public bool IsRightAngled()
    {
        if(isRightAngled == null)
        {
            var sides = new double[] {A, B, C};
            Array.Sort(sides);

            var _isRightAngled = Math.Abs(sides[0] * sides[0] + sides[1] * sides[1] - sides[2] * sides[2]) 
                < double.Epsilon;
            isRightAngled = _isRightAngled;
        }

        return isRightAngled.Value;
    }

    private bool IsTriangle(double a, double b, double c)
    {
        if(a < 0 || b < 0 || c < 0)
            return false;

        if(a+ b < c || a + c < b || b + c < a)
            return false;

        return true;
    }
}
