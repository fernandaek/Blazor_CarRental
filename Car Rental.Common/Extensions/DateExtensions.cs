using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental.Common.Extensions
{
    public static class DateExtensions
    {
        public static int Duration(this DateTime startDate, DateTime endDate)
        {
            TimeSpan time = endDate - startDate;
           

            if (time.Days == 0 && endDate.TimeOfDay - startDate.TimeOfDay > TimeSpan.MinValue)
                return 1;
            else
                return time.Days;
        }
    }
}
