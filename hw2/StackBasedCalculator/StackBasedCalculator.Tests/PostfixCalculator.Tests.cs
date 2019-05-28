using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackBasedCalculator.Tests
{
    [TestClass]
    public class PostfixCalculatorTests
    {
        private PostfixCalculator calculator;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new PostfixCalculator(new MyStackOnArray());
        }

        [TestMethod]
        public void TestOnePlusOne()
        {
            string expression = "11+";
            Assert.AreEqual(2, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void TestTwoOperatorsExpession()
        {
            string expression = "23+5*";
            Assert.AreEqual(25, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void TestAddManyOnes()
        {
            string expression = "11+1+1+";
            Assert.AreEqual(4, calculator.Evaluate(expression));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivideByZero()
        {
            string expression = "10/";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestEmptyExpression()
        {
            string expression = "";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        public void TestTwoOperators()
        {
            string expression = "12*3+";
            Assert.AreEqual(5, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void TestThreeOperators()
        {
            string expression = "23-2+3*";
            Assert.AreEqual(3, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void TestShort1()
        {
            string expression = "123*+";
            Assert.AreEqual(7, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void TestManyTwos()
        {
            string expression = "2222*-+";

            Assert.AreEqual(0, calculator.Evaluate(expression));
        }
        [TestMethod]
        public void TestLongExpression1()
        {
            string expression = "923*+1-";
            Assert.AreEqual(14, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void TestShort2()
        {
            string expression = "12+0*";
            Assert.AreEqual(0, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void TestLongExpression2()
        {
            string expression = "122*+2/";
            Assert.AreEqual(2, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void TestLongExpression3()
        {
            string expression = "167+*5+2/";
            Assert.AreEqual(9, calculator.Evaluate(expression));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestOperandsAreLetters()
        {
            string expression = "ab+";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestExpressionIsString()
        {
            string expression = "lalal";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestPointInsteadOfOperator()
        {
            string expression = "12.";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestInfixExpression()
        {
            string expression = "1+2";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestOperantorGoesBeforeTheOperand()
        {
            string expression = "+12";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestExtraOperator()
        {
            string expression = "12+*";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestExtraOperand()
        {
            string expression = "12+3*1";
            calculator.Evaluate(expression);
        }
    }
}