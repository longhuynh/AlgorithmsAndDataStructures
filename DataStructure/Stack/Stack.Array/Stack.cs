using System;

namespace Stack.Array
{
    /// <summary>
    /// A Last In First Out (LIFO) collection implemented as an array.
    /// </summary>
    /// <typeparam name="T">The type of item contained in the stack</typeparam>
    public class Stack<T> : System.Collections.Generic.IEnumerable<T>
    {
        // The array of items contained in the stack.  Initialized to 0 length,
        // will grow as needed during Push
        T[] items = new T[0];

        // The current number of items in the stack.
        int size;

        /// <summary>
        /// Adds the specified item to the stack
        /// </summary>
        /// <param name="item">The item</param>
        public void Push(T item)
        {
            // size = 0 ... first push
            // size == length ... growth boundary
            if (size == items.Length)
            {
                // initial size of 4, otherwise double the current length
                int newLength = size == 0 ? 4 : size * 2;

                // allocate, copy and assign the new array
                T[] newArray = new T[newLength];
                items.CopyTo(newArray, 0);
                items = newArray;
            }

            // add the item to the stack array and increase the size
            items[size] = item;
            size++;
        }

        /// <summary>
        /// Removes and returns the top item from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Pop()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            size--;
            return items[size];
        }

        /// <summary>
        /// Returns the top item from the stack without removing it from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return items[size - 1];
        }

        /// <summary>
        /// The current number of items in the stack
        /// </summary>
        public int Count
        {
            get
            {
                return size;
            }
        }

        /// <summary>
        /// Removes all items from the stack
        /// </summary>
        public void Clear()
        {
            size = 0;
        }

        /// <summary>
        /// Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            for (int i = size-1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        /// <summary>
        /// Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
