using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.HackerRank
{
    public static class HackerRank2
    {
        public static void AbsoluteDifference()
        {
            int numrows = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[numrows, numrows];
            for (int i = 0; i < numrows; i++)
            {
                string rowEntry = Console.ReadLine();
                var rowvalues = from r in rowEntry.Split(' ')
                                select Convert.ToInt32(r);
                for (int j = 0; j < rowvalues.Count(); j++)
                {
                    matrix[i, j] = rowvalues.ElementAt(j);
                }
            }

            int diagSum1 = 0, diagSum2 = 0;
            int row = 0, col = numrows - 1;

            while (row < numrows)
            {
                diagSum1 += matrix[row, row];
                row++;
            }

            while (col >= 0)
            {
                diagSum2 += matrix[numrows - col - 1, col];
                col--;
            }

            Console.WriteLine(Math.Abs(diagSum1 - diagSum2));

        }

        public static void staircase()
        {
            int numRows = Convert.ToInt32(Console.ReadLine());
            char[,] matrix = new char[numRows, numRows];
            
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = '#';
                }
            }

            for (int i = 0; i < numRows; i++)
            {
                for (int j = numRows -1; j >=0; j--)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void MaxHourglass()
        {
            int[,] matrix = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                string rowEntry = Console.ReadLine();
                var rowvalues = from r in rowEntry.Split(' ')
                                select Convert.ToInt32(r);
                for (int j = 0; j < rowvalues.Count(); j++)
                {
                    matrix[i, j] = rowvalues.ElementAt(j);
                }
            }
        }


        public class Node
        {
            public int data;
            public Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }

        }

        public static Node removeDuplicates(Node head)
        {
            if (head == null || head.next == null) return head;
            Node current = head, next;
            while (current != null && current.next!=null)
            {
                if (current.data == current.next.data)
                {
                    next = current.next;
                    current.next = next.next;
                    next.next = null;
                }
                else
                {
                    current = current.next;
                }
            }
            return head;
        }

        public static void xorMAtrix() {
            string rAndC = Console.ReadLine();
            string rowVals = Console.ReadLine();
            var firstRow = from r in rowVals.Split(' ') select Convert.ToInt64(r);
            var rcArray = rAndC.Split(' ');
            long columns = Convert.ToInt64(rcArray[0]);
            long rows = Convert.ToInt64(rcArray[1]);

            long[,] xorMat = new long[rows, columns];

            for (int i = 0; i < columns; i++) {
                xorMat[0,i] = firstRow.ElementAt(i);
            }

            
            for (int i = 1; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    xorMat[i, j] = xorMat[i - 1, j] ^ xorMat[i - 1, (j + 1)%columns];
                }
            }

            for (int i = 0; i < columns; i++) {
                Console.Write(xorMat[rows - 1, i]);
                Console.Write(' ');
            }
        }
    }
}
