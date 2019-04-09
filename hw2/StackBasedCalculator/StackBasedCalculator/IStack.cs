namespace StackBasedCalculator
{
    /// <summary>
    /// Stack is a last-in-first-out-container.
    /// </summary>
    interface IStack<T>
    {
        /// <summary>
        /// Pushes an element into a stack.
        /// </summary>
        void Push(T data);

        /// <summary>
        /// Pops an element from the stack.
        /// </summary>
        void Pop();

        /// <summary>
        /// Returns an element that is in the top.
        /// </summary>
        /// <returns></returns>
        T Peek();

        /// <summary>
        /// Checks if stack is empty or not.
        /// </summary>
        /// <returns></returns>
        bool isEmpty();
    }
}
