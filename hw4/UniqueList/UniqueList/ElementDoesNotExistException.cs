using System;

namespace UniqueList
{
    /// <summary>
    /// The class of the exception that is trown when element does not exist.
    /// </summary>
    [Serializable]
    public class ElementDoesNotExistException : Exception
    {
        public ElementDoesNotExistException() { }

        public ElementDoesNotExistException(string message) : base(message) { }

        public ElementDoesNotExistException(string message, Exception inner) : base(message, inner) { }
    }
}
