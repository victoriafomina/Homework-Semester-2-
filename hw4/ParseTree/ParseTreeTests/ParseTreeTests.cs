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
            Assert.AreEqual("(+ 1 1)", parser.ToString());
        }

        [TestMethod]
        public void HWProjExampleTest()
        {
            prefixExpression = "(* (+ 1 1) 2)";
            parser = new ParseTree(prefixExpression);
            Assert.AreEqual(4, parser.Calculate());
        }
    }
}
