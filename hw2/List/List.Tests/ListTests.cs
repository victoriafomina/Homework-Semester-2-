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
            Initialize();
            list.PushToPosition(0, 2);
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void PushTestOneElementCheckItIsRight()
        {
            Initialize();
            list.PushToPosition(0, 2);
            Assert.AreEqual(2, list.GetValueByPosition(0));
            Assert.AreEqual(1, list.Size);
        }

        [TestMethod]
        public void PushTestTwoElementsCheckTheyAreRight()
        {
            Initialize();
            list.PushToPosition(0, 3);
            list.PushToPosition(1, 4);
            Assert.AreEqual(3, list.GetValueByPosition(0));
            Assert.AreEqual(4, list.GetValueByPosition(1));
        }

        [TestMethod]
        public void PushTestThreeElementsCheckTheyAreRight()
        {
            Initialize();
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
            Initialize();
            list.PushToPosition(0, 6);
            list.PushToPosition(0, 5);
            Assert.AreEqual(5, list.GetValueByPosition(0));
            Assert.AreEqual(6, list.GetValueByPosition(1));
        }

        [TestMethod]
        public void PushTestSomeElementsAddToSimiliarPosition()
        {
            Initialize();
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
            Initialize();
            list.PushToPosition(1, 7);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PushTestAddToNegativePosition()
        {
            Initialize();
            list.PushToPosition(-1, -8);
        }

        // pop tests

        [TestMethod]
        public void PopTestOneElement()
        {
            Initialize();
            list.PushToPosition(0, 7);
            list.PopFromPosition(0);
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void PopTestTwoElements()
        {
            Initialize();
            list.PushToPosition(0, 3);
            list.PushToPosition(1, -4);
            list.PopFromPosition(0);
            Assert.AreEqual(-4, list.GetValueByPosition(0));
        }

        [TestMethod]
        public void PopTestThreeElementsPopFromSimiliarPosition()
        {
            Initialize();
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
            Initialize();
            list.PopFromPosition(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PopTestPopFromInvalidPosition()
        {
            Initialize();
            list.PushToPosition(0, 7);
            list.PopFromPosition(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PopTestPopFromNegativePosition()
        {
            Initialize();
            list.PushToPosition(0, 7);
            list.PopFromPosition(-1);
        }

        // get value by position tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetValueByPositionInvalidPositionEmptyList()
        {
            Initialize();
            list.GetValueByPosition(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetValueByPositionInvalidPositionNotEmptyList()
        {
            Initialize();
            list.PushToPosition(0, 8);
            list.PopFromPosition(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetValueByPositionInvalidNegativePosition()
        {
            Initialize();
            list.PushToPosition(0, 6);
            list.GetValueByPosition(-1);
        }

        [TestMethod]
        public void GetValueByPositionOneElement()
        {
            Initialize();
            list.PushToPosition(0, -7);
            Assert.AreEqual(-7, list.GetValueByPosition(0));
        }

        [TestMethod]
        public void GetValueByPositionTwoElements()
        {
            Initialize();
            list.PushToPosition(0, 7);
            list.PushToPosition(1, 8);
            Assert.AreEqual(7, list.GetValueByPosition(0));
            Assert.AreEqual(8, list.GetValueByPosition(1));
        }

        // is empty tests

        [TestMethod]
        public void IsEmptyTestForEmptyList()
        {
            Initialize();
            Assert.AreEqual(true, list.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyTestForOneElement()
        {
            Initialize();
            list.PushToPosition(0, 6);
            Assert.AreEqual(false, list.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyTestForTwoElements()
        {
            Initialize();
            list.PushToPosition(0, 7);
            list.PushToPosition(0, 8);
            Assert.AreEqual(false, list.IsEmpty());
        }

        // size of list tests

        [TestMethod]
        public void SizeTestEmptyList()
        {
            Initialize();
            Assert.AreEqual(0, list.Size);
        }

        [TestMethod]
        public void SizeTestOneElement()
        {
            Initialize();
            list.PushToPosition(0, 7);
            Assert.AreEqual(1, list.Size);
        }

        [TestMethod]
        public void SizeTestTwoElements()
        {
            Initialize();
            list.PushToPosition(0, 5);
            list.PushToPosition(1, 6);
            Assert.AreEqual(2, list.Size);
        }

        [TestMethod]
        public void SizeTestAfterPop()
        {
            Initialize();
            list.PushToPosition(0, 5);
            list.PushToPosition(1, 6);
            list.PushToPosition(2, 7);
            list.PopFromPosition(1);
            Assert.AreEqual(2, list.Size);
        }
    }
}
