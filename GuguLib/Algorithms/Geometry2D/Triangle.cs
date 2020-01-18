using System;

namespace GuguLib.Algorithms.Geometry2D
{
    public class Triangle
    {
        /// <summary>
        /// Find a side of a triangle.
        /// </summary>
        /// <param name="side">a, b or c</param>
        /// <param name="perimeter">Perimeter</param>
        /// <param name="a">Side a</param>
        /// <param name="b">Side b</param>
        /// <param name="c">Side c</param>
        /// <returns>The side of a triangle</returns>
        [Controllable]
        public static Controlled<double, ArgumentException> FindSide(char side, double perimeter, double a = 0, double b = 0, double c = 0)
        {
            var ctrl = new Controlled<double, ArgumentException>();
            switch (side)
            {
                case 'a':
                    ctrl.ReturnValue = perimeter - b - c;
                    break;
                case 'b':
                    ctrl.ReturnValue = perimeter - a - c;
                    break;
                case 'c':
                    ctrl.ReturnValue = perimeter - a - b;
                    break;
                default:
                    ctrl.Exception = new ArgumentException("Invalid character");
                    break;
            }

            return ctrl;
        }

        /// <summary>
        /// Find and angle of a triangle
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <param name="gamma"></param>
        /// <returns></returns>
        public static double FindAngle(char angle, double alpha = 0, double beta = 0, double gamma = 0)
        {
            switch (angle)
            {
                case 'a':
                    return 180 - beta - gamma;
                case 'b':
                    return 180 - alpha - gamma;
                case 'c':
                    return 180 - alpha - beta;
                default:
                    return default;
            }
        }

        /// <summary>
        /// Find the height of a triangle with it's sides.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double FindHeight(int a, int b, int c) => (2 * FindArea(a, b, c)) / b;

        /// <summary>
        /// Find the height of a triangle with it's area.
        /// </summary>
        /// <param name="area"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double FindHeight(int area, int b)
            => (2 * area) / b;

        /// <summary>
        /// Returns the parameter of a triangle.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double FindParameter(double a, double b, double c)
        {
            return (a + b + c);
        }
        
        /// <summary>
        /// Returns the area of a triangle.
        /// a = side; h = hight of the corresponding side;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static double FindArea(double a, double h)
            => (a * h) / 2;

        /// <summary>
        /// Returns a triangle's area using Heron's formula.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double FindArea(double a, double b, double c)
        {
            double halfParam = FindParameter(a, b, c) / 2;
            return Math.Sqrt(halfParam * (halfParam - a) * (halfParam - b) * (halfParam - c));
        }
    }
}
