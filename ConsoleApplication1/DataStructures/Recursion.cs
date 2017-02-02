using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
    public class Recursion
    {
        #region Parenthesis
        public static List<string> GenerateParanthesis(int numPairs)
        {
            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
            GenerateParamsHelper(2 * numPairs, 0, result, sb);
            return result;
        }

        public static void GenerateParamsHelper(int remainingChars, int leftParens, List<string> result, StringBuilder sb)
        {
            if (remainingChars == 0)
            {
                result.Add(sb.ToString());
                return;
            }

            if (leftParens < remainingChars)
            {
                sb.Append('(');
                GenerateParamsHelper(remainingChars - 1, leftParens + 1, result, sb);
                sb.Length--;
            }

            if (leftParens > 0)
            {
                sb.Append(')');
                GenerateParamsHelper(remainingChars - 1, leftParens - 1, result, sb);
                sb.Length--;
            }
        }
        #endregion

        #region combinationsum
        public static List<List<int>> CombinationSum3(int k, int n)
        {
            List<List<int>> result = new List<List<int>>();
            List<int> validCombo = new List<int>();
            CombinationSumHelper(validCombo, result, 1, k, n);
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
        #endregion

        #region generateIpAddresses
        public static void generateIPAddresses(string input)
        {
            if (input.Length < 4)
            {
                Console.WriteLine("RIGITED");
                return;
            }

            StringBuilder sb = new StringBuilder(input);
            generateIpHelper(sb, 0);
        }

        public static void generateIpHelper(StringBuilder sb, int segments)
        {
            if (segments == 3)
            {
                if (isValidIp(sb.ToString()))
                {
                    Console.WriteLine(sb.ToString());
                    return;
                }
            }

            int lastDot = sb.ToString().LastIndexOf('.');

            for (int i = 2; i <= 4 && lastDot + i < sb.Length; i++)
            {
                sb.Insert(lastDot + i, '.');
                generateIpHelper(sb, segments + 1);
                sb.Remove(lastDot + i, 1);
            }
        }


        public static bool isValidIp(string input)
        {
            string pattern = "^([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\." +
                             "([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\." +
                             "([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\." +
                             "([01]?\\d\\d?|2[0-4]\\d|25[0-5])$";
            Regex ip = new Regex(pattern);
            MatchCollection result = ip.Matches(input);
            return result.Count > 0;
        }
        #endregion

        #region maximal word partition
        /// <summary>
        /// Given a word and a dictionary of valid words, find
        /// the maximal number of word partitions possible
        /// .. "fireman" can be split into
        /// ..."fire", "man"
        /// ..."fireman"
        /// .. so the maximal partition for fireman is 2
        /// </summary>
        public static int maxWordPartition(string input, HashSet<string> dictionary)
        {
            int partitionCount = 0;

            if (string.IsNullOrEmpty(input)) return 0;
            partitionCountHelper(input, dictionary, ref partitionCount);
            return partitionCount;
        }

        private static void partitionCountHelper(string input, HashSet<string> dictionary, ref int count)
        {
            if (input.Length == 0)
            {
                count++;
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                string first = input.Substring(0, i+1);
                if (dictionary.Contains(first))
                {
                    string rest = input.Substring(i+1);
                    partitionCountHelper(rest, dictionary, ref count);
                }
            }
        }
        #endregion

        #region list all subsets
        public static List<List<int>> subsets(int[] input)
        {
            return subsetsHelper(input, 0);
        }

        private static List<List<int>> subsetsHelper(int[] input, int index)
        {
            List<List<int>> result = new List<List<int>>();
            if (index == input.Length)
            {
                result.Add(new List<int>());
                return result;
            }

            int val = input[index];

            result = subsetsHelper(input, index + 1);
            List<List<int>> more = new List<List<int>>();
            foreach (var entry in result)
            {
                List<int> newEntry = new List<int>();
                newEntry.AddRange(new List<int>(entry));
                newEntry.Add(val);
                more.Add(new List<int>(newEntry));
            }
            result.AddRange(more);
            return result;
        }
        #endregion
    }
}
