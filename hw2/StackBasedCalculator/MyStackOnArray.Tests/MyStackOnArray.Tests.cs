using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackBasedCalculator.Tests
{
    [TestClass]
    public class MyStackOnArrayTests
    {
        MyStackOnArray stack;
        
        // initialize

        [TestInitialize]
        public void Initialize()
        {
            stack = new MyStackOnArray();
        }

        // IsEmpty() tests

        [TestMethod]
        public void IsEmptyTestOnEmptyStack()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyTestNotEmptyStack()
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }

        // Peek() tests

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekTestEmptyStack()
        {
            stack.Peek();
        }

        [TestMethod]
        public void PeekTestNotEmptyStack()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Peek());
            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
        }

        [TestMethod]
        public void PeekTestAfterRemove()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            Assert.AreEqual(1, stack.Peek());
        }

        // Push() tests

        [TestMethod]
        public void PushTestToEmptyStack()
        {
            stack.Push(0);
            Assert.AreEqual(0, stack.Peek());
        }

        [TestMethod]
        public void PushTestToNotEmptyStack()
        {
            stack.Push(-1);
            stack.Push(-2);
            Assert.AreEqual(-2, stack.Peek());
        }

        [TestMethod]
        public void PushTestManyElements()
        {
            int howManyElementsToPush = 105;
            for (int i = 0; i < howManyElementsToPush; ++i)
            {
                stack.Push(i);
            }
            Assert.AreEqual(104, stack.Peek());
        }

        // Pop() tests

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopTestEmptyStack()
        {
            stack.Pop();
        }

        [TestMethod]
        public void PopTestNotEmptyStack()
        {
            stack.Push(-10);
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void PopTestManyElementsToPop()
        {
            int howManyElementsToPush = 202;
            for (int i = 0; i < howManyElementsToPush; ++i)
            {
                stack.Push(-i);
            }
            for (int i = 0; i < howManyElementsToPush - 2; ++i)
            {
                stack.Pop();
            }
            Assert.AreEqual(-1, stack.Peek());
        }
    }
}