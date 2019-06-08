using System.Collections.Generic;

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
            root = null;
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
                if (IsOperator(expression[i]))
                {
                    expression = expression.Substring(0, i) + " " + expression.Substring(i);
                }
            }

            string[] expressionInArray = expression.Split(' ');

            var symbols = new Queue<string>();

            for (var i = 0; i < expressionInArray.Length; ++i)
            {
                symbols.Enqueue(expressionInArray[i]);
            }

            ParseRecursion(symbols);
        }
        
        private void ParseRecursion(Queue<string> expression)
        {
            
        }

        private bool IsOperator(char symbol) => symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
    }
}
