using System;
using System.Collections;
using System.Collections.Generic;

namespace PriorityQueue
{
    /// <summary>
    ///     A collection that returns the highest priority item first and lowest priority item last.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the collection</typeparam>
    public class PriorityQueue<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly LinkedList<T> items =
            new LinkedList<T>();

        /// <summary>
        ///     The number of items in the queue
        /// </summary>
        public int Count => items.Count;

        /// <summary>
        ///     Returns an enumerator that enumerates the queue
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        /// <summary>
        ///     Returns an enumerator that enumerates the queue
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        /// <summary>
        ///     Adds an item to the queue in priority order
        /// </summary>
        /// <param name="item">The item to place in the queue</param>
        public void Enqueue(T item)
        {
            // if the list is empty, just add the item
            if (items.Count == 0)
            {
                items.AddLast(item);
            }
            else
            {
                // find the proper insert point
                var current = items.First;

                // while we're not at the end of the list and the current value
                // is larger than the value being inserted...
                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    // we made it to the end of the list
                    items.AddLast(item);
                }
                else
                {
                    // the current item is <= the one being added
                    // so add the item before it.
                    items.AddBefore(current, item);
                }
            }
        }

        /// <summary>
        ///     Removes and returns the highest priority item from the queue
        /// </summary>
        /// <returns>The front item from the queue</returns>
        public T Dequeue()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            // store the last value in a temporary variable
            var value = items.First.Value;

            // remove the last item
            items.RemoveFirst();

            // return the stored last value
            return value;
        }

        /// <summary>
        ///     Returns the highest priority item from the queue without removing it from the queue
        /// </summary>
        /// <returns>The front item from the queue</returns>
        public T Peek()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return items.First.Value;
        }

        /// <summary>
        ///     Removes all items from the queue
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }
    }
}