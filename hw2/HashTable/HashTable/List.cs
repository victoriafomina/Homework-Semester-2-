using System;

namespace HashTable
{
    /// <summary>
    /// List is a linear collection of data elements.
    /// </summary>
    public class List<T>
    {
        private Node head = null;

        private int size = 0;

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
        /// Size of a list.
        /// </summary>
        public int Size
        {
            get => size;
        }

        /// <summary>
        /// Checks if list is empty.
        /// </summary>
        public bool IsEmpty()
                => size == 0;

        private Node GetPreviousElementByPosition(int position)
        {
            if (position < 0 || position > size)
            {
                throw new ArgumentOutOfRangeException($"Invalid position " +
                        $"{position} \"position\"");
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
        /// Pushes an element into position.
        /// </summary>
        /// <param name="position">Index by which element is going to be add.</param>
        /// <param name="data">Element to add.</param>
        public void PushToPosition(int position, T data)
        {
            if (position < 0 || position > size)
            {
                throw new ArgumentOutOfRangeException($"Invalid position " +
                       $"{position} \"position\"");
            }
            ++size;
            if (position == 0)
            {
                var temp = head;
                head = new Node(data)
                {
                    Next = temp
                };
            }
            else if (position == size)
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
        public void PopFromPosition(int position)
        {
            if (position < 0 || position > size - 1)
            {
                throw new ArgumentOutOfRangeException($"Invalid position " +
                       $"{position} \"position\"");
            }
            if (size == 1)
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
            --size;
        }

        /// <summary>
        /// Gets value by the position.
        /// </summary>
        /// <param name="position">Index by which value is going to be returned.</param>
        /// <returns>Element at the given position.</returns>
        public T GetValueByPosition(int position)
        {
            if (IsEmpty() || position < 0 || position > size - 1)
            {
                throw new ArgumentOutOfRangeException($"Invalid position " +
                       $"{position} \"position\"");
            }
                      
            Node currentNode = head;
            for (int i = 0; i < position; ++i)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Data;
        }

        /// <summary>
        /// Returns position of the value if the value is in the list. 
        /// Returns -1 if the value does not exist in the list.
        /// </summary>
        /// <param name="value">The value position of what we want to know.</param>
        public int GetPositionByValue(T value)
        {
            if (!Exists(value))
            {
                return -1;
            }
            Node currentNode = head;
            int position = 0;
            for (int i = 0; i <= size; ++i)
            {
                if (currentNode.Data.Equals(value))
                {
                    position = i;
                    break;
                }
                currentNode = currentNode.Next;
            }
            return position;
        }

        /// <returns>String that contains current list.</returns>
        public override string ToString()
        {
            string s = "";
            var temp = head;
            while (temp != null)
            {
                s += temp.Data.ToString() + " ";
                temp = temp.Next;
            }
            return s;
        }

        /// <summary>
        /// Checks if an item with the data exists.
        /// </summary>
        /// <param name="data">Data to check if is in the list.</param>
        public bool Exists(T data)
        {
            if (IsEmpty())
            {
                return false;
            }
            var currentNode = head;
            for (int i = 0; i <= size; ++i)
            {
                if (currentNode.Data.Equals(data))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }
    }
}