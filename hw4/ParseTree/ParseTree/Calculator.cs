using System;

namespace ParseTree
{
    /// <summary>
    /// Lets calculate expressions.
    /// </summary>
    public static class Calculator
    {
        /// <summary>
        /// Calculates an expression.
        /// </summary>
        /// <param name="firstOperand">first operand</param>
        /// <param name="operation">operator</param>
        /// <param name="secondOperand">second operand</param>
        /// <returns>calculated expression</returns>
        public static int Calculate(int firstOperand, string operation, int secondOperand)
        {
            int result = 0;

            switch (operation)
            {
                case "+":
                    result = firstOperand + secondOperand;
                    break;
                case "-":
                    result = firstOperand - secondOperand;
                    break;
                case "*":
                    result = firstOperand * secondOperand;
                    break;
                case "/":
                    result = firstOperand / secondOperand;
                    break;
                default:
                    throw new ArgumentException("The second argument must be an operator (+, -, *, /)!\n");
            }

            return result;
        }
    }
}
