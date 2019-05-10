using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinalTestTests
{
    [TestClass]
    public class FinalTestTest
    {
        private string[] array;
        private FinalTest.ListApplication app;

        [TestMethod]
        public void TestMethod1()
        {
            array = new string[2];
            array[0] += "lala ololo";
            array[1] += "tltltltltlt ololo epepepep";
            app = new FinalTest.ListApplication(array);
            Assert.AreEqual("lala ololo ololo epepepep tltltltltlt ", app.ToString());
        }
    }
}
