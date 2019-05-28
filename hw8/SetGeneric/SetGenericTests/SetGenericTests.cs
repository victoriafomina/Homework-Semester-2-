using Microsoft.VisualStudio.TestTools.UnitTesting;
using SetGeneric;

namespace SetGenericTests
{
    [TestClass]
    public class SetGenericTests
    {
        private Set<int> set;

        [TestInitialize]
        public void Initialize()
        {
            set = new Set<int>();
        }

        // add tests

        [TestMethod]
        public void AddTestEmptySet()
        {
            Assert.IsFalse(set.Contains(1));
            Assert.AreEqual(0, set.Count);
            Assert.IsTrue(set.Add(1));
            Assert.AreEqual(1, set.Count);
            Assert.IsTrue(set.Contains(1));
        }

        [TestMethod]
        public void AddTestSomeElements()
        {
            Assert.IsFalse(set.Contains(0));
            Assert.IsFalse(set.Contains(3));
            Assert.IsFalse(set.Contains(9));
            Assert.IsFalse(set.Contains(75));
            Assert.IsFalse(set.Contains(-5));
            Assert.IsFalse(set.Contains(-24));
            Assert.IsTrue(set.Add(-5));
            Assert.IsTrue(set.Add(3));
            Assert.IsTrue(set.Add(9));
            Assert.IsTrue(set.Add(-24));
            Assert.IsTrue(set.Add(75));
            Assert.IsTrue(set.Add(0));
            Assert.AreEqual(6, set.Count);
            Assert.IsTrue(set.Contains(0));
            Assert.IsTrue(set.Contains(3));
            Assert.IsTrue(set.Contains(9));
            Assert.IsTrue(set.Contains(75));
            Assert.IsTrue(set.Contains(-5));
            Assert.IsTrue(set.Contains(-24));
        }

        [TestMethod]
        public void AddTestDuplicateElements()
        {
            Assert.IsTrue(set.Add(100));
            Assert.IsFalse(set.Add(100));
            Assert.AreEqual(1, set.Count);
            Assert.IsTrue(set.Contains(100));
        }

        // remove tests

        [TestMethod]
        public void RemoveTestEmptySet()
        {
            Assert.IsFalse(set.Remove(2));
        }

        [TestMethod]
        public void RemoveTestSomeElements()
        {
            set.Add(1);
            set.Add(2);
            set.Add(-5);
            set.Add(10);
            set.Add(-3);
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(-5));
            Assert.IsTrue(set.Remove(1));
            Assert.IsTrue(set.Remove(-5));
            Assert.IsFalse(set.Contains(1));
            Assert.IsFalse(set.Contains(-5));
        }
    }
}