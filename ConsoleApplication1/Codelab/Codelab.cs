using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Codelab
{
    public class Codelab
    {
        public static int NumberOfRegions(int[,] input) {
            int rows = input.GetLength(0);
            int columns = input.GetLength(1);
            int count = 0;
            bool[,] traversed = new bool[rows, columns];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    if (input[i, j] == 1 && !traversed[i, j]) {
                        count++;
                        traverseRegion(i, j, input, traversed, rows, columns);
                    }
                }
            }

            return count;
        }

        private static void traverseRegion(int i, int j, int[,] input, bool[,] traversed, int rows, int columns) {
            if (!isSafe(input, i, j, traversed, rows, columns)) return;

            traversed[i, j] = true;
            traverseRegion(i + 1, j, input, traversed, rows, columns);
            traverseRegion(i - 1, j, input, traversed, rows, columns);
            traverseRegion(i, j + 1, input, traversed, rows, columns);
            traverseRegion(i, j - 1, input, traversed, rows, columns);
        }

        private static bool isSafe(int[,] input, int i, int j, bool[,] traversed, int rows, int columns) {
            return (i >= 0 && i < rows && j >= 0 && j < columns && input[i, j] == 1 && !traversed[i, j]);
        }

        public static int bulbs(List<int> A)
        {
            int state = 0, count = 0;

            foreach (int i in A) {
                if (i == state) {
                    state = 1 - state;
                    count++;
                }
            }
            return count;
        }

        public static int maxp3(List<int> A)
        {
            int length = A.Count;
            if (length == 0) return 0;
            A.Sort();
            return Math.Max(A[length - 1] * A[length - 2] * A[length - 3], Math.Max(A[length - 1] * A[length - 2] * A[0], A[length-1]*A[0]*A[1]));
        }

        public static int mice(List<int> A, List<int> B)
        {
            int maxTime = 0;
            A.Sort();
            B.Sort();
            for (int i = 0; i < A.Count; i++) {
                maxTime = Math.Max(maxTime, Math.Abs(A[i] - B[i]));
            }

            return maxTime;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { this.val = x; this.next = null; }
        }

        public static ListNode deleteDuplicates(ListNode A)
        {
            if (A == null || A.next == null) return A;

            ListNode current = A;
            ListNode next = null;
            while (current != null && current.next != null) {
                if (current.val == current.next.val)
                {
                    next = current.next;
                    current.next = next.next;
                    next.next = null;
                }
                else {
                    current = current.next;
                }
            }

            return A;
        }

        public static List<int> wave(List<int> A)
        {
            List<int> result = new List<int>();
            int len = A.Count, i = 0; ;
            A.Sort();

            while (i < len - 1) {
                int temp = A[i];
                A[i] = A[i + 1];
                A[i + 1] = temp;
                i += 2;
            }

            return A;
        }
    }
}
