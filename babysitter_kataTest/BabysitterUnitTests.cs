using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using babysitter_kata;

namespace babysitter_kataTest
{
    [TestClass]
    public class BabysitterUnitTests
    {
        Babysitter sitter;
        DateTime startTime;
        DateTime endTime;
        DateTime bedTime;
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
        {
            sitter = new Babysitter();
        }

        [TestCleanup]
        public void tearDownUnitTest()
        {}

        [TestMethod]
        public void babysitterHasNoJob()
        {
            Assert.AreEqual("$0.00", sitter.fee());
        }

        [TestMethod]
        public void emptyTimesMeanNoJob()
        {
            startTime   = new DateTime();
            endTime     = new DateTime();
            bedTime     = new DateTime();
            Assert.AreEqual("$0.00", sitter.job(startTime, endTime, bedTime));
        }
    }
}
