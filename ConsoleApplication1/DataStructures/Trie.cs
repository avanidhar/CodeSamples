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
                AddWord(word);
			}
		}

		public Trie(string word) 
		{
			root = new TrieNode();
            AddWord(word);
		}

		public void AddWord(string word) 
		{
            if (string.IsNullOrEmpty(word)) return;

            TrieNode cur = root;
            var children = cur.children;

            for (int i = 0; i < word.Length; i++)
            {
                if (children.ContainsKey(word[i]))
                {
                    cur = children[word[i]];
                }
                else
                {
                    TrieNode t = new TrieNode(word[i]);
                    children.Add(word[i], t);
                    cur = t;
                }
                children = cur.children;

                if (i == word.Length - 1)
                {
                    cur.terminates = true;
                }
            }

        }

		public bool ContainsWord(string word) 
		{
			if (string.IsNullOrEmpty(word)) 
			{
				return false;
			}

			TrieNode cur = root;
            var children = cur.children;
			for (int i = 0; i < word.Length; i++) 
			{
                if (children.ContainsKey(word[i]))
                {
                    cur = children[word[i]];
                    children = cur.children;
                }
                else
                {
                    return false;
                }
			}

			return cur.terminates;
		}

		public bool ContainsPrefix(string prefix) 
		{
            if (string.IsNullOrEmpty(prefix)) 
			{
				return false;
			}

			TrieNode cur = root;
            var children = cur.children;
			for (int i = 0; i < prefix.Length; i++) 
			{
                if (children.ContainsKey(prefix[i]))
                {
                    cur = children[prefix[i]];
                    children = cur.children;
                }
                else
                {
                    return false;
                }
			}

			return true;
		}

        /// <summary>
        /// Searches for a word in the trie under the following req
        /// .. if the word is a regular word, nothing changes 
        /// .. if the word has a '.' then we match any character.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool SearchWord(string word)
        {
            return SearchWordHelper(word, this.root);
        }

        private bool SearchWordHelper(string word, TrieNode node)
        {
            if (string.IsNullOrEmpty(word)) return false;

            TrieNode cur = node;
            var children = cur.children;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == '.')
                {
                    string newWord = word.Substring(i+1);
                    foreach (var child in children.Values)
                    {
                        if (SearchWordHelper(newWord, child)) return true;
                    }
                    return false;
                }
                else
                {
                    if (!children.ContainsKey(word[i])) return false;

                    cur = children[word[i]];
                    children = cur.children;
                }
            }

            return cur.terminates;
        }
	}
}
