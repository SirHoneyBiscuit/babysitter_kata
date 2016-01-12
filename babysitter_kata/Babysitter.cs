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

        public string fee()
        {
            return String.Format("{0:C}", TotalFee);
        }

        public string job(DateTime _startTime, DateTime _endTime, DateTime _bedTime)
        {
            var midnight = _startTime.Subtract(_startTime.TimeOfDay);
            // If we start after midnight, we want the midnight of the next day
            // This will allow us to use the built in comparison functions
            if (_startTime.Hour > 4)
                midnight = midnight.AddDays(1);

            var normalRateHours = getNormalRateHours(_startTime, _endTime, midnight);
            var afterMidnightHours = getAfterMidnightHours(_startTime, _endTime, midnight);
            TotalFee = (normalRateHours * StartToBedOrMidnightRate) 
                     + (afterMidnightHours * MidnightToEndRate);             
            return fee();
        }

        public int getNormalRateHours(DateTime _startTime, DateTime _endTime, DateTime _midnight)
        {
            if(_endTime <= _startTime || _startTime > _midnight)
            {
                return 0;
            }
            if (_endTime < _midnight)
                return _endTime.Hour - _startTime.Hour;
            // Since the midnight hour is 0, we need to subtract the start time from 24 (which, in this case, is also midnight)
            return 24 - _startTime.Hour;
        }

        public int getAfterMidnightHours(DateTime _startTime, DateTime _endTime, DateTime _midnight)
        {
            if(_endTime < _midnight)
            {
                return 0;
            }
            if(_startTime > _midnight)
            {
                return _endTime.Hour - _startTime.Hour;
            }
            return _endTime.Hour;
        }
    }
}
