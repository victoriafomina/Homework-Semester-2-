using System;

namespace ParseTree
{
    /// <summary>
    /// The class that represents the operator.
    /// </summary>
    public abstract class Operator : Node
    {
        /// <summary>
        /// The property that returns the operation symbol.
        /// </summary>
        public abstract char OperationSymbol { get; }

        /// <returns>a string that represents the current object: operator with two operands.</returns>
        public override string ToString()
        {
            string output = "";

            output += "(" + OperationSymbol.ToString() + " " + LeftChild.ToString() + " " + RightChild.ToString() + ")";

            return output;
        }

        /// <summary>
        /// Prints a string that represents the current object: operator with two operands.
        /// </summary>
        public override void Print() => Console.Write(ToString());
    }
}
