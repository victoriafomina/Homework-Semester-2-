using System;

namespace UniqueList
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
        public int Size => size;

        /// <summary>
        /// Checks if list is empty.
        /// </summary>
        public bool IsEmpty()
             => size == 0;

        /// <summary>
        /// Checks if element is in a list.
        /// </summary>
        /// <param name="data">Element to check.</param>
        public bool Exists(T data)
        {
            if (IsEmpty())
            {
                return false;
            }
            var temp = head;
            while (temp != null)
            {
                if (temp.Data.Equals(data))
                {
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        private Node GetPreviousElementByPosition(int position)
        {
            if (position < 0 || position > size)
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
        /// Pushes an element into position.
        /// </summary>
        /// <param name="position">Index by which element is going to be add.</param>
        /// <param name="data">Element to add.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when position is invalid.</exception>
        public virtual void PushToPosition(int position, T data)
        {
            if (position < 0 || position > size)
            {
                throw new ArgumentOutOfRangeException($"Invalid position {position}" +
                       " \"position\"\n");
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
        /// Removes an element with the data "data".
        /// </summary>
        /// <param name="data">Data of the element to pop.</param>
        /// <exception cref="InvalidOperationException">Thrown when element does not found.</exception>
        public virtual void Remove(T data)
        {
            if (!Exists(data))
            {
                throw new InvalidOperationException($"Element with the data {data} is not in the list\n");
            }
            --size;
            var temp = head;
            while (!temp.Data.Equals(data))
            {
                temp = temp.Next;
            }
            if (temp == head)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Previous = null;
                }
            }
            else
            {
                temp.Previous.Next = temp.Next;
                if (temp.Next != null)
                {
                    temp.Next.Previous = temp.Previous;
                }
            }
        }

        /// <summary>
        /// Gets value by the position.
        /// </summary>
        /// <param name="position">Index by which value is going to be returned.</param>
        /// <returns>Element at the given position.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when position is invalid.</exception>
        public T GetValueByPosition(int position)
        {
            if (IsEmpty() || position < 0 || position > size - 1)
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
    }
}
