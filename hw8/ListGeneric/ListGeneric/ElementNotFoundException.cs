using System;

namespace ListGeneric
{
    [Serializable]
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string message) : base(message) { }
    }
}
