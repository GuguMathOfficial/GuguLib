using System;

namespace GuguLib.Algorithms.Geometry2D
{
    public class Rectangle
    {
        public static double FindPerimeter(double a, double b) => 2 * (a + b);

        public static double FindArea(double a, double b) => a * b;

        public static double FindDiagonal(double a, double b) => Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

        public static double FindSide(double side, double area = 0, double perimeter = 0)
        {
            if (area != 0 && perimeter == 0)
                return area / side;
            else if (area == 0 && perimeter != 0)
                return (perimeter / 2) - side;
            return default;
        }
    }
}
