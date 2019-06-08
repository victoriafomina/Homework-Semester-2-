namespace PrefixParseTree
{
    /// <summary>
    /// The class that represents the addition operator.
    /// </summary>
    public class Addition : Operator
    {
        /// <summary>
        /// Returns the calculated value of the node.
        /// </summary>
        public override int Value => LeftChild.Value + RightChild.Value;

        /// <summary>
        /// Returns operation symbol.
        /// </summary>
        public override char OperationSymbol { get; } = '+';
    }
}
