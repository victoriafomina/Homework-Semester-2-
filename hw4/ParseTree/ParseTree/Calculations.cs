using System;

namespace ParseTree
{
    public static class Calculations
    {
        public static int Calculate(int operandLeft, string operation, int operandRight)
        {
            int result = 0;

            switch (operation)
            {
                case "+":
                    result = operandLeft + operandRight;
                    break;
                case "-":
                    result = operandLeft - operandRight;
                    break;
                case "*":
                    result = operandLeft * operandRight;
                    break;
                case "/":
                    result = operandLeft / operandRight;
                    break;
                default:
                    throw new ArgumentException("The second argument must be an operator!\n");
            }

            return result;
        }
    }
}
