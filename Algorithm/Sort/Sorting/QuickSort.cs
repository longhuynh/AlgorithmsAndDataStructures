using System;
using Tracker;

namespace Sorting
{
    public class QuickSort<T> : Tracker<T>, ISorter<T>
        where T : IComparable<T>
    {

        readonly Random random = new Random();

        public void Sort(T[] items)
        {
            QuickSortPartition(items, 0, items.Length - 1);
        }

        private void QuickSortPartition(T[] items, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = random.Next(left, right);
                int newPivot = Partition(items, left, right, pivotIndex);

                QuickSortPartition(items, left, newPivot - 1);
                QuickSortPartition(items, newPivot + 1, right);
            }
        }

        private int Partition(T[] items, int left, int right, int pivotIndex)
        {
            T pivotValue = items[pivotIndex];

            Swap(items, pivotIndex, right);

            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (Compare(items[i], pivotValue) < 0)
                {
                    Swap(items, i, storeIndex);
                    storeIndex += 1;
                }
            }

            Swap(items, storeIndex, right);
            return storeIndex;
        }
    }
}
