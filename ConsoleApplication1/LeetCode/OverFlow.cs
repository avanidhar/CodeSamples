using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.LeetCode
{
    public static class OverFlow
    {
        public static IList<string> FindRepeatedDnaSequences(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;

            List<string> result = new List<string>();
            int i = 0;

            if (s.Length <= 10) return result;

            StringBuilder sb = new StringBuilder();
            Dictionary<string, int> cache = new Dictionary<string, int>();

            for (i = 0; i < 10; i++)
            {
                sb.Append(s[i]);
            }

            cache.Add(sb.ToString(), 1);

            for (; i < s.Length; i++)
            {
                sb.Remove(0, 1);
                sb.Append(s[i]);

                string temp = sb.ToString();
                if (cache.ContainsKey(temp))
                {
                    if (cache[temp] == 1) result.Add(temp);
                    cache[temp]++;
                }
                else
                {
                    cache.Add(temp, 1);
                }
            }

            return result;
        }

        public static int FindSubstringInWraproundString(string p)
        {
            if (string.IsNullOrEmpty(p)) return 0;

            int len = p.Length;

            HashSet<char> cache = new HashSet<char>();

            int[] counts = new int[len];

            counts[0] = 1;
            cache.Add(p[0]);

            for (int i = 1; i < len; i++)
            {
                if ((p[i] - p[i - 1] == 1 || p[i - 1] - p[i] == 25))
                {
                    if (cache.Contains(p[i]))
                    {
                        counts[i] = 0;
                    }
                    else
                    {
                        counts[i] += counts[i - 1];
                    }
                }
                else
                {
                    if (!cache.Contains(p[i]))
                    {
                        counts[i] = 1;
                        cache.Add(p[i]);
                    }
                }
            }

            int sum = 0;
            for (int i = 0; i < len; i++)
            {
                sum += counts[i];
            }

            return sum;
        }

        public static int MinSubArrayLen(int s, int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int minLen = Int32.MaxValue;

            int cur_sum = nums[0], start = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                cur_sum += nums[i];

                while (cur_sum > s && start <= i)
                {
                    cur_sum -= nums[start++];
                }

                if (cur_sum == s)
                {
                    minLen = Math.Min(minLen, i - start);
                }
            }

            return minLen == Int32.MaxValue ? 0 : minLen;
        }

        #region reconstruct tree
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val)
            {
                this.val = val;
            }
        }

        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            Dictionary<int, int> indexes = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                indexes.Add(inorder[i], i);
            }

            TreeNode root = BuildHelper(preorder, 0, inorder, 0, inorder.Length, indexes);
            return root;
        }

        public static TreeNode BuildHelper(int[] preorder, int preStart, int[] inorder, int inStart, int inEnd, Dictionary<int, int> cache)
        {
            if (preStart >= preorder.Length || inStart > inEnd) return null;

            int rootVal = preorder[preStart];
            int rootIdx = cache[rootVal];
            TreeNode root = new TreeNode(rootVal);
            root.left = BuildHelper(preorder, preStart + 1, inorder, inStart, rootIdx - 1, cache);
            root.right = BuildHelper(preorder, preStart + rootIdx - inStart + 1, inorder, rootIdx + 1, inEnd, cache);

            return root;

        }
        #endregion

        #region post to in
        public static TreeNode BuildTreePostToIn(int[] inorder, int[] postorder)
        {
            Dictionary<int, int> indexes = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                indexes.Add(inorder[i], i);
            }

            TreeNode root = BuildTreePostToInHelper(postorder, 0, postorder.Length - 1, inorder, 0, inorder.Length - 1, indexes);
            return root;
        }

        public static TreeNode BuildTreePostToInHelper(int[] postorder, int p_s, int p_e, int[] inorder, int in_s, int in_e, Dictionary<int, int> cache)
        {
            if (p_s > p_e || in_s > in_e) return null;

            int rootVal = postorder[p_e];
            int rootIdx = cache[rootVal];
            TreeNode root = new TreeNode(rootVal);
            root.left = BuildTreePostToInHelper(postorder, p_s, p_s + rootIdx - in_s - 1, inorder, in_s, rootIdx - 1, cache);
            root.right = BuildTreePostToInHelper(postorder, p_s + rootIdx - in_s, p_e - 1, inorder, rootIdx + 1, in_e, cache);

            return root;

        }
        #endregion

        /// <summary>
        /// https://leetcode.com/problems/longest-consecutive-sequence/
        /// </summary>
        public static int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0) return 0;
            HashSet<int> visited = new HashSet<int>();
            foreach (int val in nums) visited.Add(val);
            int maxSum = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                int sum = 1;
                int val = nums[i];
                while (visited.Remove(val - 1))
                {
                    val--;
                }

                sum += nums[i] - val;

                val = nums[i];
                while (visited.Remove(val + 1)) val++;

                sum += val - nums[i];

                maxSum = Math.Max(maxSum, sum);
            }

            return maxSum;
        }

        // Definition for singly-linked list with a random pointer.
        public class RandomListNode
        {
            public int label;
            public RandomListNode next, random;
            public RandomListNode(int x) { this.label = x; }
        }

        public static RandomListNode CopyRandomList(RandomListNode head)
        {
            if (head == null) return null;
            RandomListNode cur = head;
            while (cur != null)
            {
                RandomListNode n = new RandomListNode(cur.label);
                n.next = cur.next;
                cur.next = n;
                cur = n.next;
            }

            cur = head;
            while (cur != null && cur.next != null)
            {
                cur.next.random = cur.random == null ? null : cur.random.next;
                cur = cur.next.next;
            }

            RandomListNode newHead = head.next;
            cur = head;
            var cur2 = newHead;

            while (cur != null && cur2 != null)
            {
                cur.next = cur2.next;
                cur = cur.next;

                cur2.next = cur == null? null : cur.next;
                cur2 = cur2.next;
            }

            return newHead;
        }

        /// <summary>
        /// https://leetcode.com/problems/multiply-strings/
        /// </summary>
        public static string Multiply(string num1, string num2)
        {
            if (string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2)) return string.Empty;

            int len1 = num1.Length, len2 = num2.Length;

            // Reverse strings to make it easier to multiply
            num1 = new string(num1.Reverse().ToArray());
            num2 = new string(num2.Reverse().ToArray());

            int[] output = new int[len1 + len2];

            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    output[i + j] += (num1[i] - '0') * (num2[j] - '0');
                    output[i + j + 1] += output[i + j] / 10;
                    output[i + j] = output[i + j] % 10;
                }
            }

            int index = len1 + len2 - 1;
            for (; output[index] == 0 && index > 0; index--) { }

            StringBuilder sb = new StringBuilder();

            for (; index >= 0; index--)
            {
                sb.Append(output[index]);
            }

            return sb.Length == 0? "0" :sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public static string SimplifyPath(string path)
        {
            if (string.IsNullOrEmpty(path)) return string.Empty;

            Stack<string> s = new Stack<string>();
            Stack<string> res = new Stack<string>();

            var splitPaths = path.Split('/').Where(str => !string.IsNullOrEmpty(str));

            foreach (string name in splitPaths)
            {
                if (name.Equals(".."))
                {
                    if (s.Count != 0)
                    {
                        s.Pop();
                    }
                }
                else if(!name.Equals("."))
                {
                    s.Push(name);
                }
            }

            StringBuilder sb = new StringBuilder();

            if (s.Count == 0)
            {
                sb.Append('/');
                return sb.ToString();
            }

            while (s.Count != 0)
            {
                res.Push(s.Pop());
            }

            while (res.Count != 0)
            {
                sb.Append("/").Append(res.Pop());
            }
            return sb.ToString();
        }

        public static char FindTheDifference(string s, string t)
        {
            if (string.IsNullOrEmpty(s)) return ' ';

            int[] counts = new int[26];

            foreach (char c in s)
            {
                counts[c - 'a']++;
            }

            foreach (char c in t)
            {
                counts[c - 'a']--;
            }

            for (int i = 0; i < 26; i++)
            {
                if (counts[i] == -1)
                {
                    return Convert.ToChar(i + 'a');
                }
            }

            return ' ';
        }

        /// <summary>
        /// https://leetcode.com/problems/longest-increasing-path-in-a-matrix/
        /// </summary>
        public static int LongestIncreasingPath(int[,] matrix)
        {
            if (matrix.GetLength(0) == 0) return 0;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int maxLen = 0;

            int[,] cache = new int[rows, cols];
            bool[,] visited = new bool[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int maxVal = LongestIncreasingPathHelper(i, j, rows, cols, matrix, cache, visited, Int32.MinValue);
                    maxLen = Math.Max(maxLen, maxVal);
                }
            }

            return maxLen;
        }

        private static int LongestIncreasingPathHelper(int row, int col, int rows, int cols, int[,] matrix, int[,] cache, bool[,] visited, int previousVal)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols || matrix[row, col] <= previousVal || visited[row, col]) return 0;

            if (cache[row, col] > 0) return cache[row, col];

            int current = matrix[row, col];
            int tempMax = 0;

            visited[row, col] = true;
            tempMax = Math.Max(tempMax, 1 + LongestIncreasingPathHelper(row - 1, col, rows, cols, matrix, cache, visited, current));
            tempMax = Math.Max(tempMax, 1 + LongestIncreasingPathHelper(row + 1, col, rows, cols, matrix, cache, visited, current));
            tempMax = Math.Max(tempMax, 1 + LongestIncreasingPathHelper(row, col - 1, rows, cols, matrix, cache, visited, current));
            tempMax = Math.Max(tempMax, 1 + LongestIncreasingPathHelper(row, col + 1, rows, cols, matrix, cache, visited, current));
            visited[row, col] = false;

            cache[row, col] = tempMax;
            return tempMax;
        }

        public static bool CanStringBePalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            int unpairedCount = 0;

            Dictionary<char, int> occurrences = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (occurrences.ContainsKey(c))
                {
                    occurrences[c] = occurrences[c] + 1;
                }
                else
                {
                    occurrences.Add(c, 1);
                }
            }

            foreach (var value in occurrences.Values)
            {
                if ((value & 1) != 0)
                {
                    if (unpairedCount == 1) return false;
                    unpairedCount++;
                }
            }

            return true;
        }

        public static bool IsNumber(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            int decimalCount = 0;
            bool numberBefore = false;
            string res = s.Trim();
            res = res[0] == '-' ? res.Substring(1) : res;

            foreach (char c in res)
            {
                if (c == '.')
                {
                    decimalCount++;
                    if (decimalCount > 1) return false;
                }
                else if (isValidNumChar(c))
                {
                    if (!numberBefore) return false;
                }
                else if (isValidNum(c))
                {
                    numberBefore = true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isValidNum(char c)
        {
            return ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'));
        }

        private static bool isValidNumChar(char c)
        {
            return ((c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'));
        }


        /// <summary>
        /// https://leetcode.com/problems/is-subsequence/?tab=Description
        /// This can be solved using dynamic programming, but that is not 
        /// really needed and is also memory overkill. We can just use two pointers and increment the
        /// s pointer when a character match happens in t and s. If we have not 
        /// gone through s when the t loop is done, return false. Else true.
        /// </summary>
        public static bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(t)) { return string.IsNullOrEmpty(s); }
            if (string.IsNullOrEmpty(s)) return true;
            int slen = s.Length;
            int tlen = t.Length;
            int sIter = 0;
            for (int i = 0; i < tlen; i++)
            {
                if (t[i] == s[sIter])
                {
                    sIter++;
                }

                if (sIter == slen) return true;
            }
            return false;
        }
    }
}
