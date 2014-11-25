using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class Trie
	{
		private TrieNode root { get; set; }

		public Trie(List<string> words)
		{
			root = new TrieNode();
			foreach (string word in words) 
			{
				root.AddWord(word);
			}
		}

		public Trie(string word) 
		{
			root = new TrieNode();
			root.AddWord(word);
		}

		public void AddWord(string word) 
		{
			if (root == null) 
			{
				root = new TrieNode();
			}

			root.AddWord(word);
		}

		public bool ContainsWord(string word) 
		{
			if (string.IsNullOrEmpty(word)) 
			{
				return false;
			}

			TrieNode lastNode = root;
			for (int i = 0; i < word.Length; i++) 
			{
				lastNode = lastNode.GetChild(word[i]);
				if (lastNode == null) 
				{
					return false;
				}
			}

			return lastNode.GetTermination() == true;
		}

		public bool ContainsPrefix(string prefix) 
		{
			return false;
		}
	}
}
