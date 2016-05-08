﻿using System;

namespace Queue.List
{
    /// <summary>
    /// A First In First Out collection
    /// </summary>
    /// <typeparam name="T">The type of data stored in the collection</typeparam>
    public class Queue<T> : System.Collections.Generic.IEnumerable<T>
    {
        // the queued items - the Last list item is the
        // newest queue item, the First is the oldest.
        // This is so LinkedList<T>.GetEnumerator "just works" 
        private readonly System.Collections.Generic.LinkedList<T> items =
            new System.Collections.Generic.LinkedList<T>();

        /// <summary>
        /// Adds an item to the back of the queue
        /// </summary>
        /// <param name="item">The item to place in the queue</param>
        public void Enqueue(T item)
        {
            items.AddLast(item);
        }

        /// <summary>
        /// Removes and returns the front item from the queue
        /// </summary>
        /// <returns>The front item from the queue</returns>
        public T Dequeue()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            // store the last value in a temporary variable
            T value = items.First.Value;

            // remove the last item
            items.RemoveFirst();

            // return the stored last value
            return value;
        }

        /// <summary>
        /// Returns the front item from the queue without removing it from the queue
        /// </summary>
        /// <returns>The front item from the queue</returns>
        public T Peek()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            // return the last value in the queue
            return items.First.Value;
        }

        /// <summary>
        /// The number of items in the queue
        /// </summary>
        public int Count => items.Count;

        /// <summary>
        /// Removes all items from the queue
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }

        /// <summary>
        /// Returns an enumerator that enumerates the queue
        /// </summary>
        /// <returns>The enumerator</returns>
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that enumerates the queue
        /// </summary>
        /// <returns>The enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
