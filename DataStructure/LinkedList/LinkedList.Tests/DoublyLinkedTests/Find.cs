using NUnit.Framework;

namespace DoublyLinkedList.Tests
{
    [TestFixture]
    public class Find
    {
        [Test]
        public void FindEmpty()
        {
            LinkedList<int> list = new LinkedList<int>();
            Assert.IsFalse(list.Contains(10), "Nothing should have been found.");
        }

        [Test, TestCaseSource("FindMissingCases")]
        public void FindMissing(int[] testData, int value)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int data in testData)
            {
                list.AddLast(new LinkedListNode<int>(data));
            }

            Assert.IsFalse(list.Contains(value), "Nothing should have been found.");
        }

        [Test, TestCaseSource("FindFoundCases")]
        public void FindFound(int[] testData, int value)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int data in testData)
            {
                list.AddLast(new LinkedListNode<int>(data));
            }

            Assert.IsTrue(list.Contains(value), "There should have been a node found");
        }

        static object[] FindMissingCases =
                     {
                       new object[] { new int[] { 0 }, 10 },
                       new object[] { new int[] { 0, 1 }, 10 },
                       new object[] { new int[] { 0, 1, 2 }, 10 },
                       new object[] { new int[] { 0, 1, 2, 3 }, 10 }
                     };

        static object[] FindFoundCases =
                     {
                       new object[] { new int[] { 10 }, 10 },
                       new object[] { new int[] { 10, 0 }, 10 },
                       new object[] { new int[] { 0, 10 }, 10 },
                       new object[] { new int[] { 0, 1, 10 }, 10 },
                       new object[] { new int[] { 0, 10, 0 }, 10 },
                     };

    }
}
