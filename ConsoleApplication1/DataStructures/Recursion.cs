using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
    public class Recursion
    {
        public static List<string> GenerateParanthesis(int numPairs) {
            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
            GenerateParamsHelper(2 * numPairs, 0, result, sb);
            return result;
        }

        public static void GenerateParamsHelper(int remainingChars, int leftParens, List<string> result, StringBuilder sb)
        {
            if (remainingChars == 0) {
                result.Add(sb.ToString());
                return;
            }

            if (leftParens < remainingChars) {
                sb.Append('(');
                GenerateParamsHelper(remainingChars - 1, leftParens + 1, result, sb);
                sb.Length--;
            }

            if (leftParens > 0) {
                sb.Append(')');
                GenerateParamsHelper(remainingChars - 1, leftParens - 1, result, sb);
                sb.Length--;
            }
        }

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
    }
}
