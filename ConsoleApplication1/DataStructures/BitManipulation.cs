using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	public class BitManipulation 
	{
		public static bool IsPowerOfTwo(int n) 
		{
			return ((n & (n - 1))==0);
		}

		public static int GetBit(int n, int i)
		{
			return (n & (1 << i)) != 0 ? 1 : 0;
		}

		public static ulong SameWeightClosestInt(ulong x)
		{
			for (int i = 0; i < 63; i++) 
			{
				if ((((x >> i) & 1) ^ ((x >> (i + 1))&1)) != 0)
				{
					x ^= (1UL << i) | (1UL << (i + 1));
				}
			}
			return x;
		}
	}
}
