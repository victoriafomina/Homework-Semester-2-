using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class InficCalculatorLogicTests
    {
        private InfixCalculatorLogic calculator;
        private string expression;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new InfixCalculatorLogic();
            expression = "";
        }

        [TestMethod]
        public void OnePlusOneTest()
        {
            expression = calculator.NumberClickHandler(expression, "1");
            expression = calculator.OperatorClickHandler(expression, "+");
            expression = calculator.NumberClickHandler(expression, "1");
            expression = calculator.EquallyClickHandler(expression);
            Assert.AreEqual("2", expression);
        }

        [TestMethod]
        public void OneMinusTwoTest()
        {
            expression = calculator.NumberClickHandler(expression, "1");
            expression = calculator.OperatorClickHandler(expression, "-");
            expression = calculator.NumberClickHandler(expression, "2");
            expression = calculator.EquallyClickHandler(expression);
            Assert.AreEqual("-1", expression);
        }

        [TestMethod]
        public void TwoMultipliedByForDivideByOneTenthTest()
        {
            expression = calculator.NumberClickHandler(expression, "2");
            expression = calculator.OperatorClickHandler(expression, "*");
            expression = calculator.NumberClickHandler(expression, "4");
            expression = calculator.OperatorClickHandler(expression, "/");
            expression = calculator.NumberClickHandler(expression, "0");
            expression = calculator.CommaClickHandler(expression);
            expression = calculator.NumberClickHandler(expression, "1");
            expression = calculator.EquallyClickHandler(expression);
            Assert.AreEqual("80", expression);
        }

        [TestMethod]
        public void OneMultipliedByZeroDivideByNothingTest()
        {
            expression = calculator.NumberClickHandler(expression, "1");
            expression = calculator.OperatorClickHandler(expression, "*");
            expression = calculator.NumberClickHandler(expression, "0");
            expression = calculator.OperatorClickHandler(expression, "/");
            Assert.AreEqual("0 / ", expression);
        }

        [TestMethod]
        public void CommaWasPressedAfterThreeThenEquallyWasPressedTest()
        {
            expression = calculator.NumberClickHandler(expression, "3");
            expression = calculator.CommaClickHandler(expression);
            expression = calculator.EquallyClickHandler(expression);
            Assert.AreEqual("3", expression);
        }

        [TestMethod]
        public void CommaWhenPressedWhenExpressionWasEmptyThenEquallyWasPressedTest()
        {
            expression = calculator.CommaClickHandler(expression);
            expression = calculator.EquallyClickHandler(expression);
            Assert.AreEqual("0", expression);
        }

        [TestMethod]
        public void ThreeMinusSixPlusOneMinusSevenTest()
        {
            expression = calculator.NumberClickHandler(expression, "3");
            expression = calculator.OperatorClickHandler(expression, "-");
            expression = calculator.NumberClickHandler(expression, "6");
            expression = calculator.OperatorClickHandler(expression, "+");
            expression = calculator.NumberClickHandler(expression, "1");
            expression = calculator.OperatorClickHandler(expression, "-");
            expression = calculator.NumberClickHandler(expression, "7");
            expression = calculator.EquallyClickHandler(expression);
            Assert.AreEqual("-9", expression);
        }

        [TestMethod]
        public void DivideByZeroTest1()
        {
            expression = calculator.NumberClickHandler(expression, "1");
            expression = calculator.OperatorClickHandler(expression, "/");
            expression = calculator.NumberClickHandler(expression, "0");
            expression = calculator.EquallyClickHandler(expression);
            Assert.AreEqual("Division by zero is not allowed", expression);
        }

        [TestMethod]
        public void DivideByZeroTest2()
        {
            expression = calculator.NumberClickHandler(expression, "1");
            expression = calculator.OperatorClickHandler(expression, "*");
            expression = calculator.NumberClickHandler(expression, "0");
            expression = calculator.OperatorClickHandler(expression, "/");
            expression = calculator.EquallyClickHandler(expression);
            Assert.AreEqual("Division by zero is not allowed", expression);
        }

        [TestMethod]
        public void  ClearAfterDivideByZeroTest()
        {
            expression = calculator.NumberClickHandler(expression, "1");
            expression = calculator.OperatorClickHandler(expression, "/");
            expression = calculator.NumberClickHandler(expression, "0");
            expression = calculator.EquallyClickHandler(expression);
            expression = calculator.ClearClickHandler();
            Assert.AreEqual("", expression);
        }
    }
}
