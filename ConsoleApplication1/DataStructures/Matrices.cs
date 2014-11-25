using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class Matrices
	{
		public static void PrintSpiral(int [,] A){

			int rows = A.GetLength(0);

			int offset = 0, i = 0, j = 0;

			for (offset = 0; offset < Math.Ceiling(rows*0.5); offset++) 
			{
				if (offset == rows - offset - 1) 
				{
					Console.Write(A[offset, offset]);
				}

				for (j = offset; j < rows - offset - 1; j++) 
				{
					Console.Write(A[offset, j]);
				}

				for (i = offset; i < rows - offset - 1; i++) 
				{
					Console.Write(A[i, rows - offset - 1]);
				}

				for (j = rows - offset - 1; j > offset; j--) 
				{
					Console.Write(A[rows - offset - 1, j]);
				}

				for (i = rows - offset - 1; i > offset; i--) 
				{
					Console.Write(A[i, offset]);
				}
			}
		}

	}
}
