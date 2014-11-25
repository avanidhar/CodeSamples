using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
	class MyHashTable
	{
		List<HashElement>[] elements { get; set; }

		public MyHashTable() 
		{
			this.elements = new List<HashElement>[100];
		}

		public void Put(string key, int value) 
		{
			int HashValue = GetHash(key);
			if (this.Exists(key)) 
			{
				throw new Exception("An element already exists for this key");
			}
			if (this.elements[HashValue] == null) 
			{
				elements[HashValue] = new List<HashElement>();
			}

			elements[HashValue].Add(new HashElement(key, value));
		}

		public int Get(string key) 
		{
			int HashValue = GetHash(key);
			foreach (var element in elements[HashValue]) 
			{
				if (element.Key.Equals(key)) 
				{
					return element.Value;
				}
			}

			return 9999;
		}

		public int Size() 
		{
			int size = 0;
			foreach(List<HashElement> elementList in elements)
			{
				size += elementList.Count;
			}
			return size;
		}

		public IEnumerable<string> GetKeys() 
		{
			IList<string> keys = new List<string>();
			foreach (var itemList in this.elements) 
			{
				foreach (HashElement element in itemList) 
				{
					keys.Add(element.Key);
				}
			}

			return keys;
		}

		public bool Exists(String key) 
		{
			int hash = GetHash(key);
			if (elements[hash] == null) return false;
			return elements[hash].Exists(item => item.Key.Equals(key));
		}
		private static int GetHash(string s)
		{
			int value = 0;
			foreach(char c in s)
			{
				value += c - 'a';
			}
			return value % 100;
		}
	}

	class HashElement
	{
		public string Key { get; set; }

		public int Value { get; set; }

		public HashElement(string key, int value) 
		{
			Key = key;
			Value = value;
		}
	}
}
