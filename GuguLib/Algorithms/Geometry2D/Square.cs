using System;

namespace GuguLib.Algorithms.Geometry2D
{
    public class Square
    {
        public static double FindPerimeter(double a) => 4 * a;

        public static double FindArea(double a) => Math.Pow(a, 2);

        public static double FindAreaWithDiagonal(double d) => (Math.Pow(d, 2) / 2);

        public static double FindDiagonal(double a) => Math.Sqrt(2) * a;

        public static double FindSide(double area = 0, double perimeter = 0, double diagonal = 0)
        {
            if (area != 0 && perimeter == 0 && diagonal == 0)
                return Math.Sqrt(area);
            else if (area == 0 && perimeter != 0 && diagonal == 0)
                return perimeter / 4;
            else if (area == 0 && perimeter == 0 && diagonal != 0)
                return diagonal / Math.Sqrt(2);
            return default;
        }
    }
}
