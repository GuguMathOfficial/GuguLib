namespace GuguLib.Algorithms.Series
{
    /// <summary>
    /// Contains methods for harmonical series problems
    /// </summary>
    class Harmonical
    {
        /// <summary>
        /// Calculates harmonical series
        /// </summary>
        /// <param name="numbers">Array of the numbers</param>
        /// <returns>Value in string</returns>
        public static string CalculateSeries(params double[] numbers)
        {
            double temp = 0;

            for(int i = 0; i < numbers.Length; i++)
                temp = temp + (1 / numbers[i]);

            return (numbers.Length / temp).ToString();
        }
    }
}
