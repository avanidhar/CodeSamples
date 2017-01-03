using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class TrieNode
	{
		public char data { get; set; }

		public Dictionary<char, TrieNode> children { get; set; }

		public bool terminates { get; set; }
		public TrieNode() 
		{
			children = new Dictionary<char, TrieNode>();
		}

		public TrieNode(char c) 
		{
			this.data = c;
			this.children = new Dictionary<char, TrieNode>();
        }
		
		public bool GetTermination() 
		{
			return this.terminates;
		}

	}
}
