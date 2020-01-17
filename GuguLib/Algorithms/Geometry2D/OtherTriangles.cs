using System;

namespace GuguLib.Algorithms.Geometry2D
{
    public class EquilateralTriangle : Triangle
    {
        public static double FindPerimeter(double a) => a * 4;

        public static double FindArea(double a) => (Math.Sqrt(3) / 4) * Math.Pow(a, 2);

        public static double FindSide(double area = 0, double perimeter = 0)
        {
            if (area != 0 && perimeter == 0)
                return Math.Sqrt((4 * area) / Math.Sqrt(3));
            else if (perimeter != 0 && area == 0)
                return perimeter / 3;

            return default;
        }
    }

    public class IsoscelesTriangle : Triangle
    {
        public static double FindPerimeter(double a, double b) => (2 * a) + b;

        public static double FindAreaIso(double b, double h) => (b * h) / 2;

        public static double FindHeight(double area, double b) => (2 * area) / b;

        public static double FindAngle(double alpha = 0, double beta = 0)
        {
            if (alpha != 0 && beta == 0)
                return (180 - alpha) / 2;
            else if (beta != 0 && alpha == 0)
                return (180 - beta) / 2;

            return default;
        }
    }

    public class RightAngledTriangle : Triangle
    {
        public static double FindAreaRA(double a, double b) => (a * b) / 2;

        /// <summary>
        /// Returns the perimeter of a right angled triangle using Pytagoras' theorem.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double FindPerimeter(double a, double b) => (a + b) + Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

        public static double FindSide(double a = 0, double b = 0, double c = 0)
        {
            if (a != 0 && b != 0)
                return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            else if (b != 0 && c != 0)
                return Math.Sqrt(Math.Pow(b, 2) + Math.Pow(c, 2));
            else if (a != 0 && c != 0)
                return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(c, 2));
            return default;
        }
    }
}
