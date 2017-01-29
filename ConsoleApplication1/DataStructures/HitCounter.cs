using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataStructures
{
    interface IHitCounter
    {
        void recordHit();
        long getHitsInLastFiveMins();
    }

    /// <summary>
    /// This implements a rudimentary hit counter
    /// Hits are recorded per second. We will keep track of the 
    /// total number of entries in the hit counter dictionary
    /// We only need to keep track of the last 5 minutes worth of
    /// hits, so we can discard the rest.
    /// </summary>
    public class HitCounter : IHitCounter
    {
        private readonly int numSlots = 5*60;

        private int StartTime;
        private long TotalHits;
        private Dictionary<int, long> hitCounter = new Dictionary<int, long>();
        public HitCounter()
        {
            StartTime = DateTime.Now.Second;
            TotalHits = 0L;
        }
        public long getHitsInLastFiveMins()
        {
            return TotalHits;
        }

        public void recordHit()
        {
            int curTime = DateTime.Now.Second;
            if (hitCounter.ContainsKey(curTime))
            {
                hitCounter[curTime]++;
            }
            else
            {
                hitCounter.Add(curTime, 1L);
            }

            TotalHits++;

            if(curTime - StartTime >= numSlots)
            {
                TotalHits -= hitCounter[StartTime];
                hitCounter.Remove(StartTime);
                StartTime++;
            }
        }
    }
}
