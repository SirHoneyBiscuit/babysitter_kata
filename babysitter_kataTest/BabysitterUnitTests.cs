/*
Project: Babysitter_Kata
Author: Benjamin Smith
Date: 1/11/2016
*/

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
        DateTime todaysDate;
        DateTime tomorrowsDate;
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
            todaysDate = DateTime.Now;
            tomorrowsDate = DateTime.Now.AddDays(1);
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

        [TestMethod]
        public void StartAndEndTimeBeforeMidnightwithNoBedTimeOneHour()
        {
            startTime = new DateTime(todaysDate.Year, todaysDate.Month, todaysDate.Day, 17,0,0);
            endTime = new DateTime(todaysDate.Year, todaysDate.Month, todaysDate.Day, 18, 0, 0);
            bedTime = new DateTime();
            Assert.AreEqual("$12.00", sitter.job(startTime, endTime, bedTime));
        }

        [TestMethod]
        public void StartAndEndTimeAtMaxValuesNoBed()
        {
            startTime = new DateTime(todaysDate.Year, todaysDate.Month, todaysDate.Day, 17, 0, 0);
            endTime = new DateTime(tomorrowsDate.Year, tomorrowsDate.Month, tomorrowsDate.Day, 4, 0, 0);
            bedTime = new DateTime();
            Assert.AreEqual("$148.00", sitter.job(startTime, endTime, bedTime));
        }

        [TestMethod]
        public void StartAndEndTimeAtMaxValuesWithABedtimeBeforeMidnight()
        {
            startTime = new DateTime(todaysDate.Year, todaysDate.Month, todaysDate.Day, 17, 0, 0);
            endTime = new DateTime(tomorrowsDate.Year, tomorrowsDate.Month, tomorrowsDate.Day, 4, 0, 0);
            bedTime = new DateTime(todaysDate.Year, todaysDate.Month, todaysDate.Day, 19, 0, 0);
            Assert.AreEqual("$128.00", sitter.job(startTime, endTime, bedTime));
        }

        [TestMethod]
        public void StartAndEndTimeWithPartialValues()
        {
            startTime = new DateTime(todaysDate.Year, todaysDate.Month, todaysDate.Day, 17, 29, 0);
            endTime = new DateTime(tomorrowsDate.Year, tomorrowsDate.Month, tomorrowsDate.Day, 3, 30, 0);
            bedTime = new DateTime();
            Assert.AreEqual("$148.00", sitter.job(startTime, endTime, bedTime));
        }

        [TestMethod]
        public void InvalidTimeReturnsNoMoney()
        {
            startTime = new DateTime(todaysDate.Year, todaysDate.Month, todaysDate.Day, 16, 0, 0);
            endTime = new DateTime(tomorrowsDate.Year, tomorrowsDate.Month, tomorrowsDate.Day, 3, 30, 0);
            bedTime = new DateTime();
            Assert.AreEqual("$0.00", sitter.job(startTime, endTime, bedTime));
        }
    }
}
