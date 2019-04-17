using System.Collections.Generic;
using System;
using System.Linq;

namespace StackBasedCalculator
{
    /// <summary>
    /// Stack is a last-in-first-out container.
    /// </summary>
    public class MyStackOnList : IStack<int>
    {
        private List<int> list;

        public MyStackOnList()
        {
            list = new List<int>();
        }

        /// <summary>
        /// Pushes an element into a stack.
        /// </summary>
        public void Push(int data)
        {
            list.Insert(list.Count, data);
        }

        /// <summary>
        /// Pops an element from the stack.
        /// </summary>
        public void Pop()
        {
            list.RemoveAt(list.Count - 1);
        }

        /// <summary>
        /// Returns an element that is in the top.
        /// </summary>
        /// <returns>Last element that came into a stack.</returns>
        public int Peek()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException($"Stack is empty!!!\n");
            }
            return list.ElementAt(list.Count - 1);
        }

        /// <summary>
        /// Checks if stack is empty or not.
        /// </summary>
        public bool IsEmpty()
        {
            return list.Count == 0;
        }
    }
}
