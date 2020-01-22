using System;

namespace GuguLib.Algorithms.Series
{
    /// <summary>
    /// Contains methods for geometric series problems
    /// </summary>
    class Geometric
    {
        /// <summary>
        /// Calculates geometric series
        /// </summary>
        /// <param name="numbers">Array of the numbers</param>
        /// <returns>Value in string</returns>
        public static string CalculateSeries(params double[] numbers)
        {
            double temp = 1;

            for(int i = 0; i < numbers.Length; i++)
                temp *= numbers[i];

            return Math.Pow(temp, 1.0 / numbers.Length).ToString();
        }
    }
}
