using System;
using System.Linq;

namespace Calculator
{
    public class InfixCalculatorLogic
    {
        private void AddANumeralButtonToTheExpression(string expression, char number)
        {
            expression += number;
        }

        private void AddAnOperatorToTheExpression(string expression, char operation)
        {
            expression += " " + operation + " ";
        }

        private void OperatorWasPressedWhenExpressionIsEmptyOrContainsMessageAboutError(string expression)
        {
            expression += "0";
        }

        private (bool, double) CalculateExpression(double operandLeft, char operation, double operandRight)
        {
            var result = (true, 0.0);

            switch (operation)
            {
                case '+':
                    result.Item2 = operandLeft + operandRight;
                    break;
                case '-':
                    result.Item2 = operandLeft - operandRight;
                    break;
                case '*':
                    result.Item2 = operandLeft * operandRight;
                    break;
                case '/':
                    if (operandRight == 0)
                    {
                        result.Item1 = false;
                    }
                    else
                    {
                        result.Item2 = operandLeft / operandRight;
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

        private void ExpressionIncludesAnOperatorWithTwoOperandsCalculate(string expression)
        {
            double operandLeft;
            double operandRight;
            ParseLeftOperandToDouble(out operandLeft, expression);
            ParseRightOperandToDouble(out operandRight, expression);

            var result = (false, 0.0);
            if (expression.Contains('+'))
            {
                result = CalculateExpression(operandLeft, '+', operandRight);
            }
            else if (expression.Contains('-'))
            {
                result = CalculateExpression(operandLeft, '-', operandRight);
            }
            else if (expression.Contains('*'))
            {
                result = CalculateExpression(operandLeft, '*', operandRight);
            }
            else
            {
                result = CalculateExpression(operandLeft, '/', operandRight);
            }

            int lastPositionOfTheRightOperand = RightOperandLastPosition(expression);

            if (result.Item1)
            {
                expression = expression.Remove(0, lastPositionOfTheRightOperand + 1);
                expression = result.Item2.ToString() + expression;
            }
            else
            {
                expression = "";
                expression += "Division by zero is not allowed";
            }
        }

        private void RemovesTheLastElementIfIsAnOperator(string expression)
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

        // Method that must be execute if the operator (+, -, *, /) button was pressed.
        public string OperatorClickHandler(string expression, char operation)
        {
            if (!IsOperator(operation))
            {
                throw new FormatException("The second argument must be an operator (+, -, *, /)\n");
            }

            RemovesTheLastElementIfIsAnOperator(expression);

            // discribes the situation when the expression already includes operator
            if (expression.Contains('+') || expression.Contains('-') || expression.Contains('*') ||
                    expression.Contains('/'))
            {
                ExpressionIncludesAnOperatorWithTwoOperandsCalculate(expression);
            }
            // the situation when the operator was pressed when the expression was empty
            else if (expression.Count() == 0)
            {
                OperatorWasPressedWhenExpressionIsEmptyOrContainsMessageAboutError(expression);
            }
            // describes the situation when the comma is the last element
            else if (expression[expression.Count() - 1] == ',')
            {
                expression += "0";
            }
            // describes the situation when "Division by zero is not allowed" in the expression
            else if (expression == "Division by zero is not allowed")
            {
                expression = "";
                OperatorWasPressedWhenExpressionIsEmptyOrContainsMessageAboutError(expression);
            }

            if (expression != "Division by zero is not allowed")
            {
                AddAnOperatorToTheExpression(expression, operation);
            }

            return expression;
        }

        public string NumberClickHandler(string expression, char number)
        {
            if (!char.IsDigit(number))
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

            AddANumeralButtonToTheExpression(expression, number);

            return expression;
        }

        public string CommaClickHandler(string expression, char comma)
        {
            if (comma != ',')
            {
                throw new FormatException("The second argument must be a comma\n");
            }

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
            else if (!expression.Contains('+') && !expression.Contains('-') && !expression.Contains('*')
                    && !expression.Contains('/'))
            {
                if (!expression.Contains(','))
                {
                    expression += ',';
                }
            }
            // check if the right operator already has a comma
            else
            {
                int posOfTheOperator;
                if (expression.Contains('+'))
                {
                    posOfTheOperator = expression.IndexOf('+');
                }
                else if (expression.Contains('-'))
                {
                    posOfTheOperator = expression.IndexOf('-');
                }
                else if (expression.Contains('*'))
                {
                    posOfTheOperator = expression.IndexOf('*');
                }
                else
                {
                    posOfTheOperator = expression.IndexOf('/');
                }
                bool flagTheRightOperatorHasAComma = false;
                for (int i = posOfTheOperator + 2; i < expression.Count(); ++i)
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

        public string EquallyClickHandler(string expression, char equally)
        {
            if (equally != '=')
            {
                throw new FormatException("The second argument must be an equally\n");
            }

            if (expression.Count() == 0)
            {
                expression += "0";
            }
            else if (expression.Count() > 3 && IsOperator(expression[expression.Count() - 2]))
            {
                // duplicate the left operator if there is no right one
                expression += expression.Substring(0, expression.Count() - 3);
                ExpressionIncludesAnOperatorWithTwoOperandsCalculate(expression);
            }
            else if (char.IsDigit(expression[expression.Count() - 1]))
            {
                if (expression.Contains('+') || expression.Contains('-') || expression.Contains('*')
                        || expression.Contains('/'))
                {
                    ExpressionIncludesAnOperatorWithTwoOperandsCalculate(expression);
                }
            }

            return expression;
        }
    }
}
