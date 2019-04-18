using System;

namespace UniqueList
{
    [Serializable]
    public class ElementDoesNotExistException :Exception
    {
        public ElementDoesNotExistException() { }

        public ElementDoesNotExistException(string message) : base(message) { }

        public ElementDoesNotExistException(string message, Exception inner) : base(message, inner) { }
    }
}
