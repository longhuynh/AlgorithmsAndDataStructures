namespace Queue.Array
{
    /// <summary>
    /// A First In First Out collection
    /// </summary>
    /// <typeparam name="T">The type of data stored in the collection</typeparam>
    public class Queue<T> : System.Collections.Generic.IEnumerable<T>
    {
        private T[] items = new T[0];

        // the number of items in the queue
        private int size = 0;

        // the index of the first (oldest) item in the queue
        private int head = 0;

        // the index of the last (newest) item in the queue
        private int tail = -1;

        /// <summary>
        /// Adds an item to the back of the queue
        /// </summary>
        /// <param name="item">The item to place in the queue</param>
        public void Enqueue(T item)
        {
            // if the array needs to grow
            if (items.Length == size)
            {
                int newLength = (size == 0) ? 4 : size*2;

                T[] newArray = new T[newLength];

                if (size > 0)
                {
                    // copy contents...
                    // if the array has no wrapping, just copy the valid range
                    // else copy from head to end of the array and then from 0 to the tail
                    // if tail is less than head we've wrapped
                    int targetIndex = 0;

                    if (tail < head)
                    {
                        // copy the _items[head].._items[end] -> newArray[0]..newArray[N]
                        for (int index = head; index < items.Length; index++)
                        {
                            newArray[targetIndex] = items[index];
                            targetIndex++;
                        }

                        // copy _items[0].._items[tail] -> newArray[N+1]..
                        for (int index = 0; index <= tail; index++)
                        {
                            newArray[targetIndex] = items[index];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        // copy the _items[head].._items[tail] -> newArray[0]..newArray[N]
                        for (int index = head; index <= tail; index++)
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

            // if _tail is at the end of the array we need to wrap around
            if (tail == items.Length - 1)
            {
                tail = 0;
            }
            else
            {
                tail++;
            }

            items[tail] = item;
            size++;
        }

        /// <summary>
        /// Removes and returns the front item from the queue
        /// </summary>
        /// <returns>The front item from the queue</returns>
        public T Dequeue()
        {
            if (size == 0)
            {
                throw new System.InvalidOperationException("The queue is empty");
            }

            T value = items[head];

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

            size--;

            return value;
        }

        /// <summary>
        /// Returns the front item from the queue without removing it from the queue
        /// </summary>
        /// <returns>The front item from the queue</returns>
        public T Peek()
        {
            if (size == 0)
            {
                throw new System.InvalidOperationException("The queue is empty");
            }

            return items[head];
        }

        /// <summary>
        /// The number of items in the queue
        /// </summary>
        public int Count => size;

        /// <summary>
        /// Removes all items from the queue
        /// </summary>
        public void Clear()
        {
            size = 0;
            head = 0;
            tail = -1;
        }

        /// <summary>
        /// Returns an enumerator that enumerates the queue
        /// </summary>
        /// <returns>The enumerator</returns>
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            if (size > 0)
            {
                // if the queue wraps then handle that case
                if (tail < head)
                {
                    // head -> end
                    for (int index = head; index < items.Length; index++)
                    {
                        yield return items[index];
                    }

                    // 0 -> tail
                    for (int index = 0; index <= tail; index++)
                    {
                        yield return items[index];
                    }
                }
                else
                {
                    // head -> tail
                    for (int index = head; index <= tail; index++)
                    {
                        yield return items[index];
                    }
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that enumerates the queue
        /// </summary>
        /// <returns>The enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
