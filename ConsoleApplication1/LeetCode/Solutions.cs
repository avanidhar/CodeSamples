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

        public static string ZigzagConvert(string s, int numRows)
        {
            if (numRows <= 1) return s;
            int cycleLength = 2 * numRows - 2;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numRows; i++) 
            {
                for (int j = i; j < s.Length; j += cycleLength) 
                {
                    sb.Append(s[j]);

                    int nextInCycle = j - i + cycleLength - i;

                    if (i != 0 && i != numRows - 1 && nextInCycle < s.Length) 
                    {
                        sb.Append(s[nextInCycle]);
                    }
                }
            }

            return sb.ToString();
        }

        public static void MoveZeroesToEnd(int[] nums)
        {
            int length = nums.Length;
            if (length <= 1) return;
            int write_idx = 0;

            for (int i = 0; i < length; i++) 
            {
                if (nums[i] != 0) 
                {
                    nums[write_idx++] = nums[i];
                }
            }

            while (write_idx < length) 
            {
                nums[write_idx] = 0;
                write_idx++;
            }
        }

        /// <summary>
        /// Solution to https://leetcode.com/problems/jump-game/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CanJump(int[] nums)
        {
            int len = nums.Length;
            if (len == 0) return false;
            if (len == 1) return true;

            int max_reachable_idx = 0;
            int iter = 0;

            while (iter < len) 
            {
                if (iter > max_reachable_idx) return false;
                max_reachable_idx = Math.Max(max_reachable_idx, iter + nums[iter]);
                iter++;
            }

            return true;
        }


        /// <summary>
        /// Solution to https://leetcode.com/problems/jump-game/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CanJumpHard(int[] nums)
        {
            if (nums.Length == 0) return true;

            bool isEscapable = CanJumpHelper(nums, 0);

            return isEscapable;
        }

        private static bool CanJumpHelper(int[] nums, int startIndex) {
            if (startIndex >= nums.Length) return true;
            for (int jumpValue = nums[startIndex]; jumpValue > 0; jumpValue--) {
                if (CanJumpHelper(nums, startIndex + jumpValue)) return true;
            }
            return false;
        }

        public static int LengthOfLongestSubstring(string s)
        {
            int length = s.Length;
            if (s.Length <= 1) { return length; }

            int maxLength = 1, left = 0, right = 0 ;
            Dictionary<char, int> locationMap = new Dictionary<char, int>();
            int i = 0;

            for (i = 0; i < length; i++) 
            {
                if (locationMap.ContainsKey(s[i]))
                {
                    int location = locationMap[s[i]];
                    maxLength = Math.Max(maxLength, right - left + 1);
                    if (location >= left)
                    {
                        left = location + 1;
                    }
                    
                }
                locationMap[s[i]] = i;
                right = i;
            }

            return Math.Max(maxLength, right - left + 1);
        }

        public static int MaxProduct(int[] nums) {
            int len = nums.Length;
            if (nums.Length == 0) return 0;
            else if (len == 1) return nums[0];

            int maxProd = int.MinValue, prodTillNow = 1;

            for (int i = 0; i < len; i++) 
            {
                if (nums[i] > 0)
                {
                    prodTillNow *= nums[i];
                    maxProd = Math.Max(prodTillNow, maxProd);
                }
                else if (nums[i] == 0)
                {
                    prodTillNow = 1;
                }
                else 
                {
                                    
                }
            }

            return maxProd;
        
        }

        public static List<List<int>> CombinationSum3(int k, int n)
        {
            List<List<int>> result = new List<List<int>>();
            List<int> validCombo = new List<int>();
            CombinationSumHelper(validCombo, result,1, k, n);
            return result;
        }

        public static void CombinationSumHelper(List<int> validCombo, List<List<int>> answer, int start, int totalNumsToUse, int sum) 
        {
            if (validCombo.Count == totalNumsToUse && sum == 0) 
            {
                answer.Add(new List<int>(validCombo));
                return;
            }

            for (int i = start; i < 10; i++) 
            {
                validCombo.Add(i);
                CombinationSumHelper(validCombo, answer, i + 1, totalNumsToUse, sum - i);
                validCombo.RemoveAt(validCombo.Count - 1);
            }

        }
    }
}
