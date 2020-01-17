using System;
using System.Collections.Generic;
using System.Text;

namespace GuguLib.Algorithms.Seqences
{
    public class Fibonacci
    {
        /// <summary>
        /// Checks if an array is filled with Fibonacci numbers
        /// </summary>
        /// <param name="arr">Fibonacci Array</param>
        /// <returns>True or False</returns>
        public static bool IsFibonacci(int[] arr)
        {
            if (arr.Length < 3)
            {
                return false;
            }

            int fib1 = 0;
            int fib2 = 1;

            while (fib1 < arr[0])
            {
                int tmp = fib1 + fib2;
                fib1 = fib2;
                fib2 = tmp;
            }

            if (fib1 != arr[0] || fib2 != arr[1])
                return false;

            for (int i = 2; i < arr.Length; i++)
                if (arr[i] != (arr[i - 1] + arr[i - 2]) || arr[i] < 0)
                    return false;
            
            return true;
        }

        /// <summary>
        /// Generates a fibonaci row
        /// </summary>
        /// <param name="count">Number of fibonaci numbers</param>
        /// <param name="row">Contains the sequence</param>
        /// <returns>The Sequence</returns>
        public static string GetFibonacciRow(int count, out double[] row)
        {
            row = new double[count];
            row[0] = 0;
            row[1] = 1;

            for (int i = 2; i < count; i++)
            {
                row[i] = row[0] + row[1];
                row[0] = row[1];
                row[1] = row[i];
            }
            row[0] = 0;
            row[1] = 1;

            return string.Join(",", row);
        }
    }
}
