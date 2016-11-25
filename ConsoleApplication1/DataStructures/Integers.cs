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

		public static bool isPalindrome(long n) 
		{
			if (n < 0) return false;
			long divisor = 10;
			while (n / divisor > 10) 
			{
				divisor *= 10;
			}

			while (n != 0) 
			{
				long left = n / divisor;
				long right = n % 10;
				if (left != right) 
				{
					return false;
				}

				n = (n % divisor) / 10;
				divisor /= 100;
			}

			return true;
		}

		public static int squareRoot(int n) 
		{
			if (n < 0) return -1;
			if (n == 0 || n == 1) return n;

			int l = 0, r = n;

			while (l <= r) 
			{
				int mid = l + (r - l) / 2;
				long midSquare = mid * mid;

				if (midSquare == n) 
				{
					return mid;
				}
				else if (midSquare < n)
				{
					l = mid + 1;
				}
				else 
				{
					r = mid - 1;
				}
			}
			return l - 1;
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

		public static int LargestInMonotonicArray(int[] arr, int low, int high)
		{
			if (low > high) return -1;

			while (low <= high)
			{
				int mid = (low + high) / 2;
				if ((arr[mid - 1] < arr[mid]) && arr[mid] > arr[mid + 1])
				{
					return arr[mid];
				}
				else if (arr[mid - 1] < arr[mid] && arr[mid] < arr[mid + 1])
				{
					low = mid + 1;
				}
				else if (arr[mid - 1] > arr[mid] && arr[mid] > arr[mid + 1])
				{
					high = mid - 1;
				}
			}
			return -1;
		}

        /// <summary>
        /// Find the number of occurrences of an integer in a sorted array
        /// Approach : Find the first occurrence. Find the last. Diff + 1
        /// </summary>
        /// <param name="input"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int numTimes(int[] input, int n) {
            if (input.Length == 0) return 0;
            int len = input.Length;
            int first = findFirst(input, 0, len - 1, n);
            if (first == -1) return 0;
            int last = findLast(input, 0, len - 1, n);
            return last - first + 1;
        }

        public static int findFirst(int[] input, int low, int high, int n) {

            while (low <= high) {
                int mid = low + (high - low) / 2;
                if (input[mid] == n && input[mid] > input[mid - 1])
                {
                    return mid;
                }
                else if (input[mid] < n)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
                
            }
            return -1;
        }

        public static int findLast(int[] input, int low, int high, int n) {
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (input[mid] == n && input[mid] < input[mid+1])
                {
                    return mid;
                }
                else if (input[mid] > n)
                {
                    high = mid -1;
                }
                else 
                {
                    low = mid + 1;
                }

            }
            return -1;
        }

        public static int[] IncrementNumber(int[] num)
        {
            if (num == null || num.Length == 0) return num;

            int len = num.Length - 1;
            int sum = 0, carry = 0;

            while (len >= 0)
            {
                sum = len == num.Length -1 ? 
                    num[len] + carry + 1 : num[len] + carry;
                carry = sum / 10;
                sum = sum % 10;
                num[len] = sum;
                len--;
            }

            if (carry > 0)
            {
                int[] result = new int[num.Length + 1];
                result[0] = carry;
                num.CopyTo(result, 1);
                return result;
            }

            return num;
        }
    }
}
