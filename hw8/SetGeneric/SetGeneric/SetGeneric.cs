using System;
using System.Collections.Generic;
using System.Text;

namespace SetGeneric
{
    /// <summary>
    /// Set is an abstract data type that can store unique values.
    /// </summary>
    public class Set<T> : ISet<T>
    {
        private Node head;
        private int count;

        private class Node
        {
            public Node(T item)
            {
                Item = item;
                Parent = null;
                LeftChild = null;
                RightChild = null;
            }

            public T Item { get; set; }
            
            public Node Parent { get; set; }

            public Node LeftChild { get; set; }

            public Node RightChild { get; set; }
        }

        /// <summary>
        /// Initializes object of the Set class.
        /// </summary>
        public Set()
        {
            head = null;
            count = 0;
        }

        /// <summary>
        /// Gets number of the elements in the Set.
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Determines whether the Set containes a specific value.
        /// </summary>
        public bool Contains(T item)
        {
            if (head == null)
            {
                return false;
            }
            return ContainsRecursion(head, item);
        }

        private bool ContainsRecursion(Node currentNode, T item)
        {
            if (currentNode.Item == item)
            {
                return true;
            }
            else if (currentNode.Item < item && currentNode.RightChild == null)
            {
                return false;
            }
            else if (currentNode.Item > item && currentNode.LeftChild == null)
            {
                return false;
            }

            if (currentNode.LeftChild != null)
            {
                return ContainsRecursion(currentNode.LeftChild, item);
            }
            if (currentNode.RightChild != null)
            {
                return ContainsRecursion(currentNode.RightChild, item);
            }
        }

        public bool Add(T item)
        {
            if (head == null)
            {
                head = new Node(item);
            }
            else if (Contains(item))
            {
                return false;
            }
            ++count;
            return true;
        }
    }
}
