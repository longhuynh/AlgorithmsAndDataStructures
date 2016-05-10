﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace AVLTree
{
    public class AVLTree<T> : IEnumerable<T>
        where T : IComparable
    {
        internal AVLTreeNode<T> head;

        public AVLTreeNode<T> Head => head;

        /// <summary>
        ///     Returns the number of items currently contained in the tree
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Determines if the specified value exists in the binary tree.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>True if the tree contains the value, false otherwise</returns>
        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        /// <summary>
        ///     Finds and returns the first node containing the specified value.  If the value
        ///     is not found, returns null.  Also returns the parent of the found node (or null)
        ///     which is used in Remove.
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <param name="parent">The parent of the found node (or null)</param>
        /// <returns>The found node (or null)</returns>
        private AVLTreeNode<T> Find(T value)
        {
            // Now, try to find data in the tree
            var current = head;

            // while we don't have a match
            while (current != null)
            {
                var result = current.CompareTo(value);

                if (result > 0)
                {
                    // if the value is less than current, go left.
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // if the value is more than current, go right.
                    current = current.Right;
                }
                else
                {
                    // we have a match!
                    break;
                }
            }

            return current;
        }

        #region Remove

        /// <summary>
        ///     Removes the first occurance of the specified value from the tree.
        /// </summary>
        /// <param name="value">The value to remove</param>
        /// <returns>True if the value was removed, false otherwise</returns>
        public bool Remove(T value)
        {
            AVLTreeNode<T> current;
            current = Find(value);

            if (current == null)
            {
                return false;
            }

            var treeToBalance = current.Parent;

            Count--;

            // Case 1: If current has no right child, then current's left replaces current
            if (current.Right == null)
            {
                if (current.Parent == null)
                {
                    head = current.Left;
                    if (head != null)
                    {
                        head.Parent = null;
                    }
                }
                else
                {
                    var result = current.Parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // if parent value is greater than current value
                        // make the current left child a left child of parent
                        current.Parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        // if parent value is less than current value
                        // make the current left child a right child of parent
                        current.Parent.Right = current.Left;
                    }
                }
            }
            // Case 2: If current's right child has no left child, then current's right child
            //         replaces current
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (current.Parent == null)
                {
                    head = current.Right;
                    if (head != null)
                    {
                        head.Parent = null;
                    }
                }
                else
                {
                    var result = current.Parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // if parent value is greater than current value
                        // make the current right child a left child of parent
                        current.Parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        // if parent value is less than current value
                        // make the current right child a right child of parent
                        current.Parent.Right = current.Right;
                    }
                }
            }
            // Case 3: If current's right child has a left child, replace current with current's
            //         right child's left-most child
            else
            {
                // find the right's left-most child
                var leftmost = current.Right.Left;

                while (leftmost.Left != null)
                {
                    leftmost = leftmost.Left;
                }

                // the parent's left subtree becomes the leftmost's right subtree
                leftmost.Parent.Left = leftmost.Right;

                // assign leftmost's left and right to current's left and right children
                leftmost.Left = current.Left;

                leftmost.Right = current.Right;

                if (current.Parent == null)
                {
                    head = leftmost;
                    if (head != null)
                    {
                        head.Parent = null;
                    }
                }
                else
                {
                    var result = current.Parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // if parent value is greater than current value
                        // make leftmost the parent's left child
                        current.Parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        // if parent value is less than current value
                        // make leftmost the parent's right child
                        current.Parent.Right = leftmost;
                    }
                }
            }

            if (treeToBalance != null)
            {
                treeToBalance.Balance();
            }
            else
            {
                head?.Balance();
            }

            return true;
        }

        #endregion

        /// <summary>
        ///     Removes all items from the tree
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        #region Add

        /// <summary>
        ///     Adds the provided value to the binary tree.
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            // Case 1: The tree is empty - allocate the head
            if (head == null)
            {
                head = new AVLTreeNode<T>(value, null, this);
            }
            // Case 2: The tree is not empty so find the right location to insert
            else
            {
                AddTo(head, value);
            }

            Count++;
        }

        // Recursive add algorithm
        private void AddTo(AVLTreeNode<T> node, T value)
        {
            // Case 1: Value is less than the current node value
            if (value.CompareTo(node.Value) < 0)
            {
                // if there is no left child make this the new left
                if (node.Left == null)
                {
                    node.Left = new AVLTreeNode<T>(value, node, this);
                }
                else
                {
                    // else add it to the left node
                    AddTo(node.Left, value);
                }
            }
            // Case 2: Value is equal to or greater than the current value
            else
            {
                // If there is no right, add it to the right
                if (node.Right == null)
                {
                    node.Right = new AVLTreeNode<T>(value, node, this);
                }
                else
                {
                    // else add it to the right node
                    AddTo(node.Right, value);
                }
            }

            node.Balance();
        }

        #endregion

        #region Pre-Order Traversal

        /// <summary>
        ///     Performs the provided action on each binary tree value in pre-order traversal order.
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, head);
        }

        private void PreOrderTraversal(Action<T> action, AVLTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }

        #endregion

        #region Post-Order Traversal

        /// <summary>
        ///     Performs the provided action on each binary tree value in post-order traversal order.
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, head);
        }

        private void PostOrderTraversal(Action<T> action, AVLTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }

        #endregion

        #region In-Order Enumeration

        /// <summary>
        ///     Performs the provided action on each binary tree value in in-order traversal order.
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, head);
        }

        private void InOrderTraversal(Action<T> action, AVLTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(action, node.Left);

                action(node.Value);

                InOrderTraversal(action, node.Right);
            }
        }

        /// <summary>
        ///     Enumerates the values contains in the binary tree in in-order traversal order.
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<T> InOrderTraversal()
        {
            // This is a non-recursive algorithm using a stack to demonstrate removing
            // recursion to make using the yield syntax easier.
            if (head != null)
            {
                // store the nodes we've skipped in this stack (avoids recursion)
                var stack = new Stack<AVLTreeNode<T>>();

                var current = head;

                // when removing recursion we need to keep track of whether or not
                // we should be going to the left node or the right nodes next.
                var goLeftNext = true;

                // start by pushing Head onto the stack
                stack.Push(current);

                while (stack.Count > 0)
                {
                    // If we're heading left...
                    if (goLeftNext)
                    {
                        // push everything but the left-most node to the stack
                        // we'll yield the left-most after this block
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    // in-order is left->yield->right
                    yield return current.Value;

                    // if we can go right then do so
                    if (current.Right != null)
                    {
                        current = current.Right;

                        // once we've gone right once, we need to start
                        // going left again.
                        goLeftNext = true;
                    }
                    else
                    {
                        // if we can't go right then we need to pop off the parent node
                        // so we can process it and then go to it's right node
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        /// <summary>
        ///     Returns an enumerator that performs an in-order traversal of the binary tree
        /// </summary>
        /// <returns>The in-order enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        /// <summary>
        ///     Returns an enumerator that performs an in-order traversal of the binary tree
        /// </summary>
        /// <returns>The in-order enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}