using System;

namespace GuguLib.Algorithms.Geometry2D
{
    public class Rhombus
    {
        public static double FindPerimeter(double a) => 4 * a;

        public static double FindArea(double a, double h) => a * h;

        public static double FindAreaWithDiagonals(double p, double q) => (p * q) / 2;

        public static double FindHeight(double a, double area) => area / a;

        public static double FindDiagonal(double givenDiagonal, double a = 0, double area = 0)
        {
            if (a != 0 && area == 0)
                return Math.Sqrt((4 * Math.Pow(a, 2)) - Math.Pow(givenDiagonal, 2));
            else if (a == 0 && area != 0)
                return (2 * area) / givenDiagonal;
            return default;
        }

        public static double FindSideWithArea(double area, double h) => area / h;

        public static double FindSideWithDiagonals(double d, double q) => Math.Sqrt(Math.Pow(d, 2) + Math.Pow(q, 2)) / 2;


        /// <summary>
        /// Alpha finds Beta(and vice versa)
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double FindAngle(int angle) => 180 - angle;

    }
}
