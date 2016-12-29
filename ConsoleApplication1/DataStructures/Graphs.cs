using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
    public static class Graphs
    {
        public static int NumberOfRegions(int[,] input)
        {
            int rows = input.GetLength(0);
            int columns = input.GetLength(1);
            int count = 0;
            bool[,] traversed = new bool[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (input[i, j] == 1 && !traversed[i, j])
                    {
                        count++;
                        traverseRegion(i, j, input, traversed, rows, columns);
                    }
                }
            }

            return count;
        }

        private static void traverseRegion(int i, int j, int[,] input, bool[,] traversed, int rows, int columns)
        {
            if (!isSafe(input, i, j, traversed, rows, columns)) return;

            traversed[i, j] = true;
            traverseRegion(i + 1, j, input, traversed, rows, columns);
            traverseRegion(i - 1, j, input, traversed, rows, columns);
            traverseRegion(i, j + 1, input, traversed, rows, columns);
            traverseRegion(i, j - 1, input, traversed, rows, columns);
        }

        private static bool isSafe(int[,] input, int i, int j, bool[,] traversed, int rows, int columns)
        {
            return (i >= 0 && i < rows && j >= 0 && j < columns && input[i, j] == 1 && !traversed[i, j]);
        }
    }
}
