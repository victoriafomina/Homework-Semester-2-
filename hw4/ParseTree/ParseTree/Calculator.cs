using System;

namespace ParseTree
{
    /// <summary>
    /// This class lets calculate prefix expressions.
    /// </summary>
    public class PrefixCalculator
    {
        private ParseTree parsing;

        /// <summary>
        /// Initializes an object of a calculator.
        /// </summary>
        public PrefixCalculator(string expression)
        {
            parsing = new ParseTree(expression);
        }

        /// <summary>
        /// Calculates an expression.
        /// </summary>
        public int Calculate() => parsing.Calculate();
    }
}
