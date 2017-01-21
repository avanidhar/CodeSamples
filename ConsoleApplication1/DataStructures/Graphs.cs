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
                        traverseRegionIter(i, j, input, traversed, rows, columns);
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

        private static void traverseRegionIter(int row, int col, int[,] input, bool[,] visited, int rows, int columns)
        {
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            q.Enqueue(Tuple.Create(row, col));

            while (!(q.Count == 0))
            {
                var element = q.Dequeue();
                int r = element.Item1;
                int c = element.Item2;

                visited[r, c] = true;
                if (input[r, c] == 1)
                {
                    if (r > 0 && input[r - 1, c] == 1 && !visited[r - 1, c]) q.Enqueue(Tuple.Create(r - 1, c));
                    if (r < rows - 1 && input[r + 1, c] == 1 && !visited[r + 1, c]) q.Enqueue(Tuple.Create(r + 1, c));
                    if (c > 0 && input[r, c - 1] == 1 && !visited[r, c - 1]) q.Enqueue(Tuple.Create(r, c - 1));
                    if (c < columns - 1 && input[r, c + 1] == 1 && !visited[r, c + 1]) q.Enqueue(Tuple.Create(r, c + 1));
                }

            }
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

        #region size of smallest region
        public static int SizeOfSmallestRegion(int[,] input)
        {
            int rows = input.GetLength(0);
            int columns = input.GetLength(1);
            int count = Int32.MaxValue;
            bool[,] traversed = new bool[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (input[i, j] == 1 && !traversed[i, j])
                    {
                       count = Math.Min(count, smallestRegionHelper(i, j, input, traversed, rows, columns));
                    }
                }
            }

            return count;
        }

        public static int smallestRegionHelper(int row, int col, int[,] input, bool[,] visited, int rows, int cols)
        {
            int count = 0;
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            q.Enqueue(Tuple.Create(row, col));

            while (!(q.Count == 0))
            {
                var element = q.Dequeue();
                int r = element.Item1;
                int c = element.Item2;

                visited[r, c] = true;
                if(input[r,c] == 1)
                {
                    count++;
                    if (r > 0 && input[r - 1, c] == 1 && !visited[r - 1, c]) q.Enqueue(Tuple.Create(r - 1, c));
                    if (r < rows - 1 && input[r + 1, c] == 1 && !visited[r + 1, c]) q.Enqueue(Tuple.Create(r + 1, c));
                    if (c > 0 && input[r, c -1] == 1 && !visited[r, c-1]) q.Enqueue(Tuple.Create(r, c - 1));
                    if (c <cols -1 && input[r, c + 1] == 1 && !visited[r, c + 1]) q.Enqueue(Tuple.Create(r, c + 1));
                }

            }

            return count;
        }
        #endregion

        #region game of go
        public static int scoreGameOfGo(char[,] board, char player)
        {
            if(board.GetLength(0) == 0) return 0;

            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            bool[,] visited = new bool[rows, cols];
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j] == ' ' && !visited[i, j])
                    {
                        count += scoreGameHelper(i, j, rows, cols, board, visited, player);
                    }
                }
            }

            return count;
        }

        private static int scoreGameHelper(int row, int col, int rows, int cols, char[,] input, bool[,] visited, char player)
        {
            int count = 0;
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();

            q.Enqueue(Tuple.Create(row, col));

            while (!(q.Count == 0))
            {
                var val = q.Dequeue();
                int r = val.Item1;
                int c = val.Item2;

                visited[r, c] = true;
                if (input[r, c] == ' ')
                {
                    count++;
                    if (r > 0 && !visited[r - 1, c]) q.Enqueue(Tuple.Create(r - 1, c));
                    if (r < rows - 1 && !visited[r + 1, c]) q.Enqueue(Tuple.Create(r + 1, c));
                    if (c > 0 && !visited[r, c - 1]) q.Enqueue(Tuple.Create(r, c - 1));
                    if (c < cols - 1 && !visited[r, c + 1]) q.Enqueue(Tuple.Create(r, c + 1));
                }
                else if (input[r, c] != player)
                {
                    return 0;
                }
            }

            return count;
        }
        #endregion

        #region GuardsToGates
        public static void updateDistances(int[,] layout)
        {
            if (layout.GetLength(0) == 0) return;

            int rows = layout.GetLength(0);
            int cols = layout.GetLength(1);

            Queue<Tuple<int, int, int>> q = new Queue<Tuple<int, int, int>>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (layout[i, j] == -1)
                    {
                        q.Enqueue(Tuple.Create(i, j, 0));
                    }
                }
            }

            while (!(q.Count == 0))
            {
                var val = q.Dequeue();
                int r = val.Item1;
                int c = val.Item2;
                int dist = val.Item3;

                if (isSafeToGo(r - 1, c, rows, cols, layout))
                {
                    if (layout[r - 1, c] == 0 || layout[r - 1, c] > dist + 1)
                    {
                        layout[r - 1, c] = dist + 1;
                        q.Enqueue(Tuple.Create(r - 1, c, dist + 1));
                    }
                }

                if (isSafeToGo(r + 1, c, rows, cols, layout))
                {
                    if (layout[r + 1, c] == 0 || layout[r + 1, c] > dist + 1)
                    {
                        layout[r + 1, c] = dist + 1;
                        q.Enqueue(Tuple.Create(r + 1, c, dist + 1));
                    }
                }

                if (isSafeToGo(r, c-1, rows, cols, layout))
                {
                    if (layout[r, c - 1] == 0 || layout[r, c - 1] > dist + 1)
                    {
                        layout[r, c - 1] = dist + 1;
                        q.Enqueue(Tuple.Create(r, c - 1, dist + 1));
                    }
                }

                if (isSafeToGo(r, c + 1, rows, cols, layout))
                {
                    if (layout[r, c + 1] == 0 || layout[r, c + 1] > dist + 1)
                    {
                        layout[r, c + 1] = dist + 1;
                        q.Enqueue(Tuple.Create(r, c + 1, dist + 1));
                    }
                }
            }
        }

        private static bool isSafeToGo(int r, int c, int rows, int cols, int[,] layout)
        {
            return (r >= 0 && r < rows && c >= 0 && c < cols && layout[r, c] != -1 && layout[r, c] != -2);
        }
        #endregion
    }
}
