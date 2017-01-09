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
    }
}
