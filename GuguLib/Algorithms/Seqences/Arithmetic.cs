using System;
using static GuguLib.Algorithms.EuclidAlgorithms;

namespace GuguLib.Algorithms.Seqences
{
    public static class Arithmetic
    {
        /// <summary>
        /// Calculates an arithmetic sequence
        /// </summary>
        /// <param name="top">Elements on the top line</param>
        /// <param name="bot">Elements on the bot line</param>
        /// <param name="sum">Array of both equals</param>
        /// <returns>The Sequence's answer</returns>            
        public static string Sequence(double[] top, double[] bot, double[] sum) // It only works with a1 elements for now. Ex. (a3+a6=8 | a2-a7=16)
        {
            if (sum.Length > 2) // Checks of the sum array has only 2 elements
                throw new ArgumentException("The sum can have only 2 elements");

            double[] a1 = new double[top.Length];
            double[] b1 = new double[bot.Length];

            FindAandD(ref top, ref a1); // Uses a function which seperates the A to an A and a D
            FindAandD(ref bot, ref b1);

            double a, d1, b, d2, temp;
            a = d1 = b = d2 = 0;

            if (top.Length == 1)
            {
                d1 = top[0];
            }
            for (int i = 1; i < top.Length; i++)//The bottom for loops calculate the A and D on both lines
            {
                if (i >= 2)
                {
                    d1 = top[i] + d1;
                }
                else
                {
                    temp = top[i] + top[i - 1];
                    d1 = temp + d1;
                }
            }
            if (a1.Length == 1)
            {
                a = a1[0];
            }
            for (int i = 1; i < a1.Length; i++)
            {
                if (i >= 2)
                {
                    a = a + a1[i];
                }
                else
                {
                    temp = a1[i] + a1[i - 1];
                    a = temp + a;
                }
            }
            if (bot.Length == 1)
            {
                d2 = bot[0];
            }
            for (int i = 1; i < bot.Length; i++)
            {
                if (i >= 2)
                {
                    d2 = d2 + bot[i];
                }
                else
                {
                    temp = bot[i] + bot[i - 1];
                    d2 = temp + d2;
                }
            }
            if (b1.Length == 1)
            {
                b = 1;
            }
            for (int i = 1; i < b1.Length; i++)
            {
                if (i >= 2)
                {
                    b = b1[i] + b;
                }
                else
                {
                    temp = b1[i] + b1[i - 1];
                    b = temp + b;
                }
            }

            a1 = new double[2]; // Reuse of the array
            double d = 0;
            double den_d = 0, num_d = 0;
            double num_a = 0, den_a = 0;

            if (a != 0 && b != 0 || d1 == 0 || d2 == 0) // Checks if either A on the first or A on the second line is != 0. If so it uses the elimination method.
            {
                if (d1 == 0)
                {
                    num_a = a < 0 ? sum[0] * -1 : sum[0];
                    a = num_a * b;
                    sum[1] -= a;
                    if (sum[1] % d1 != 0)
                    {
                        num_d = sum[0];
                        den_d = d1;
                    }
                    else
                    {
                        num_d = sum[1] / d1;
                        den_d = 1;
                    }
                    den_a = 1;
                }
                else if (d2 == 0)
                {
                    num_a = b < 0 ? sum[1] * -1 : sum[1];
                    a = num_a * a;
                    sum[0] -= a;
                    if (sum[0] % d1 != 0)
                    {
                        num_d = sum[0];
                        den_d = d1;
                    }
                    else
                    {
                        num_d = sum[0] / d1;
                        den_d = 1;
                    }
                    den_a = 1;
                }
                else if (a != 0 && b != 0)
                {
                    a1[0] = LeastCommonMultiple(a, b);
                    a1[1] = LeastCommonMultiple(d1, d2);

                    if (a1[0] < a1[1])
                    {
                        d1 *= (a1[0] / a);
                        sum[0] *= (a1[0] / a);
                        a *= (a1[0] / a);

                        if (a < 0 && b > 0 || a > 0 && b < 0)
                        {
                            if (a < 0 && b > 0)
                            {
                                d2 *= (a1[0] / b);
                                sum[1] *= (a1[0] / b);
                                b *= (a1[0] / b);
                            }
                            else
                            {
                                d2 *= -(a1[0] / b);
                                sum[1] *= -(a1[0] / b);
                                b *= -(a1[0] / b);
                            }
                        }
                        else
                        {
                            d2 *= -(a1[0] / b);
                            sum[1] *= -(a1[0] / b);
                            b *= -(a1[0] / b);
                        }
                    }
                    else
                    {
                        d1 *= (a1[1] / d1);
                        sum[0] *= (a1[1] / d1);
                        a *= (a1[1] / d1);

                        if (d1 < 0 && d2 > 0 || d1 > 0 && d2 < 0)
                        {
                            d2 *= (a1[1] / d2);
                            sum[1] *= (a1[1] / d2);
                            b *= (a1[1] / d2);
                        }
                        else
                        {
                            sum[1] *= -(a1[1] / d2);
                            b *= -(a1[1] / d2);
                            d2 *= -(a1[1] / d2);
                        }
                    }

                    num_a = a;
                    den_a = 1;
                    den_d = d1 + d2;
                    num_d = sum[0] + sum[1];
                    d = (sum[0] + sum[1]) / den_d;

                    if (num_d % den_d != 0)
                    {
                        Fractions.CalculateFraction(new double[] { num_d, d1 }, new int[] { (int)den_d, 1 }, ref num_a, ref den_a, '*');
                        Fractions.Shorten(ref num_a, ref den_a);
                        Fractions.CalculateFraction(new double[] { sum[0], -num_a }, new int[] { 1, (int)den_a }, ref num_a, ref den_a, '+');
                        Fractions.CalculateFraction(new double[] { num_a, a }, new int[] { (int)den_a, 1 }, ref num_a, ref den_a, '/');
                    }
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
                    num_d = sum[0];
                    den_d = d1;
                    num_a = sum[1] - (d * d2);
                    den_a = b;

                    if (num_d % den_d != 0)
                    {
                        Fractions.CalculateFraction(new double[] { num_d, d2 }, new int[] { (int)den_d, 1 }, ref num_a, ref den_a, '*');
                        Fractions.Shorten(ref num_a, ref den_a);
                        Fractions.CalculateFraction(new double[] { sum[1], -num_a }, new int[] { 1, (int)den_a }, ref num_a, ref den_a, '+');
                        num_a *= -1;
                        Fractions.CalculateFraction(new double[] { num_a, b }, new int[] { (int)den_a, 1 }, ref num_a, ref den_a, '/');
                    }

                    if (num_a % den_a == 0 && num_d % den_d == 0) // Checks if you can devide the numbers and if you can it devides them and returns the answer.
                    {
                        a = num_a / den_a;
                        d = num_d / den_d;
                        return "a = " + a + " d = " + d;
                    }
                    else if (num_a % den_a == 0 && num_d % den_d != 0)
                    {
                        a = num_a / den_a;
                        Fractions.Shorten(ref num_d, ref den_d);
                        return "a = " + a + " d = " + num_d + "/" + den_d;
                    }
                    else if (num_a % den_a != 0 && num_d % den_d == 0)
                    {
                        d = num_d / den_d;
                        Fractions.Shorten(ref num_a, ref den_a);
                        return "a = " + num_a + "/" + den_a + " d = " + d;
                    }
                    else
                    {
                        Fractions.Shorten(ref num_d, ref den_d);
                        Fractions.Shorten(ref num_a, ref den_a);
                        return "a = " + num_a + "/" + den_a + " d = " + num_d + "/" + den_d;
                    }
                }
                else if (b == 0)
                {
                    d = GreatestCommonDivider(sum[1], d2);
                    if (d > 1)
                    {
                        sum[1] /= d;
                        d2 /= d;
                    }

                    d = sum[1] / d2;
                    num_d = sum[1];
                    den_d = d2;
                    den_a = a;

                    if (num_d % den_d != 0)
                    {
                        Fractions.CalculateFraction(new double[] { num_d, d1 }, new int[] { (int)den_d, 1 }, ref num_a, ref den_a, '*');
                        Fractions.Shorten(ref num_a, ref den_a);
                        Fractions.CalculateFraction(new double[] { sum[0], -num_a }, new int[] { 1, (int)den_a }, ref num_a, ref den_a, '+');
                        Fractions.CalculateFraction(new double[] { num_a, a }, new int[] { (int)den_a, 1 }, ref num_a, ref den_a, '/');
                    }
                }
            }

            if (num_a % den_a == 0 && num_d % den_d == 0) // Checks if you can devide the numbers and if you can it devides them and returns the answer.
            {
                a = num_a / den_a;
                d = num_d / den_d;
                return "a = " + a + " d = " + d;
            }
            else if (num_a % den_a == 0 && num_d % den_d != 0)
            {
                a = num_a / den_a;
                Fractions.Shorten(ref num_d, ref den_d);
                return "a = " + a + " d = " + num_d + "/" + den_d;
            }
            else if (num_a % den_a != 0 && num_d % den_d == 0)
            {
                d = num_d / den_d;
                Fractions.Shorten(ref num_a, ref den_a);
                return "a = " + num_a + "/" + den_a + " d = " + d;
            }
            else
            {
                Fractions.Shorten(ref num_d, ref den_d);
                Fractions.Shorten(ref num_a, ref den_a);
                return "a = " + num_a + "/" + den_a + " d = " + num_d + "/" + den_d;
            }
        }

        /// <summary>
        /// Seperates the A on the first and second row into As and Ds(Arithmetic Sequence)
        /// </summary>
        /// <param name="d">Variable where you save the Ds</param>
        /// <param name="a1">Variable where you save the As</param>
        public static void FindAandD(ref double[] d, ref double[] a1)
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
    }
}
