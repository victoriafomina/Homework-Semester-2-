using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using List;

namespace List.Tests
{
    [TestClass]
    public class ListTests
    {
        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>();
        }

        [TestMethod]
        public void PushToEmptyListTest()
        {
            list.push(1);
            Assert.IsFalse(list.isEmpty());
        }

        [TestMethod]
        public void PushToPositionTest()
        {
            list.push(1);
            list.push(2);
            list.push(3);
            list.push(4);
        }
    }
}
