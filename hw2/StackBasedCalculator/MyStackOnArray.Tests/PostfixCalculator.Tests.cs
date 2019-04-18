using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackBasedCalculator.Tests
{
    [TestClass]
    public class PostfixCalculatorTests
    {
        PostfixCalculator calculator;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new PostfixCalculator(new MyStackOnArray());
        }

        [TestMethod]
        public void Test1()
        {
            string expression = "11+";
            Assert.AreEqual(2, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void Test2()
        {
            string expression = "23+5*";
            Assert.AreEqual(25, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void Test3()
        {
            string expression = "11+1+1+";
            Assert.AreEqual(4, calculator.Evaluate(expression));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Test4()
        {
            string expression = "10/";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test5()
        {
            string expression = "";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        public void Test6()
        {
            string expression = "12*3+";
            Assert.AreEqual(5, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void Test7()
        {
            string expression = "23-2+3*";
            Assert.AreEqual(3, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void Test8()
        {
            string expression = "123*+";
            Assert.AreEqual(7, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void Test9()
        {
            string expression = "2222*-+";
  
          Assert.AreEqual(0, calculator.Evaluate(expression));
        }
        [TestMethod]
        public void Test10()
        {
            string expression = "923*+1-";
            Assert.AreEqual(14, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void Test11()
        {
            string expression = "12+0*";
            Assert.AreEqual(0, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void Test12()
        {
            string expression = "122*+2/";
            Assert.AreEqual(2, calculator.Evaluate(expression));
        }

        [TestMethod]
        public void Test13()
        {
            string expression = "167+*5+2/";
            Assert.AreEqual(9, calculator.Evaluate(expression));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test14()
        {
            string expression = "ab+";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test15()
        {
            string expression = "lalal";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test16()
        {
            string expression = "12.";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test17()
        {
            string expression = "1+2";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test18()
        {
            string expression = "+12";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test19()
        {
            string expression = "12+*";
            calculator.Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test20()
        {
            string expression = "12+3*1";
            calculator.Evaluate(expression);
        }
    }
}
