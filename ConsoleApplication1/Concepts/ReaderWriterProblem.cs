using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1.Concepts
{
    public class ReaderWriterProblem
    {
        private string BUFFER;

        private ReaderWriterLockSlim rwlock;

        private static object lockObject;
        private int readerCount;
        private bool waitingWriter;

        public ReaderWriterProblem()
        {
            BUFFER = string.Empty;
            rwlock = new ReaderWriterLockSlim();
            lockObject = new object();
            readerCount = 0;
            waitingWriter = false;
        }

        #region UseReaderWriterLock
        public void Write(string value)
        {
            rwlock.EnterWriteLock();
            Console.WriteLine("Entered Writelock");
            BUFFER = value;

            rwlock.ExitWriteLock();
            Console.WriteLine("Exited Writelock");
        }

        public void Read()
        {
            rwlock.EnterReadLock();
            Console.WriteLine("Entered read lock");
            Console.WriteLine(BUFFER);
            rwlock.ExitReadLock();
            Console.WriteLine("Exited read lock");
        }
        #endregion

        #region UseMonitorWithWriterStarvation
        public void WriteWithMonitors(string value)
        {
            Monitor.Enter(lockObject);
            while (readerCount > 0)
            {
                Monitor.Wait(lockObject);
            }
            Monitor.Exit(lockObject);

            BUFFER = value;

            Monitor.Enter(lockObject);
            Monitor.Pulse(lockObject);
            Monitor.Exit(lockObject);
        }
        public void ReadWithMonitor()
        {
            Monitor.Enter(lockObject);
            readerCount++;
            Monitor.Exit(lockObject);

            Console.WriteLine(BUFFER);

            Monitor.Enter(lockObject);
            readerCount--;
            if (readerCount == 0)
            {
                Monitor.PulseAll(lockObject);
            }
            Monitor.Exit(lockObject);
        }
        #endregion

        #region UseMonitorWithWritePriority
        public void WriteWithWriterPriority(string value)
        {
            // Enter write
            Monitor.Enter(lockObject);
            waitingWriter = true;
            while (readerCount > 0) Monitor.Wait(lockObject);
            Monitor.Exit(lockObject);

            BUFFER = value;

            Monitor.Enter(lockObject);
            waitingWriter = false;
            Monitor.Pulse(lockObject);
            Monitor.Exit(lockObject);
        }

        public void ReadWithWritePriority()
        {
            Monitor.Enter(lockObject);
            while (waitingWriter)
            {
                Console.WriteLine("Writer waiting. Waiting for writer to get done");
                Monitor.Wait(lockObject);
            }
            readerCount++;
            Monitor.Exit(lockObject);

            Console.WriteLine(BUFFER);

            Monitor.Enter(lockObject);
            readerCount--;
            if (readerCount == 0)
            {
                Monitor.Pulse(lockObject);
            }
            Monitor.Exit(lockObject);
        }
        #endregion
    }
}
