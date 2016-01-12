/*
Project: Babysitter_Kata
Author: Benjamin Smith
Date: 1/11/2016
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babysitter_kata
{
    public class Babysitter
    {
        private double TotalFee = 0.0;
        private const double StartToBedOrMidnightRate = 12.0;
        private const double BedToMidnightRate = 8.0;
        private const double MidnightToEndRate = 16.0;

        public Babysitter(){}

        /// <summary>
        /// Returns the total expected fee for the job, formatted as currency
        /// </summary>
        /// <returns></returns>
        public string fee()
        {
            return String.Format("{0:C}", TotalFee);
        }

        /// <summary>
        /// Returns the total expected fee for the passed DateTime values
        /// </summary>
        /// <param name="_startTime"></param>
        /// <param name="_endTime"></param>
        /// <param name="_bedTime"></param>
        /// <returns></returns>
        public string job(DateTime _startTime, DateTime _endTime, DateTime _bedTime)
        {
            Job tonightsJob = new Job(_startTime, _endTime, _bedTime);
            return job(tonightsJob);
        }

        /// <summary>
        /// Returns the total expected fee for the job passed
        /// </summary>
        /// <param name="_newJob"></param>
        /// <returns></returns>
        public string job(Job _newJob)
        {
            if (_newJob.hasValidHours())
            {
                var normalRateHours = _newJob.getNormalRateHours();
                var bedtimeHours = _newJob.getBedTimeHours();
                var afterMidnightHours = _newJob.getAfterMidnightHours();
                TotalFee = (normalRateHours * StartToBedOrMidnightRate)
                         + (bedtimeHours * BedToMidnightRate)
                         + (afterMidnightHours * MidnightToEndRate);
            }
            return fee();
        }
    }
}
