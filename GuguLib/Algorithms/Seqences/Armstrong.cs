using System;

namespace GuguLib.Algorithms.Seqences
{
    public class Armsrong
    {
        /// <summary>
        /// Checks if a number is Armstrong
        /// </summary>
        /// <param name="number">The number that is being checked</param>
        /// <returns>True or False</returns>
        public static bool IsArmstrong(int number)
        {
            double[] index = Array.ConvertAll(number.ToString().ToCharArray(), x => char.GetNumericValue(x));
            int pow = index.Length;
            double value = 0;

            for (int i = 0; i < pow; i++)
                value += Math.Pow(index[i], pow);

            return value == number;
        }

        /// <summary>
        /// Checks if a row consists of Armstrong numbers
        /// </summary>
        /// <param name="arr">Array of armstrong numbers</param>
        /// <returns>True or False</returns>
        public static bool IsArmstrongRow(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                if (IsArmstrong(arr[i]) != true)
                    return false;

            return true;
        }

        /// <summary>
        /// Generates an armstrong sequence
        /// </summary>
        /// <param name="count">Amount of armstrong numbers</param>
        /// <returns>The armstrong numbers</returns>
        public static string GenerateArmstrong(int count)
        {
            double[] row = new double[count];
            int j = 0;

            for (int i = 1; i < count; i++)
                while (true)
                {
                    j++;
                    if (IsArmstrong(j))
                    {
                        row[i] = j;
                        break;
                    }
                }

            return string.Join(",", row);
        }
    }
}
