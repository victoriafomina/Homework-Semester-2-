using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Написать связный список в виде класса.От списка хочется:
//- Добавлять/удалять элемент по произвольной позиции, задаваемой целым числом
//- Узнавать размер, проверять на пустоту
//- Получать или устанавливать значение элемента по позиции, задаваемой целым числом

namespace List
{
    class List<T1>
    {
        private Node<T1> head = null;

        private Node<T1> tail = null;

        private int size = 0;

        public class Node<T2>
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

        public List() { }

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

        public void Push(int position, T1 value)
        {
            CheckCorectnessOfPosition(position);
            if (IsEmpty())
            {
                head = new Node<T1>(value);
                tail = head;
            }
            else
            {

            }
        }

        public void Pop(int position)
        {

        }

        public int GetValue(int position)
        {
            return -1;
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