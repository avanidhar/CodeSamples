using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.LeetCode
{
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }

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

        /// <summary>
        /// https://leetcode.com/problems/container-with-most-water/
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int MaxArea(int[] height)
        {
            if (height.Length == 0) return 0;

            int length = height.Length;

            int left = 0, right = length-1, maxArea = Int32.MinValue;

            while (left < right) {
                maxArea = Math.Max(maxArea, (right - left) * Math.Min(height[left], height[right]));

                if (height[left] < height[right])
                {
                    left++;
                }
                else right--;
            }

            return maxArea;
        }

        public static string RemoveDuplicateLetters(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 2) return s;
            StringBuilder sb = new StringBuilder();

            bool[] res = new bool[26];

            foreach (char c in s.ToCharArray())
            {
                if (!res[c - 'a'])
                {
                    res[c - 'a'] = true;
                }
            }

            for (int i = 0; i < 26; i++)
            {
                if (res[i])
                {
                    sb.Append((char)('a' + i));
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// https://leetcode.com/problems/odd-even-linked-list/
        /// </summary>
        /// <param name="head">The head node</param>
        /// <returns>The list with an even odd split</returns>
        public static ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode odd = head, even = head.next, evenHead = even;
            while (odd.next != null && even.next != null) {
                odd.next = even.next;
                odd = odd.next;

                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenHead;
            return head;
        }

        /// <summary>
        /// https://leetcode.com/problems/longest-increasing-subsequence/
        /// </summary>
        /// <param name="nums">The input array</param>
        /// <returns></returns>
        public static int LengthOfLIS(int[] nums)
        {
            int length = nums.Length;
            if (length == 0) return 0;

            int[] res = new int[length];
            res[0] = 1;

            for (int i = 1; i < length; i++) {
                for (int j = 0; j < i; j++)
                {
                    if(nums[i] > nums[j])
                    {
                        res[i] = Math.Max(res[i], res[j] + 1);
                    }
                }
            }

            int maxLen = 0;

            for (int i = 0; i < length; i++)
            {
                maxLen = Math.Max(maxLen, res[i]);
            }

            return maxLen;
        }

        /// <summary>
        /// https://leetcode.com/problems/russian-doll-envelopes/
        /// </summary>
        /// <param name="envelopes"></param>
        /// <returns></returns>
        public static int MaxEnvelopes(int[,] envelopes)
        {
            // TODO TODO
            // use a comparator to sort this array
            // Then find the longest increasing subsequence like above.
            return 0;
        }

        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Array.Sort(candidates);

            CombinationSumHelper(candidates, 0, target, new List<int>(), result);

            return result.Distinct().ToList();
        }

        public static void CombinationSumHelper(int[] candidates, int index, int target, List<int> holder, IList<IList<int>> result)
        {
            if (target == 0) {
                result.Add(new List<int>(holder));
                return;
            }

            if (index >= candidates.Length)
            {
                return;
            }

            CombinationSumHelper(candidates, index + 1, target, holder, result);

            holder.Add(candidates[index]);
            CombinationSumHelper(candidates, index + 1, target - candidates[index], holder, result);
            holder.RemoveAt(holder.Count - 1);
        }

        public static string[] missingWords(string s, string t)
        {

            if (string.IsNullOrEmpty(s)) return null;
            var sequence = s.Split(' ');

            if (string.IsNullOrEmpty(t)) return sequence;
            var text = t.Split(' ').Select( item => item.ToLower());
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (string element in text)
            {
                dictionary.Add(element, element);
            }

            var result = new List<string>();

            foreach (string element in sequence)
            {
                if (!dictionary.ContainsKey(element.ToLower()))
                {
                    result.Add(element);
                }
            }

            return result.ToArray();
        }

        public static int fourthBit(int num)
        {
            if (num == 0) return 0;
            int count = 1;
            while (count < 4)
            {
                num = num >> 1;
                count++;
            }

            return (num & 1);
        }

        public static long kSub(int k, int[] nums)
        {
            long result = 0;
            int length = nums.Length;
            if (length == 0) return 0;
            for(int i =0; i<length; i++)
            {
                long sum = 0;
                for (int j = i; j < length; j++)
                {
                    sum += nums[j];
                    if (sum % k == 0) result++;
                }
            }

            return result;
        }

        public static void customSort(int[] arr)
        {
            if (arr.Length == 0) return;

            // Sort the array in increasing order
            Array.Sort(arr);

            Dictionary<int, int> cache = new Dictionary<int, int>();

            foreach (int element in arr)
            {
                if (cache.ContainsKey(element))
                {
                    cache[element] = cache[element] + 1;
                }
                else
                {
                    cache.Add(element, 1);
                }
            }

            // Sort the cache in ascending order of keys
            var sortedByValue = cache.OrderBy(item => item.Value);

            foreach (var kvp in sortedByValue)
            {
                for (int i = 1; i <= kvp.Value; i++)
                {
                    Console.WriteLine(kvp.Key);
                }
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/pacific-atlantic-water-flow/
        /// </summary>
        /// <param name="matrix">The input</param>
        /// <returns></returns>
        public static IList<int[]> PacificAtlantic(int[,] matrix)
        {
            IList<int[]> result = new List<int[]>();
            if (matrix.GetLength(0) == 0) return result;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            bool[,] pacific = new bool[rows, cols];
            bool[,] atlantic = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                explore(matrix, pacific, i, 0);
                explore(matrix, atlantic, i, cols - 1);
            }

            for (int j = 0; j < cols; j++)
            {
                explore(matrix, pacific, 0, j);
                explore(matrix, atlantic, rows - 1, j);
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (pacific[i, j] == true && atlantic[i, j] == true)
                    {
                        result.Add(new int[] { i, j });
                    }
                }
            }
            return result;

        }

        public static void explore(int[,] matrix, bool[,] visited, int row, int col)
        {
            visited[row, col] = true;

            if ((isSafeToFlow(matrix, visited, row -1, col)) && (matrix[row, col] <= matrix[row - 1, col])) explore(matrix, visited, row - 1, col);
            if ((isSafeToFlow(matrix, visited, row + 1, col)) && (matrix[row, col] <= matrix[row + 1, col])) explore(matrix, visited, row + 1, col);
            if ((isSafeToFlow(matrix, visited, row, col + 1)) && (matrix[row, col] <= matrix[row , col + 1])) explore(matrix, visited, row, col + 1);
            if ((isSafeToFlow(matrix, visited, row, col -1)) && (matrix[row, col] <= matrix[row, col - 1])) explore(matrix, visited, row, col - 1);
        }

        public static bool isSafeToFlow(int[,] matrix, bool[,] visited, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1) && !visited[row, col];
        }

        /// <summary>
        /// https://leetcode.com/problems/pascals-triangle-ii/
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static IList<int> GetRow(int rowIndex)
        {
            IList<int> current = new List<int>();
            List<int> next = new List<int>();

            current.Add(1);

            for (int i = 1; i <= rowIndex; i++) {
                next.Add(1);
                for(int j = 1; j < current.Count; j++)
                {
                    next.Add(current[j] + current[j - 1]);
                }
                next.Add(1);

                current = next;
                next = new List<int>();
            }

            return current;
        }

        /// <summary>
        /// https://leetcode.com/problems/top-k-frequent-elements/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IList<int> TopKFrequent(int[] nums, int k)
        {
            IList<int> result = new List<int>();
            int i = 0;
            Dictionary<int, int> cache = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (cache.ContainsKey(num))
                {
                    cache[num] = cache[num] + 1;
                }
                else
                {
                    cache.Add(num, 1);
                }
            }

            var sortedByValue = cache.OrderByDescending(kvp => kvp.Value);

            while (i < k)
            {
                result.Add(sortedByValue.ElementAt(i).Key);
                i++;
            }

            return result;
        }

    }
}
