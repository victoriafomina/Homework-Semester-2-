using System;
using System.Linq;

namespace Calculator
{
    public class InfixCalculatorLogic
    {
        private double CalculateExpression(double operandLeft, char operation, double operandRight, ref string expression)
        {
            double result = 0;

            switch (operation)
            {
                case '+':
                    result = operandLeft + operandRight;
                    break;
                case '-':
                    result = operandLeft - operandRight;
                    break;
                case '*':
                    result = operandLeft * operandRight;
                    break;
                case '/':
                    if (operandRight == 0)
                    {
                        throw new DivideByZeroException("Division by zero is not allowed!\n");
                    }
                    else
                    {
                        result = operandLeft / operandRight;
                    }
                    break;
                default:
                    throw new ArgumentException("Argument \"char operation\" is not operation!");
            }
            return result;
        }

        private bool IsOperator(char operation)
                => operation == '+' || operation == '-' || operation == '*' || operation == '/';

        private void ParseLeftOperandToDouble(out double operandLeft, string expression)
        {
            // left operand ends before the first space
            int lastPosOfTheLeftOperand = expression.IndexOf(' ') - 1;
            string leftOperand = expression.Substring(0, lastPosOfTheLeftOperand + 1);
            if (!double.TryParse(leftOperand, out operandLeft))
            {
                throw new FormatException("Invalid expression!");
            }
        }

        private void ParseRightOperandToDouble(out double operandRight, string expression)
        {
            int firstPosOfTheRightOperand = RightOperandFirstPosition(expression);
            int lastPosOfTheRightOperand = RightOperandLastPosition(expression);

            string rightOperand = expression.Substring(firstPosOfTheRightOperand,
                    lastPosOfTheRightOperand - firstPosOfTheRightOperand + 1);
            if (!double.TryParse(rightOperand, out operandRight))
            {
                throw new FormatException("Invalid expression!");
            }
        }

        private int RightOperandFirstPosition(string expression)
        {
            // right operand starts after the second space
            int firstPosOfTheRightOperand = expression.IndexOf(' ') + 3;
            return firstPosOfTheRightOperand;
        }

        private int RightOperandLastPosition(string expression)
        {
            int lastPosOfTheRightOperand = expression.Length - 1;
            return lastPosOfTheRightOperand;
        }

        private void ExpressionIncludesAnOperatorWithTwoOperandsCalculate(ref string expression)
        {
            double operandLeft;
            double operandRight;
            ParseLeftOperandToDouble(out operandLeft, expression);
            ParseRightOperandToDouble(out operandRight, expression);

            double result = 0;

            if (expression.Contains('+'))
            {
                result = CalculateExpression(operandLeft, '+', operandRight, ref expression);
            }
            else if (expression.Contains('*'))
            {
                result = CalculateExpression(operandLeft, '*', operandRight, ref expression);
            }
            else if (expression.Contains('/'))
            {
                try
                {
                    result = CalculateExpression(operandLeft, '/', operandRight, ref expression);
                }
                catch (DivideByZeroException)
                {
                    expression = "Division by zero is not allowed";
                }
            }
            else
            {
                result = CalculateExpression(operandLeft, '-', operandRight, ref expression);
            }

            int lastPositionOfTheRightOperand = RightOperandLastPosition(expression);

            if (expression != "Division by zero is not allowed")
            {
                expression = expression.Remove(0, lastPositionOfTheRightOperand + 1);
                expression = result.ToString() + expression;
            }
        }

        private void RemovesTheLastElementIfIsAnOperator(ref string expression)
        {
            // check if in the expression (not to count spaces) could be an operator
            if (expression.Count() > 2)
            {
                int position = expression.Count() - 1;
                char symbolToCheckIfIsOperator = expression[position - 1];

                // if the last element is an operator then remove it from theTextBoxExpression
                if (IsOperator(symbolToCheckIfIsOperator))
                {
                    expression = expression.Remove(position - 2, 3);
                }
            }
        }

        /// <summary>
        /// Method that must be execute if the operator (+, -, *, /) button was pressed.
        /// </summary>
        public string OperatorClickHandler(string expression, string operation)
        {
            if (operation.Count() != 1 && !IsOperator(operation[0]))
            {
                throw new FormatException("The second argument must be an operator (+, -, *, /)\n");
            }

            RemovesTheLastElementIfIsAnOperator(ref expression);

            // the situation when the operator was pressed when the expression was empty or when the comma is the last element
            if (expression.Count() == 0 || expression[expression.Count() - 1] == ',')
            {
                expression += "0";
            }
            // discribes the situation when the expression already includes operator
            else if (expression.LastIndexOf('-') > 0 || expression.Contains('+') || expression.Contains('*') 
                    || expression.Contains('/'))
            {
                ExpressionIncludesAnOperatorWithTwoOperandsCalculate(ref expression);
            }
            // describes the situation when "Division by zero is not allowed" in the expression
            else if (expression == "Division by zero is not allowed")
            {
                expression = "";
                expression += "0";
            }

            expression += " " + operation + " ";

            return expression;
        }

        public string NumberClickHandler(string expression, string number)
        {
            if (number.Count() == 1 && !char.IsDigit(number[0]))
            {
                throw new FormatException("The second argument must be a digit\n");
            }

            // trying to understand which operator is being written (left or right)

            // the right one
            if (expression.Contains('+') || expression.Contains('-') || expression.Contains('*') ||
                    expression.Contains('/'))
            {
                // find position of the last space after which the second operator is being written
                int posOfTheLastSpace = expression.LastIndexOf(' ');

                // remove insignificant zero in the beginning of the right operand
                if (posOfTheLastSpace < expression.Count() - 1 && expression[posOfTheLastSpace + 1] == '0' &&
                        expression.Count() == posOfTheLastSpace + 2)
                {
                    expression = expression.Remove(expression.Count() - 1);
                }
            }
            // the left one
            else if (expression.Count() > 0)
            {
                if (!expression.Contains(',') && expression[0] == '0' ||
                        expression == "Division by zero is not allowed")
                {
                    expression = "";
                }
            }

            expression += number;

            return expression;
        }

        /// <summary>
        /// Method that must be execute if the comma was pressed.
        /// </summary>
        public string CommaClickHandler(string expression)
        {
            // expression is empty or expression contains string "Division by zero is not allowed"
            if (expression == "Division by zero is not allowed" ||
                    expression.Count() == 0)
            {
                expression = "";
                expression += "0,";
            }
            // the last element (not to count spaces) is an operator
            else if (expression.Count() > 3 && IsOperator(expression[expression.Count() - 2]))
            {
                expression += "0,";
            }
            // check if the left operator already has a comma
            else if (!expression.Contains('+') && !expression.Contains('*') && !expression.Contains('/') 
                    && expression.LastIndexOf('-') <= 0 && !expression.Contains(','))
            {
                expression += ',';
            }
            // check if the right operator already has a comma
            else if (expression.Contains('+') || expression.LastIndexOf('-') > 0 || expression.Contains('*')
                    || expression.Contains('/'))
            {
                char[] searchingForOperator = new char[4] { '+', '-', '*', '/' };
                var posOfTheOperator = expression.LastIndexOfAny(searchingForOperator);
                bool flagTheRightOperatorHasAComma = false;

                for (var i = posOfTheOperator + 2; i < expression.Count(); ++i)
                {
                    if (expression[i] == ',')
                    {
                        flagTheRightOperatorHasAComma = true;
                        break;
                    }
                }

                if (!flagTheRightOperatorHasAComma)
                {
                    expression += ',';
                }
            }

            return expression;
        }

        public string EquallyClickHandler(string expression)
        {
            if (expression.Count() == 0)
            {
                expression += "0";
            }
            else if (expression.Count() > 3 && IsOperator(expression[expression.Count() - 2]))
            {
                // duplicate the left operator if there is no right one
                expression += expression.Substring(0, expression.Count() - 3);
                ExpressionIncludesAnOperatorWithTwoOperandsCalculate(ref expression);
            }
            else if (char.IsDigit(expression[expression.Count() - 1]))
            {
                if (expression.Contains('+') || expression.LastIndexOf('-') > 0 || expression.Contains('*')
                        || expression.Contains('/'))
                {
                    ExpressionIncludesAnOperatorWithTwoOperandsCalculate(ref expression);
                }
            }
            else if (expression[expression.Count() - 1] == ',')
            {
                if (expression[0] != '-' && (expression.Contains('+') || expression.Contains('-') || expression.Contains('*')
                        || expression.Contains('/')))
                {
                    // if the right operator is being written
                    expression += "0";
                    ExpressionIncludesAnOperatorWithTwoOperandsCalculate(ref expression);
                }
                else
                {
                    // if the left operator is being written
                    expression = expression.Remove(expression.Count() - 1);

                }
            }
            else if (expression[0] == '-')
            {
                char[] searchingForOperator = new char[4] { '+', '-', '*', '/' };
                if (expression.LastIndexOfAny(searchingForOperator) > 0)
                {
                    ExpressionIncludesAnOperatorWithTwoOperandsCalculate(ref expression);
                }
            }

            return expression;
        }

        public string ClearClickHandler() => "";
    }
}