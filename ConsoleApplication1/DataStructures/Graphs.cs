using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
    public static class Graphs
    {
        #region number of regions
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
        #endregion

        #region word path
        /// <summary>
        /// For two given words, this method checks if a path exists between the two words
        /// The path must go through valid dictionary words. The dictionary is also passed.
        /// This is a classic BFS example where
        /// .. the graph starts at the begin string
        /// .. the neighbors are valid dictionary strings that are one character away
        /// .. the goal is to find a path between the begin and end string.
        /// This same algorithm can be used to solve a maze or find a region or whatever it is.
        /// </summary>
        public static bool doesPathExist(string begin, string end, HashSet<string> dictionary)
        {
            if (begin.Equals(end)) return true;
            if (string.IsNullOrEmpty(begin)) return false;

            Queue<string> inputQueue = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();

            inputQueue.Enqueue(begin);

            while (inputQueue.Count != 0)
            {
                string val = inputQueue.Dequeue();
                if (val.Equals(end))
                {
                    foreach (string s in visited)
                    {
                        Console.WriteLine(s);
                    }
                    return true;
                }

                visited.Add(val);
                IList<string> neighbors = GetNeighborStrings(val);
                foreach (string neighbor in neighbors)
                {
                    if (dictionary.Contains(neighbor) && !visited.Contains(neighbor))
                    {
                        inputQueue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }

            return false;
        }

        private static IList<string> GetNeighborStrings(string input)
        {
            int len = input.Length;
            IList<string> result = new List<string>();
            StringBuilder sb = new StringBuilder(input);

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    sb[i] = Convert.ToChar('a' + j);
                    result.Add(sb.ToString());
                }

                // Replace original char
                sb[i] = input[i];
            }

            return result;
        }
        #endregion
    }
}
