using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class BinaryTreeNode<T> where T : IComparable
	{
		private T data;
		public BinaryTreeNode<T> Left, Right, Next;

		public BinaryTreeNode(T data)
		{
			this.data = data;
			Left = null;
			Right = null;
			Next = null;
		}

		public T Data
		{

			get { return this.data; }

			set { this.data = value; }
		}

		public static void InOrderTraverse(BinaryTreeNode<T> head)
		{
			if (head == null) return;

			InOrderTraverse(head.Left);
			Console.WriteLine(head.Data);
			InOrderTraverse(head.Right);

		}

		public static void PreOrderTraverse(BinaryTreeNode<T> head)
		{
			if (head == null) return;

			Console.WriteLine(head.Data);
			PreOrderTraverse(head.Left);
			PreOrderTraverse(head.Right);

		}

		public static List<T> PostOrderTraverse(BinaryTreeNode<T> head, List<T> results)
		{
			if (head == null) return null;

			PostOrderTraverse(head.Left, results);
			PostOrderTraverse(head.Right, results);
			results.Add(head.data);

			return results;
		}

		public static bool Search(BinaryTreeNode<T> head, T data)
		{
			if (head == null) return false;

			if (head.Data.Equals(data))
			{
				return true;
			}
			else if (data.CompareTo(head.Data) < 0)
			{
				return Search(head.Left, data);
			}
			else
			{
				return Search(head.Right, data);
			}
		}

		public static void InsertNode(BinaryTreeNode<T> head, T data)
		{
			if (head == null) return;
			BinaryTreeNode<T> current = head, parent = null;
			BinaryTreeNode<T> dataNode = new BinaryTreeNode<T>(data);
			while (current != null)
			{
				if (current.Data.Equals(data)) return;
				if (data.CompareTo(current.Data) < 0)
				{
					parent = current;
					current = current.Left;
				}
				else if (data.CompareTo(current.Data) > 0)
				{
					parent = current;
					current = current.Right;
				}
			}

			if (data.CompareTo(parent.Data) < 0)
			{
				parent.Left = dataNode;
			}
			else
			{
				parent.Right = dataNode;
			}
		}

		public static BinaryTreeNode<T> InsertNodeRecursive(BinaryTreeNode<T> head, T data)
		{
			if (head == null)
			{
				head = new BinaryTreeNode<T>(data);
				return head;
			}
			BinaryTreeNode<T> current = head;
			if (data.CompareTo(current.Data) < 0)
			{
				current.Left = InsertNodeRecursive(current.Left, data);
			}
			else if (data.CompareTo(current.Data) > 0)
			{
				current.Right = InsertNodeRecursive(current.Right, data);
			}
			return current;
		}

		/*
		 * TODO IMPLEMENT
		 * DELETE
		 * ROTATE <possibly>
		 * 
		 */

		public static bool IsBST(BinaryTreeNode<T> head)
		{
			return IsBSTHelper(head, null, null);
		}

		private static bool IsBSTHelper(BinaryTreeNode<T> head, Object min, Object max)
		{
			if (head == null)
			{
				return true;
			}
			if (min != null && head.Data.CompareTo(min) < 0)
			{
				return false;
			}

			if (max != null && head.Data.CompareTo(max) > 0)
			{
				return false;
			}

			return IsBSTHelper(head.Left, min, head.Data) && IsBSTHelper(head.Right, head.Data, max);
		}

		public static LinkedList<T> CreateLeafList(BinaryTreeNode<T> head) 
		{
			LinkedList<T> leafList = new LinkedList<T>();
			LeafListHelper(head, leafList);

			return leafList;
		}

		private static void LeafListHelper(BinaryTreeNode<T> head, LinkedList<T> leafList) 
		{
			if (head == null) return;
			LeafListHelper(head.Left, leafList);
			if (head.Left == null && head.Right == null) 
			{
				leafList.AddLast(head.Data);
			}
			LeafListHelper(head.Right, leafList);
		}

		public static void PostOrderIter(BinaryTreeNode<T> root) 
		{
			if (root == null) return;
			Stack<BinaryTreeNode<T>> inputStack = new Stack<BinaryTreeNode<T>>();
			Stack<BinaryTreeNode<T>> outputStack = new Stack<BinaryTreeNode<T>>();

			inputStack.Push(root);

			while (inputStack.Count != 0) 
			{
				BinaryTreeNode<T> current = inputStack.Pop();
				outputStack.Push(current);
				if (current.Left != null) 
				{
					inputStack.Push(current.Left);
				}

				if (current.Right != null) 
				{
					inputStack.Push(current.Right);
				}
			}

			StringBuilder sb = new StringBuilder();

			while (outputStack.Count != 0) 
			{
				sb.Append(outputStack.Pop().Data);	
			}

			Console.WriteLine(sb.ToString());
		}

		public static void InOrderIter(BinaryTreeNode<T> root)
		{
			if (root == null) return;
			Stack<BinaryTreeNode<T>> inputStack = new Stack<BinaryTreeNode<T>>();

			BinaryTreeNode<T> current = root;
			StringBuilder sb = new StringBuilder();
			while (true) 
			{
				if (current != null)
				{
					inputStack.Push(current);
					current = current.Left;
				}
				else 
				{
					if (inputStack.Count == 0) break;
					else 
					{
						current = inputStack.Pop();
						sb.Append(current.Data);
						current = current.Right;
					}
				}
			}

			Console.WriteLine(sb.ToString());
		}

		public static void PreOrderIter(BinaryTreeNode<T> root)
		{
			if (root == null) return;
			Stack<BinaryTreeNode<T>> inputStack = new Stack<BinaryTreeNode<T>>();

			StringBuilder sb = new StringBuilder();
			inputStack.Push(root);
			while (inputStack.Count != 0)
			{
				BinaryTreeNode<T> current = inputStack.Pop();
				sb.Append(current.Data);
				if (current.Right != null) 
				{
					inputStack.Push(current.Right);
				}
				if (current.Left != null) 
				{
					inputStack.Push(current.Left);
				}
			}

			Console.WriteLine(sb.ToString());
		}

		public static void LevelOrderTraversal(BinaryTreeNode<T> root) 
		{
			if (root == null) return;
			StringBuilder sb = new StringBuilder();
			Queue<BinaryTreeNode<T>> inputQueue = new Queue<BinaryTreeNode<T>>();
			inputQueue.Enqueue(root);
			while (inputQueue.Count != 0) 
			{
				BinaryTreeNode<T> current = inputQueue.Dequeue();
				sb.Append(current.Data);
				if (current.Left != null) 
				{
					inputQueue.Enqueue(current.Left);
				}
				if (current.Right != null) 
				{
					inputQueue.Enqueue(current.Right);
				}
			}

			Console.WriteLine(sb.ToString());
		}

		public static bool IsSameTree(BinaryTreeNode<T> root1, BinaryTreeNode<T> root2) 
		{
			if (root1 == null && root2 == null) return true;

			else if(root1!=null && root2!=null)
			{
				return ((root1.data.CompareTo(root2.data) == 0) &&
					(IsSameTree(root1.Left, root2.Left)) &&
					(IsSameTree(root1.Right, root2.Right)));
			}
			else
			{
				return false;
			}
		}
	}
}
