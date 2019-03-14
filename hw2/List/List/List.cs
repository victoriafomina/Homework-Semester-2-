using System;

//Написать связный список в виде класса.От списка хочется:
//- Добавлять/удалять элемент по произвольной позиции, задаваемой целым числом
//- Узнавать размер, проверять на пустоту
//- Получать или устанавливать значение элемента по позиции, задаваемой целым числом

namespace List
{
    /// <summary>
    /// List is a linear collection of data elements.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    class List<T1>
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

        private void CheckCorectnessOfPosition(int position)
        {
            if (position < 0 || position > Size)
            {
                throw new ArgumentException(string.Format("Invalid position", position,
                        " position\n"));
            }
        }

        private Node<T1> GetPreviousElementByPosition(int position)
        {
            Node<T1> previous = head;
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
        public void PushByPosition(int position, T1 data)
        {
            CheckCorectnessOfPosition(position);
            if (position == 0)
            {
                ++size;
                var temp = head;
                head = new Node<T1>(data)
                {
                    Next = temp
                };
            }
            else
            {
                ++size;
                Node<T1> previous = GetPreviousElementByPosition(position);
                Node<T1> next = previous.Next;
                previous.Next = new Node<T1>(data)
                {
                    Previous = previous,
                    Next = next
                };
                next.Previous = previous.Next;   
            }
        }

        /// <summary>
        /// Removes the item at the given position.
        /// </summary>
        /// <param name="position">Index by which item is going to be removed.</param>
        public void PopByPosition(int position)
        {
            CheckCorectnessOfPosition(position);
            if (position == 0)
            {
                --size;
                head = null;
            }
            else
            {
                --size;
                // copypaste
                Node<T1> previous = GetPreviousElementByPosition(position);
                Node<T1> next = previous.Next.Next;
                previous.Next = next;
                next.Previous = previous;
            }
        }

        /// <summary>
        /// Gets value by the position.
        /// </summary>
        /// <param name="position">Index by which value is going to be returned.</param>
        /// <returns>Element at the given position.</returns>
        public T1 GetValueByPosition(int position)
        {
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
    }
}