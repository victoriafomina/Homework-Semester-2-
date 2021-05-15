using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace List.Tests
{ 
    [TestClass]
    public class ListTests
    {
        private List<int> list;

        // initialization

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>();
        }

        // push tests

        [TestMethod]
        public void PushTestListOfOneElementCheckItIsNotEmpty()
        {
            list.PushToPosition(0, 2);
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void PushTestOneElementCheckItIsRight()
        {
            list.PushToPosition(0, 2);
            Assert.AreEqual(2, list.GetValueByPosition(0));
            Assert.AreEqual(1, list.Size);
        }

        [TestMethod]
        public void PushTestTwoElementsCheckTheyAreRight()
        {
            list.PushToPosition(0, 3);
            list.PushToPosition(1, 4);
            Assert.AreEqual(3, list.GetValueByPosition(0));
            Assert.AreEqual(4, list.GetValueByPosition(1));
        }

        [TestMethod]
        public void PushTestThreeElementsCheckTheyAreRight()
        {
            list.PushToPosition(0, 5);
            list.PushToPosition(1, 6);
            list.PushToPosition(2, 7);
            Assert.AreEqual(7, list.GetValueByPosition(2));
            Assert.AreEqual(6, list.GetValueByPosition(1));
            Assert.AreEqual(5, list.GetValueByPosition(0));
        }

        [TestMethod]
        public void PushTestTwoElementsAlwaysAddToZeroPosition()
        {
            list.PushToPosition(0, 6);
            list.PushToPosition(0, 5);
            Assert.AreEqual(5, list.GetValueByPosition(0));
            Assert.AreEqual(6, list.GetValueByPosition(1));
        }

        [TestMethod]
        public void PushTestSomeElementsAddToSimiliarPosition()
        {
            list.PushToPosition(0, 6);
            list.PushToPosition(1, 7);
            list.PushToPosition(1, 8);
            list.PushToPosition(2, 9);
            Assert.AreEqual(6, list.GetValueByPosition(0));
            Assert.AreEqual(8, list.GetValueByPosition(1));
            Assert.AreEqual(9, list.GetValueByPosition(2));
            Assert.AreEqual(7, list.GetValueByPosition(3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PushTestAddToInvalidPosition()
        {
            list.PushToPosition(1, 7);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PushTestAddToNegativePosition()
        {
            list.PushToPosition(-1, -8);
        }

        // pop tests

        [TestMethod]
        public void PopTestOneElement()
        {
            list.PushToPosition(0, 7);
            list.PopFromPosition(0);
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void PopTestTwoElements()
        {
            list.PushToPosition(0, 3);
            list.PushToPosition(1, -4);
            list.PopFromPosition(0);
            Assert.AreEqual(-4, list.GetValueByPosition(0));
        }

        [TestMethod]
        public void PopTestThreeElementsPopFromSimiliarPosition()
        {
            list.PushToPosition(0, 7);
            list.PushToPosition(1, -8);
            list.PushToPosition(2, 9);
            list.PopFromPosition(0);
            list.PopFromPosition(0);
            Assert.AreEqual(9, list.GetValueByPosition(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PopTestEmptyList()
        {
            list.PopFromPosition(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PopTestPopFromInvalidPosition()
        {
            list.PushToPosition(0, 7);
            list.PopFromPosition(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PopTestPopFromNegativePosition()
        {
            list.PushToPosition(0, 7);
            list.PopFromPosition(-1);
        }

        // get value by position tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetValueByPositionInvalidPositionEmptyList()
        {
            list.GetValueByPosition(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetValueByPositionInvalidPositionNotEmptyList()
        {
            list.PushToPosition(0, 8);
            list.PopFromPosition(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetValueByPositionInvalidNegativePosition()
        {
            list.PushToPosition(0, 6);
            list.GetValueByPosition(-1);
        }

        [TestMethod]
        public void GetValueByPositionOneElement()
        {
            list.PushToPosition(0, -7);
            Assert.AreEqual(-7, list.GetValueByPosition(0));
        }

        [TestMethod]
        public void GetValueByPositionTwoElements()
        {
            list.PushToPosition(0, 7);
            list.PushToPosition(1, 8);
            Assert.AreEqual(7, list.GetValueByPosition(0));
            Assert.AreEqual(8, list.GetValueByPosition(1));
        }

        // is empty tests

        [TestMethod]
        public void IsEmptyTestForEmptyList()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyTestForOneElement()
        {
            list.PushToPosition(0, 6);
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyTestForTwoElements()
        {
            list.PushToPosition(0, 7);
            list.PushToPosition(0, 8);
            Assert.IsFalse(list.IsEmpty());
        }

        // size of list tests

        [TestMethod]
        public void SizeTestEmptyList()
        {
            Assert.AreEqual(0, list.Size);
        }

        [TestMethod]
        public void SizeTestOneElement()
        {
            list.PushToPosition(0, 7);
            Assert.AreEqual(1, list.Size);
        }

        [TestMethod]
        public void SizeTestTwoElements()
        {
            list.PushToPosition(0, 5);
            list.PushToPosition(1, 6);
            Assert.AreEqual(2, list.Size);
        }

        [TestMethod]
        public void SizeTestAfterPop()
        {
            list.PushToPosition(0, 5);
            list.PushToPosition(1, 6);
            list.PushToPosition(2, 7);
            list.PopFromPosition(1);
            Assert.AreEqual(2, list.Size);
        }
    }
}
