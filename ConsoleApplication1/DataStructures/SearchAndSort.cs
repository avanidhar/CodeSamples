using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class SearchAndSort
	{
		public static int BinarySearch(int [] a, int num) 
		{
			int low = 0, high = a.Count();
			
			if (low > high) return -1;

			while (low <= high) 
			{
				int mid = (high + low) / 2;
				if (num < a[mid]) 
				{
					high = mid - 1;
				}
				else if (num > a[mid])
				{
					low = mid + 1;
				}
				else 
				{
					return mid;
				}
			}
			return -1;
		}

		public static void MergeSort(int[] a, int low, int high) 
		{
			if (low < high) 
			{
				int mid = low + high / 2;
				MergeSort(a, low, mid);
				MergeSort(a, mid + 1, high);
				Merge(a, low, mid, high);
			}
		}

		public static void Merge(int[] a, int low, int mid, int high) 
		{
			int[] left = a.ToList().GetRange(0, mid).ToArray();
			int[] right = a.ToList().GetRange(left.Length, high-mid-1).ToArray();

			int leftLength = left.Length, rightLength = right.Length;
			int counter = 0, i =0, j=0;
			for(counter =low;counter<high;counter++)
			{
				if (left[i] < right[j]) 
				{
					a[counter] = left[i];
					i++;
				}
				else if (left[i] > right[j]) 
				{
					a[counter] = right[j];
					j++;
				}
			}
		}

		public static void QuickSort(int[] a, int low, int high)
		{
			if (low < high)
			{
				int pivot = partition(a, low, high);
				QuickSort(a, low, pivot - 1);
				QuickSort(a, pivot + 1, high);
			}
		}

		/// <summary>
		/// Partition the array to sort
		/// </summary>
		/// <param name="a"></param>
		/// <param name="low"></param>
		/// <param name="high"></param>
		/// <returns></returns>
		public static int partition(int[] a, int low, int high) 
		{
			int i = low;
			int pivot = a[high];
			for(int j = low; j < high; j++)
			{
				if (a[j] <= pivot) 
				{
					int temp = a[i];
					a[i] = a[j];
					a[j] = temp;
					i++;
				}
				
			}
			int temp2 = a[i];
			a[i] = a[high];
			a[high] = temp2;
			return i;
		}

		/// <summary>
		/// This is the code to find the kth smallest element. If you need to find the 
		/// kth largest element, change the partition to check for greater than instead of less than
		/// </summary>
		/// <param name="ar"></param>
		/// <param name="k"></param>
		/// <returns></returns>
		public static int FindKthSmallestElement(int[] ar, int k) 
		{
			int l =0, h = ar.Length-1;
			int index = partition(ar, l, h);
			if (index == k-1) return ar[index];
			else if (index < k-1) 
			{
				return ar[partition(ar, index + 1, h)];
			}
			else if (index > k-1) 
			{
				return ar[partition(ar, l, index -1)];
			}
			return -1;
		}
		public static void InsertionSort(int[] a)
		{
			int length = a.Length;
			int i = 0;
			for (i = 0; i < length; i++) 
			{
				int j = i;
				while((j > 0)&&(a[j] < a[j-1]))
				{
					int temp = a[j];
					a[j] = a[j-1];
					a[j-1] = temp;
					j--;
				}
			}
		}

		/// <summary>
		/// Method to find the largest contiguous sum in an array
		/// </summary>
		/// <param name="a"></param>
		/// <param name="l"></param>
		/// <param name="h"></param>
		/// <returns></returns>
		public static int MaximumSum(int[] a, int l, int h) 
		{
			if (l > h) return 0;
			if (l == h) return a[l];
			int sum;
			int m = (l + h) / 2;
			int lMax = sum = 0;
			for (int i = m; i >= l; i--) 
			{
				sum += a[i];
				lMax = Math.Max(lMax, sum);
			}

			int rMax = sum = 0;
			for (int j = m + 1; j <= h; j++) 
			{
				sum += a[j];
				rMax = Math.Max(rMax, sum);
			}

			return Math.Max(lMax + rMax, Math.Max(MaximumSum(a, l, m), MaximumSum(a, m + 1, h)));
		}

		public static int MaximumSum2(int[] a) 
		{
			int maxSoFar = 0, maxSum = 0;
			for (int i = 0; i < a.Length; i++) 
			{
				maxSoFar = Math.Max(0, maxSoFar + a[i]);
				maxSum = Math.Max(maxSum, maxSoFar);
			}

			return maxSum;
		}
	}
}
