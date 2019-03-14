using System;

//Написать связный список в виде класса.От списка хочется:
//- Добавлять/удалять элемент по произвольной позиции, задаваемой целым числом
//- Узнавать размер, проверять на пустоту
//- Получать или устанавливать значение элемента по позиции, задаваемой целым числом

namespace List
{
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

        public int Size
        {
            get
            {
                return size;
            }
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        private void CheckCorectnessOfPosition(int position)
        {
            if (position < 0 || position > Size)
            {
                throw new ArgumentException(string.Format("Invalid position", position,
                        " position\n"));
            }
        }

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
                Node<T1> previous = head;
                Node<T1> next = null;
                for (int i = 0; i < position - 1; ++i)
                {
                    previous = previous.Next;
                }
                next = previous.Next;
                previous.Next = new Node<T1>(data)
                {
                    Previous = previous,
                    Next = next
                };
                next.Previous = previous.Next;   
            }
        }

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
                Node<T1> previous = head;
                Node<T1> next = null;
                for (int i = 0; i < position - 1; ++i)
                {
                    previous = previous.Next;
                }
                next = previous.Next.Next;
                previous.Next = next;
                next.Previous = previous;
            }
        }

        public T1 GetValueByPosition(int position)
        {
            Node<T1> currentNode = head;
            for (int i = 0; i < position; ++i)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Data;
        }

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