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
    }
}
