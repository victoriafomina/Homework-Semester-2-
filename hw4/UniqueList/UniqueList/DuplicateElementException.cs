using System;
using System.Runtime.Serialization;

namespace UniqueList
{
    [Serializable]
    public class DuplicateElementException : Exception
    {
        public DuplicateElementException() { }

        public DuplicateElementException(string message) : base(message) { }

        public DuplicateElementException(string message, Exception inner) : base(message, inner) { }
    }
}
