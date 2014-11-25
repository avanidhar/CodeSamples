using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class StackStruct
	{
		Node top;

		public StackStruct(int n) 
		{
			this.top = new Node(n);
		}
		public void Push(int n) 
		{
			Node newNode = new Node(n);
			newNode.Next = this.top;
			this.top = newNode;
		}

		public int pop() 
		{
			if (this.top != null) 
			{
				int value = this.top.Data;
				top = top.Next;
				return value;
			}
			return -1;
		}
	}
}
