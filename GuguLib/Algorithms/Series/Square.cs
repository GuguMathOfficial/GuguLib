using System;

namespace GuguLib.Algorithms.Series
{
    /// <summary>
    /// Contains methods for square series problems
    /// </summary>
    class Square
    {
        /// <summary>
        /// Calculates square series
        /// </summary>
        /// <param name="numbers">Array of the numbers</param>
        /// <returns>Value in string</returns>
        public static string CalculateSeries(params int[] numbers)
        {
            double temp = 0;

            for (int i = 0; i < numbers.Length; i++)
                temp += Math.Pow(numbers[i], 2);

            return Math.Sqrt(temp / numbers.Length).ToString();
        }
    }
}
