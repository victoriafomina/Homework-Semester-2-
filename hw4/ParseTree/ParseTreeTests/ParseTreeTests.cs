using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrefixParseTree;

namespace ParseTreeTests
{
    [TestClass]
    public class ParseTreeTests
    {
        private string prefixExpression;
        private ParseTree parser;

        [TestMethod]
        public void SmokeCalculateTest()
        {
            prefixExpression = "(+ 1 1)";
            parser = new ParseTree(prefixExpression);
            Assert.AreEqual(2, parser.Calculate());
        }

        [TestMethod]
        public void SmokeToStringTest()
        {
            prefixExpression = "(+ 1 1)";
            parser = new ParseTree(prefixExpression);
            Assert.AreEqual(prefixExpression, parser.ToString());
        }

        [TestMethod]
        public void HWProjExampleCalculateTest()
        {
            prefixExpression = "(* (+ 1 1) 2)";
            parser = new ParseTree(prefixExpression);
            Assert.AreEqual(4, parser.Calculate());
        }

        [TestMethod]
        public void HWProjExampleToStringTest()
        {
            prefixExpression = "(* (+ 1 1) 2)";
            parser = new ParseTree(prefixExpression);
            Assert.AreEqual(prefixExpression, parser.ToString());
        }

        [TestMethod]
        public void SmallCalculateTest()
        {
            prefixExpression = "(* (- 5 6) 7)";
            parser = new ParseTree(prefixExpression);
            Assert.AreEqual(-7, parser.Calculate());
        }

        [TestMethod]
        public void SmallToStringTest()
        {
            prefixExpression = "(* (- 5 6) 7)";
            parser = new ParseTree(prefixExpression);
            Assert.AreEqual(prefixExpression, parser.ToString());
        }

        [TestMethod]
        public void ManyOnesCalculateTest()
        {
            prefixExpression = "(+ 1 (+ 1 (+ 1 1)))";
            parser = new ParseTree(prefixExpression);
            Assert.AreEqual(4, parser.Calculate());
        }

        [TestMethod]
        public void ManyOnesToStringTest()
        {
            prefixExpression = "(+ 1 (+ 1 (+ 1 1)))";
            parser = new ParseTree(prefixExpression);
            Assert.AreEqual(prefixExpression, parser.ToString());
        }

        [TestMethod]
        public void ThreeOperandsCalculateTest()
        {
            prefixExpression = "(* (+ 2 3) (+ 10 5))";
            parser = new ParseTree(prefixExpression);
            Assert.AreEqual(75, parser.Calculate());
        }

        [TestMethod]
        public void ThreeOperandsToStringTest()
        {
            prefixExpression = "(* (+ 2 3) 8)";
            parser = new ParseTree(prefixExpression);
            Assert.AreEqual(prefixExpression, parser.ToString());
        }
    }
}
