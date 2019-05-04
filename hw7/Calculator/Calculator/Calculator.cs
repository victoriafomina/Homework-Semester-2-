using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private double operandLeft = 0;
        private double operandRight = 0;
        private double result = 0;
        char operation = '+';

        public Calculator()
        {
            InitializeComponent();
        }

        private void NumeralButtonWasPressed(object sender)
        {
            textBoxExpression.Text += (sender as Button).Text;
        }

        private void OperationButtonWasPressed(object sender)
        {
            textBoxExpression.Text += " " + (sender as Button).Text + " ";
        }

        private void CalculateExpression(char operation)
        {
            switch (operation)
            {
                case '+':
                    result = operandLeft / operandRight;
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
                        throw new DivideByZeroException("Division by zero is not allowed");
                    }
                    result = operandLeft / operandRight;
                    break;
                default:
                    throw new ArgumentException("Argument \"char operation\" is not operation!");
            }
        }

        private bool IsOperator(char operation)
        {
            return operation == '+' || operation == '-' || operation == '*' || operation == '/';
        }

        private void ParseLeftOperandToDouble()
        {
            int lastPosOfTheLeftOperand = textBoxExpression.Text.IndexOf(' ') - 1;
            string leftOperand = textBoxExpression.Text.Substring(0, lastPosOfTheLeftOperand + 1);
            if (!double.TryParse(leftOperand, out operandLeft))
            {
                throw new FormatException("Invalid expression!");
            }
        }

        private void ParseRightOperandToDouble()
        {
            int firstPosOfTheRightOperand = textBoxExpression.Text.IndexOf(' ') + 3;
            
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            NumeralButtonWasPressed(sender);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            NumeralButtonWasPressed(sender);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            NumeralButtonWasPressed(sender);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            NumeralButtonWasPressed(sender);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            NumeralButtonWasPressed(sender);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            NumeralButtonWasPressed(sender);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            NumeralButtonWasPressed(sender);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            NumeralButtonWasPressed(sender);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            NumeralButtonWasPressed(sender);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            NumeralButtonWasPressed(sender);
        }

        private void ButtonComma_Click(object sender, EventArgs e)
        {
            NumeralButtonWasPressed(sender);
        }

        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            OperationButtonWasPressed(sender);

            // discribes the situation when the pressed operator is not the first operator in textBoxExpresion
            if (textBoxExpression.Text.Contains('+') || textBoxExpression.Text.Contains('-') || textBoxExpression.Text.Contains('*') ||
                    textBoxExpression.Text.IndexOf('/') != textBoxExpression.Text.LastIndexOf('/'))
            {
                ParseLeftOperandToDouble();
                ParseRightOperandToDouble();
            }
        }

        private void ButtonMultiply_Click(object sender, EventArgs e)
        {
            OperationButtonWasPressed(sender);
        }

        private void ButtonSubstract_Click(object sender, EventArgs e)
        {
            OperationButtonWasPressed(sender);
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            OperationButtonWasPressed(sender);
        }

        private void ButtonEqually_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBoxExpression.Clear();
            operandLeft = 0;
            operandRight = 0;
            result = 0;
            operation = '+';
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void TextBoxExpression_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
