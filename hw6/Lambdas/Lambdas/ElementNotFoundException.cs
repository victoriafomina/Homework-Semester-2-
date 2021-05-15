using System;

namespace Lambdas
{
    /// <summary>
    /// The exception that is thrown when the element was not found.
    /// </summary>
    [Serializable]
    public class ElementNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the ElementNotFoundException class with the specified error message.
        /// </summary>
        public ElementNotFoundException(string message) : base(message) { }
    }
}