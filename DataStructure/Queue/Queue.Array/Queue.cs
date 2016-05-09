using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue.Array
{
    /// <summary>
    ///     A First In First Out collection
    /// </summary>
    /// <typeparam name="T">The type of data stored in the collection</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        // the index of the first (oldest) item in the queue
        private int head;
        private T[] items = new T[0];

        // the number of items in the queue

        // the index of the last (newest) item in the queue
        private int tail = -1;

        /// <summary>
        ///     The number of items in the queue
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Returns an enumerator that enumerates the queue
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (Count > 0)
            {
                // if the queue wraps then handle that case
                if (tail < head)
                {
                    // head -> end
                    for (var index = head; index < items.Length; index++)
                    {
                        yield return items[index];
                    }

                    // 0 -> tail
                    for (var index = 0; index <= tail; index++)
                    {
                        yield return items[index];
                    }
                }
                else
                {
                    // head -> tail
                    for (var index = head; index <= tail; index++)
                    {
                        yield return items[index];
                    }
                }
            }
        }

        /// <summary>
        ///     Returns an enumerator that enumerates the queue
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Adds an item to the back of the queue
        /// </summary>
        /// <param name="item">The item to place in the queue</param>
        public void Enqueue(T item)
        {
            // if the array needs to grow
            if (items.Length == Count)
            {
                var newLength = Count == 0 ? 4 : Count*2;

                var newArray = new T[newLength];

                if (Count > 0)
                {
                    // copy contents...
                    // if the array has no wrapping, just copy the valid range
                    // else copy from head to end of the array and then from 0 to the tail
                    // if tail is less than head we've wrapped
                    var targetIndex = 0;

                    if (tail < head)
                    {
                        // copy the items[head]..items[end] -> newArray[0]..newArray[N]
                        for (var index = head; index < items.Length; index++)
                        {
                            newArray[targetIndex] = items[index];
                            targetIndex++;
                        }

                        // copy items[0]..items[tail] -> newArray[N+1]..
                        for (var index = 0; index <= tail; index++)
                        {
                            newArray[targetIndex] = items[index];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        // copy the items[head]..items[tail] -> newArray[0]..newArray[N]
                        for (var index = head; index <= tail; index++)
                        {
                            newArray[targetIndex] = items[index];
                            targetIndex++;
                        }
                    }

                    head = 0;
                    tail = targetIndex - 1; // compensate for the extra bump
                }
                else
                {
                    head = 0;
                    tail = -1;
                }

                items = newArray;
            }

            // now we have a properly sized array and can focus on wrapping issues.

            // if tail is at the end of the array we need to wrap around
            if (tail == items.Length - 1)
            {
                tail = 0;
            }
            else
            {
                tail++;
            }

            items[tail] = item;
            Count++;
        }

        /// <summary>
        ///     Removes and returns the front item from the queue
        /// </summary>
        /// <returns>The front item from the queue</returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            var value = items[head];

            if (head == items.Length - 1)
            {
                // if the head is at the last index in the array - wrap around.
                head = 0;
            }
            else
            {
                // move to the next value
                head++;
            }

            Count--;

            return value;
        }

        /// <summary>
        ///     Returns the front item from the queue without removing it from the queue
        /// </summary>
        /// <returns>The front item from the queue</returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return items[head];
        }

        /// <summary>
        ///     Removes all items from the queue
        /// </summary>
        public void Clear()
        {
            Count = 0;
            head = 0;
            tail = -1;
        }
    }
}