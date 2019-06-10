using System;

namespace Lambdas
{
    /// <summary>
    /// The exception that is thrown when the list is empty.
    /// </summary>
    [Serializable]
    public class EmptyListException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the EmptyListException class with the specified error message.
        /// </summary>
        public EmptyListException(string message) : base(message) { }
    }
}