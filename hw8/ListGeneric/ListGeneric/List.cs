using System;
using System.Collections.Generic;

namespace ListGeneric
{
    /// <summary>
    /// List is a linear collection of data elements.
    /// </summary>
    public class List<T> : IList<T>
    {
        private Node head = null;

        private int count = 0;

        private class Node
        {
            public Node(T data)
            {
                Data = data;
                Previous = null;
                Next = null;
            }

            public T Data { get; set; }

            public Node Next { get; set; }

            public Node Previous { get; set; }
        }

        /// <summary>
        /// Counts number of elements in the list.
        /// </summary>
        /// <returns>Number of the elements in the list.<returns>
        public int Count => count;

        /// <summary>
        /// Checks if list is empty.
        /// </summary>
        public bool IsEmpty()
                => count == 0;

        /// <summary>
        /// Checks if element is in the list.
        /// </summary>
        /// <param name="data">Element to check.</param>
        /// <exception cref="EmptyListException"Thrown when list is empty.></exception>
        public bool Contains(T data)
        {
            if (head == null)
            {
                throw new EmptyListException($"List is empty!!! Invalid operation!\n");
            }
            var temp = head;
            while (temp != null)
            {
                if (temp.Data.Equals(data))
                {
                    break;
                }
                temp = temp.Next;
            }
            return temp != null;
        }

        private Node GetPreviousElementByPosition(int position)
        {
            if (position < 0 || position > count)
            {
                throw new ArgumentOutOfRangeException($"Invalid position {position}" +
                       " \"position\"\n");
            }
            if (position == 0)
            {
                return null;
            }
            Node previous = head;
            for (int i = 0; i < position - 1; ++i)
            {
                previous = previous.Next;
            }
            return previous;
        }
        
        /// <summary>
        /// Adds an element to end of the list.
        /// </summary>
        /// <param name="data">The element to add.</param>
        public void Add(T data)
        {
            PushToPosition(count, data);
        }

        /// <summary>
        /// Pushes an element into position.
        /// </summary>
        /// <param name="position">Index by which element is going to be add.</param>
        /// <param name="data">Element to add.</param>
        /// <exception cref="ArgumentOutOfRangeException"Thrown when position is invalid.></exception>
        public void PushToPosition(int position, T data)
        {
            if (position < 0 || position > count)
            {
                throw new ArgumentOutOfRangeException($"Invalid position {position}" +
                       " \"position\"\n");
            }
            ++count;
            if (position == 0)
            {
                var temp = head;
                head = new Node(data)
                {
                    Next = temp
                };
            }
            else if (position == count)
            {
                Node previous = GetPreviousElementByPosition(position);
                previous.Next = new Node(data)
                {
                    Previous = previous
                };
            }
            else
            {
                Node previous = GetPreviousElementByPosition(position);
                Node next = previous.Next;
                previous.Next = new Node(data)
                {
                    Previous = previous,
                    Next = next
                };
                if (next != null)
                {
                    next.Previous = previous.Next;
                }
            }
        }

        /// <summary>
        /// Removes the item from the given position.
        /// </summary>
        /// <param name="position">Index by which item is going to be removed.</param>
        /// <exception cref="ArgumentOutOfRangeException"Thrown when position is invalid.></exception>
        public void PopFromPosition(int position)
        {
            if (position < 0 || position > count - 1)
            {
                throw new ArgumentOutOfRangeException($"Invalid position {position}" +
                        " \"position\"\n");
            }
            if (count == 1)
            {
                head = null;
            }
            else
            {
                Node previous = GetPreviousElementByPosition(position);
                Node next = head;
                if (position == 0)
                {
                    head = next.Next;
                    next.Next.Previous = null;
                    next = null;
                }
                if (previous != null)
                {
                    next = previous.Next.Next;
                    previous.Next = next;
                }
                if (next != null)
                {
                    next.Previous = previous;
                }
            }
            --count;
        }

        /// <summary>
        /// Clears the list.
        /// </summary>
        public void Clear()
        {
            head = null;
            count = 0;
        }

        /// <summary>
        /// Gets value by the position.
        /// </summary>
        /// <param name="position">Index by which value is going to be returned.</param>
        /// <returns>Element at the given position.</returns>
        /// <exception cref="ArgumentOutOfRangeException"Thrown when position is invalid.></exception>
        public T GetValueByPosition(int position)
        {
            if (IsEmpty() || position < 0 || position > count - 1)
            {
                throw new ArgumentOutOfRangeException($"Invalid position {position} \"position\"\n");
            }
            Node currentNode = head;
            for (int i = 0; i < position; ++i)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Data;
        }

        /// <summary>
        /// Gives the information if the object is only for reading.
        /// </summary>
        /// <returns>True if the object is only for reading. Otherwise returns false.</returns>
        public bool IsReadOnly()
                => false;

        /// <returns>String that contains current list.</returns>
        public override string ToString()
        {
            string str = "";
            var temp = head;
            while (temp != null)
            {
                str += temp.Data.ToString() + " ";
                temp = temp.Next;
            }
            return str;
        }
    }
}