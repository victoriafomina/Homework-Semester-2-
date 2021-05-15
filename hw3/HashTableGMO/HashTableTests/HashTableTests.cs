using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HashTableTests
{
    [TestClass]
    public class HashTableTests
    {
        private HashTableGMO.IHashing hashing;
        private HashTableGMO.HashTable table;

        [TestInitialize]
        public void Init()
        {
            hashing = new HashTableGMO.Hashing();
            table = new HashTableGMO.HashTable(hashing);
        }

        [TestMethod]
        public void AddValueTestOneElement()
        {
            table.AddValue(1);
            Assert.IsTrue(table.Exists(1));
        }

        [TestMethod]
        public void AddTestTwoValues()
        {
            table.AddValue(1);
            table.AddValue(5);
            Assert.IsTrue(table.Exists(1));
            Assert.IsTrue(table.Exists(5));
        }

        [TestMethod]
        public void AddTestTwoSameValues()
        {
            table.AddValue(1);
            table.AddValue(1);
            table.DeleteValue(1);
            Assert.IsTrue(table.Exists(1));
        }

        // delete tests
        public void DeleteTestOneElementOneDelete()
        {
            table.AddValue(-8);
            table.DeleteValue(-8);
            Assert.IsFalse(table.Exists(-8));
        }

        [TestMethod]
        public void DeleteTestTwoSameElementsTwoDeletes()
        {
            table.AddValue(0);
            table.AddValue(0);
            table.DeleteValue(0);
            table.DeleteValue(0);
            Assert.IsFalse(table.Exists(0));
        }

        [TestMethod]
        public void DeleteTestTwoSameElementsOneDelete()
        {
            table.AddValue(4);
            table.AddValue(4);
            table.DeleteValue(4);
            Assert.IsTrue(table.Exists(4));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteTestDeleteElementThatDoesNotExist()
        {
            table.DeleteValue(6);
        }

        // exists tests

        [TestMethod]
        public void ExistsTestOneElementCheckIfExists()
        {
            table.AddValue(4);
            Assert.IsTrue(table.Exists(4));
        }

        [TestMethod]
        public void ExistsTestTwoElementsCheckIfExist()
        {
            table.AddValue(5);
            table.AddValue(7);
            Assert.IsTrue(table.Exists(5));
            Assert.IsTrue(table.Exists(7));
        }

        [TestMethod]
        public void ExistsTestCheckIfDoesNotExist()
        {
            Assert.IsFalse(table.Exists(5));
        }

        [TestMethod]
        public void ExistsTestCheckIfDoesNotExistDeletedElement()
        {
            table.AddValue(9);
            table.DeleteValue(9);
            Assert.IsFalse(table.Exists(9));
        }
    }
}
