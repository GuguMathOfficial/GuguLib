using System;
using static GuguLib.Algorithms.EuclidAlgorithms;

namespace GuguLib
{
    public static class Fractions
    {
        /// <summary>
        /// Calculates a fraction
        /// </summary>
        /// <param name="numerator">Each numerator</param>
        /// <param name="denominator">Each denominator</param>
        /// <param name="num">Store for the numerator as ref variable</param>
        /// <param name="den">Store the denominator as ref variable</param>
        /// <param name="symbol">The symbol used to calculate the fraction</param>
        /// <returns>The calculated fraction</returns>
        [Controllable]
        public static Controlled<double, ArgumentException> CalculateFraction(double[] numerator, int[] denominator, ref double num, ref double den, char symbol = '+')
        {
            var ctrl = new Controlled<double, ArgumentException>();
            double result = 0;
            double commonDenominator = 1;

            if (numerator.Length > denominator.Length || numerator.Length < denominator.Length)
                ctrl.Exception = new ArgumentException("Not enough numerators or denominators");

            if (symbol == '+' || symbol == '-')
            {
                for (int i = 0; i < denominator.Length; i++)
                    commonDenominator = LeastCommonMultiple(commonDenominator, denominator[i]);

                for (int i = 0; i < numerator.Length; i++)
                {
                    double temp = (commonDenominator / denominator[i]) * numerator[i];
                    _ = symbol == '+' ? result += temp : result = temp - result;
                    if (symbol == '-') { result *= -1; }
                }
            }

            else if (symbol == '*' || symbol == '/')
            {
                commonDenominator = denominator[0];
                if (symbol == '/')
                    for (int i = 0; i < numerator.Length - 1; i++)
                    {
                        double tempNum = numerator[i] * denominator[i + 1];
                        result += tempNum;
                        commonDenominator *= numerator[i + 1];
                    }

                if (symbol == '*')
                    for (int i = 0; i < numerator.Length - 1; i++)
                    {
                        double tempNum = (numerator[i] * numerator[i + 1]);
                        result += tempNum;
                        commonDenominator *= denominator[i + 1];
                    }
            }
            else
                ctrl.Exception = new ArgumentException("Not a valid symbol set");

            num = result;
            den = commonDenominator;

            ctrl.ReturnValue = result / commonDenominator;
            return ctrl;
        }

        /// <summary>
        /// Converts a decimal number to a fraction
        /// </summary>
        /// <param name="num">The number we want to convert</param>
        /// <param name="wholeNum">If we want a whole number or not</param>
        /// <returns>The fraction</returns>
        public static string ConvertToFraction(double num, bool wholeNum)
        {
            string number = num.ToString();
            string[] numbers = number.Split('.');
            
            if (numbers.Length < 2)
                return number + "/" + 1;

            double numerator = double.Parse(numbers[1]);
            double denominator = 1;

            for (int i = 0; i < numbers[1].Length; i++)
                denominator *= 10;

            double greatestCommonDivider = GreatestCommonDivider(numerator, denominator);
            numerator /= greatestCommonDivider;
            denominator /= greatestCommonDivider;

            return wholeNum == true ? (numbers[0] + " " + numerator + "/" + denominator) :
                ((double.Parse(numbers[0]) * denominator) + numerator) + "/" + denominator;
        }

        /// <summary>
        /// Shortens a fraction
        /// </summary>
        /// <param name="x">Numerator</param>
        /// <param name="y">Denominator</param>
        public static void Shorten(ref double x, ref double y)
        {
            double temp = GreatestCommonDivider(x, y);
            x /= temp;
            y /= temp;
        }

    }
}
