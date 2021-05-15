using System;

namespace UniqueList
{
    /// <summary>
    /// The class of the exception that is thrown when duplicate element is to add.
    /// </summary>
    [Serializable]
    public class DuplicateElementException : Exception
    {
        public DuplicateElementException() { }

        public DuplicateElementException(string message) : base(message) { }

        public DuplicateElementException(string message, Exception inner) : base(message, inner) { }
    }
}
