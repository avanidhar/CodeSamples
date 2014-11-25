using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class Integers
	{
		public static int MthLargest(int[] a, int[] b, int m) 
		{
			if (m > a.Length + b.Length) 
			{
				return int.MinValue;
			}

			int l1 = a.Length, l2 = b.Length;
			int i = l1 - 1, j = l2 - 1;
			int max = int.MinValue;
			int counter = 0;

			while ((i >= 0) && (j >= 0)&&(counter<m)) 
			{
				if (a[i] > b[j]) 
				{
					max = a[i];
					i--;
				}
				else if (a[i] < b[j])
				{
					max = b[j];
					j--;
				}
				else 
				{
					max = a[i];
					i--; j--;
				}
				counter++;
			}

			while (i >= 0 && counter < m) 
			{
				max = a[i];
				counter++;
				i--;
			}

			while (j >= 0 && counter < m)
			{
				max = b[j];
				counter++;
				j--;
			}

			return max;

		}
	}
}
