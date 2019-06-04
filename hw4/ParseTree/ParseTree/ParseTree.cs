using System;

namespace ParseTree
{
    /// <summary>
    /// Implements IParseTree interface.
    /// </summary>
    public class ParseTree : IParseTree
    {
        private string expression;
        private Node root;

        /// <summary>
        /// Initializes an object of the class ParseTree.
        /// </summary>
        public ParseTree(string expression)
        {
            this.expression = expression;
        }

        /// <summary>
        /// Calculates an expression.
        /// </summary>
        public int Calculate() => root.Value;

        /// <returns>an expression</returns>
        public string GetExpression() => expression;

        private abstract class Node
        {
            public Node LeftChild { get; set; }

            public Node RightChild { get; set; }

            public abstract int Value { get; set; }

            public abstract void Print();
        }

        private class Operand
        {
            public int Value {get; set;}
            public void Print() => Console.WriteLine(Value);
            public override string ToString() => Value.ToString();
        }

        private class Operator : Node
        {
            public Node LeftOperand { get; set; }

            public Node RightOperand { get; set; }

            public string Operation { get; set; }

            public override int Value { get; set; }

            public override void Print() => Console.WriteLine(Operation);

            public override string ToString() => Operation;
        }
    }
}
