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

        public static int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            if (n == 0) return 0;

            long totalSum = n * (n + 1) / 2;
            long arrSum = 0;
            foreach(int i in nums)
            {
                arrSum += i;
            }

            return Convert.ToInt32(totalSum - arrSum);
        }

        public static int FirstPositiveMissingNumber(int[] nums) 
        {
            int len = nums.Length;
            if (len == 0) { return 1; }

            for (int i = 0; i < len; i++) 
            {
                if ((nums[i] > 0) && (nums[i] <= len) && (nums[i] != nums[nums[i]-1])) 
                {
                    int temp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = temp;
                }
            }

            for (int i = 0; i < len; i++) 
            {
                if (nums[i] != i + 1) { return i + 1; }
            }

            return len + 1;
        }

        public static int MySqrt(int x)
        {
            if ((x == 0) || (x == 1)) return x;

            long l = 0, r = x;

            while (l <= r) 
            {
                long mid = l + (r - l) / 2;

                long midSquare = mid * mid;

                if (midSquare == x) return (int)mid;
                else if (midSquare > x) r = mid - 1;
                else l = mid + 1;
            }

            return (int)l - 1;
        }

        public static double MyPow(double x, int n)
        {
            double result = 1;
            if (n == 0) return 1;
            if (n < 0) 
            {
                n = -n;
                x = 1 / x;
            }

            while (n != 0) 
            {
                if ((n&1) != 0)
                {
                    result *= x;
                }

                x *= x; n /= 2;
            }

            return result;
        }

        public static int SearchInsert(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1;

            if (target < nums[0]) return 0;
            if (target > nums[r]) return r + 1;
            while (l <= r) 
            {
                int mid = l + (r - l) / 2;

                if (nums[mid] == target) return mid;
                else if (nums[mid] > target) r = mid - 1;
                else l = mid + 1;
            }
            return nums[l] > target ? l : l + 1;
        }

        public static int[] SearchRange(int[] nums, int target)
        {
            int[] result = { -1, -1};
            int l = 0, r = nums.Length - 1;

            while (l <= r) 
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] == target) 
                {
                    int i = mid;
                    while (i >= 0 && nums[mid] == nums[i]) 
                    {
                        i = i - 1;
                    }

                    result[0] = i + 1;
                    i = mid;
                    while (i < nums.Length && nums[mid] == nums[i]) { i++; }
                    result[1] = i - 1;
                    return result;
                }
                else if (nums[mid] > target) 
                {
                    r = mid - 1;
                }
                else 
                {
                    l = mid + 1;
                }
            }

            return result;
        }
    }
}
