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
    // The start, end, and beds times are not really a charactic of a baby sitter, but rather the job itself.
    // It makes sense to split this out into it's own class.
    public class Job
    {
        DateTime StartTime;
        DateTime EndTime;
        DateTime BedTime;
        DateTime Midnight;
        private const int MinStartTime = 17;
        private const int MaxEndTime = 4;
        private const int MidnightAsHour = 24;

        private int StartHours { get { return TimeFormatter.roundedHourValue(StartTime); } }
        private int EndHours { get { return TimeFormatter.roundedHourValue(EndTime); } }
        private int BedHours { get { return TimeFormatter.roundedHourValue(BedTime); } }

        public Job(DateTime _startTime, DateTime _endTime, DateTime _bedTime)
        {
            StartTime = _startTime;
            EndTime = _endTime;
            BedTime = _bedTime;

            // If we start after midnight, we want the midnight of the next day
            // This will allow us to use the built in comparison operators
            Midnight = StartTime.Subtract(_startTime.TimeOfDay);
            if (StartHours > Midnight.Hour)
                Midnight = Midnight.AddDays(1);
        }

        /// <summary>
        /// Ensures the Job's start and end times are valid
        /// </summary>
        /// <returns></returns>
        public bool hasValidHours()
        {
            if (!isValidTime(StartHours))
                return false;
            if (!isValidTime(EndHours) || 
                (EndTime.Minute != 0 && EndTime.Hour == 4 ))
                return false;
            return true;
        }

        /// <summary>
        /// Ensures the Job's time values are valid based on the min and max value rules
        /// </summary>
        /// <param name="_hour"></param>
        /// <returns></returns>
        private bool isValidTime(int _hour)
        {
            if(isBetween(MinStartTime, MidnightAsHour, _hour) || 
                isBetween(0, MaxEndTime, _hour))
                return true;
            else return false;
        }

        /// <summary>
        ///  Returns id testValue is or is between minValue and maxValue
        /// </summary>
        /// <param name="_minValue"></param>
        /// <param name="_maxValue"></param>
        /// <param name="_testValue"></param>
        /// <returns></returns>
        private bool isBetween(int _minValue, int _maxValue, int _testValue)
        {
            if (_testValue >= _minValue && _testValue <= _maxValue)
                return true;
            else return false;
        }

        /// <summary>
        /// Gets the amount of hours that qualify for the normal rate
        /// </summary>
        /// <returns></returns>
        public int getNormalRateHours()
        {
            if (EndTime <= StartTime || 
                StartTime > Midnight)
            {
                return 0;
            }
            if (BedTime != new DateTime() && 
                BedTime < Midnight)
            {
                if(BedTime > EndTime)
                    return EndHours - StartHours;
                return BedHours - StartHours;
            }
            if (EndTime < Midnight)
                return EndHours - StartHours;
            // Since the midnight hour is 0, we need to subtract the start time from 24 (which, in this case, is also midnight)
            return MidnightAsHour - StartHours;
        }

        /// <summary>
        /// Gets the amount of hours the qualify for the midnight to end of job rate
        /// </summary>
        /// <returns></returns>
        public int getAfterMidnightHours()
        {
            if (EndTime < Midnight)
            {
                return 0;
            }
            if (StartTime > Midnight)
            {
                return EndHours - StartHours;
            }
            return EndHours;
        }

        /// <summary>
        /// Gets the amount of hours that qualify for the bedtime to midnight rate
        /// </summary>
        /// <returns></returns>
        public int getBedTimeHours()
        {
            if(BedTime == new DateTime() || 
                BedTime > Midnight || 
                BedTime < StartTime || 
                BedTime > EndTime)
            {
                return 0;
            }
            return MidnightAsHour - BedHours;
        }
    }
}
