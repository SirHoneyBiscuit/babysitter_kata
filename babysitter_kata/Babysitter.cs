using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babysitter_kata
{
    public class Babysitter
    {
        private int totalFee = 0;

        public Babysitter(){}

        public string fee()
        {
            return "$" + totalFee.ToString();
        }

        public string job(DateTime _startTime, DateTime _endTime, DateTime _bedTime)
        {
            return fee();
        }
    }
}
