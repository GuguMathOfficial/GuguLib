using System;
using System.Collections.Generic;

using static GuguLib.Algorithms.EuclidAlgorithms;

namespace GuguLib.Algorithms.Seqences
{
    /// <summary>
    /// Contains methods for arithmethic sequnece problems
    /// </summary>
    public static class Arithmetic
    {
        /// <summary>
        /// Calculates an arithmetic sequence with A values only
        /// </summary>
        /// <param name="top">Elements on the top row</param>
        /// <param name="bot">Elements on the bot bottom</param>
        /// <param name="sum">Array of both equals</param>
        /// <returns>The sequence's answer</returns>
        [Controllable]
        public static Controlled<string, ArgumentException> CalculateSequence(double[] top, double[] bot, double[] sum)
        {
            var ctrl = new Controlled<string, ArgumentException>();

            if (sum.Length != 2) // Checks of the sum array has only 2 elements
                ctrl.Exception = new ArgumentException("The sum can have only 2 elements");

            double denD = 0, numD = 0;
            double numA = 0, denA = 0;
            double a, d;

            CalculateSequence(top, bot, sum, ref numA, ref denA, ref numD, ref denD);

            if (numA % denA == 0 && numD % denD == 0) // Checks if you can devide the numbers and if you can it devides them and returns the answer.
            {
                a = numA / denA;
                d = numD / denD;
                ctrl.ReturnValue = $"a = {a} d = {d}";
            }
            else if (numA % denA == 0 && numD % denD != 0)
            {
                a = numA / denA;
                Fractions.Shorten(ref numD, ref denD);
                ctrl.ReturnValue = $"a = {a} + d =  {numD}/{denD}";
            }
            else if (numA % denA != 0 && numD % denD == 0)
            {
                d = numD / denD;
                Fractions.Shorten(ref numA, ref denA);
                ctrl.ReturnValue = $"a = {numA}/{denA} d = {d}";
            }
            else
            {
                Fractions.Shorten(ref numD, ref denD);
                Fractions.Shorten(ref numA, ref denA);
                ctrl.ReturnValue = $"a = {numA}/{denA } d = {numD}/{denD}";
            }

            return ctrl;
        }

        /// <summary>
        /// Calculates an arithmetic sequence with A and S values
        /// </summary>
        /// <param name="top">Values of A on the top row</param>
        /// <param name="bot">Values of A the bottom row</param>
        /// <param name="topS">Values of S on the top row</param>
        /// <param name="botS">Values of S on the bottom row</param>
        /// <param name="sum">Array of both equals</param>
        /// <returns>The sequence's answer</returns>
        [Controllable]
        public static Controlled<string, ArgumentException> CalculateSequence(double[] top, double[] bot, double[] topS, double[] botS, double[] sum)
        {
            var ctrl = new Controlled<string, ArgumentException>();

            if (sum.Length != 2) // Checks of the sum array has only 2 elements
                ctrl.Exception = new ArgumentException("The sum can have only 2 elements");

            double denD = 0, numD = 0;
            double numA = 0, denA = 0;
            double a, d;

            CalculateSequence(top, bot, topS, botS, sum, ref numA, ref denA, ref numD, ref denD);
            
            if (numA % denA == 0 && numD % denD == 0) // Checks if you can devide the numbers and if you can it devides them and returns the answer.
            {
                a = numA / denA;
                d = numD / denD;
                ctrl.ReturnValue = $"a = {a} d = {d}";
            }
            else if (numA % denA == 0 && numD % denD != 0)
            {
                a = numA / denA;
                Fractions.Shorten(ref numD, ref denD);
                ctrl.ReturnValue = $"a = {a} + d =  {numD}/{denD}";
            }
            else if (numA % denA != 0 && numD % denD == 0)
            {
                d = numD / denD;
                Fractions.Shorten(ref numA, ref denA);
                ctrl.ReturnValue = $"a = {numA}/{denA} d = {d}";
            }
            else
            {
                Fractions.Shorten(ref numD, ref denD);
                Fractions.Shorten(ref numA, ref denA);
                ctrl.ReturnValue = $"a = {numA}/{denA } d = {numD}/{denD}";
            }

            return ctrl;
        }

        /// <summary>
        /// Generates an arithmetic sequence
        /// </summary>
        /// <param name="firstNumber">Number from which generating starts</param>
        /// <param name="steps">Steps for every generated number</param>
        /// <param name="termCount">Amount of generated numbers</param>
        /// <returns>A list of the generated numbers</returns>
        [Controllable]
        public static Controlled<List<int>, ArgumentException> GenerateSequence(int firstNumber, int steps, uint termCount)
        {
            var numbers = new List<int>();
            var ctrl = new Controlled<List<int>, ArgumentException>();

            if (termCount < 1)
                ctrl.Exception = new ArgumentException("Term count can not be a negative number!");

            do
            {
                numbers.Add(firstNumber);
                firstNumber += steps;
            } while (numbers.Count < termCount);

            ctrl.ReturnValue = numbers;

            return ctrl;
        }

        #region Squence calculations
        /// <summary>
        /// Calculates the sequnce
        /// </summary>
        /// <param name="top">Array of the values on the top row</param>
        /// <param name="bot">Array of the values on the bottom row</param>
        /// <param name="sum">Array of the sum on both rows</param>
        /// <param name="numA">Store for A's numerator value as a reference value</param>
        /// <param name="denA">Store for A's denominator value as a reference value</param>
        /// <param name="numD">Store for D's numerator value as a reference value</param>
        /// <param name="denD">Store for A's denominator value as a reference value</param>
        static void CalculateSequence(double[] top, double[] bot, double[] sum, ref double numA, ref double denA, ref double numD, ref double denD)
        {
            double[] a1 = new double[top.Length];
            double[] b1 = new double[bot.Length];

            FindAandD(ref top, ref a1);
            FindAandD(ref bot, ref b1);

            double a, d1, b, d2; // a and d1 are A and D on first row, b and d2 are A and D on second row
            a = d1 = b = d2 = 0;

            CalculateAandD(a1, top, ref a, ref d1);
            CalculateAandD(b1, bot, ref b, ref d2);

            CalculateSequence(a, b, d1, d2, sum, ref numA, ref denA, ref numD, ref denD);
        }

        /// <summary>
        /// Calculates a sequnce with a sum
        /// </summary>
        /// <param name="top">Array of the values on the top row</param>
        /// <param name="bot">Array of the values on the bottom row</param>
        /// <param name="topS">Array of the S values on top row</param>
        /// <param name="botS">Array of the S values on bottom row</param>
        /// <param name="sum">Array of the sum on both rows</param>
        /// <param name="numA">Store for A's numerator value as a reference value</param>
        /// <param name="denA">Store for A's denominator value as a reference value</param>
        /// <param name="numD">Store for D's numerator value as a reference value</param>
        /// <param name="denD">Store for A's denominator value as a reference value</param>
        static void CalculateSequence(double[] top, double[] bot, double[] topS, double[] botS, double[] sum, ref double numA, ref double denA, ref double numD, ref double denD)
        {
            byte dLenTop = (byte)top.Length;
            byte dLenBot = (byte)bot.Length;
            double[] a1 = new double[top.Length + topS.Length];
            double[] b1 = new double[bot.Length + botS.Length];
            double[] dTop = new double[top.Length + topS.Length];
            double[] dBot = new double[bot.Length + botS.Length];
            top.CopyTo(dTop, 0);
            bot.CopyTo(dBot, 0);

            FindAandD(ref dTop, ref a1, topS, dLenTop);
            FindAandD(ref dBot, ref b1, botS, dLenBot);

            double a, d1, b, d2;
            a = d1 = b = d2 = 0;

            CalculateAandD(a1, dTop, ref a, ref d1);
            CalculateAandD(b1, dBot, ref b, ref d2);

            CalculateSequence(a, b, d1, d2, sum, ref numA, ref denA, ref numD, ref denD);
        }

        /// <summary>
        /// Calculates the elimination and calculation portion of the arithemtic sequence
        /// </summary>
        /// <param name="a">Value of A1 on first row</param>
        /// <param name="b">Value of A1 on second row</param>
        /// <param name="d1">Value of D on first row</param>
        /// <param name="d2">Value of D on second row</param>
        /// <param name="sum">Array of the sum on both rows</param>
        /// <param name="numA">Store for A's numerator value as a reference value</param>
        /// <param name="denA">Store for A's denominator value as a reference value</param>
        /// <param name="numD">Store for D's numerator value as a reference value</param>
        /// <param name="denD">Store for A's denominator value as a reference value</param>
        static void CalculateSequence(double a, double b, double d1, double d2, double[] sum, ref double numA, ref double denA, ref double numD, ref double denD)
        {
            double[] leastCommonMultiple = new double[2];
            double d;

            if (a != 0 && b != 0 || d1 == 0 || d2 == 0) // Checks if either A on the first or A on the second line is != 0. If so it uses the elimination method.
            {
                if (d1 == 0)
                {
                    numA = a < 0 ? sum[0] * -1 : sum[0];
                    a = numA * b;
                    sum[1] -= a;
                    if (sum[1] % d2 != 0)
                    {
                        numD = sum[1];
                        denD = d2;
                    }
                    else
                    {
                        numD = sum[1] / d2;
                        denD = 1;
                    }
                    denA = 1;
                }
                else if (d2 == 0)
                {
                    numA = b < 0 ? sum[1] * -1 : sum[1];
                    a = numA * a;
                    sum[0] -= a;
                    if (sum[0] % d1 != 0)
                    {
                        numD = sum[0];
                        denD = d1;
                    }
                    else
                    {
                        numD = sum[0] / d1;
                        denD = 1;
                    }
                    denA = 1;
                }
                else if (a != 0 && b != 0)
                {
                    leastCommonMultiple[0] = LeastCommonMultiple(a, b);
                    leastCommonMultiple[1] = LeastCommonMultiple(d1, d2);

                    if (leastCommonMultiple[0] < leastCommonMultiple[1])
                    {
                        d1 *= (leastCommonMultiple[0] / a);
                        sum[0] *= (leastCommonMultiple[0] / a);
                        a *= (leastCommonMultiple[0] / a);

                        if (a < 0 && b > 0 || a > 0 && b < 0)
                        {
                            if (a < 0 && b > 0)
                            {
                                d2 *= (leastCommonMultiple[0] / b);
                                sum[1] *= (leastCommonMultiple[0] / b);
                            }
                            else
                            {
                                d2 *= -(leastCommonMultiple[0] / b);
                                sum[1] *= -(leastCommonMultiple[0] / b);
                            }
                        }
                        else
                        {
                            d2 *= -(leastCommonMultiple[0] / b);
                            sum[1] *= -(leastCommonMultiple[0] / b);
                        }
                    }
                    else
                    {
                        d1 *= (leastCommonMultiple[1] / d1);
                        sum[0] *= (leastCommonMultiple[1] / d1);
                        a *= (leastCommonMultiple[1] / d1);

                        if (d1 < 0 && d2 > 0 || d1 > 0 && d2 < 0)
                        {
                            sum[1] *= (leastCommonMultiple[1] / d2);
                            d2 *= (leastCommonMultiple[1] / d2);
                        }
                        else
                        {
                            sum[1] *= -(leastCommonMultiple[1] / d2);
                            d2 *= -(leastCommonMultiple[1] / d2);
                        }
                    }

                    numA = a;
                    denA = 1;
                    denD = d1 + d2;
                    numD = sum[0] + sum[1];

                    if (numD % denD != 0)
                        CalctulateFraction(numD, denD, d1, a, sum[0], ref numA, ref denA);
                }
            }
            else
            {
                if (a == 0)
                {
                    d = GreatestCommonDivider(sum[0], d1);
                    if (d > 1)
                    {
                        sum[0] /= d;
                        d1 /= d;
                    }
                    d = sum[0] / d1;
                    numD = sum[0];
                    denD = d1;
                    numA = sum[1] - (d * d2);
                    denA = b;

                    if (numD % denD != 0)
                        CalctulateFraction(numD, denD, d2, b, sum[1], ref numA, ref denA);
                }
                else if (b == 0)
                {
                    d = GreatestCommonDivider(sum[1], d2);
                    if (d > 1)
                    {
                        sum[1] /= d;
                        d2 /= d;
                    }

                    numD = sum[1];
                    denD = d2;
                    denA = a;

                    if (numD % denD != 0)
                        CalctulateFraction(numD, denD, d1, a, sum[0], ref numA, ref denA);
                }
            }
        }

        /// <summary>
        /// Calculates the fraction portion of arithmetic equation
        /// </summary>
        /// <param name="numD">D's numerator</param>
        /// <param name="denD">D's denominator</param>
        /// <param name="d">Value of D</param>
        /// <param name="a">Value of A</param>
        /// <param name="sum">Value of sum</param>
        /// <param name="numA">Store for A's numerator value as a reference value</param>
        /// <param name="denA">Store for A's denominator value as a reference value</param>
        static void CalctulateFraction(double numD, double denD, double d, double a, double sum, ref double numA, ref double denA)
        {
            Fractions.CalculateFraction(new double[] { numD, d }, new int[] { (int)denD, 1 }, ref numA, ref denA, '*');
            Fractions.Shorten(ref numA, ref denA);
            Fractions.CalculateFraction(new double[] { sum, -numA }, new int[] { 1, (int)denA }, ref numA, ref denA, '+');
            Fractions.CalculateFraction(new double[] { numA, a }, new int[] { (int)denA, 1 }, ref numA, ref denA, '/');
        }

        #endregion

        #region Operations on a single row
        /// <summary>
        /// Seperates the A on a row into As and Ds(Arithmetic Sequence)
        /// </summary>
        /// <param name="d">Reference variable where you save the Ds</param>
        /// <param name="a1">Reference variable where you save the As</param>
        static void FindAandD(ref double[] d, ref double[] a1)
        {
            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] == 1)
                {
                    a1[i] = 1;
                    d[i] = 0;
                    continue;
                }
                else if (d[i] == -1)
                {
                    a1[i] = -1;
                    d[i] = 0;
                    continue;
                }

                if (d[i] > 0)
                {
                    a1[i] = 1;
                    d[i]--;
                }
                else if (d[i] < 0)
                {
                    a1[i] = -1;
                    d[i]++;
                }
            }
        }

        /// <summary>
        /// Seperates the A and S on a row into As and Ds(Arithmetic Sequence)
        /// </summary>
        /// <param name="d">Reference variable where you save the Ds</param>
        /// <param name="a1">Reference variable where you save the As</param>
        /// <param name="s">Array of the S values on a row</param>
        /// <param name="dLen">Length of d values array</param>
        static void FindAandD(ref double[] d, ref double[] a1, double[] s, byte dLen)
        {
            FindAandD(ref d, ref a1);
            for (int i = dLen; i < d.Length; i++)
            {
                a1[i] = 2;
                if (s[i - dLen] > 0)
                    d[i] = s[i - dLen] - 1;
                else
                {
                    d[i] = s[i - dLen] + 1;
                    d[i] *= -1;
                }

                if (s[i - dLen] % 2 == 0)
                {
                    a1[i] *= s[i - dLen] / 2;
                    d[i] *= s[i - dLen] / 2;
                }
                else
                {
                    a1[i] = 1;
                    d[i] /= 2;
                    a1[i] *= s[i - dLen];
                    d[i] *= s[i - dLen];

                }
            }
        }

        /// <summary>
        /// Calculates A and D on a row
        /// </summary>
        /// <param name="aArr">Array of A values</param>
        /// <param name="dArr">Array of D values</param>
        /// <param name="a">Store for A value as a reference value</param>
        /// <param name="d">Store for D value as a reference value</param>
        static void CalculateAandD(double[] aArr, double[] dArr, ref double a, ref double d)
        {
            double temp;

            if (dArr.Length == 1)
                d = dArr[0];

            for (int i = 1; i < dArr.Length; i++)
            {
                if (i >= 2)
                    d = dArr[i] + d;

                else
                {
                    temp = dArr[i] + dArr[i - 1];
                    d = temp + d;
                }
            }

            if (aArr.Length == 1)
                a = aArr[0];

            for (int i = 1; i < aArr.Length; i++)
            {
                if (i >= 2)
                    a += aArr[i];

                else
                {
                    temp = aArr[i] + aArr[i - 1];
                    a = temp + a;
                }
            }
        }

        #endregion

    }
}
