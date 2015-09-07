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
                var rowvalues =  from r in rowEntry.Split(' ')
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
                diagSum2 += matrix[numrows-col-1, col];
                col--;
            }

            Console.WriteLine(Math.Abs(diagSum1 - diagSum2));
            
        }

        public static void staircase()
        {
            int numRows = Convert.ToInt32(Console.ReadLine());
            char[,] matrix = new char[numRows, numRows];
            for (int i = numRows-1; i >= 0; i--) 
            {
                for (int j = numRows - 1; j >= numRows - 1 - i; j--)
                {
                    matrix[i, j] = '#';
                }
            }

            for(int i=0;i<numRows;i++)
            {
                for(int j=0;j<numRows;j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
