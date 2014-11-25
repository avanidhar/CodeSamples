using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.DataStructures;
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

			//BinaryTreeNode<int>.PostOrderIter(head);
			//BinaryTreeNode<int>.InOrderIter(head);
			//BinaryTreeNode<int>.PreOrderIter(head);
			//Console.WriteLine(BinaryTreeNode<int>.IsBST(head));
			//var x = BinaryTreeNode<int>.PostOrderTraverse(head, new List<int>());
			////BinaryTreeNode<int>.InsertNode(head, 7);
			//head = BinaryTreeNode<int>.InsertNodeRecursive(head, 7);
			//Console.WriteLine(BinaryTreeNode<int>.Search(head, 8));
			//BinaryTreeNode<int>.InOrderTraverse(head);
			//var leafList = BinaryTreeNode<int>.CreateLeafList(head);
			//BinaryTreeNode<int>.PreOrderTraverse(head);
			//Console.WriteLine(SearchAndSort.BinarySearch(a, 6));

			//int [] a = new int[]{3,4,5,6,9,10,14,15};
			//int[] b = new int[] { 2,8,7,1,3,5,6,4};
			//SearchAndSort.QuickSort(b, 0, b.Count()-1);
			//int element = SearchAndSort.FindKthSmallestElement(b, 8);
			//Strings.LongestIncreasingSubarray(b);
			//SearchAndSort.MergeSort(b, 0, b.Length);
			//int[] array = new int[] { 4,8,-3,-4,12,9,-10,-1,2,3,20,4,11,-10};
			// Console.Write(SearchAndSort.MaximumSum(array, 0, array.Count() -1));
			//Console.Write(SearchAndSort.MaximumSum2(array));
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
			//int[] a2 = { 3, 4, 5, 6, 7, 8};

			//int max = Integers.MthLargest(a1, a2, 4);
			// Strings.Result result = Strings.SolveMasterMind("RGYB", "GGBR");

			//int[,] sudokuMatrix = new int[,] { { 0,0 , 3, 4 }, { 3, 4, 0, 0 }, { 0, 0, 4, 3 }, {0,3,2,0} };

			// Uses backtracking to solve a maze.
			//Maze simpleMaze = new Maze();
			//int[,] maze = new int[,] { { 1, 0, 1, 1, 1 }, { 1, 1, 1, 0, 1 }, { 0, 1, 1, 0, 1 }, { 0, 0, 1, 0, 1 }, { 0, 0, 0, 1, 1 } };
			//simpleMaze.InputMaze = maze;
			//simpleMaze.SolveMaze();

			string s = "ABCABA";
			string t = "ACEBA";

			Console.WriteLine(Strings.LongestCommonSubsequence(s, t));
			//bool solved = Sudoku.SolveSudoku(ref sudokuMatrix);

			//foreach (int val in sudokuMatrix) 
			//{
			//	Console.Write(val);
			//}
			Console.ReadKey(true);
		}
	
		static void countChange(int pennies) 
		{
			int qrts = pennies / 25;
			int change = pennies % 25;

			int dimes = change / 10;
			change = change % 10;

			int nickels = change / 5;
			change = change % 5;

			int penniesRemain = change;

			Console.WriteLine("Quarters : " + qrts +" Dimes : " + dimes + " Nickels : " + nickels + "Pennies : " + penniesRemain);
		}

		static void HashFun() 
		{
			List<string> first = new List<string>() { "america", "india", "japan", "pakistan"};
			List<string> second = new List<string>() { "india", "pakistan", "china" };
			Hashtable table = new Hashtable();
			foreach(string country in first)
			{
				table.Add(country, true);		
			}
			foreach (string state in second) 
			{
				if (!table.ContainsKey(state)) 
				{
					Console.WriteLine("The first country not in the list is : " + state);
					break;
				}
			}
		}

		public static string GetLongestPalindrome(string input) 
		{
			if (string.IsNullOrEmpty(input)) 
			{
				return string.Empty;
			}
			int length = input.Length;
			List<string> palindromes = new List<string>();
			string currentPalindrome = string.Empty, longestPalindrome = string.Empty;
			int leftIndex = 0, rightIndex = 0;
			for (int i = 1; i < length - 1; i++) 
			{
				leftIndex = i - 1;
				rightIndex = i + 1;
				while (leftIndex >= 0 && rightIndex < length) 
				{
					if (input[leftIndex] != input[rightIndex])
					{
						break;
					}
					string palindrome = input.Substring(leftIndex, rightIndex - leftIndex + 1);
					palindromes.Add(palindrome);
					leftIndex--; rightIndex++;
				}
			}

			longestPalindrome = palindromes.OrderByDescending(w => w.Length).First();
			return longestPalindrome;
		}

		public void HasSum(int[] array, int targetSum) 
		{
			Dictionary<int, int> disco = new Dictionary<int, int>();

		}
	}
}
