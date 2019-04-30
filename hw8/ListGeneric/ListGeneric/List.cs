using System;
using System.Collections;
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
        /// Checks if the list has fixed size.
        /// </summary>
        public bool IsFixedSize() => false;

        /// <summary>
        /// Checks if element is in the list.
        /// </summary>
        /// <param name="data">Element to check.</param>
        public bool Contains(T data)
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
                    break;
                }
                temp = temp.Next;
            }
            return temp != null;
        }

        /// <summary>
        /// Finds the index of the element.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>The index of the element.</returns>
        /// <exception cref="EmptyListException"Thrown when list is empty.></exception>
        /// <exception cref="ElementNotFoundException"Thrown when element is not in the list.></exception> 
        public int IndexOf(T data)
        {
            if (IsEmpty())
            {
                throw new EmptyListException($"List is empty! Invalid operation!\n");
            }
            if (!Contains(data))
            {
                throw new ElementNotFoundException($"Element was not found in the list! Invalid operation!\n");
            }
            var temp = head;
            int index = 0;
            while (!temp.Data.Equals(data))
            {
                temp = temp.Next;
                ++index;
            }
            return index;            
        }

        /// <summary>
        /// Property lets get or set element by index.
        /// </summary>
        /// <param name="index">Index by which to get or to set.</param>
        /// <returns>Value of the element by index.</returns>
        /// <exception cref="ArgumentOutOfRangeException"Thrown when index is invalid.></exception>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException($"Invalid index {index} \"index\"\n");
                }
                var temp = head;
                for (int i = 0; i < index; ++i)
                {
                    temp = temp.Next;
                }
                return temp.Data;
            }
            set
            {
                if (index < 0 || index > count)
                {
                    throw new ArgumentOutOfRangeException($"Invalid index {index} \"index\"\n");
                }
                Insert(index, value);
            }
        }

        private Node GetPreviousElementByPosition(int position)
        {
            if (position < 0 || position > count)
            {
                throw new ArgumentOutOfRangeException($"Invalid position {position} \"position\"\n");
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
            Insert(count, data);
        }

        /// <summary>
        /// Inserts an element into position.
        /// </summary>
        /// <param name="position">Index by which element is going to be add.</param>
        /// <param name="data">Element to add.</param>
        /// <exception cref="ArgumentOutOfRangeException"Thrown when position is invalid.></exception>
        public void Insert(int position, T data)
        {
            if (position < 0 || position > count)
            {
                throw new ArgumentOutOfRangeException($"Invalid position {position} \"position\"\n");
            }
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
            ++count;
        }

        /// <summary>
        /// Removes the first entry of the element.
        /// </summary>
        /// <param name="data">Element to remove.</param>
        public bool Remove(T data)
        {
            if (IsEmpty())
            {
                return false;
            }
            if (!Contains(data))
            {
                return false;
            }
            RemoveAt(IndexOf(data));
            return true;
        }

        /// <summary>
        /// Removes the item from the given position.
        /// </summary>
        /// <param name="position">Index by which item is going to be removed.</param>
        /// <exception cref="ArgumentOutOfRangeException"Thrown when position is invalid.></exception>
        public void RemoveAt(int position)
        {
            if (position < 0 || position > count - 1)
            {
                throw new ArgumentOutOfRangeException($"Invalid position {position} \"position\"\n");
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
        /// Copies elements of the list to an array starting at particular index.
        /// </summary>
        /// <param name="array">The one-dimensional array that is destination for the elements copied from list.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentOutOfRangeException"Thrown when position is invalid.></exception>
        /// <exception cref="ArgumentException"Thrown when the number of elements in the list is greater that the
        /// available space in the array.></exception>
        /// <exception cref="EmptyListException"Thrown when the list is empty></exception>
        public void CopyTo(T[] array, int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException($"Invalid index {index} \"index\"\n");
            }
            if (array.Length < count - index)
            {
                throw new ArgumentException($"The number of elements in the list is greater than the available space " +
                        "from the index to the end of destination array\n");
            }
            if (IsEmpty())
            {
                throw new EmptyListException($"List is empty!!! Invalid operation!\n");
            }
            var temp = head;
            for (int i = 0; i < index; ++i)
            {
                temp = temp.Next;
            }
            for (int i = 0; i < count - index; ++i)
            {
                array[i] = temp.Data;
                temp = temp.Next;
            }
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
        /// Gives the information if the object is only for reading.
        /// </summary>
        /// <returns>True if the object is only for reading. Otherwise returns false.</returns>
        public bool IsReadOnly => false;

        public IEnumerator<T> GetEnumerator()
        {
            var temp = head;
            while (temp != null)
            {
                yield return temp.Data;
                temp = temp.Next;
            }
        }
        
        /// <returns>IEnumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

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