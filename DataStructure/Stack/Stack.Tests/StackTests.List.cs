using Stack.List;
using NUnit.Framework;
using System;

namespace Stack.Tests
{
    [TestFixture]
    public class StackTestsList
    {
        [Test]
        [TestCaseSource("PushTestData")]
        public void StackSuccessCases(int[] testData)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(stack.Count, i, "The stack count is off");

                stack.Push(testData[i]);

                Assert.AreEqual(stack.Count, i + 1, "The stack count is off");

                Assert.AreEqual(testData[i], stack.Peek(), "The recently pushed value is not peeking");

                int counter = i;
                foreach (int value in stack)
                {
                    Assert.AreEqual(testData[counter], value, "The enumeration is not accurate");
                    counter--;
                }
            }

            Assert.AreEqual(testData.Length, stack.Count, "The end count was not as expected");

            for (int i = testData.Length - 1; i >= 0; i--)
            {
                int expected = testData[i];
                Assert.AreEqual(expected, stack.Peek(), "The peeked value was not expected");
                Assert.AreEqual(expected, stack.Pop(), "The popped value was not expected");
                Assert.AreEqual(i, stack.Count, "The popped value was not expected");
            }
        }

        [Test]
        [TestCaseSource("PushTestData")]
        public void ClearSuccessCases(int[] testData)
        {
            Stack<int> s = new Stack<int>();

        	foreach (int i in testData)
            {
                s.Push(i);
            }

            Assert.AreEqual(testData.Length, s.Count, "Count is not accurate");

            s.Clear();

            Assert.AreEqual(0, s.Count);

            foreach (int missing in s)
            {
                Assert.Fail("There should be nothing in the list");
            }
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyThrows()
        {
            Stack<int> s = new Stack<int>();
            s.Pop();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyThrowsAfterPush()
        {
            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Pop();
            s.Pop();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromEmptyThrows()
        {
            Stack<int> s = new Stack<int>();
            s.Peek();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromEmptyThrowsAfterPush()
        {
            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Pop();
            s.Peek();
        }

        object[] PushTestData = new[]
                                 {
                                     new int[0],
                                     new [] { 0 },
                                     new [] { 0, 1 },
                                     new [] { 0, 1, 2 },
                                     new [] { 0, 1, 2, 3 },
                                     new [] { 0, 1, 2, 3, 4 },
                                 };
    }
}
