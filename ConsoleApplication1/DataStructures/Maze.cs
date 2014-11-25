using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class Maze
	{
		public int[,] InputMaze { get; set; }

		private const int DIM = 5;
		public int[,] Solution { get; set; }

		public Maze() 
		{
			this.Solution = new int[DIM, DIM];
			for (int i = 0; i < DIM; i++) 
			{
				for (int j = 0; j < DIM; j++) 
				{
					Solution[i, j] = 0;
				}
			}
		}

		public void SolveMaze() 
		{
			bool solved = this.SolveMazeHelper(0, 0);
			for (int i = 0; i < DIM; i++) 
			{
				for (int j = 0; j < DIM; j++) 
				{
					Console.Write(this.Solution[i, j]);
				}
				Console.WriteLine();
			}
		}
		private bool SolveMazeHelper(int x, int y) 
		{
			if (x == DIM - 1 && y == DIM - 1) 
			{
				this.Solution[x, y] = 1;
				return true;
			}

			if (IsValid(x, y)) 
			{
				this.Solution[x, y] = 1;
				if(SolveMazeHelper(x, y + 1)) return true;
				if(SolveMazeHelper(x + 1, y)) return true;
				if (SolveMazeHelper(x -1, y)) return true;
				if (SolveMazeHelper(x, y-1)) return true;
				
				this.Solution[x, y] = 0;
			}
			return false;
		}

		public bool IsValid(int i, int j) 
		{
			if ((i >= 0 && i < DIM) && (j >= 0 && j < DIM) && (this.InputMaze[i, j] == 1) && (this.Solution[i,j] != 1)) return true;
			else return false;
		}
	}
}
