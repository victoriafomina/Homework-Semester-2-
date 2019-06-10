using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniqueList.Tests
{
    [TestClass]
    public class UniqueListTests
    {
        UniqueList list;

        [TestInitialize]
        public void Initialize()
        {
            list = new UniqueList();
        }

        [TestMethod]
        public void PushToPositionTestToEmptyList()
        {
            Assert.IsTrue(list.IsEmpty());
            list.PushToPosition(0, 5);
            Assert.AreEqual(5, list.GetValueByPosition(0));
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void PushToPositionTestTwoElements()
        {
            list.PushToPosition(0, -2);
            list.PushToPosition(1, 3);
            Assert.AreEqual(-2, list.GetValueByPosition(0));
            Assert.AreEqual(3, list.GetValueByPosition(1));
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void PushToPositionTestThreeElements()
        {
            list.PushToPosition(0, 0);
            list.PushToPosition(0, -4);
            Assert.AreEqual(-4, list.GetValueByPosition(0));
            Assert.AreEqual(0, list.GetValueByPosition(1));
            list.PushToPosition(2, 5);
            Assert.AreEqual(-4, list.GetValueByPosition(0));
            Assert.AreEqual(0, list.GetValueByPosition(1));
            Assert.AreEqual(5, list.GetValueByPosition(2));
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void PushToPositionTestFiveElements()
        {
            list.PushToPosition(0, -2);
            list.PushToPosition(0, 0);
            list.PushToPosition(1, 9);
            list.PushToPosition(2, 7);
            list.PushToPosition(2, -20);
            Assert.AreEqual(0, list.GetValueByPosition(0));
            Assert.AreEqual(9, list.GetValueByPosition(1));
            Assert.AreEqual(-20, list.GetValueByPosition(2));
            Assert.AreEqual(7, list.GetValueByPosition(3));
            Assert.AreEqual(-2, list.GetValueByPosition(4));
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateElementException))]
        public void PushToPositionTestTwoElementsOneIsDuplicate()
        {
            list.PushToPosition(0, 7);
            list.PushToPosition(1, 7);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateElementException))]
        public void PushToPositionTestManyElementsAndAlsoDuplicateElement()
        {
            list.PushToPosition(0, 0);
            list.PushToPosition(1, 1);
            list.PushToPosition(2, 2);
            list.PushToPosition(0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementDoesNotExistException))]
        public void PopTestEmptyList()
        {
            list.Remove(5);
        }

        [TestMethod]
        public void PopTestOneElement()
        {
            list.PushToPosition(0, 0);
            Assert.IsTrue(list.Exists(0));
            list.Remove(0);
            Assert.IsTrue(list.IsEmpty());
            Assert.IsFalse(list.Exists(0));
        }

        [TestMethod]
        public void PopTestAfterPushWhichAfterPop()
        {
            list.PushToPosition(0, 1);
            Assert.IsTrue(list.Exists(1));
            list.Remove(1);
            Assert.IsTrue(list.IsEmpty());
            list.PushToPosition(0, 1);
            Assert.IsFalse(list.IsEmpty());
            list.Remove(1);
            Assert.IsFalse(list.Exists(1));
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void PopTestAfterPopListIsNotEmpty()
        {
            list.PushToPosition(0, 9);
            list.PushToPosition(0, -3);
            list.PushToPosition(1, 10);
            list.PushToPosition(3, 20);
            Assert.IsTrue(list.Exists(10));
            list.Remove(10);
            Assert.IsFalse(list.Exists(10));
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(ElementDoesNotExistException))]
        public void PopTestElementDoesNotExist()
        {
            list.PushToPosition(0, 9);
            list.PushToPosition(0, -3);
            list.PushToPosition(1, 10);
            list.PushToPosition(3, 20);
            list.Remove(12);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementDoesNotExistException))]
        public void PopTestTryingToPopElementThatIsAlreadyPoped()
        {
            list.PushToPosition(0, 9);
            list.PushToPosition(0, -3);
            list.PushToPosition(1, 10);
            list.PushToPosition(3, 20);
            list.Remove(10);
            list.Remove(10);
        }
    }
}