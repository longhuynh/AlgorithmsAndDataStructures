using BinaryTree;
using NUnit.Framework;

namespace BinaryTreeTests
{
    [TestFixture]
    public class EnumerationTests
    {
        [Test]
        public void EnumeratorOfSingle()
        {
            var tree = new BinaryTree<int>();

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
            var tree = new BinaryTree<int> {4, 5, 2, 7, 3, 6, 1, 8};

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8


            int[] expected = {1, 2, 3, 4, 5, 6, 7, 8};

            var index = 0;

            tree.InOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [Test]
        public void InOrderEnumerator()
        {
            var tree = new BinaryTree<int> {4, 5, 2, 7, 3, 6, 1, 8};

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8


            int[] expected = {1, 2, 3, 4, 5, 6, 7, 8};

            var index = 0;

            foreach (var actual in tree)
            {
                Assert.AreEqual(expected[index++], actual, "The item enumerated in the wrong order");
            }
        }

        [Test]
        public void PostOrderDelegate()
        {
            var tree = new BinaryTree<int> {4, 5, 2, 7, 3, 6, 1, 8};

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8
            
            int[] expected = {1, 3, 2, 6, 8, 7, 5, 4};

            var index = 0;

            tree.PostOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [Test]
        public void PreOrderDelegate()
        {
            var tree = new BinaryTree<int> {4, 5, 2, 7, 3, 6, 1, 8};

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8


            int[] expected = {4, 2, 1, 3, 5, 7, 6, 8};

            var index = 0;

            tree.PreOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }
    }
}