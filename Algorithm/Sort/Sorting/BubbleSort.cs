using System;
using Tracker;

namespace Sorting
{
    public class BubbleSort<T> : Tracker<T>, ISorter<T>
        where T: IComparable<T>
    {
        public void Sort(T[] items)
        {
            bool swapped;
            int times = 0;
            do
            {
                swapped = false;
                for (int i = 1; i < items.Length - times; i++)
                {
                    if (Compare(items[i - 1], items[i]) > 0)
                    {
                        Swap(items, i - 1, i);
                        swapped = true;
                    }
                }
                times++;
            } while (swapped);
        }
    }
}
