using System;

// Примечание: числа во входной строке однозначные

namespace StackBasedCalculator
{
    /// <summary>
    /// Calculator of postfix expressions for integer numbers.
    /// </summary>
    public class PostfixCalculator
    {
        private IStack<int> stack;

        /// <summary>
        /// Constructor of the class PostfixCalculator.
        /// </summary>
        /// <param name="stack">Object of a class with interface IStack.</param>
        public PostfixCalculator(IStack<int> stack)
        {
            this.stack = stack;
            while (!stack.IsEmpty())
            {
                stack.Pop();
            }
        }

        /// <summary>
        /// Evaluates postfix expression.
        /// </summary>
        /// <param name="expression">Expression in postfix form including single
        /// digits and operators.</param>
        /// <returns>Evaluation of postfix expression.</returns>
        /// <exception cref="FormatException">Thrown when expression is invalid.</exception>
        public double Evaluate(string expression)
        {
            for (int i = 0; i < expression.Length; ++i)
            {
                if (!IsOperator(expression[i]))
                {
                    if (!char.IsDigit(expression[i]))
                    {
                        throw new FormatException($"Invalid expression {expression}, " +
                                $"\"expression\"!!!");
                    }
                    char number = expression[i];
                    stack.Push(Convert.ToInt32(number) - Convert.ToInt32('0'));
                }
                else
                {
                    if (stack.IsEmpty())
                    {
                        throw new FormatException($"Invalid expression {expression}, " +
                                $"\"expression\"!!!");
                    }
                    int number2 = stack.Peek();
                    stack.Pop();
                    if (stack.IsEmpty())
                    {
                        throw new FormatException($"Invalid expression {expression}, " +
                                $"\"expression\"!!!");
                    }
                    int number1 = stack.Peek();
                    stack.Pop();
                    int resultOfOperation = PerformOperation(expression[i], number1, number2);
                    stack.Push(resultOfOperation);
                }
            }
            if (stack.IsEmpty())
            {
                throw new FormatException($"Invalid expression {expression}, " +
                                $"\"expression\"!!!");
            }
            int result = stack.Peek();
            stack.Pop();
            if (!stack.IsEmpty())
            {
                throw new FormatException($"Invalid expression {expression}, " +
                                $"\"expression\"!!!");
            }
            return result;
        }

        private int PerformOperation(char operation, int firstNumber, int secondNumber)
        {
            int result;
            switch (operation)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    break;
                case '-':
                    result = firstNumber - secondNumber;
                    break;
                case '*':
                    result = firstNumber * secondNumber;
                    break;
                case '/':
                    if (secondNumber == 0)
                    {
                        throw new DivideByZeroException($"You tried to divide by zero" +
                                " \"secondNumber\" is equal to {secondNumber}!!!");
                    }
                    result = firstNumber / secondNumber;
                    break;
                default:
                    throw new ArgumentException($"\"operation\" is not operator!!!");
            }
            return result;
        }

        private bool IsOperator(char symbol) 
                => symbol == '-' || symbol == '+' || symbol == '/' || symbol == '*';
    }
}