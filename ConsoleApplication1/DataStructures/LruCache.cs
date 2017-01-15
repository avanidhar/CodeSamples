using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
    public class CacheNode
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public CacheNode next, previous;

        public CacheNode(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }
    public class LruCache
    {
        private int CACHELEN;
        public int count;
        LinkedList<int> data;

        CacheNode head, tail;

        Dictionary<int, CacheNode> resourceMap;

        public LruCache(int len)
        {
            this.CACHELEN = len;
            data = new LinkedList<int>();
            resourceMap = new Dictionary<int, CacheNode>();
            count = 0;
            head = new CacheNode(0,0);
            tail = new CacheNode(0,0);
            head.next = tail;
            tail.previous = head;
        }

        private void AddToHead(CacheNode d)
        {
            CacheNode next = head.next;
            d.next = head.next;
            head.next.previous = d;
            d.previous = head;
            head.next = d;
        }

        private void deleteNode(CacheNode d)
        {
            CacheNode prev = d.previous;
            prev.next = d.next;
            d.next.previous = prev;
        }
        public void Set(int key, int value)
        {
            if (resourceMap.ContainsKey(key))
            {
                CacheNode d = resourceMap[key];
                d.Value = value;
                deleteNode(d);
                AddToHead(d);
            }
            else
            {
                CacheNode toInsert = new CacheNode(key, value);
                resourceMap.Add(key, toInsert);

                if (count < CACHELEN)
                {
                    AddToHead(toInsert);
                    count++;
                }
                else
                {
                    resourceMap.Remove(tail.previous.Key);
                    deleteNode(tail.previous);
                    AddToHead(toInsert);
                }
            }
        }

        public int Get(int key)
        {
            if (!resourceMap.ContainsKey(key))
            {
                return -1;
            }

            CacheNode resultNode = resourceMap[key];
            int result = resultNode.Value;
            deleteNode(resultNode);
            AddToHead(resultNode);
            return result;
        }
    }
}
