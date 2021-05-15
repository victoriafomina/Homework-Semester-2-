namespace PrefixParseTree
{
    public abstract class Node
    {
        /// <summary>
        /// The propetry that retuns or sets the value of the node.
        /// </summary>
        public abstract int Value { get; }

        /// <summary>
        /// Prints value of the node.
        /// </summary>
        public abstract void Print();
    }
}
