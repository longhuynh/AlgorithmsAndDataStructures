using AVLTree;
using NUnit.Framework;

namespace AVLTreeTests
{
    internal class RemoveTests
    {
        [Test]
        public void RemoveHead()
        {
            var tree = new AVLTree<int> {4, 5, 2, 7, 3, 6, 1, 8};

            //     4
            //   /   \
            //  2     6
            // / \   / \
            //1   3 5   7
            //           \
            //            8

            tree.Remove(4);

            //     5
            //   /   \
            //  2     6
            // / \     \
            //1   3     7
            //           \
            //            8

            int[] expected = {1, 3, 2, 8, 7, 6, 5};

            var index = 0;
            tree.PostOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [Test]
        public void RemoveHeadLineRight()
        {
            var tree = new AVLTree<int>();

            // 1
            //  \
            //   2
            //    \
            //     3


            tree.Add(1);
            tree.Add(2);
            tree.Add(3);

            tree.Remove(1);

            // 2
            //  \
            //   3


            int[] expected = {3, 2};

            var index = 0;

            tree.PostOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [Test]
        public void RemoveHeadLineLeft()
        {
            var tree = new AVLTree<int> {3, 2, 1};

            //     3
            //    /
            //   2
            //  /
            // 1

            tree.Remove(3);

            //   2
            //  /
            // 1

            int[] expected = {1, 2};

            var index = 0;

            tree.PostOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }


        [Test]
        public void RemoveHeadOnlyNode()
        {
            var tree = new AVLTree<int> {4};


            Assert.IsTrue(tree.Remove(4), "Remove should return true for found node");

            foreach (var item in tree)
            {
                Assert.Fail("An empty tree should not enumerate any values");
            }
        }

        [Test]
        public void RemoveNodeNoLeftChild()
        {
            var tree = new AVLTree<int> {4, 5, 2, 7, 3, 6, 1, 8};

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8


            Assert.IsTrue(tree.Remove(5), "Remove should return true for found node");

            //         4
            //       /  \
            //      2     7
            //     / \   / \
            //    1   3  6  8

            int[] expected = {1, 3, 2, 6, 8, 7, 4};

            var index = 0;

            tree.PostOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [Test]
        public void RemoveNodeRightLeaf()
        {
            var tree = new AVLTree<int> {4, 5, 2, 7, 3, 6, 1, 8};

            //         4
            //       /   \
            //      2     6
            //     / \   / \
            //    1   3 5   7
            //               \
            //               8

            Assert.IsTrue(tree.Remove(8), "Remove should return true for found node");

            //         4
            //       /   \
            //      2     6
            //     / \   / \
            //    1   3 5   7

            int[] expected = {1, 3, 2, 5, 7, 6, 4};

            var index = 0;

            tree.PostOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [Test]
        public void RemoveNodeLeftLeaf()
        {
            var tree = new AVLTree<int> {4, 5, 2, 7, 3, 6, 1, 8};

            //         4
            //       /   \
            //      2     6
            //     / \   / \
            //    1   3 5   7
            //               \
            //               8

            Assert.IsTrue(tree.Remove(1), "Remove should return true for found node");

            //        4
            //      /   \
            //    2      6
            //     \    / \
            //      3  5   7
            //              \
            //               8

            int[] expected = {3, 2, 5, 8, 7, 6, 4};

            var index = 0;

            tree.PostOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }


        [Test]
        public void RemoveCurrentRightHasNoLeft()
        {
            var tree = new AVLTree<int> {4, 6, 5, 2, 7, 3, 1, 8};

            //       5 
            //     /   \
            //    3     7
            //   / \   / \
            //  2   4 6   8
            // /
            //1

            Assert.IsTrue(tree.Remove(4), "Remove should return true for found node");

            //     5 
            //   /   \
            //  2     7
            // / \   / \
            //1   3 6   8

            int[] expected = {1, 3, 2, 6, 8, 7, 5};

            var index = 0;

            tree.PostOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [Test]
        public void RemoveCurrentHasNoRight()
        {
            var tree = new AVLTree<int> {4, 2, 1, 3, 8, 6, 7, 5};

            //         4
            //       /   \
            //      2     8 
            //     / \    /
            //    1   3  6
            //          / \
            //         5   7   


            Assert.IsTrue(tree.Remove(8), "Remove should return true for found node");

            //         4
            //       /   \
            //      2      6 
            //     / \    / \
            //    1   3  5   7

            int[] expected = {1, 3, 2, 5, 7, 6, 4};

            var index = 0;

            tree.PostOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [Test]
        public void RemoveCurrentRightHasLeft()
        {
            var tree = new AVLTree<int> {4, 2, 1, 3, 6, 5, 8, 7};

            //         4
            //       /    \
            //      2      6 
            //     / \    / \
            //    1   3  5   8
            //              /
            //             7


            Assert.IsTrue(tree.Remove(6), "Remove should return true for found node");

            //         4
            //       /    \
            //      2      7 
            //     / \    / \
            //    1   3  5   8

            int[] expected = {1, 3, 2, 5, 8, 7, 4};

            var index = 0;

            tree.PostOrderTraversal(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [Test]
        public void RemoveFromEmpty()
        {
            var tree = new AVLTree<int>();
            Assert.IsFalse(tree.Remove(10));
        }

        [Test]
        public void RemoveMissingFromTree()
        {
            var tree = new AVLTree<int>();

            //         4
            //       /   \
            //      2     8 
            //     / \    /
            //    1   3  6
            //          / \
            //         5   7   

            int[] values = {4, 2, 1, 3, 8, 6, 7, 5};

            foreach (var i in values)
            {
                Assert.IsFalse(tree.Contains(10), "Tree should not contain 10");
                tree.Add(i);
            }
        }
    }
}