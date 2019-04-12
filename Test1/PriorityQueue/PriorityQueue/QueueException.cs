using System;

namespace PriorityQueue
{
    [Serializable]
    public class QueueException : Exception
    {
        public QueueException(string message) : base(message) { }
    }
}
