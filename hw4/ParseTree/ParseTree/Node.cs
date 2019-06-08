namespace PrefixParseTree
{
    public abstract class Node
    {
        /// <summary>
        /// The property that lets get or set the left child.
        /// </summary>
        public  Node LeftChild { get; set; }

        /// <summary>
        /// The property that lest get or set right child.
        /// </summary>
        public Node RightChild { get; set; }

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
