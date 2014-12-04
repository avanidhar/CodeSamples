using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class Sudoku
	{
		private const int DIMENSION = 4;
		private const int BOXSIZE = 2;
		private const int UNASSIGNED = 0;

		public static bool SolveSudoku(ref int[,] matrix)
		{
			Tuple<int, int> free = FindUnassignedLocation(matrix);
			
			// Everything assigned. Return true
			if (free == null) 
			{
				return true;
			}

			int row = free.Item1;
			int col = free.Item2;

			for (int n = 1; n <= DIMENSION; n++) 
			{
				if (IsSafe(matrix, row, col, n)) 
				{
					matrix[row, col] = n;

					if (SolveSudoku(ref matrix))
					{
						return true;
					}
					matrix[row, col] = UNASSIGNED;
				}
			}

			return false;
		}

		private static bool IsSafe(int[,] grid, int row, int col, int num) 
		{
			return (!IsUsedInRow(grid, row, num) && (!IsUsedInColumn(grid, col, num)) && (!IsUsedInBox(grid, (row+1) - (row-1) % DIMENSION, (col+1) - (col-1) % DIMENSION, num))) ;
		}
		private static Tuple<int, int> FindUnassignedLocation(int[,] grid)
		{
			for (int i = 0; i < DIMENSION; i++)
			{
				for (int j = 0; j < DIMENSION; j++)
				{
					if (grid[i, j] == UNASSIGNED)
					{
						return new Tuple<int, int>(i, j);
					}
				}
			}

			return null;
		}

		private static bool IsUsedInRow(int[,] grid, int row, int num)
		{
			for (int i = 0; i < DIMENSION; i++)
			{
				if (grid[row, i] == num)
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsUsedInColumn(int[,] grid, int column, int num)
		{
			for (int i = 0; i < DIMENSION; i++)
			{
				if (grid[i, column] == num)
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsUsedInBox(int[,] grid, int boxRowStart, int boxColumnStart, int num) 
		{
			for (int row = 0; row < BOXSIZE; row++) 
			{
				for (int col = 0; col < BOXSIZE; col++) 
				{
					if (grid[row + boxRowStart, col + boxColumnStart] == num) 
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}
