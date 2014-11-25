using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class TrieNode
	{
		char data { get; set; }

		List<TrieNode> children { get; set; }

		bool terminates { get; set; }
		public TrieNode() 
		{
			children = new List<TrieNode>();
		}

		public TrieNode(char c) 
		{
			this.data = c;
			this.children = new List<TrieNode>();
		}

		public void AddWord(string word) 
		{
			if (string.IsNullOrEmpty(word)) return;

			TrieNode t, child;
			char c = word[0];

			t = GetChild(c);

			if (t == null)
			{
				child = new TrieNode(c);
				this.children.Add(child);
			}
			else 
			{
				child = t;
			}

			if (word.Length > 1)
			{
				child.AddWord(word.Substring(1));
			}
			else 
			{
				child.terminates = true;
			}
		}

		/// <summary>
		/// Gets the child of a node which has the particular character as its data
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public TrieNode GetChild(char c) 
		{
			foreach(TrieNode t in this.children)
			{
				if (t.data == c) 
				{
					return t;
				}
			}

			return null;
		}

		public bool GetTermination() 
		{
			return this.terminates;
		}

	}
}
