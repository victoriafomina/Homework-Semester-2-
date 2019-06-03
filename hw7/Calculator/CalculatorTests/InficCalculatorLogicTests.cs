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
        public void DivideByZeroTest()
        {
            expression = calculator.NumberClickHandler(expression, "1");
            expression = calculator.OperatorClickHandler(expression, "/");
            expression = calculator.NumberClickHandler(expression, "0");
            expression = calculator.EquallyClickHandler(expression);
            Assert.AreEqual("Division by zero is not allowed", expression);
        }
    }
}
