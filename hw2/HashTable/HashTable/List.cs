using System;

namespace HashTable
{
    /// <summary>
    /// List is a linear collection of data elements.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    public abstract class List<T1>
    {
        private Node<T1> head = null;

        private int size = 0;

        private class Node<T2>
        {
            public Node(T2 data)
            {
                Data = data;
                Previous = null;
                Next = null;
            }

            public T2 Data { get; set; }

            public Node<T2> Next { get; set; }

            public Node<T2> Previous { get; set; }
        }

        /// <summary>
        /// Size of a list.
        /// </summary>
        public int Size
        {
            get
            {
                return size;
            }
        }

        /// <summary>
        /// Checks if list is empty.
        /// </summary>
        public bool IsEmpty()
            => size == 0;

        private Node<T1> GetPreviousElementByPosition(int position)
        {
            if (position < 0 || position > size)
            {
                throw new ArgumentOutOfRangeException(string.Format("Invalid position", position,
                        " position\n"));
            }
            if (position == 0)
            {
                return null;
            }
            else
            {
                Node<T1> previous = head;
                for (int i = 0; i < position - 1; ++i)
                {
                    previous = previous.Next;
                }
                return previous;
            }
        }

        /// <summary>
        /// Pushes an element into position.
        /// </summary>
        /// <param name="position">Index by which element is going to be add.</param>
        /// <param name="data">Element to add.</param>
        public void PushToPosition(int position, T1 data)
        {
            if (position < 0 || position > size)
            {
                throw new ArgumentOutOfRangeException(string.Format("Invalid position", position,
                        " position\n"));
            }
            ++size;
            if (position == 0)
            {
                var temp = head;
                head = new Node<T1>(data)
                {
                    Previous = null,
                    Next = temp
                };
            }
            else if (position == size)
            {
                Node<T1> previous = GetPreviousElementByPosition(position);
                previous.Next = new Node<T1>(data)
                {
                    Previous = previous,
                    Next = null
                };
            }
            else
            {
                Node<T1> previous = GetPreviousElementByPosition(position);
                Node<T1> next = previous.Next;
                previous.Next = new Node<T1>(data)
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
                throw new ArgumentOutOfRangeException(string.Format("Invalid position", position,
                        " position\n"));
            }
            if (size == 1)
            {
                head = null;
            }
            else
            {
                Node<T1> previous = GetPreviousElementByPosition(position);
                Node<T1> next = head;
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
        public T1 GetValueByPosition(int position)
        {
            if (IsEmpty() || position < 0 || position > size - 1)
            {
                throw new ArgumentOutOfRangeException(string.Format("Invalid position", position,
                        " position\n"));
            }
            Node<T1> currentNode = head;
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

        /// <summary>
        /// Checks if an item with the data exists.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Exists(T1 data)
        {
            if (IsEmpty())
            {
                return false;
            }
            var currentNode = head;
            for (int i = 0; i <= size; ++i)
            {
                if (currentNode.Data == data)
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public static abstract bool operator==(T1 data1, T1 data2);

        public static abstract bool operator !=(T1 data1, T1 data2);
    }
}