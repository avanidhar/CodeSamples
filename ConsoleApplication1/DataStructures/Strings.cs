using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class Strings
	{
		public static void ColumnIdToInteger(string s) 
		{
			int result = 0;
			foreach (char c in s.ToCharArray()) 
			{
				result = result * 26 + c - 'A' + 1;
			}
			Console.WriteLine(result);
		}

        public static string IntegerToColumnId(int number)
        {
            StringBuilder sb = new StringBuilder();
            while (number > 0) 
            {
                number--;
                char c = (char)((number)%26 + 'A');
                number = number / 26;
                sb.Append(c);
            }

            char[] a = sb.ToString().ToCharArray();
            Array.Reverse(a);
            return new string(a);
        }
		public static Result SolveMasterMind(string guess, string solution) 
		{
			if (guess.Length != solution.Length) 
			{
				return null;
			}

			Result result = new Result();
			int hits = 0, pHits = 0;
			int[] frequency = new int[4];

			for (int i = 0; i < solution.Length; i++) 
			{
				if (guess[i] == solution[i])
				{
					hits++;
				}
				else 
				{
					frequency[Code(solution[i])]++;
				}
			}

			for (int j = 0; j < guess.Length; j++) 
			{
				int code = Code(guess[j]);

				if (code >= 0 && frequency[code] > 0 && guess[j] != solution[j]) 
				{
					pHits++;
					frequency[code]--;
				}
			}

			result.hits = hits;
			result.pesudoHits = pHits;
			return result;	
		}

		public static int Code(char c) 
		{
			switch (c) 
			{
				case 'B':
					return 0;
				case 'G':
					return 1;
				case 'R':
					return 2;
				case 'Y':
					return 3;
				default:
					return -1;
			}
		}

		public class Result 
		{
			public int hits = 0;
			public int pesudoHits = 0;
		}

		public static void PhoneNumberToWords(string phoneNumber) 
		{
			StringBuilder sb = new StringBuilder();
			List<string> results = new List<string>();
			PhoneNumberHelper(phoneNumber, 0, results, sb);
			foreach (string result in results) 
			{
				Console.WriteLine(result);
			}
		}

		protected static void PhoneNumberHelper(string phoneNumber, int charIndex, List<string> result, StringBuilder sb)
		{
			if (charIndex == phoneNumber.Length) 
			{
				result.Add(sb.ToString());
				return;
			}

			char digit = phoneNumber[charIndex];
			string characterString = phoneLookup[digit];

			foreach (char c in characterString) 
			{
				sb.Append(c);
				PhoneNumberHelper(phoneNumber, charIndex + 1, result, sb);
				sb.Length--;
			}

		}

		public static void SplitString()
		{
			StringBuilder sb = new StringBuilder();

			List<string> sampleList = new List<string> { "peanut", "home", "work", "homework", "random", "seattle" };
			Trie mySimpleTrie = new Trie(sampleList);
			
			string stringWithoutSpaces = "randomhomework";

			int startingIndex = 0;
			for (int i = 0; i < stringWithoutSpaces.Length; i++) 
			{
				string subStr = stringWithoutSpaces.Substring(startingIndex, i-startingIndex + 1);
				if(mySimpleTrie.ContainsWord(subStr))
				{
					sb.Append(subStr).Append(' ');
					startingIndex = i + 1;
				}
			}

			Console.WriteLine(sb.ToString());
		}

		public static int EditDistance(string s, string t) 
		{
			int m = s.Length;
			int n = t.Length;

			int[,] E = new int[m+1, n+1];
			int i=0;
			for (i = 0; i <= m; i++) {
				E[i, 0] = i;
			}

			for (i = 0; i <= n; i++) {
				E[0, i] = i;
			}

			for (i = 1; i <= m; i++) 
			{
				for (int j = 1; j <= n; j++) 
				{
					if (s[i - 1] == t[j - 1]) E[i, j] = E[i - 1, j - 1];
					else 
					{
						E[i, j] = 1 + Math.Min(E[i - 1, j - 1], Math.Min(E[i - 1, j], E[i, j - 1]));
					}
				}
			}

			return E[m, n];
		}

		public static void LongestIncreasingSubarray(int[] a) 
		{
			int maxsofar = 0, maxendinghere = 0;
			int startIndex = 0, endindex = 0;
			for (int i = 1; i < a.Length; i++) 
			{
				if (a[i] > a[i - 1])
				{
					maxendinghere += 1;
					endindex = i;
				}
				else 
				{
					maxendinghere = 1;
				}
				maxsofar = Math.Max(maxsofar, maxendinghere);
			}
			Console.WriteLine(maxsofar + "" + startIndex + "" + endindex);

		}

		public static string ReverseString(string s) 
		{
			if (string.IsNullOrEmpty(s)) 
			{
				return string.Empty;
			}

			s.Reverse();

			StringBuilder sb = new StringBuilder();

			foreach (string str in s.Split(' ')) 
			{
				sb.Append(str.Reverse()).Append(' ');
			}

			return sb.ToString();
		}

		static Dictionary<char, string> phoneLookup = new Dictionary<char, string>() 
		{
			{'0', "0"},
			{'1', "1"},
			{ '2', "ABC"},
			{'3', "DEF"},
			{'4', "GHI"},
			{'5', "JKL"},
			{'6', "MNO"},
			{'7', "PQRS"},
			{'8', "TUV"},
			{'9', "WXYZ"}
		};

		public static int LongestCommonSubsequence(string s, string t) 
		{
			if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return 0;

			int m = s.Length;
			int n = t.Length;

			int[,] LCS = new int[m + 1, n + 1];
			int i,j;
			for (i = 0; i <= m; i++) 
			{
				LCS[i, 0] = 0;
			}

			for (j = 0; j <= n; j++)
			{
				LCS[0, j] = 0;
			}

			for (i = 0; i < m; i++) 
			{
				for (j = 0; j < n; j++) 
				{
					if (s[i] == t[j]) 
					{
						LCS[i+1, j+1] = LCS[i, j] + 1;
					}

					else 
					{
						LCS[i+1, j+1] = Math.Max(LCS[i, j+1], LCS[i+1, j]);
					}
				}
			}

			return LCS[m, n];
		}

		public static int StringMatchKMP(string input, string pattern) 
		{
			return 0;
		}

		public static int[] ComputeKMPPrefix(string pattern) 
		{
			int[] prefixArray = new int[pattern.Length];
			prefixArray[0] = 0;
			int k = 0;
			int i= 1;
			while (i < pattern.Length) 
			{
				if (pattern[i] == pattern[k])
				{
					prefixArray[i] = ++k;
				}
				else 
				{
					prefixArray[i] = 0;
				}
				i++;
			}

			return prefixArray;
		}

		public static void PrintMaxFreqString(string input)
		{
			if (string.IsNullOrEmpty(input)) 
			{
				Console.Write("Empty string");
			}

			input = input.ToLowerInvariant();

			int[] countArr = new int[26];
			int max = int.MinValue;

			foreach (char c in input) 
			{
				if (c >= 'a' && c <= 'z') 
				{
					countArr[c - 'a']++;
					max = Math.Max(max, countArr[c - 'a']);
				}
			}

			for (int i = 0; i < 26; i++) 
			{
				if (countArr[i] == max) 
				{
					Console.WriteLine(Convert.ToChar('a' + i));
				}
			}
		}

		// Checks if a set of parentheses are valid ie each closing brace is preceded by an opening 
		// brace in the right order
		public static bool ParenMatching(string parenString) 
		{
			List<char> open = new List<char> {'{','(','[' };
			List<char> close = new List<char> { '}', ')', ']' };
			
			Stack<char> parenStack = new Stack<char>();

			for (int i = 0; i < parenString.Length; i++) 
			{
				if (open.Contains(parenString[i])) 
				{
					parenStack.Push(parenString[i]);
				}
				else if (close.Contains(parenString[i])) 
				{
					if (parenStack.Count == 0) 
					{
						return false;
					}

					if (parenStack.Pop() != open[close.IndexOf(parenString[i])]) 
					{
						return false;
					}
				}
			}

			return parenStack.Count == 0;
		}

        // This is similar to adding two linked lists
        public static string AddBinary(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1)) return s2;
            if (string.IsNullOrEmpty(s2)) return s1;

            StringBuilder sb = new StringBuilder();
            int len1 = s1.Length - 1, len2 = s2.Length - 1;

            int carry = 0;

            while (len1 >= 0 || len2 >= 0)
            {
                int sum = carry;

                if (len1 >= 0)
                {
                    sum += s1[len1] - '0';
                    len1--;
                }

                if (len2 >= 0)
                {
                    sum += s2[len2] - '0';
                    len2--;
                }

                carry = sum / 2;
                sum = sum % 2;

                sb.Append(sum);
            }

            if (carry == 1)
            {
                sb.Append('1');
            }

            return sb.ToString();
        }
	}
}
