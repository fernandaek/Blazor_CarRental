using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Classes
{
    public static class DateExtensions
    {
        public static int Duration(this DateTime startDate, DateTime endDate)
        {
            TimeSpan time =  startDate - endDate;
           

            if (time.Days == 0 && endDate.TimeOfDay - startDate.TimeOfDay > TimeSpan.MinValue)
                return 1;
            else
                return time.Days;
        }
    }
}
