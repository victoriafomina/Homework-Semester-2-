using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lambdas;

namespace ListUtilsTests
{
    [TestClass]
    public class ListUtilsTests
    {
        private List<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>();
        }

        [TestMethod]
        public void MapTestHWProj()
        {
            list = ListUtils.Map(new List<int>() { 1, 2, 3 }, x => x * 2);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(4, list[1]);
            Assert.AreEqual(6, list[2]);
        }

        [TestMethod]
        public void FilterTestHWProj()
        {
            var newList = new List<int>();
            newList.Add(8);
            newList.Add(10);
            newList.Add(0);
            newList.Add(1);
            newList.Add(-45);
            newList.Add(-7);

            list = ListUtils.Filter(newList, x => x % 5 == 0);

            Assert.AreEqual(3, list.Count);
            Assert.IsTrue(list.Contains(10));
            Assert.IsTrue(list.Contains(0));
            Assert.IsTrue(list.Contains(-45));
        }

        [TestMethod]
        public void FoldTestHWProj()
        {
            var result = ListUtils.Fold(new List<int>() { 1, 2, 3 }, 1, (acc, elem) => acc * elem);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void MapTestAddFiveToEveryElement()
        {
            list = ListUtils.Map(new List<int>() { 0, -5, 3 }, x => x + 5);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(5, list[0]);
            Assert.AreEqual(0, list[1]);
            Assert.AreEqual(8, list[2]);
        }

        [TestMethod]
        public void FilterTest()
        {
            var result = ListUtils.Fold(new List<int>() { -3, 2, 0 }, 3, (acc, elem) => acc + elem);

            Assert.AreEqual(2, result);
        }
    }
}
