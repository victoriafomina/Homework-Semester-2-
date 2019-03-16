using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HashTable.Tests
{
    [TestClass]
    public class HashTableTests
    {
        private HashTable table;

        // initialization

        [TestInitialize]
        public void Initialize()
        {
            table = new HashTable();
        }

        // add tests

        [TestMethod]
        public void AddValueTestOneElement()
        {
            Initialize();
            table.AddValue(1);
            Assert.AreEqual(true, table.Exists(1));
        }

        [TestMethod]
        public void AddTestTwoValues()
        {
            Initialize();
            table.AddValue(1);
            table.AddValue(5);
            Assert.AreEqual(true, table.Exists(1));
            Assert.AreEqual(true, table.Exists(5));
        }

        [TestMethod]
        public void AddTestTwoSameValues()
        {
            Initialize();
            table.AddValue(1);
            table.AddValue(1);
            table.DeleteValue(1);
            Assert.AreEqual(true, table.Exists(1));
        }

        // delete tests
        public void DeleteTestOneElementOneDelete()
        {
            Initialize();
            table.AddValue(-8);
            table.DeleteValue(-8);
            Assert.AreEqual(false, table.Exists(-8));
        }

        [TestMethod]
        public void DeleteTestTwoSameElementsTwoDeletes()
        {
            Initialize();
            table.AddValue(0);
            table.AddValue(0);
            table.DeleteValue(0);
            table.DeleteValue(0);
            Assert.AreEqual(false, table.Exists(0));
        }

        [TestMethod]
        public void DeleteTestTwoSameElementsOneDelete()
        {
            Initialize();
            table.AddValue(4);
            table.AddValue(4);
            table.DeleteValue(4);
            Assert.AreEqual(true, table.Exists(4));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteTestDeleteElementThatDoesNotExist()
        {
            Initialize();
            table.DeleteValue(6);
        }

        // exists tests

        [TestMethod]
        public void ExistsTestOneElementCheckIfExists()
        {
            Initialize();
            table.AddValue(4);
            Assert.AreEqual(true, table.Exists(4));
        }

        [TestMethod]
        public void ExistsTestTwoElementsCheckIfExist()
        {
            Initialize();
            table.AddValue(5);
            table.AddValue(7);
            Assert.AreEqual(true, table.Exists(5));
            Assert.AreEqual(true, table.Exists(7));
        }

        [TestMethod]
        public void ExistsTestCheckIfDoesNotExist()
        {
            Initialize();
            Assert.AreEqual(false, table.Exists(5));
        }

        [TestMethod]
        public void ExistsTestCheckIfDoesNotExistDeletedElement()
        {
            Initialize();
            table.AddValue(9);
            table.DeleteValue(9);
            Assert.AreEqual(false, table.Exists(9));
        }
    }
}
