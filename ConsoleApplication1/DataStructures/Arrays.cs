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
    }
}
