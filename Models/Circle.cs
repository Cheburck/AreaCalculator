﻿using AreaCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Models;

public class Circle : IFigure
{
    public readonly double Radius;

    public Circle (double radius)
    {
        if (radius < 0)
            throw new ArgumentException($"Radius must be positive value but was: {radius}");

        Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}
