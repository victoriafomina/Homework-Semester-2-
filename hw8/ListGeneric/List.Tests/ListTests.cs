using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ListGeneric;

namespace List.Tests
{
    [TestClass]
    public class ListTests
    {
        private List<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>();
        }

        [TestMethod]
        public void IsEmptyTestEmptyList()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyTestOneElementList()
        {
            list.Insert(0, 7);
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyTestNotEmptyListAfterRemove()
        {
            list.Insert(0, -4);
            list.Insert(0, 2);
            list.Remove(2);
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyTestEmptyListAfterRemove()
        {
            list.Insert(0, 0);
            list.Remove(0);
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void ClearTestsEmptyList()
        {
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void ClearTestNotEmptyList()
        {
            list.Insert(0, 0);
            list.Insert(1, 1);
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void ContainsTestEmptyList()
        {
            list.Contains(-3);
        }

        [TestMethod]
        public void ContainsTestOneElementList()
        {
            list.Insert(0, 0);
            Assert.IsTrue(list.Contains(0));
        }

        [TestMethod]
        public void ContainsTestManyElements()
        {
            list.Insert(0, 0);
            list.Insert(1, -1);
            list.Insert(1, -1);
            list.Insert(2, -2);
            list.Insert(3, -3);
            list.Insert(4, -4);
            list.Insert(5, -5);
            list.Remove(-1);
            list.Remove(-3);
            Assert.IsTrue(list.Contains(0));
            Assert.IsTrue(list.Contains(-1));
            Assert.IsTrue(list.Contains(-2));
            Assert.IsFalse(list.Contains(-3));
            Assert.IsTrue(list.Contains(-4));
            Assert.IsTrue(list.Contains(-5));
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void IndexOfTestEmptyList()
        {
            list.IndexOf(100);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementNotFoundException))]
        public void IndexOfTestElementIsNotInTheList()
        {
            list.Insert(0, -445);
            list.IndexOf(445);
        }

        [TestMethod]
        public void IndexOfTestElementsThatAreInTheList()
        {
            list.Insert(0, -10);
            list.Insert(0, 4);
            list.Insert(1, 20);
            Assert.AreEqual(0, list.IndexOf(4));
            Assert.AreEqual(1, list.IndexOf(20));
            Assert.AreEqual(2, list.IndexOf(-10));
        }

        [TestMethod]
        public void CountTestEmptyList()
        {
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void CountTestNotEmptyList()
        {
            list.Insert(0, 0);
            list.Insert(1, -1);
            list.Insert(1, -1);
            list.Insert(2, -2);
            list.Insert(3, -3);
            list.Insert(4, -4);
            list.Insert(5, -5);
            list.Remove(-1);
            list.Remove(-3);
            Assert.AreEqual(5, list.Count);
        }
    }
}
