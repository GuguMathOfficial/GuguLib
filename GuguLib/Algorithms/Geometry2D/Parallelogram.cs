namespace GuguLib.Algorithms.Geometry2D
{
    public class Parallelogram
    {
        public static double FindPerimeter(double a, double b) => 2 * (a + b);

        public static double FindArea(double b, double h) => h * b;

        public static double FindHeight(double b, double area) => area / b;

        public static double FindSide(double perimeter, double a = 0, double b = 0)
        {
            if (a != 0 && b == 0)
                return (perimeter / 2) - a;
            else if (a == 0 && b != 0)
                return (perimeter / 2) - b;

            return default;
        }

        public static double FindBase(double area, double h) => area / h;

        /// <summary>
        /// Alpha finds Beta(and vice versa)
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double FindAngle(int angle) => 180 - angle;
    }
}
