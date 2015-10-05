using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
    public class LruCache
    {
        public static int CACHELEN = 5;
        LinkedList<int> data;

        Dictionary<string, int> resourceMap;

        public LruCache()
        {
            data = new LinkedList<int>();
            resourceMap = new Dictionary<string, int>();           
        }

        public void Set(string key, int value)
        {
            if (resourceMap.ContainsKey(key))
            {
                Console.WriteLine("Cache already has item");
                return;
            }

            if((this.data.Count) == CACHELEN)
            {
                int valToEject = this.data.Last.Value;
                this.data.RemoveLast();

                this.removeFromResourceMap(valToEject);
            }

            this.data.AddFirst(value);
            this.resourceMap.Add(key, value);
        }

        public int Get(string key)
        {
            if (!resourceMap.ContainsKey(key))
            {
                return -1;
            }

            int val = resourceMap[key];

            // Remove the value from wherever it is in the list and move it to the front
            this.data.Remove(val);
            this.data.AddFirst(val);

            return val;
        }

        public void removeFromResourceMap(int value)
        {
            var itemToRemove = this.resourceMap.First(kvp => kvp.Value == value);
            this.resourceMap.Remove(itemToRemove.Key);
        }
    }
}
