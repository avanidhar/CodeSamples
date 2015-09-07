using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class HackerRank
	{
		public static void UtopianTree()
		{
			int numCases = Convert.ToInt32(Console.ReadLine());
			int[] testCases = new int[numCases];
			int i = 0;
			for (i = 0; i < numCases; i++)
			{
				testCases[i] = Convert.ToInt32(Console.ReadLine());
			}
			foreach (int testCase in testCases)
			{
				int height = 1;
				if (testCase == 0) Console.WriteLine(height);
				else
				{
					for (int j = 1; j <= testCase; j++)
					{
						if (j % 2 == 0)
						{
							height = height + 1;
						}
						else
						{
							height = height * 2;
						}
					}
					Console.WriteLine(height);
				}
			}
		}

		public static void LaneInfo()
		{
			string firstLine = Console.ReadLine();
			int freewayLength = Convert.ToInt32(firstLine.Split(' ')[0]);
			int numCases = Convert.ToInt32(firstLine.Split(' ')[1]);
			int[] widths = new int[freewayLength];
			widths = Console.ReadLine().Split(' ').Select(item => Convert.ToInt32(item)).ToArray();
			List<string> testCases = new List<string>();
			for (int i = 0; i < numCases; i++)
			{
				testCases.Add(Console.ReadLine());
			}
			foreach (string testcase in testCases)
			{
				int start = Convert.ToInt32(testcase.Split(' ')[0]);
				int end = Convert.ToInt32(testcase.Split(' ')[1]);
				int minWidth = widths[start];
				for (int i = start + 1; i <= end; i++)
				{
					if (widths[i] < minWidth)
					{
						minWidth = widths[i];
					}
				}
				Console.WriteLine(minWidth);
			}
		}

		public static void MakePalindrome()
		{
			int numCases = Convert.ToInt32(Console.ReadLine());
			List<string> values = new List<string>();
			for (int i = 0; i < numCases; i++)
			{
				values.Add(Console.ReadLine());
			}

			foreach (string value in values)
			{
				char[] array = value.ToCharArray();
				int numChanges = 0;
				int i, j;
				for (i = 0, j = array.Length - 1; i < j; i++, j--)
				{
					numChanges = numChanges + Math.Abs(array[i] - array[j]);
				}
				Console.WriteLine(numChanges);
			}
		}

		public static void ChocolateCuts()
		{
			int numCases = Convert.ToInt32(Console.ReadLine());
			List<Int64> values = new List<Int64>();
			for (int i = 0; i < numCases; i++)
			{
				values.Add(Convert.ToInt64(Console.ReadLine()));
			}

			foreach (int cuts in values)
			{
				{
					Int64 one = cuts / 2;
					Int64 two = one * (cuts - one);
					Console.WriteLine(two);
				}

			}
		}

		public static void GemRocks()
		{
			int numCases = Convert.ToInt32(Console.ReadLine());
			List<string> values = new List<string>();
			for (int i = 0; i < numCases; i++)
			{
				values.Add(Console.ReadLine());
			}

			int[] count = new int[256];
			foreach (string rock in values)
			{
				foreach (char c in rock.Distinct())
				{
					count[c]++;
				}
			}
			int commonElements = (from element in count
								  where element == numCases
								  select element).Count();
			Console.WriteLine(commonElements);
		}

		public static void Maxor()
		{

			int l = Convert.ToInt32(Console.ReadLine());
			int r = Convert.ToInt32(Console.ReadLine());

			List<int> xorVals = new List<int>();
			while (l <= r)
			{
				for (int i = l; i <= r; i++)
				{
					int result = l ^ i;
					if (!xorVals.Contains(result))
					{
						xorVals.Add(result);
					}
				}
				l++;
			}
			Console.WriteLine(xorVals.Max());
		}

		public static void WeirdGame()
		{

			int numTests = Convert.ToInt32(Console.ReadLine());
			List<ulong> Counters = new List<ulong>();
			for (int i = 0; i < numTests; i++)
			{
				Counters.Add(Convert.ToUInt64(Console.ReadLine()));
			}

			for (int i = 0; i < Counters.Count; i++)
			{
				int turns = 0;
				ulong counter = Counters[i];
				if (counter == 1)
				{
					Console.WriteLine("Richard");
				}
				while (counter != 1)
				{
					if (((counter & (counter - 1)) == 0) && (counter != 0))
					{
						counter = counter >> 1;
					}
					else
					{
						ulong lowestPowerofTwo = (ulong)(0x0000000000000001 << (int)Math.Log(counter, 2));
						counter = counter - lowestPowerofTwo;
					}
					turns++;
				}
				if (turns % 2 == 0)
				{
					Console.WriteLine("Richard");
				}
				else
				{
					Console.WriteLine("Louise");
				}
			}

		}

		public static void MakeAnagram()
		{
			int numTests = Convert.ToInt32(Console.ReadLine());
			List<string> strings = new List<string>();
			for (int i = 0; i < numTests; i++)
			{
				strings.Add(Console.ReadLine());
			}

			foreach (string testCase in strings)
			{

				char[] left = testCase.Substring(0, testCase.Length / 2).ToCharArray();
				Array.Sort(left);
				char[] right = testCase.Remove(0, testCase.Length / 2).ToCharArray();
				Array.Sort(right);
				int diff = 0;
				if (testCase.Length % 2 != 0)
				{
					Console.WriteLine(-1);
				}
				else if (left.SequenceEqual(right))
				{
					Console.WriteLine(0);
				}
				else
				{
					for (int j = 0; j < left.Count(); j++)
					{
						diff++;
					}

					Console.WriteLine(diff);
				}

			}
		}

		public static void PalindromeIndex()
		{
			int numTests = Convert.ToInt32(Console.ReadLine());
			List<string> strings = new List<string>();
			for (int i = 0; i < numTests; i++)
			{
				strings.Add(Console.ReadLine());
			}

			foreach (string testCase in strings)
			{
				int i = 0, j = testCase.Length - 1;
				int index = 0;
				while (i < j)
				{
					if (testCase[i] != testCase[j])
					{
						if (testCase[i] == testCase[j - 1])
						{
							index = j;
							break;
						}
						else if (testCase[i + 1] == testCase[j])
						{
							index = i;
							break;
						}
					}
					else
					{
						i++; j--;
					}
				}
				Console.WriteLine(index);
			}
		}

		public static void FindIndex()
		{
			int value = Convert.ToInt32(Console.ReadLine());
			int size = Convert.ToInt32(Console.ReadLine());
			int[] arr = Console.ReadLine().Split(' ').Select(item => Convert.ToInt32(item)).ToArray();
			if (arr.Length != size)
			{
				Console.WriteLine("Something went wrong");
			}
			for (int i = 0; i < size; i++)
			{
				if (arr[i] == value)
				{
					Console.WriteLine(i);
				}
			}
		}

		public static void Pangram()
		{
			string input = Console.ReadLine();
			input = input.ToLower();
			int[] counts = new int[26];
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] == ' ')
				{
					continue;
				}
				else
				{
					counts[input[i] - 'a']++;
				}
			}
			bool pangram = counts.All(item => item > 0);
			if (pangram)
			{
				Console.WriteLine("pangram");
			}
			else
			{
				Console.WriteLine("not pangram");
			}
		}
	}
}
