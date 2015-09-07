using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class Euler
	{
		public static long MultiplesOfThreeOrFive(int n)
		{
			long sum = 0;
			for (int i = 1; i < n; i++) 
			{
				if (i % 15 == 0) 
				{
					sum += i;
				}
				else if (i % 3 == 0 || i % 5 == 0)
				{
					sum += i;
				}
			}
			return sum;
		}

		public static long LargestPalindromeProduct()
		{
			long maxSum = 0;
			for (int i = 999; i >= 100; i--) 
			{
				for (int j = 999; j >= 100; j--)
				{
					long mul = i * j;
					if(IsPalinDrome(mul))
					{
						maxSum = Math.Max(maxSum, mul);
					}
				}
			}

			return maxSum;
		}

		public static bool IsPalinDrome(long n) 
		{
			string strep = n.ToString();
			char[] strep2 = strep.ToCharArray();
			Array.Reverse(strep2);
			string strep3 = new string(strep2);

			return strep.Equals(strep3);
		}

		public static long EvenlyDivisible() 
		{
			long sum = 0;
			for (int i = 1; i <= 100; i++) 
			{
				sum += i*i;
			}

			return sum;
		}
	}
}
