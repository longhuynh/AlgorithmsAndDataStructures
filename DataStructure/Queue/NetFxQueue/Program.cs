using System;
using System.Collections.Generic;

namespace NetFxQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
