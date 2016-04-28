using System;

namespace Stack.List
{
    /// <summary>
    /// A Last In First Out (LIFO) collection implemented as a linked list.
    /// </summary>
    /// <typeparam name="T">The type of item contained in the stack</typeparam>
    public class Stack<T> : System.Collections.Generic.IEnumerable<T>
    {
        private System.Collections.Generic.LinkedList<T> list = 
            new System.Collections.Generic.LinkedList<T>();

        /// <summary>
        /// Adds the specified item to the stack
        /// </summary>
        /// <param name="item">The item</param>
        public void Push(T item)
        {
            list.AddFirst(item);
        }

        /// <summary>
        /// Removes and returns the top item from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Pop()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            T value = list.First.Value;
            list.RemoveFirst();

            return value;
        }

        /// <summary>
        /// Returns the top item from the stack without removing it from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Peek()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return list.First.Value;
        }

        /// <summary>
        /// The current number of items in the stack
        /// </summary>
        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        /// <summary>
        /// Removes all items from the stack
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }

        /// <summary>
        /// Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        /// <summary>
        /// Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
