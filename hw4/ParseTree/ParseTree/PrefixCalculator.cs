namespace PrefixParseTree
{
    /// <summary>
    /// This class lets calculate prefix expressions.
    /// </summary>
    public class PrefixCalculator
    {
        string expression;

        /// <returns>a string that represents the current object.</returns>
        public override string ToString()
        {
            string output = "";

            output += Calculate(expression);

            return output;
        }

        /// <summary>
        /// Calculates an expression.
        /// </summary>
        public int Calculate(string expression)
        {
            this.expression = expression;

            var parsing = new ParseTree(expression);

            return parsing.Calculate();
        }
    }
}
