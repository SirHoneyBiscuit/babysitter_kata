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
            var normalRateHours = _endTime.Hour - _startTime.Hour;
            TotalFee += normalRateHours * StartToBedOrMidnightRate;             
            return fee();
        }
    }
}
