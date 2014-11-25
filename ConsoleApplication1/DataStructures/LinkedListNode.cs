using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class Node
	{
		public Node Next { get; set; }

		public int Data { get; set; }

		public Node(int data) 
		{
			this.Data = data;
		}

		public void AppendToTail(int data) 
		{
			Node end = new Node(data);
			Node n = this;
			while (n.Next != null) 
			{
				n = n.Next;
			}
			n.Next = end;
		}

		public void PrintList()
		{
			Node n = this;
			StringBuilder sb = new StringBuilder();
			while (n != null)
			{ 
				sb.Append(n.Data).Append(' ');
				n = n.Next;
			}
			Console.WriteLine(sb.ToString());
		}

		public static Node BuildSample() 
		{
			Node head = new Node(1);
			head.Next = new Node(2);
			head.Next.Next = new Node(3);
			return head;
		}

		public bool Search(int n)
		{
			Node head = this;
			Node current = head;
			while (current.Next != null)
			{
				if (current.Data == n)
				{
					return true;
				}
				else
				{
					current = current.Next;
				}
			}
			return false;
		}

		public Node DeleteNode(int data)
		{
			Node n = this;
			
			if(n.Data == data)
			{
				return this.Next;
			}

			while (n.Next != null) 
			{
				if (n.Next.Data == data)
				{
					n.Next = n.Next.Next;
					return this;
				}
				n = n.Next;
			}

			return this;

		}

		public static void Reverse(ref Node head) 
		{
			Node result = null;
			Node current = head;

			while (current != null) 
			{
				Node next = current.Next;
				current.Next = result;
				result = current;
				current = next;
			}

			head = result;

		}

		public static void CyclicRightShift(ref Node head, int k) 
		{
			if (head == null) return;

			int Length = Node.Length(head);

			k = k % Length;

			Node current = head;
			while (current.Next != null) 
			{
				current = current.Next;
			}

			current.Next = head;
			int distance = Length - k;
			while (distance > 0) 
			{
				current = current.Next;
				distance--;
			}

			head = current.Next;
			current.Next = null;
		}

		public static void CyclicRightShiftPt2(ref Node head, int k)
		{
			if (head == null) return;

			int Length = Node.Length(head);

			k = k % Length;

			Node current = head, current2 = head;

			while (k > 0) 
			{
				current2 = current2.Next;
				k--;
			}

			while (current2.Next != null) 
			{
				current = current.Next;
				current2 = current2.Next;
			}

			current2.Next = head;
			head = current.Next;
			current.Next = null;
		}

		public static int Length(Node head) 
		{
			if (head == null) 
			{
				return 0;
			}

			int ListLength = 0;
			Node current = head;
			while (current != null) 
			{
				current = current.Next;
				ListLength++;
			}
			return ListLength;
		}
	}
}
