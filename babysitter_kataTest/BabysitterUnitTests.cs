using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using babysitter_kata;

namespace babysitter_kataTest
{
    [TestClass]
    public class BabysitterUnitTests
    {

        /*  
         * The babysitter class contains a job function 
         *  It should take 3 values
         *  1. Start time
         *  2. End Time
         *  3. Bed Time
         *  Should return the fee for that job 
         */

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

        [TestMethod]
        public void emptyTimesMeanNoJob()
        {
            Babysitter sitter = new Babysitter();
            DateTime startTime = new DateTime();
            DateTime endTime = new DateTime();
            DateTime bedTime = new DateTime();
            Assert.AreEqual("$0", sitter.job(startTime, endTime, bedTime));
        }
    }
}
