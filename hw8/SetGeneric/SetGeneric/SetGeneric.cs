using System;
using System.Collections.Generic;
using System.Text;

namespace SetGeneric
{
    /// <summary>
    /// Set is an abstract data type that can store unique values.
    /// </summary>
    public class Set<T> : ISet<T> where T : IComparable<T>
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
            if (currentNode.Item.Equals(item))
            {
                return true;
            }
            else if (currentNode.Item.CompareTo(item) < 0 && currentNode.LeftChild == null)
            {
                return false;
            }
            else if (currentNode.Item.CompareTo(item) > 0 && currentNode.RightChild == null)
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

        /// <summary>
        /// Adds an element to the current set and returns a value to indicate if the element was successfully added.
        /// </summary>
        /// <param name="item">Element to add.</param>
        /// <returns>True if the element was successfully added.</returns>
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
            else
            {
                AddRecursion(head, item);
            }
            ++count;
            return true;
        }

        private void AddRecursion(Node currentNode, T item)
        {
            if (currentNode.Item.CompareTo(item) < 0 && currentNode.LeftChild != null)
            {
                AddRecursion(currentNode.LeftChild, item);
            }
            else if (currentNode.Item.CompareTo(item) > 0 && currentNode.RightChild != null)
            {
                AddRecursion(currentNode.RightChild, item);
            }
            else
            {
                if (currentNode.Item.CompareTo(item) < 0)
                {
                    currentNode.LeftChild = new Node(item);
                }
                else
                {
                    currentNode.RightChild = new Node(item);
                }
            }
        }

        public bool Remove(T item)
        {
            if (head == null)
            {
                return false;
            }
            if (!Contains(item))
            {
                return false;
            }

            return true;
        }

        public void RemoveRecursion(Node currentNode, T item)
        {

        }

        /// <summary>
        /// Removes all items from the Set.
        /// </summary>
        public void Clear()
        {
            head = null;
            count = 0;
        }

        /// <summary>
        /// Copies the elements of the Set to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="destination">The one-dimensional Array that is the destination of the elements copied from Set. 
        /// The Array must have zero-based indexing.</param>
        /// <param name="copyingStartsFrom">The zero-based index in array at which copying begins.</param>
        /// <exception cref="EmptySetException">Thrown when the Set is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index at which copying starts is 
        /// invalid.</exception>
        /// <exception cref="ArgumentException">Thrown when the number of the elements in the list is greater than the
        /// available space in the array.</exception>
        public void CopyTo(T[] destination, int copyingStartsFrom)
        {
            if (copyingStartsFrom < 0 || copyingStartsFrom >= count)
            {
                throw new ArgumentOutOfRangeException($"Invalid index \"copyingStartsFrom\" {copyingStartsFrom}!!!\n");
            }
            if (head == null)
            {
                throw new EmptySetException("The set is empty!!! Invalid operation.\n");
            }
            if (destination.Length < count - copyingStartsFrom)
            {
                throw new ArgumentException("The number of elements in the Set is greater than the available space " +
                        "from the index to the end of destination array\n");
            }
            
        }

        private T Traversal(Node currentNode, T[] destination, ref int copyToPos)
        {
            if (currentNode.LeftChild != null)
            {
                return Traversal(currentNode.LeftChild, destination, ref copyToPos);
            }
            if (currentNode.RightChild != null)
            {
                return Traversal(currentNode.RightChild, destination, ref copyToPos);
            }
            return currentNode.Item;
        }

        /// <summary>
        /// Gets a value indicating whether the Set is read-only.
        /// </summary>
        public bool IsReadOnly => false;
    }
}
