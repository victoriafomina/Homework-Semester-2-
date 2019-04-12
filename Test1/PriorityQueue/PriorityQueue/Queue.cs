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
        }

        /// <summary>
        /// Adds an element with the value and priority.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="priority"></param>
        public void Enqueu(int value, int priority)
        {

        }

        /// <summary>
        /// Returns an element with the highest priority and removes it from the queue.
        /// </summary>
        /// <returns></returns>
        public int Dequeue()
        {

        }

        /// <summary>
        /// Checks if the queue is empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return size == 0;
        }

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
