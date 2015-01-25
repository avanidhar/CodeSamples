using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class NQueens
	{
		public const int SIZE = 8;

		public List<int[]> results;

		public int Configurations = 0;

		public int[] config;

		public NQueens() 
		{
			results = new List<int[]>();
			config = new int[SIZE];
		}
		public void PlaceQueens(int row)
		{
			if (row == SIZE)
			{
				// Keeps track of the individual configurations
				this.results.Add((int[])this.config.Clone());

				// Keeps track of the total number of unique configurations
				this.Configurations += 1;
			}
			else 
			{
				for (int col = 0; col < SIZE; col++) 
				{
					if (IsSafe(this.config, row, col)) 
					{
						this.config[row] = col;
						PlaceQueens(row + 1);
					}
				}
			}
		}

		public static bool IsSafe(int[] col, int row, int column) 
		{
			for (int i = 0; i < row; i++) 
			{
				// If any queen has been placed in the same column before, return false
				if (col[i] == column) 
				{
					return false;
				}

				// If any queen has been placed in the diagonal before, return false
				if (Math.Abs(col[i] - column) == row - i) 
				{
					return false;
				}
			}
			return true;
		}
	}
}
