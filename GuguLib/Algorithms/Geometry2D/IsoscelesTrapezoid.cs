using System;

namespace GuguLib.Algorithms.Geometry2D
{
    public class IsoscelesTrapezoid : Trapezoid
    {
        public static double FindPerimeter(double a, double b, double c) => a + b + c;

        public static double FindDiagonal(double a, double b, double c) => Math.Sqrt((a * b) + Math.Pow(c, 2));

        public static double FindBaseIso(double c, double perimeter, double a = 0, double b = 0)
        {
            if (a != 0 && b == 0)
                return perimeter - a - c;
            else if (b != 0 && a == 0)
                return perimeter - b - c;
            return default;
        }

    }
}