using System;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private InfixCalculatorLogic calculator;

        public Calculator()
        {
            calculator = new InfixCalculatorLogic();
            InitializeComponent();
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.NumberClickHandler(expression.Text, number.Text[0]);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.NumberClickHandler(expression.Text, number.Text[0]);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.NumberClickHandler(expression.Text, number.Text[0]);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.NumberClickHandler(expression.Text, number.Text[0]);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.NumberClickHandler(expression.Text, number.Text[0]);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.NumberClickHandler(expression.Text, number.Text[0]);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.NumberClickHandler(expression.Text, number.Text[0]);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.NumberClickHandler(expression.Text, number.Text[0]);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.NumberClickHandler(expression.Text, number.Text[0]);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.NumberClickHandler(expression.Text, number.Text[0]);
        }

        private void ButtonComma_Click(object sender, EventArgs e)
        {
            var comma = (Button)sender;
            expression.Text = calculator.CommaClickHandler(expression.Text, comma.Text[0]);
        }

        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.OperatorClickHandler(expression.Text, number.Text[0]);
        }

        private void ButtonMultiply_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.OperatorClickHandler(expression.Text, number.Text[0]);
        }

        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.OperatorClickHandler(expression.Text, number.Text[0]);
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            var number = (Button)sender;
            expression.Text = calculator.OperatorClickHandler(expression.Text, number.Text[0]);
        }

        private void ButtonEqually_Click(object sender, EventArgs e)
        {
            var equally = (Button)sender;
            expression.Text = calculator.EquallyClickHandler(expression.Text, equally.Text[0]);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            expression.Clear();
        }
    }
}