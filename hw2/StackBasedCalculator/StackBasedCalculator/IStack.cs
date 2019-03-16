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
        void Push();

        /// <summary>
        /// Pops an element from the stack.
        /// </summary>
        void Pop();

        /// <summary>
        /// Gets a value of the element that was pushed last into a stack.
        /// </summary>
        /// <returns></returns>
        T Peek();

        /// <summary>
        /// Checks if an element is in the Stack.
        /// </summary>
        void Exists();
    }
}
