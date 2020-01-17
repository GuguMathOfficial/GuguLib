namespace GuguLib.Algorithms.Geometry2D
{
    public class Quadrilateral
    {
        public static double FindPerimeter(double a, double b, double c, double d) => a + b + c + d;
    }

    public class Trapezoid : Quadrilateral
    {
        public static double FindArea(double a, double b, double h) => ((a + b) / 2) * h;

        public static double FindHeight(double a, double b, double area) => (2 * area) / (a + b);

        public static double FindMedian(double a, double b) => (a + b) / 2;

        public static double FindBase(double c, double d, double perimeter, double a = 0, double b = 0)
        {
            if (a != 0 && b == 0)
                return perimeter - a - c - d;
            else if (b != 0 && a == 0)
                return perimeter - b - c - d;
            return default;
        }

        public static double FindBase(double h, double area, double a = 0, double b = 0)
        {
            if (a != 0 && b == 0)
                return ((2 * area) / h) - a;
            else if (b != 0 && a == 0)
                return ((2 * area) / h) - b;
            return default;
        }

        public static double FindSide(double perimeter, double a, double b, double c = 0, double d = 0)
        {
            if (c != 0 && d == 0)
                return perimeter - a - b - c;
            else if (d != 0 && c == 0)
                return perimeter - a - b - d;
            return default;
        }

        /// <summary>
        /// Find the angle of a Trapezoid. Alpha finds Delta(and vice versa), Beta finds Gamma(and vice versa).
        /// For the angle of an Isosceles Trapozoid Alpha finds Beta(and vice versa)
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double FindAngle(int angle) => 180 - angle;
    }
}
