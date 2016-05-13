using System;
using System.Threading;

namespace Tracker
{
    public class Tracker<T> : IPerformanceTracker
        where T : IComparable<T>
    {
        private long comparisons;
        private long swaps;

        public long Comparisons => Interlocked.Read(ref comparisons);

        public long Swaps => Interlocked.Read(ref swaps);

        public void Reset()
        {
            Interlocked.Exchange(ref comparisons, 0);
            Interlocked.Exchange(ref swaps, 0);
        }

        protected void Swap(T[] items, int left, int right)
        {
            if (left != right)
            {
                Interlocked.Increment(ref swaps);

                var temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        protected void Assign(T[] items, int index, T value)
        {
            items[index] = value;
            Interlocked.Increment(ref swaps);
        }

        protected int Compare(T lhs, T rhs)
        {
            Interlocked.Increment(ref comparisons);

            return lhs.CompareTo(rhs);
        }
    }
}