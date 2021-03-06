﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.DataStructures;
using ConsoleApplication1.HackerRank;
using ConsoleApplication1.Concepts;
using static ConsoleApplication1.LeetCode.OverFlow;
using System.Threading;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.Write("This is a written line\n");
			//string paliString = "ABCBAHELLOHOWRACECARAREYOUIAMAIDOINGGOOD";
			//Console.WriteLine(GetLongestPalindrome("123215432345"));
			//Console.WriteLine(2 << 1);

			//Node head = Node.BuildSample();
			//head.AppendToTail(4);
			//head.AppendToTail(5);
			//head.AppendToTail(6);
			//head.AppendToTail(7);
			//head.PrintList();
			//Node.CyclicRightShift(ref head, 3);
			//Hashtable h = new Hashtable();
			////Node.Reverse(ref head);
			//head.PrintList();
			//Console.WriteLine(head.Search(99));
			//head.DeleteNode(5);
			//head.PrintList();

			//Console.WriteLine(BitManipulation.GetBit(5, 3));
			//Console.WriteLine(4 ^ (~4));

			//BinaryTreeNode<int> head = new BinaryTreeNode<int>(5);
			//head.Left = new BinaryTreeNode<int>(4);
			//head.Left.Left = new BinaryTreeNode<int>(1);
			//head.Left.Right = new BinaryTreeNode<int>(2);
			//head.Right = new BinaryTreeNode<int>(7);
			//head.Right.Right = new BinaryTreeNode<int>(8);
			//head.Right.Left = new BinaryTreeNode<int>(6);

			BinaryTreeNode<int> head2 = new BinaryTreeNode<int>(5);
			head2.Left = new BinaryTreeNode<int>(4);
			head2.Left.Left = new BinaryTreeNode<int>(1);
			head2.Left.Right = new BinaryTreeNode<int>(2);
			head2.Right = new BinaryTreeNode<int>(7);
			head2.Right.Right = new BinaryTreeNode<int>(9);
			head2.Right.Left = new BinaryTreeNode<int>(6);

            BinaryTreeNode<int> head = new BinaryTreeNode<int>(5);
            head.Left = new BinaryTreeNode<int>(4);
            head.Left.Left = new BinaryTreeNode<int>(1);
            head.Left.Right = new BinaryTreeNode<int>(2);
            head.Right = new BinaryTreeNode<int>(4);
            head.Right.Right = new BinaryTreeNode<int>(1);
            head.Right.Left = new BinaryTreeNode<int>(2);

            //BinaryTreeNode<int>.PostOrderIter(head);
            //BinaryTreeNode<int>.InOrderIter(head);
            //BinaryTreeNode<int>.PreOrderIter(head);
            //BinaryTreeNode<int>.LevelOrderTraversal(head);
            //Console.WriteLine(BinaryTreeNode<int>.IsBST(head));
            //var x = BinaryTreeNode<int>.PostOrderTraverse(head, new List<int>());
            ////BinaryTreeNode<int>.InsertNode(head, 7);
            //head = BinaryTreeNode<int>.InsertNodeRecursive(head, 7);
            //Console.WriteLine(BinaryTreeNode<int>.Search(head, 8));
            //BinaryTreeNode<int>.InOrderTraverse(head);
            //var leafList = BinaryTreeNode<int>.CreateLeafList(head);
            //BinaryTreeNode<int>.PreOrderTraverse(head);
            //Console.WriteLine(SearchAndSort.BinarySearch(a, 6));

            // int [] a = new int[]{3,4,5,6,9,10,14,15};
            // SearchAndSort.InPlaceShuffle(a);
            int[] b = new int[] { 2,8,7,1,3,5,6,4};
            //SearchAndSort.QuickSort(b, 0, b.Count()-1);
            //int element = SearchAndSort.FindKthSmallestElement(b, 8);
            //Strings.LongestIncreasingSubarray(b);
            //SearchAndSort.MergeSort(b, 0, b.Length);
            //int[] array = new int[] { 4,8,-3,-4,12,9,-10,-1,2,3,20,4,11,-10};
            //int[] array = new int[] { -2, -3, 4, -1, -2, 1, 5 };
            // Console.Write(SearchAndSort.MaximumSum(array, 0, array.Count() -1));
            //Console.Write(Integers.MaximumSum2(array));
            //StackStruct myStack = new StackStruct(1);
            //myStack.Push(2);
            //myStack.Push(3);
            //Console.WriteLine(myStack.pop());
            //Console.WriteLine(myStack.pop());
            //Console.WriteLine(myStack.pop());

            //HackerRank.partition(new int[] { 2, 8, 7, 1, 3, 5, 6, 4 });

            //Console.WriteLine(BitManipulation.SameWeightClosestInt(5));

            //Strings.PhoneNumberToWords("352");


            //MyHashTable hashTable = new MyHashTable();
            //hashTable.Put("avani", 1);
            //hashTable.Put("jessica", 2);
            //hashTable.Put("kaycee", 3);
            //hashTable.Put("janani", 4);
            //hashTable.Put("inava", 22);

            //Console.WriteLine(hashTable.Exists("jinglee"));

            //Strings.SplitString();

            //string w1 = "avani";
            //string w2 = "janani";

            //Console.WriteLine(Strings.EditDistance(w1, w2));

            //int[,] array2D = new int[,] { { 1, 2, 3 }, {4,5,6 }, { 7, 8, 9 } };
            //Matrices.PrintSpiral(array2D);

            //int[] a1 = {1, 2};
            //int[] a2 = { 3, 5,7,9,14,16, 18, 15, 12, 10};

            //int max = Integers.MthLargest(a1, a2, 4);
            // Strings.Result result = Strings.SolveMasterMind("RGYB", "GGBR");

            //int[,] sudokuMatrix = new int[,] { { 0,0 , 3, 4 }, { 3, 4, 0, 0 }, { 0, 0, 4, 3 }, {0,3,2,0} };
            //bool solved = Sudoku.SolveSudoku(ref sudokuMatrix);
            // Uses backtracking to solve a maze.
            //Maze simpleMaze = new Maze();
            //int[,] maze = new int[,] { { 1, 0, 1, 1, 1 }, { 1, 1, 1, 0, 1 }, { 0, 1, 1, 0, 1 }, { 0, 0, 1, 0, 1 }, { 0, 0, 0, 1, 1 } };
            //simpleMaze.InputMaze = maze;
            //simpleMaze.SolveMaze();

            //string s = "ABCABA";
            //string t = "ACEBA";

            // Console.WriteLine(Strings.LongestCommonSubsequence(s, t));

            // string input = "This is my simple string+_+#";
            // Strings.PrintMaxFreqString(input);
            //bool solved = Sudoku.SolveSudoku(ref sudokuMatrix);

            //string pattern = "aaacaaaaac";
            //int[] prefixMatch = Strings.ComputeKMPPrefix(pattern);

            // Uses backtracking to place N Queens in an N*N chessboard
            // in a non attacking position
            //NQueens queen = new NQueens();
            //queen.PlaceQueens(0);

            // Use Binary search to look for the max element in a sonusoidal array
            //int monotonicHigh = SearchAndSort.LargestInMonotonicArray(a2, 0, a2.Length-1);
            //Console.WriteLine("Monotonic high is : " + monotonicHigh);

            // bool sameTree = BinaryTreeNode<int>.IsSameTree(head, head2);

            // Use integer arithmatic to figure out if a number is a palindrome
            //long n = 12321;
            //bool isPalindrome = Integers.isPalindrome(n);

            // Use binary search to figure out the square root of an integer
            // int a = Integers.squareRoot(10);

            //string parens = "{[]}()";
            //bool isValidParen = Strings.ParenMatching(parens);

            //Console.WriteLine(Strings.IntegerToColumnId(29));
            //Node l1 = Node.BuildSample();
            //Node l2 = Node.BuildSecondSample();
            //Node.AddTwoNumbers(l1, l2).PrintList();

            //HackerRank2.staircase();

            // string looknsay = LeetCode.Solutions.LookAndSay(7);
            //int[,] array2D = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            //Console.WriteLine(LeetCode.Solutions.SearchInMatrix( array2D, 0));

            // int[] output = LeetCode.Solutions.ProductExceptSelf(input);
            //Console.WriteLine(LeetCode.Solutions.FirstPositiveMissingNumber(input));

            // Console.WriteLine(LeetCode.Solutions.MySqrt(21));
            // string ziggy = "PAYPALISHIRING";
            // var result = LeetCode.Solutions.SearchRange(input, 1);
            // Console.WriteLine(LeetCode.Solutions.ZigzagConvert(ziggy, 4));

            //int[,] array2D = new int[,] { { 1, 1, 0, 1 }, { 0, 1, 0, 0 }, { 0, 1, 1, 0 }, {1, 0, 1, 1} };

            //Console.WriteLine(Matrices.FindCelebrity(array2D));

            // int[,] array2D = new int[,] { { 1, 1, 0, 1 }, { 0, 1, 0, 0 }, { 0, 1, 1, 0 }, {1, 0, 1, 1} };
            //Console.WriteLine(Matrices.FindCelebrity(array2D));

            int[] input = { 3, 2, 1, 0, 4 };
            Array.Reverse(input);

            //string input = "babydoll";
            //Console.WriteLine(LeetCode.Solutions.LengthOfLongestSubstring(input));

            // Node treeHead = Node.BuildSecondSample();

            // Node head22 = Node.SwapPairs(treeHead);

            //int[] nums = {-2, 3};
            //Console.WriteLine(LeetCode.Solutions.MaxProduct(nums));

            // HackerRank2.MaxHourglass();

            // LeetCode.Solutions.CombinationSum3(3, 9);
            // HackerRank2.staircase();

            //string s1 = "1001";
            //string s2 = "1010";
            //string result = Strings.AddBinary(s1, s2);
            //Console.WriteLine(result);

            // HackerRank2.xorMAtrix();
            // int[] arr = { 9, 9, 9};
            //int toFind = 4;
            //int count = Integers.numTimes(arr, toFind);

            //bool mirrored = BinaryTreeNode<int>.IsMirrorImage(head);
            //Console.WriteLine(mirrored);

            // bool escape = LeetCode.Solutions.CanJumpHard(arr);

            // arr = Integers.IncrementNumber(arr);

            // int[,] maze = new int[,] { { 1, 0, 1, 1 }, { 1, 0, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 1, 0 }, { 1, 0, 0, 1 } };
            // var result = Graphs.SizeOfSmallestRegion(maze);
            // var result = Graphs.NumberOfRegions(maze);
            // int regions = Codelab.Codelab.NumberOfRegions(maze);
            // Console.WriteLine(regions);

            //List<int> listInput = new List<int>() { 1, 2, 3, 4 };
            //int result = Codelab.Codelab.maxp3(listInput);
            //var result = Codelab.Codelab.wave(listInput);
            //var result = Recursion.GenerateParanthesis(3);

            // Recursion.generateIPAddresses("25525511135");

            // int[,] nums = new int[,]{ { 1, 2, 2, 3, 5 }, { 3, 2, 3, 4, 4 }, { 2, 4, 5, 3, 1 }, { 6, 7, 1, 4, 5 }, { 5, 1, 1, 2, 4 } };
            // int[] nums = new int[] { 1, 2, 3, 4 };
            // var result = LeetCode.Solutions.TopKFrequent(nums, 2);
            // var result = LeetCode.Solutions.NumberOfArithmeticSlices(nums);

            // var result = LeetCode.OverFlow.FindRepeatedDnaSequences("AAAAAAAAAAAA");

            //HashSet<string> dictionary = new HashSet<string>();
            //dictionary.Add("aa");
            //dictionary.Add("ab");
            //dictionary.Add("ac");
            //dictionary.Add("bc");
            //dictionary.Add("cc");

            // var result = Graphs.doesPathExist("aa", "cd", dictionary);

            //HashSet<string> dictionary2 = new HashSet<string>();
            //dictionary2.Add("fireman");
            //dictionary2.Add("fire");
            //dictionary2.Add("man");
            //dictionary2.Add("fir");

            // var result = Recursion.maxWordPartition("fireman", dictionary2);

            // string palInput = "avenaanee";
            // var result = Strings.stringPermutations("cat");

            //Trie t = new Trie("avanidhar");
            //var result = t.ContainsPrefix("avani");

            // Console.WriteLine(result);

            //Calculator c = new Calculator();
            //c.KeyPressed('1');
            //c.KeyPressed('2');
            //c.KeyPressed('+');
            //c.KeyPressed('2');
            //c.KeyPressed('=');

            //LruCache cache = new LruCache(1);
            //cache.Set(2, 1);
            //cache.Get(2);
            //cache.Set(3, 2);
            //cache.Get(2);
            //cache.Get(3);

            //RandomListNode one = new RandomListNode(1);
            //RandomListNode two = new RandomListNode(2);
            //RandomListNode three = new RandomListNode(3);
            //one.next = two;
            //two.next = three;
            //one.random = three;
            //two.random = one;
            //three.random = two;
            //var result = CopyRandomList(one);

            //var result = LeetCode.OverFlow.Multiply("0", "456");
            // var result = LeetCode.OverFlow.SimplifyPath("///../../..");

            //var result = LeetCode.OverFlow.FindTheDifference("abcd", "dcabe");

            //int[,] nums = new int[,] { {9, 9, 4 }, { 6, 6, 8 }, { 2, 1, 1 }};
            //var result = LeetCode.OverFlow.LongestIncreasingPath(nums);

            //var result = LeetCode.OverFlow.IsNumber("ef2");
            //char[,] gameboard = new char[,] { { 'w', 'b', 'b' }, { ' ', 'b', ' ' }, { 'w', 'b', ' ' }, { 'w', 'b', ' ' } };
            //var result = Graphs.scoreGameOfGo(gameboard, 'b');

            //int[,] museum = new int[,] { {0,0,0 }, {-2, -1, -1 }, {-2, 0, 0 } };
            //Graphs.updateDistances(museum);
            //for (int i = 0; i < museum.GetLength(0); i++)
            //{
            //    for(int j =0;j<museum.GetLength(1); j++)
            //    {
            //        Console.Write(museum[i, j]);
            //        Console.Write(" ");
            //    }
            //    Console.WriteLine();
            //}

            //ReaderWriterProblem rw = new ReaderWriterProblem();
            //ThreadPool.QueueUserWorkItem((o) => rw.WriteWithWriterPriority("hello"));
            //ThreadPool.QueueUserWorkItem((o) => rw.WriteWithWriterPriority("world"));
            //ThreadPool.QueueUserWorkItem((o) => rw.WriteWithWriterPriority("microsoft"));
            //for (int i = 0; i< 5; i++) ThreadPool.QueueUserWorkItem((p) => rw.ReadWithWritePriority());

            //ProducerConsumer pc = new ProducerConsumer();
            //ThreadPool.QueueUserWorkItem((o) => pc.Produce(1));
            //ThreadPool.QueueUserWorkItem((o) => pc.Produce(2));
            //ThreadPool.QueueUserWorkItem((o) => pc.Produce(3));
            //ThreadPool.QueueUserWorkItem((o) => pc.Consume());
            //ThreadPool.QueueUserWorkItem((o) => pc.Consume());
            //ThreadPool.QueueUserWorkItem((o) => pc.Consume());

            //int[] i = new int[] { 1, 2, 3};
            //var result = Recursion.subsets(i);

            //Trie t = new Trie("cat");
            //t.AddWord("bat");
            //t.AddWord("ball");
            //t.AddWord("cot");
            //var result = t.SearchWord("c..t");
            //Console.WriteLine(result);

            string s = "abx";
            string t = "ahbgdc";
            var result = LeetCode.OverFlow.IsSubsequence(s, t);
            Console.WriteLine(result);

            Console.ReadKey(true);
		}
	}
}
