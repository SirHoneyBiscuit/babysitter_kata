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
        private const int MinStartTime   = 17;
        private const int MaxEndTime     = 4;
        private const int MidnightAsHour = 24;

        public Job(DateTime _startTime, DateTime _endTime, DateTime _bedTime)
        {
            StartTime = _startTime;
            EndTime = _endTime;
            BedTime = _bedTime;

            // If we start after midnight, we want the midnight of the next day
            // This will allow us to use the built in comparison operators
            Midnight = StartTime.Subtract(_startTime.TimeOfDay);
            if (StartTime.Hour > MaxEndTime)
                Midnight = Midnight.AddDays(1);
        }

        public int getNormalRateHours()
        {
            if (EndTime <= StartTime || StartTime > Midnight)
            {
                return 0;
            }
            if (BedTime != new DateTime() && BedTime < Midnight)
            {
                if(BedTime > EndTime)
                    return EndTime.Hour - StartTime.Hour;
                return BedTime.Hour - StartTime.Hour;
            }
            if (EndTime < Midnight)
                return EndTime.Hour - StartTime.Hour;
            // Since the midnight hour is 0, we need to subtract the start time from 24 (which, in this case, is also midnight)
            return MidnightAsHour - StartTime.Hour;
        }

        public int getAfterMidnightHours()
        {
            if (EndTime < Midnight)
            {
                return 0;
            }
            if (StartTime > Midnight)
            {
                return EndTime.Hour - StartTime.Hour;
            }
            return EndTime.Hour;
        }

        public int getBedTimeHours()
        {
            if(BedTime == new DateTime() || 
                BedTime > Midnight || 
                BedTime < StartTime || 
                BedTime > EndTime)
            {
                return 0;
            }
            return MidnightAsHour - BedTime.Hour;

        }
    }
}
