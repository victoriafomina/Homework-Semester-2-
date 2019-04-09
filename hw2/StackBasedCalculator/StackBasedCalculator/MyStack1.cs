using System;

namespace StackBasedCalculator
{
    /// <summary>
    /// Stack is a last-in-first-out container.
    /// </summary>
    public class MyStack1 : IStack<int>
    {
        private int numberOfElements;
        private int[] array;

        /// <summary>
        /// Construtor without parameters for MyStack1 class.
        /// </summary>
        public MyStack1()
        {
            array = new int[100];
            numberOfElements = 0;
        }
        
        /// <summary>
        /// Pushes an element into a stack.
        /// </summary>
        public void Push(int number)
        {

        }

        /// <summary>
        /// Pops an element from the stack.
        /// </summary>
        public void Pop()
        {

        }

        /// <summary>
        /// Returns an element that is in the top.
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Checks if stack is empty or not.
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return numberOfElements == 0;
        }
    }
}
