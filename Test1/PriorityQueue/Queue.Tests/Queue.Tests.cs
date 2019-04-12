using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Queue.Tests
{
    [TestClass]
    public class QueueTests
    {
        private PriorityQueue.Queue queue;

        [TestInitialize]
        public void Init()
        {
            queue = new PriorityQueue.Queue();
        }

        [TestMethod]
        public void EnqueueTestOnEmpty()
        {
            queue.Enqueu(3, 2);
            Assert.AreEqual(3, queue.Dequeue());
            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void EnqueueTestOnTwoElements()
        {
            queue.Enqueu(1, 10);
            queue.Enqueu(3, 7);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.IsTrue(queue.IsEmpty());
        }


        [TestMethod]
        [ExpectedException(typeof(PriorityQueue.QueueException))]
        public void DequeueFromEmptyTest()
        {
            queue.Dequeue();
        }

        [TestMethod]
        public void EnqueueTestTwoElementsThatHaveToBeChangedInQueue()
        {
            queue.Enqueu(3, 7);
            queue.Enqueu(1, 10);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void EnqueueTestThreeElements()
        {
            queue.Enqueu(1, 5);
            queue.Enqueu(3, 5);
            queue.Enqueu(2, 2);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyTestNotEmptyQueue()
        {
            queue.Enqueu(1, 1);
            Assert.IsFalse(queue.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyTestEmptyQueueFromWhichElementWasRemoved()
        {
            queue.Enqueu(1, 1);
            queue.Dequeue();
            Assert.IsTrue(queue.IsEmpty());
        }
    }
}
