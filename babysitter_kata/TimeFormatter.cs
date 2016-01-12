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
    public static class TimeFormatter
    {
        private const int CeilingMinutes = 30;
        // Partial hours not allowed.
        // Floor any values before 30 and ceiling any that are 30 or over

        /// <summary>
        /// Rounds the parameter date time based on TimeFormatter.CeilingMintues
        /// </summary>
        /// <param name="_timeToRound"></param>
        /// <returns> Rounded Hour value</returns>
        public static int roundedHourValue(DateTime _timeToRound)
        {
            if (_timeToRound.Minute >= CeilingMinutes)
                return (_timeToRound.Hour + 1);
            else return (_timeToRound.Hour);
        }
    }
}
