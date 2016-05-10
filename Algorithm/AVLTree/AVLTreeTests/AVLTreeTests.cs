using System;
using System.Collections.Generic;
using System.Diagnostics;
using AVLTree;
using NUnit.Framework;

namespace AVLTreeTests
{
    [TestFixture]
    public class EnumerationTests
    {
        [Test]
        public void AddAndRemove1KUniqueItems()
        {
            var tree = new AVLTree<int>();
            var items = new List<int>();

            // add random unique items to the tree
            var rng = new Random();
            while (items.Count < 1000)
            {
                var next = rng.Next();
                if (!items.Contains(next))
                {
                    items.Add(next);
                    tree.Add(next);

                    Assert.AreEqual(items.Count, tree.Count, "items and tree collection should have the same count");
                }
            }

            // make sure they all exist in the tree
            foreach (var value in items)
            {
                Assert.IsTrue(tree.Contains(value), "The tree does not contain the expected value " + value);
            }

            // remove the item from the tree and make sure it's gone
            foreach (var value in items)
            {
                Assert.IsTrue(tree.Remove(value), "The tree does not contain the expected value " + value);
                Assert.IsFalse(tree.Contains(value), "The tree should not have contained the value " + value);
                Assert.IsFalse(tree.Remove(value), "The tree should not have contained the value " + value);
            }

            // now make sure the tree is empty
            Assert.AreEqual(0, tree.Count, "The tree should be empty");
        }

        [Test]
        public void EnumeratorOfSingle()
        {
            var tree = new AVLTree<int>();

            foreach (var item in tree)
            {
                Assert.Fail("An empty tree should not enumerate any values");
            }

            Assert.IsFalse(tree.Contains(10), "Tree should not contain 10 yet");

            tree.Add(10);

            Assert.IsTrue(tree.Contains(10), "Tree should contain 10");

            var count = 0;
            foreach (var item in tree)
            {
                count++;
                Assert.AreEqual(1, count, "There should be exactly one item");
                Assert.AreEqual(item, 10, "The item value should be 10");
            }
        }

        [Test]
        public void InOrderDelegate()
        {
            var tree = new AVLTree<int>();

            var expected = new List<int>();
            for (var i = 0; i < 100; i++)
            {
                tree.Add(i);
                expected.Add(i);
            }

            var index = 0;

            tree.InOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [Test]
        public void LeftRightRotationBasic()
        {
            var tree = new AVLTree<int> {1, 3, 2};

            //  1
            //   \
            //    3
            //   /
            //  2

            //   2
            //  / \
            // 1   3

            int[] expected = {2, 1, 3};
            var index = 0;

            tree.PreOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [Test]
        public void LeftRotationBasic()
        {
            var tree = new AVLTree<int> {1, 2, 3};

            //  1
            //   \
            //    2
            //     \
            //      3

            //   2
            //  / \
            // 1   3

            int[] expected = {2, 1, 3};
            var index = 0;

            tree.PreOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [Test]
        public void RightLeftRotationBasic()
        {
            var tree = new AVLTree<int> {3, 1, 2};

            //   3
            //  /
            // 1
            //  \
            //   2

            //   2
            //  / \
            // 1   3

            int[] expected = {2, 1, 3};
            var index = 0;

            tree.PreOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [Test]
        public void RightRotationBasic()
        {
            var tree = new AVLTree<int> {3, 2, 1};

            //      3
            //     /
            //    2
            //   /
            //  1

            //   2
            //  / \
            // 1   3

            int[] expected = {2, 1, 3};
            var index = 0;

            tree.PreOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }


        [Test]
        public void RotationComplexish()
        {
            var tree = new AVLTree<int> {3, 2, 1};

            //      3
            //     /
            //    2
            //   /
            //  1

            //   2
            //  / \
            // 1   3

            int[] expected = {2, 1, 3};
            var index = 0;

            tree.PreOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
            Assert.AreEqual(index, expected.Length, "The wrong number of items were enumerated?");

            //   2
            //  / \
            // 1   3
            //      \
            //       4

            tree.Add(4);

            expected = new[] {2, 1, 3, 4};
            index = 0;

            tree.PreOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
            Assert.AreEqual(index, expected.Length, "The wrong number of items were enumerated?");

            //   2
            //  / \
            // 1   3
            //      \
            //       4
            //        \
            //         5

            tree.Add(5);

            //   2
            //  / \
            // 1   4
            //    /  \
            //   3    5

            expected = new[] {2, 1, 4, 3, 5};
            index = 0;

            tree.PreOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
            Assert.AreEqual(index, expected.Length, "The wrong number of items were enumerated?");

            //   2
            //  / \
            // 1   4
            //    /  \
            //   3    5
            //         \
            //          6

            tree.Add(6);

            //     4
            //    / \
            //   2   5
            //  / \   \
            // 1   3   6

            expected = new[] {4, 2, 1, 3, 5, 6};
            index = 0;

            tree.PreOrderTraversal(item => Debug.WriteLine(item));

            tree.PreOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
            Assert.AreEqual(index, expected.Length, "The wrong number of items were enumerated?");
        }
    }
}