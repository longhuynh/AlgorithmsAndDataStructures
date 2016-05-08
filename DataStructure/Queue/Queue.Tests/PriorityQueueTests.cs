using NUnit.Framework;
using PriorityQueue;

namespace Queue.Tests
{
    [TestFixture]
    public class PriorityQueueTests
    {
        [Test]
        public void EnqueueSimple()
        {
            var queue = new PriorityQueue<int>();
            for (var i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            Assert.AreEqual(queue.Count, 10, "The wrong number of items are in the queue");

            var expected = 9;
            while (queue.Count > 0)
            {
                Assert.AreEqual(expected, queue.Dequeue(), "The expected priority value was not dequeued");
                expected--;
            }
        }

        [Test]
        public void EnqueueSpecific()
        {
            var queue = new PriorityQueue<int>();

            queue.Enqueue(5);
            queue.Enqueue(4);
            queue.Enqueue(2);
            queue.Enqueue(4);
            queue.Enqueue(6);
            queue.Enqueue(3);

            Assert.AreEqual(6, queue.Dequeue(), "Unexpected pq value");
            Assert.AreEqual(5, queue.Dequeue(), "Unexpected pq value");
            Assert.AreEqual(4, queue.Dequeue(), "Unexpected pq value");
            Assert.AreEqual(4, queue.Dequeue(), "Unexpected pq value");
            Assert.AreEqual(3, queue.Dequeue(), "Unexpected pq value");
            Assert.AreEqual(2, queue.Dequeue(), "Unexpected pq value");
        }

        [Test]
        public void EnumerationSimple()
        {
            int[] input = {2, 4, 7, 4, 2, 8, 1};
            int[] expected = {8, 7, 4, 4, 2, 2, 1};

            var queue = new PriorityQueue<int>();

            foreach (var i in input)
            {
                queue.Enqueue(i);
            }

            var index = 0;

            foreach (var i in queue)
            {
                Assert.AreEqual(expected[index], i, "The enumerated value was unexpected");
                index++;
            }
        }
    }
}