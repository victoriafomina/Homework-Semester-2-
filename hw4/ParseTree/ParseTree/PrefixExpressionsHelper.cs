using System.Text.RegularExpressions;

namespace ParseTree
{
    public static class PrefixExpressionsHelper
    {
        /// <summary>
        /// Gets position of the last symbol in the number.
        /// </summary>
        public static int GetPositionOfLastSymbolInNumber(string expession, int firstPosOfTheNumber)
        {
            int lastPosOfTheNumber = firstPosOfTheNumber;

            for (var i = firstPosOfTheNumber; i < expession.Length; ++i)
            {
                if (!char.IsDigit(expession[i]))
                {
                    break;
                }
            }

            return lastPosOfTheNumber;
        }

        /// <summary>
        /// A string where the first symbol is a opening bracket.
        /// </summary>
        public static int GetPositionOfClosingBracket(string expression, int posOfTheOpeningBracket)
        {
            int closingBrackets = 1;
            int positionOfClosingBracket = -1;

            for (var i = posOfTheOpeningBracket + 1; i < expression.Length; ++i)
            {
                if (expression[i] == '(')
                {
                    ++closingBrackets;
                }
                else if (expression[i] == ')')
                {
                    --closingBrackets;
                }

                if (closingBrackets == 0)
                {
                    positionOfClosingBracket = i;
                    break;
                }
            }

            return positionOfClosingBracket;
        }

        /// <summary>
        /// Checks if symbol is an operator.
        /// </summary>
        public static bool IsOperator(char symbol) 
                => symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
    }
}