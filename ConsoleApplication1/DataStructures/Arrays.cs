using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
    public static class Arrays
    {
        public static Tuple<int, int> DoesSumExist(int[] arr, int sum)
        {
            if (arr.Length == 0) return Tuple.Create(-1, -1);
            int cur_sum = arr[0], start = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                cur_sum += arr[i];

                while (cur_sum > sum && start <= i)
                {
                    cur_sum -= arr[start++];
                }

                if (cur_sum == sum) return Tuple.Create(start, i);
            }

            return Tuple.Create(-1, -1);
        }

        #region merge one array into another
        /// <summary>
        /// Given two sorted arrays such that the first array has space
        /// at the end to accommodate the second, write a method to merge
        /// the second into the first and maintain the sort.
        /// </summary>
        public static void MergeInPlace(int[] first, int[] second)
        {
            if (first.Length == 0) return;
            int flen = first.Length - 1;
            int slen = second.Length - 1;
            int mlen = first.Length + second.Length - 1;

            while (flen >= 0 && slen >= 0)
            {
                if (first[flen] >= second[slen])
                {
                    first[mlen--] = first[flen--];
                }
                else
                {
                    first[mlen--] = second[slen--];
                }
            }

            // Only check for the second as the first will already be sorted.
            while (slen >= 0)
            {
                first[mlen--] = second[slen--];
            }
        }
        #endregion

    }
}
