using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using babysitter_kata;

namespace babysitter_kataTest
{
    [TestClass]
    public class BabysitterUnitTests
    {

        [TestInitialize]
        public void setupUnitTest()
        {}

        [TestCleanup]
        public void tearDownUnitTest()
        {}

        [TestMethod]
        public void babysitterHasNoJob()
        {
            Babysitter sitter = new Babysitter();
            Assert.AreEqual("$0", sitter.fee());
        }
    }
}
