﻿using NUnit.Framework;
using Sorting;
using System;

namespace SortingTests
{
    [TestFixture]
    public class SortingCorrectnessTests
    {
        public readonly ISorter<int>[] SortingTypes =
        {
            new BubbleSort<int>(),
            new InsertionSort<int>(),
            new MergeSort<int>(),
            new SelectionSort<int>(),
            new QuickSort<int>(),
        };

        [TestCaseSource("SortingTypes")]
        public void PreSorted(ISorter<int> sorter)
        {
            int[] presorted = new[] {int.MinValue, 0, 1, 2, 3, 4, 5, 6, 7, int.MaxValue};
            sorter.Sort(presorted);

            AssertArrayIsSorted(presorted);
        }

        [TestCaseSource("SortingTypes")]
        public void AllReversed(ISorter<int> sorter)
        {
            int[] reversed = {int.MaxValue, 7, 6, 5, 4, 3, 2, 1, 0, int.MinValue};
            sorter.Sort(reversed);

            AssertArrayIsSorted(reversed);
        }

        [TestCaseSource("SortingTypes")]
        public void SingleOutOfOrder(ISorter<int> sorter)
        {
            int[] values = {3, 8, 2, 1, 5, 4, 6, 7};
            sorter.Sort(values);

            AssertArrayIsSorted(values);
        }

        [TestCaseSource("SortingTypes")]
        public void MultipleOutOfOrder(ISorter<int> sorter)
        {
            int[] values = {4, 3, 1, 2};
            sorter.Sort(values);

            AssertArrayIsSorted(values);
        }

        [TestCaseSource("SortingTypes")]
        public void RandomValuesSort(ISorter<int> sorter)
        {
            int[] items = new int[1000];
            Random random = new Random();

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = random.Next();
            }

            sorter.Sort(items);
            AssertArrayIsSorted(items);
        }

        [TestCaseSource("SortingTypes")]
        public void EmptyDoesNotCompareOrSwap(ISorter<int> sorter)
        {
            int[] empty = {};
            sorter.Sort(empty);
        }


        private void AssertArrayIsSorted(int[] values)
        {
            int previous = int.MinValue;

            foreach (int current in values)
            {
                Assert.IsTrue(previous <= current, "The current value is greater than the previous value (not sorted)");
                previous = current;
            }
        }
    }
}
