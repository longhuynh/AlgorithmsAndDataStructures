using System;

namespace AVLTree
{
    /// <summary>
    ///     An AVL tree node class
    /// </summary>
    /// <typeparam name="TNode"></typeparam>
    public class AVLTreeNode<TNode> : IComparable<TNode>
        where TNode : IComparable
    {
        private AVLTreeNode<TNode> left;

        private AVLTreeNode<TNode> right;

        private readonly AVLTree<TNode> tree;

        public AVLTreeNode(TNode value, AVLTreeNode<TNode> parent, AVLTree<TNode> tree)
        {
            Value = value;
            Parent = parent;
            this.tree = tree;
        }

        private TreeState State
        {
            get
            {
                if (LeftHeight - RightHeight > 1)
                {
                    return TreeState.LeftHeavy;
                }

                if (RightHeight - LeftHeight > 1)
                {
                    return TreeState.RightHeavy;
                }

                return TreeState.Balanced;
            }
        }

        private int BalanceFactor => RightHeight - LeftHeight;

        private int LeftHeight => MaxChildHeight(Left);

        private int RightHeight => MaxChildHeight(Right);

        public AVLTreeNode<TNode> Left
        {
            get { return left; }
            internal set
            {
                left = value;
                if (left != null)
                {
                    left.Parent = this;
                }
            }
        }

        public AVLTreeNode<TNode> Right
        {
            get { return right; }
            internal set
            {
                right = value;
                if (right != null)
                {
                    right.Parent = this;
                }
            }
        }

        public AVLTreeNode<TNode> Parent { get; internal set; }
        public TNode Value { get; }

        /// <summary>
        ///     Compares the current node to the provided value
        /// </summary>
        /// <param name="other">The node value to compare to</param>
        /// <returns>1 if the instance value is greater than the provided value, -1 if less or 0 if equal.</returns>
        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }

        internal void Balance()
        {
            if (State == TreeState.RightHeavy)
            {
                if (Right != null && Right.BalanceFactor < 0)
                {
                    LeftRightRotation();
                }
                else
                {
                    LeftRotation();
                }
            }
            else if (State == TreeState.LeftHeavy)
            {
                if (Left != null && Left.BalanceFactor > 0)
                {
                    RightLeftRotation();
                }
                else
                {
                    RightRotation();
                }
            }
        }

        private void LeftRotation()
        {
            //     a
            //      \
            //       b
            //        \
            //         c
            //
            // becomes
            //       b
            //      / \
            //     a   c

            var newRoot = Right;

            // replace the current root with the new root
            ReplaceRoot(newRoot);

            // take ownership of right's left child as right (now parent)
            Right = newRoot.Left;

            // the new root takes this as it's left
            newRoot.Left = this;
        }

        private void RightRotation()
        {
            //     c (this)
            //    /
            //   b
            //  /
            // a
            //
            // becomes
            //       b
            //      / \
            //     a   c

            var newRoot = Left;

            // replace the current root with the new root
            ReplaceRoot(newRoot);

            // take ownership of left's right child as left (now parent)
            Left = newRoot.Right;

            // the new root takes this as it's right
            newRoot.Right = this;
        }

        private void ReplaceRoot(AVLTreeNode<TNode> newRoot)
        {
            if (Parent != null)
            {
                if (Parent.Left == this)
                {
                    Parent.Left = newRoot;
                }
                else if (Parent.Right == this)
                {
                    Parent.Right = newRoot;
                }
            }
            else
            {
                tree.head = newRoot;
            }

            newRoot.Parent = Parent;
            Parent = newRoot;
        }

        private void LeftRightRotation()
        {
            Right.RightRotation();
            LeftRotation();
        }

        private void RightLeftRotation()
        {
            Left.LeftRotation();
            RightRotation();
        }

        private int MaxChildHeight(AVLTreeNode<TNode> node)
        {
            if (node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
            }

            return 0;
        }
    }

    public enum TreeState
    {
        Balanced,
        LeftHeavy,
        RightHeavy
    }
}