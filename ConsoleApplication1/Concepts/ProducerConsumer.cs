using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1.Concepts
{
    public class ProducerConsumer
    {
        private static readonly Object queueobj = new object();

        private Queue<object> pcqueue;

        public ProducerConsumer()
        {
            pcqueue = new Queue<object>();
        }

        public void Produce(Object o)
        {
            Monitor.Enter(queueobj);
            Console.WriteLine("Producing object {0}", o);
            pcqueue.Enqueue(o);
            Monitor.Pulse(queueobj);
            Monitor.Exit(queueobj);
        }

        public void Consume()
        {
            Monitor.Enter(queueobj);
            while (pcqueue.Count == 0)
            {
                Console.WriteLine("Queue Empty.. waiting");
                Monitor.Wait(queueobj);
            }

            var o = pcqueue.Dequeue();
            Console.WriteLine("Consumed {0}", o);
            Monitor.Exit(queueobj);
        }
    }
}
