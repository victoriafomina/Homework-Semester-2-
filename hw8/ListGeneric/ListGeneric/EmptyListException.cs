using System;

namespace ListGeneric
{
    [Serializable]
    public class EmptyListException : Exception
    {
        public EmptyListException(string message) : base(message) { }
    }
}