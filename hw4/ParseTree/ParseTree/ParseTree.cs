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
            root = null;
            Parse();
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
            ParseRecursion(expression, root);
        }
        
        private void ParseRecursion(string expression, Node parent)
        {
            if (parent == null)
            {
                root = new Operator(expression[1].ToString());
            }

            var rightOperandStartsFrom = ParseLeftOperand(expression, parent);

            ParseRightOperand(expression, parent, rightOperandStartsFrom);
        }

        /// <summary>
        /// Parses the left operand.
        /// </summary>
        /// <returns>the first position if the right operand</returns>
        private int ParseLeftOperand(string expression, Node parent)
        {
            int rightOperandStartsFrom = 0;

            if (char.IsDigit(expression[3]))
            {
                var posOfTheLastSymbol = PrefixExpressionsHelper.GetPositionOfLastSymbolInNumber(expression, 3);
                rightOperandStartsFrom = posOfTheLastSymbol + 2;
                parent.Left = new Operand(expression.Substring(3, posOfTheLastSymbol - 2));
            }
            else // then it is an opening bracket
            {
                var posOfClosingBracket = PrefixExpressionsHelper.GetPositionOfClosingBracket(expression, 3);
                rightOperandStartsFrom = posOfClosingBracket + 2;

                if (parent == null)
                {
                    ParseRecursion(expression.Substring(3, posOfClosingBracket - 2), root);
                }
                else
                {
                    ParseRecursion(expression.Substring(3, posOfClosingBracket - 2), parent.Left);
                }
            }

            return rightOperandStartsFrom;
        }

        private void ParseRightOperand(string expression, Node parent, int firstPosOfTheRightOperand)
        {
            if (char.IsDigit(expression[firstPosOfTheRightOperand]))
            {
                var posOfTheLastSymbol = PrefixExpressionsHelper.GetPositionOfLastSymbolInNumber(expression,
                        firstPosOfTheRightOperand);
                parent.Right = new Operand(expression.Substring(firstPosOfTheRightOperand,
                        posOfTheLastSymbol - firstPosOfTheRightOperand + 1));
            }
            else // then it is an opening bracket
            {
                var posOfClosingBracket = PrefixExpressionsHelper.GetPositionOfClosingBracket(expression, 3);

                if (parent == null)
                {
                    ParseRecursion(expression.Substring(3, posOfClosingBracket - 2), root);
                }
                else
                {
                    ParseRecursion(expression.Substring(3, posOfClosingBracket - 2), parent.Right);
                }
            }
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
