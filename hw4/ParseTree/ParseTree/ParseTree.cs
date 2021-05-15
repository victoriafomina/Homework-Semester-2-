using System.Collections.Generic;
using System;

namespace PrefixParseTree
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
            Parse();
        }

        /// <summary>
        /// Calculates an expression.
        /// </summary>
        public int Calculate() => root.Value;

        /// <summary>
        /// Parses an expression.
        /// </summary>
        private void Parse()
        {
            for (var i = 0; i < expression.Length; ++i)
            { 
                if (IsOperator(expression[i]) || expression[i] == ')')
                {
                    expression = expression.Substring(0, i) + " " + expression.Substring(i);
                    ++i;
                }
            }

            string[] expressionInArray = expression.Split(' ');

            var symbols = new Queue<string>();

            for (var i = 0; i < expressionInArray.Length; ++i)
            {
                symbols.Enqueue(expressionInArray[i]);
            }

            root = ParseRecursion(symbols);
        }
        
        private Node ParseRecursion(Queue<string> expression)
        {
            Node newNode;

            if (expression.Peek() == "(")
            {
                expression.Dequeue();

                switch (expression.Dequeue())
                {
                    case "+":
                        newNode = new Addition();
                        break;
                    case "-":
                        newNode = new Subtraction();
                        break;
                    case "*":
                        newNode = new Multiplication();
                        break;
                    case "/":
                        newNode = new Division();
                        break;
                    default:
                        throw new FormatException("Invalid format of input string!\n");
                }

                if (newNode is Operator op)
                {
                    op.LeftChild = ParseRecursion(expression);
                    op.RightChild = ParseRecursion(expression);
                }

                expression.Dequeue();
            }
            else
            {
                newNode = new Operand(int.Parse(expression.Dequeue()));
            }

            return newNode;
        }

        /// <returns>a string that represents the current object.</returns>
        public override string ToString() => root.ToString();

        private bool IsOperator(char symbol) => symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
    }
}
