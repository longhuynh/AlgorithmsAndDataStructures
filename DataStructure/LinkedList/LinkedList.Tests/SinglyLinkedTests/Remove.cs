using NUnit.Framework;

namespace LinkedList.Tests
{
    [TestFixture]
    public class Remove
    {
        [Test]
        public void RemoveFirstLastEmptyLists()
        {
            LinkedList<int> list = new LinkedList<int>();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);

            list.RemoveFirst();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);

            list.RemoveLast();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [Test]
        public void RemoveFirstLastOneNode()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddFirst(10);
            list.RemoveFirst();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);

            list.AddFirst(10);
            list.RemoveLast();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);            
        }

        [Test]
        public void RemoveFirstLastTwoNode()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddFirst(10);
            list.AddFirst(20);

            list.RemoveFirst();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(10, list.Head.Value);
            Assert.AreEqual(10, list.Tail.Value);

            list.AddFirst(10);
            list.RemoveLast();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(10, list.Head.Value);
            Assert.AreEqual(10, list.Tail.Value);
        }


        [Test]
        public void RemoveFirstTenNodes()
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.AddFirst(i);
            }

            for (int i = 10; i > 0; i--) 
            {
                Assert.AreEqual(i, list.Count, "Unexpected list count");
                list.RemoveFirst();
            }

            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [Test]
        public void RemoveLastTenNodes()
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.AddFirst(i);
            }

            for (int i = 10; i > 0; i--)
            {
                Assert.AreEqual(i, list.Count, "Unexpected list count");
                list.RemoveLast();
            }

            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [Test, TestCaseSource("RemoveMissingCases")]
        public void RemoveMissing(int[] testData, int value)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int data in testData)
            {
                list.AddLast(new LinkedListNode<int>(data));
            }

            Assert.IsFalse(list.Remove(value), "Nothing should have been removed");
            Assert.AreEqual(testData.Length, list.Count, "The expected list count was incorrect");
        }

        [Test, TestCaseSource("RemoveFoundCases")]
        public void RemoveFound(int[] testData, int value)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int data in testData)
            {
                list.AddLast(new LinkedListNode<int>(data));
            }

            Assert.IsTrue(list.Remove(value), "A node should have been removed");
            Assert.AreEqual(testData.Length - 1, list.Count, "The expected list count was incorrect");
        }

        static object[] RemoveMissingCases =
                     {
                       new object[] { new int[] { 0 }, 10 },
                       new object[] { new int[] { 0, 1 }, 10 },
                       new object[] { new int[] { 0, 1, 2 }, 10 },
                       new object[] { new int[] { 0, 1, 2, 3 }, 10 }
                     };

        static object[] RemoveFoundCases =
                     {
                       new object[] { new int[] { 10 }, 10 },
                       new object[] { new int[] { 10, 0 }, 10 },
                       new object[] { new int[] { 0, 10 }, 10 },
                       new object[] { new int[] { 0, 0, 10 }, 10 },
                       new object[] { new int[] { 0, 10, 0 }, 10 },
                       new object[] { new int[] { 10, 0, 0}, 10 },
                     };

    }
}
