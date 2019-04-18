using System;

namespace StackBasedCalculator
{
    /// <summary>
    /// Stack is a last-in-first-out container.
    /// </summary>
    public class MyStackOnArray : IStack<int>
    {
        private int numberOfElements;
        private int[] arrayOfElements;

        /// <summary>
        /// Construtor without parameters for MyStackOnArray class.
        /// </summary>
        public MyStackOnArray()
        {
            arrayOfElements = new int[100];
            numberOfElements = 0;
        }

        /// <summary>
        /// Pushes an element into a stack.
        /// </summary>
        public void Push(int data)
        {
            if (numberOfElements == arrayOfElements.Length)
            {
                Resize(numberOfElements);
            }
            arrayOfElements[numberOfElements] = data;
            ++numberOfElements;
        }

        /// <summary>
        /// Pops an element from the stack.
        /// </summary>
        /// <exception cref="InvalidOperationException"Thrown when stack is empty.></exception>
        public void Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException($"Stack is empty! Nothing to pop!!!\n");
            }
            --numberOfElements;
        }

        /// <summary>
        /// Returns an element that is in the top.
        /// </summary>
        /// <returns>Last element that came into a stack.</returns>
        /// <exception cref="InvalidOperationException"Thrown when stack is empty.></exception>
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException($"Stack is empty!!!\n");
            }
            return arrayOfElements[numberOfElements - 1];
        }

        /// <summary>
        /// Checks if stack is empty or not.
        /// </summary>
        public bool IsEmpty()
        {
            return numberOfElements == 0;
        }

        private void Resize(int position)
        {
            if (position >= numberOfElements)
            {
                int[] arrayCopy = new int[numberOfElements];
                for (int i = 0; i < numberOfElements; ++i)
                {
                    arrayCopy[i] = arrayOfElements[i];
                }
                arrayOfElements = new int[numberOfElements * 2];
                for (int i = 0; i < numberOfElements; ++i)
                {
                    arrayOfElements[i] = arrayCopy[i];
                }
            }
        }
    }
}