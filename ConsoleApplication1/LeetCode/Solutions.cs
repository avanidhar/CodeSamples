using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.LeetCode
{
    public static class Solutions
    {
        public static int Robber(int[] nums) 
        {
            if (nums.Length == 0) return 0;
            int evenSum = 0, oddSum = 0;
            for (int i = 0; i < nums.Length;i++ )
            {
                if ((i & 1) == 0)
                {
                    evenSum += nums[i];
                }
                else 
                {
                    oddSum += nums[i];
                }
            }

            return Math.Max(evenSum, oddSum);
        }

        public static string LookAndSay(int n) 
        {
            string sequence = "1";
            for (int i = 1; i < n; i++) 
            {
                sequence = GetNextInSequence(sequence);
            }

            return sequence;
        }

        public static string GetNextInSequence(string input) 
        {
            char begin = input[0];
            int count = 1;
            StringBuilder sb = new StringBuilder();
            int iterator = 1;
            while(iterator<input.Length) 
            {
                if (input[iterator] == begin)
                {
                    count++;
                }
                else 
                {
                    sb.Append(Convert.ToString(count)).Append(Convert.ToString(begin));
                    begin = input[iterator];
                    count = 1;
                }
                iterator++;
            }

            sb.Append(Convert.ToString(count)).Append(Convert.ToString(begin));

            return sb.ToString();
        }

        public static bool SearchInMatrix(int[,] matrix, int target) 
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int row = 0, column = columns-1;
            while (row < rows && column >= 0) 
            {
                if (target == matrix[row, column]) return true;
                else if (target > matrix[row, column]) 
                {
                    row++;
                }
                else if (target < matrix[row, column]) 
                {
                    column--;
                }
            }

            return false;
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            if (nums.Length == 0) return null;

            int len = nums.Length;
            int[] output = new int[len];
            int product = 1;
            output[0] = 1;

            // First pass
            for (int i = 1; i < len; i++) 
            {
                product = product * nums[i - 1];
                output[i] = product;
            }

            // second pass
            product = 1;
            for (int j = len - 2; j >= 0; j--) 
            {
                product = product*nums[j+1];
                output[j] = output[j] * product;            
            }

            return output;
        }
    }
}
