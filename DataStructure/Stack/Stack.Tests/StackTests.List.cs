﻿using System;
using NUnit.Framework;
using Stack.List;

namespace Stack.Tests
{
    [TestFixture]
    public class StackTestsList
    {
        private readonly object[] PushTestData =
        {
            new int[0],
            new[] {0},
            new[] {0, 1},
            new[] {0, 1, 2},
            new[] {0, 1, 2, 3},
            new[] {0, 1, 2, 3, 4}
        };

        [Test]
        [TestCaseSource("PushTestData")]
        public void ClearSuccessCases(int[] testData)
        {
            var stack = new Stack<int>();

            foreach (var i in testData)
            {
                stack.Push(i);
            }

            Assert.AreEqual(testData.Length, stack.Count, "Count is not accurate");

            stack.Clear();

            Assert.AreEqual(0, stack.Count);

            foreach (var missing in stack)
            {
                Assert.Fail("There should be nothing in the list");
            }
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromEmptyThrows()
        {
            var s = new Stack<int>();
            s.Peek();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromEmptyThrowsAfterPush()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Pop();
            stack.Peek();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyThrows()
        {
            var stack = new Stack<int>();
            stack.Pop();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyThrowsAfterPush()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Pop();
            stack.Pop();
        }

        [Test]
        [TestCaseSource("PushTestData")]
        public void StackSuccessCases(int[] testData)
        {
            var stack = new Stack<int>();

            for (var i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(stack.Count, i, "The stack count is off");

                stack.Push(testData[i]);

                Assert.AreEqual(stack.Count, i + 1, "The stack count is off");

                Assert.AreEqual(testData[i], stack.Peek(), "The recently pushed value is not peeking");

                var counter = i;
                foreach (var value in stack)
                {
                    Assert.AreEqual(testData[counter], value, "The enumeration is not accurate");
                    counter--;
                }
            }

            Assert.AreEqual(testData.Length, stack.Count, "The end count was not as expected");

            for (var i = testData.Length - 1; i >= 0; i--)
            {
                var expected = testData[i];
                Assert.AreEqual(expected, stack.Peek(), "The peeked value was not expected");
                Assert.AreEqual(expected, stack.Pop(), "The popped value was not expected");
                Assert.AreEqual(i, stack.Count, "The popped value was not expected");
            }
        }
    }
}