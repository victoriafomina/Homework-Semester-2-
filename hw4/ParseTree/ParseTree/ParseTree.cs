using System;

namespace ParseTree
{
    /// <summary>
    /// Implements IParseTree interface.
    /// </summary>
    public class ParseTree
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
        public int Calculate() => root.Calculate();

        /// <summary>
        /// Parses an expression.
        /// </summary>
        private void Parse()
        {
            
        }

        private abstract class Node
        {
            public Node Left { get; set; }

            public Node Right { get; set; }

            public abstract void Print();

            public abstract int Calculate();

            public string Value { get; set; }
        }

        private class Operator : Node
        {
            public Operator(string operation)
            {
                Value = operation;
                Left = null;
                Right = null;
            }

            public override string ToString()
            {
                string result = "";
                result += Value;

                if (Left != null)
                {
                    if (Left is Operator)
                    {
                        result += "(";
                    }
                    result += Left.ToString();
                }
                if (Right != null)
                {
                    if (Right is Operator)
                    {
                        result += "(";
                    }

                    result += Right.ToString();
                    if (Right is Operand)
                    {
                        result += ")";
                    }
                }

                return result;
            }

            public override void Print() => Console.WriteLine(this.ToString());

            public override int Calculate()
            {
                int result;

                if (Left is Operand && Right is Operand)
                {
                    result = Calculations.Calculate(int.Parse(Left.Value), Value, int.Parse(Right.Value));
                }
                else if (Left is Operand)
                {
                    result = Calculations.Calculate(int.Parse(Left.Value), Value, Right.Calculate());
                }
                else if (Right is Operand)
                {
                    result = Calculations.Calculate(Left.Calculate(), Value, int.Parse(Right.Value));
                }
                else
                {
                    result = Calculations.Calculate(Left.Calculate(), Value, Right.Calculate());
                }

                return result;
            }
        }

        private class Operand : Node
        {
            public Operand(string operand)
            {
                Value = operand;
                Left = null;
                Right = null;
            }

            public override string ToString()
            {
                string result = "";
                result += Value;
                return result;
            }

            public override void Print() => Console.Write(Value);

            public override int Calculate() => int.Parse(Value);
        }
    }
}
