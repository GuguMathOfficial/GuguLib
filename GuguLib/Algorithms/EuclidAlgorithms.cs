using System;

namespace GuguLib.Algorithms
{

    /// <summary>
    /// Contains refferences for Euclid formulas.
    /// </summary>
    public static class EuclidAlgorithms
    {
        /// <summary>
        /// Returns the Greatest Common Divider
        /// </summary>
        /// <param name="x">First number</param>
        /// <param name="y">Second number</param>
        /// <returns>The GreatestCommonDivider</returns>
        public static double GreatestCommonDivider(double x, double y)
        {
            x = x < 0 ? x * -1 : x;
            y = y < 0 ? y * -1 : y;

            while (x != y)
                _ = x > y ? x -= y : y -= x;

            return x;
        }

        /// <summary>
        /// Returns the Greatest Common Divider with a_n numbers.
        /// </summary>
        /// <param name="numbers">Array of numbers that we want to find their GreatestCommonDivider</param>
        /// <returns>The GreatestCommonDivider</returns>
        public static double GreatestCommonDivider(params double[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();
            else if (numbers.Length == 1)
                return numbers[0];
            else if (numbers.Length == 2)
                return GreatestCommonDivider(numbers[0], numbers[1]);
            else
                for (int i = 1; i < numbers.Length; i++)
                    numbers[i] = GreatestCommonDivider(Math.Round(numbers[i - 1], 0), Math.Round(numbers[i], 0));

            return (numbers[numbers.Length - 1]);
        }

        /// <summary>
        /// Returns the Greatest Common Divider by Substracting
        /// </summary>
        /// <param name="x">First number</param>
        /// <param name="y">Second number</param>
        /// <returns>The GreatestCommonDivider</returns>
        public static double SubstractGreatestCommonDivider(double x, double y)
         => x != y ? (x > y ? SubstractGreatestCommonDivider((x - y), y) : SubstractGreatestCommonDivider(x, y - x)) : x;
        
        /// <summary>
        /// Returns the Greatest Common Divider by Dividing
        /// </summary>
        /// <param name="x">First number</param>
        /// <param name="y">Second number</param>
        /// <returns>The GreatestCommonDivider</returns>
        public static double DivideGreatestCommonDivider(double x, double y)
        {
            double max = ((x + y) - Math.Abs(x - y)) / 2, min = ((x + y) + Math.Abs(x - y)) / 2;

            if (max % min == 0)
                return min;

            double ob = max % min;

            while (ob != 0)
            {
                max = min;
                min = ob;
                ob = max % min;
            }

            return min != -1 ? min : 0;
        }

        /// <summary>
        /// Checks if two numbers a coprime
        /// </summary>
        /// <param name="x">First number</param>
        /// <param name="y">Second number</param>
        /// <returns>True or False</returns>
        public static bool IsCoprime(double x, double y)
        {
            while (x != y)
                _ = x > y ? x -= y : y -= x;

            return x == 1 ? true : false;
        }

        /// <summary>
        /// Returns the Least Common Multiple
        /// </summary>
        /// <param name="x">First number</param>
        /// <param name="y">Second number</param>
        /// <returns>The LeastCommonMultiple</returns>
        public static double LeastCommonMultiple(double x, double y)
            => ((x * y) / GreatestCommonDivider(x, y) < 0) ?
                ((x * y) / GreatestCommonDivider(x, y)) * -1 :
                (x * y) / GreatestCommonDivider(x, y);

        /// <summary>
        /// Returns the Least Common Multiple with a_n numbers.
        /// </summary>
        /// <param name="numbers">Array of the numbers we are searching the LeastCommonMultiple of</param>
        /// <returns>The LeastCommonMultiple</returns>
        public static double LeastCommonMultiple(params double[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();
            else if (numbers.Length == 1)
                return numbers[0];
            else if (numbers.Length == 2)
                return LeastCommonMultiple(numbers[0], numbers[1]);
            else
                for (int i = 1; i < numbers.Length; i++)
                    numbers[i] = LeastCommonMultiple(Math.Round(numbers[i - 1], 0), Math.Round(numbers[i], 0));

            return numbers[numbers.Length - 1];
        }
    }
}
