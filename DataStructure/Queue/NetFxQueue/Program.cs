using System;
using System.Collections.Generic;

namespace NetFxQueue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var queue = new Queue<int>();

            for (var i = 0; i < 10; i++)
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