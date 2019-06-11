using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleGame;

namespace ConsoleGameTests
{
    [TestClass]
    public class ConsoleGameTests
    {
        [TestMethod]
        public void MapTestCharacterCantGoAnywhere1()
        {
            var map = new Map("map1.txt");

            Assert.AreEqual(3, map.Width);
            Assert.AreEqual(3, map.Height);

            bool flagWorksRight = true;

            for (var i = 0; i < map.Height; ++i)
            {
                for (var j = 0; j < map.Width; ++j)
                {
                    if (i == 1 && j == 1 && map[i, j] != ' ' || i != 1 && j != 1 && map[i, j] != '▓')
                    {
                        flagWorksRight = false;
                        break;
                    }
                }

                if (!flagWorksRight)
                {
                    break;
                }
            }

            Assert.IsTrue(flagWorksRight);
        }

        [TestMethod]
        public void MapTestCharacterCantGoAnywhere2()
        {
            var map = new Map("map5.txt");

            Assert.AreEqual(8, map.Width);
            Assert.AreEqual(3, map.Height);

            bool flagWorksRight = true;

            for (var i = 0; i < map.Height; ++i)
            {
                for (var j = 0; j < map.Width; ++j)
                {
                    if (i == 1 && j == 3 && map[i, j] != ' ' || i != 1 && j != 3 && map[i, j] != '▓')
                    {
                        flagWorksRight = false;
                        break;
                    }
                }

                if (!flagWorksRight)
                {
                    break;
                }
            }

            Assert.IsTrue(flagWorksRight);
        }
    }
}
