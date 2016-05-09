using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack.Array
{
    /// <summary>
    ///     A Last In First Out (LIFO) collection implemented as an array.
    /// </summary>
    /// <typeparam name="T">The type of item contained in the stack</typeparam>
    public class Stack<T> : IEnumerable<T>
    {
        // The array of items contained in the stack.  
        // Initialized to 0 length, will grow as needed during Push
        private T[] items = new T[0];
        
        /// <summary>
        ///     The current number of items in the stack
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        /// <summary>
        ///     Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Adds the specified item to the stack
        /// </summary>
        /// <param name="item">The item</param>
        public void Push(T item)
        {
            // Size = 0 ... first push
            // Size == length ... growth boundary
            if (Count == items.Length)
            {
                // Initial size of 4, otherwise double the current length
                var newLength = Count == 0 ? 4 : Count*2;

                // Allocate, copy and assign the new array
                var newArray = new T[newLength];
                items.CopyTo(newArray, 0);
                items = newArray;
            }

            // Add the item to the stack array and increase the size
            items[Count] = item;
            Count++;
        }

        /// <summary>
        ///     Removes and returns the top item from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            Count--;
            return items[Count];
        }

        /// <summary>
        ///     Returns the top item from the stack without removing it from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return items[Count - 1];
        }

        /// <summary>
        ///     Removes all items from the stack
        /// </summary>
        public void Clear()
        {
            Count = 0;
        }
    }
}