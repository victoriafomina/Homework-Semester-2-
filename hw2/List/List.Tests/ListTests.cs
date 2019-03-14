using System;
using List;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void PushTestAddingToListOneElement()
        {
            Initialize();
            list
        }
    }
}
