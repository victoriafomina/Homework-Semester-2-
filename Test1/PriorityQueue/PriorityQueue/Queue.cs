// Реализовать очередь с приоритетами. Очередь должна иметь метод Enqueue(), 
// принимающий на вход значение и численный приоритет, и метод Dequeue(), 
// возвращающий значение с наивысшим приоритетом и удаляющий его из очереди. 
// Тип хранимых значений -- любой. Если очередь пуста, Dequeue() должен бросать 
// исключение. Комментарии и юнит-тесты обязательны.

// last in - last out

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class Queue
    {
        /// <summary>
        /// Creates an object of a class PriorityQueue.
        /// </summary>
        public Queue()
        {
            size = 0;
            head = null;
        }

        /// <summary>
        /// Adds an element with the value and priority.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="priority"></param>
        public void Enqueu(int value, int priority)
        {
            var newElement = new QueueElement(value, priority);
            if (size == 0)
            {
                head = newElement;
            }
            else
            {
                var temp = head;
                while (newElement.Priority <= temp.Priority && temp.Next != null)
                {
                    temp = temp.Next;
                }
                if (temp == head)
                {
                    newElement.Next = head;
                    newElement.Previous = null;
                    head.Previous = newElement;
                    head = newElement;
                }
                else
                {
                    temp.Next = newElement;
                    newElement.Previous = temp;
                }
            }
        }

        /// <summary>
        /// Returns an element with the highest priority and removes it from the queue.
        /// </summary>
        /// <returns></returns>
        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            var temp = head;
            head = head.Next;
            head.Previous = null;
            return temp.Value;
        }

        /// <summary>
        /// Checks if the queue is empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
                => size == 0;

        private QueueElement head;
        private int size;
        public int Size
        {
            get
            {
                return size;
            }
        }

        private class QueueElement
        {
            /// <summary>
            /// Creates an object of the class QueueElement.
            /// </summary>
            /// <param name="value"></param>
            /// <param name="priority"></param>
            public QueueElement(int value, int priority)
            {
                Value = value;
                Priority = priority;
                Previous = null;
                Next = null;
            }
            public QueueElement Previous { get; set; }
            public QueueElement Next { get; set; }
            public int Value { get; set; }
            public int Priority { get; set; }
        }
    }
}
