using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Concepts
{
    /// <summary>
    /// Creates an integer ID pool of positive integers
    /// </summary>
    public class IntegerIdPool
    {
        private uint m_Counter;

        private Queue<uint> idQueue;
        public IntegerIdPool()
        {
            this.m_Counter = 0;
            this.idQueue = new Queue<uint>();
        }

        public uint getId()
        {
            // We use intmax here, but we can just 
            // use any arbitrary unsigned int too.
            // Just make sure you are checking that the counter does not
            // exceed the max value
            if (this.m_Counter == Int32.MaxValue)
            {
                return idQueue.Dequeue();
            }

            return this.m_Counter++;
        }

        public void releaseId(uint id)
        {
            this.idQueue.Enqueue(id);
        }
    }
}
