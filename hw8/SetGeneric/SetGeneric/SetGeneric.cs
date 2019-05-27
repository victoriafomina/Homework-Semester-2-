using System;
using System.Collections;
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

            if (count == 0)
            {
                return false;
            }

            var currentNode = head;

            while (true)
            {
                if (currentNode.Item.CompareTo(item) > 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        return false;
                    }
                    currentNode = currentNode.LeftChild;
                }
                else if (currentNode.Item.CompareTo(item) < 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        return false;
                    }
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    return true;
                }
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
                    currentNode.Parent = currentNode;
                }
                else
                {
                    currentNode.RightChild = new Node(item);
                    currentNode.Parent = currentNode;
                }
            }
        }

        /// <summary>
        /// Removes an element from the Set (if the element is in the set).
        /// </summary>
        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }

            if (Count == 1)
            {
                head = null;
            }

            RemoveRecursion(head, item);

            return true;
        }

        private void RemoveRecursion(Node currentNode, T item)
        {
            if (currentNode.Item.CompareTo(item) > 0)
            {
                RemoveRecursion(currentNode.LeftChild, item);
            }
            else if (currentNode.Item.CompareTo(item) < 0)
            {
                RemoveRecursion(currentNode.RightChild, item);
            }
            else
            {
                if (currentNode.LeftChild == null || currentNode.RightChild == null)
                {
                    RemoveWhenChildIsNull(currentNode);
                }
                else
                {
                    currentNode.Item = MaximumInSubtree(currentNode);
                    RemoveRecursion(currentNode.LeftChild, currentNode.Item);
                }
            }
        }

        private T MaximumInSubtree(Node current)
        {
            if (current.RightChild != null)
            {
                return MaximumInSubtree(current.RightChild);
            }
            else
            {
                return current.RightChild.Item;
            }
        }

        private void RemoveWhenChildIsNull(Node NodeToRemove)
        {
            if (NodeToRemove.LeftChild == null && NodeToRemove.RightChild == null)
            {
                if (NodeToRemove == NodeToRemove.Parent.LeftChild)
                {
                    NodeToRemove.Parent.LeftChild = null;
                }
                else
                {
                    NodeToRemove.Parent.RightChild = null;
                }
            }
            else if (NodeToRemove.LeftChild == null)
            {
                if (NodeToRemove == NodeToRemove.Parent.LeftChild)
                {
                    NodeToRemove.RightChild.Parent = NodeToRemove.Parent;
                    NodeToRemove.Parent.LeftChild = NodeToRemove.RightChild;
                }
                else
                {
                    NodeToRemove.RightChild.Parent = NodeToRemove.Parent;
                    NodeToRemove.Parent.RightChild = NodeToRemove.RightChild;
                }
            }
            else
            {
                if (NodeToRemove == NodeToRemove.Parent.LeftChild)
                {
                    NodeToRemove.LeftChild.Parent = NodeToRemove.Parent;
                    NodeToRemove.Parent.LeftChild = NodeToRemove.LeftChild;
                }
                else
                {
                    NodeToRemove.LeftChild.Parent = NodeToRemove.Parent;
                    NodeToRemove.Parent.RightChild = NodeToRemove.LeftChild;
                }
            }
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
        /// Getting a set item by index.
        /// </summary>
        public T this[int index]
        {
            get
            {
                if (index >= count || count == 0)
                {
                    throw new IndexOutOfRangeException("Invalid index!\n");
                }
                return TreeTraversal(index);
            }
        }

        private T TreeTraversal(int index)
        {
            var currentNode = head;
            int currentIndex = 0;
            while (true)
            {
                if (CheckWeHaveGotNeededElement(index, currentIndex))
                {
                    return currentNode.Item;
                }

                if (currentNode.LeftChild != null)
                {
                    currentNode = currentNode.LeftChild;
                    ++currentIndex;
                    if (CheckWeHaveGotNeededElement(index, currentIndex))
                    {
                        return currentNode.Item;
                    }
                }
                else if (currentNode.RightChild != null)
                {
                    currentNode = currentNode.RightChild;
                    ++currentIndex;
                }
            }
        }

        private bool CheckWeHaveGotNeededElement(int searching, int currentPosition)
                => searching == currentPosition;

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
            // implementation
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new Iterator(this);
        }

        private class Iterator : IEnumerator<T>
        {
            private Set<T> tree;
            private int currentIndex;

            public Iterator(Set<T> tree)
            {
                this.tree = tree;
                currentIndex = -1;
            }

            public T Current
            {
                get
                {
                    if (currentIndex < 0 || currentIndex >= tree.Count)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    return tree[currentIndex];
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (currentIndex < tree.Count)
                {
                    ++currentIndex;
                }

                return currentIndex < tree.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
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
