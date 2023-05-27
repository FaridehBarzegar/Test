using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Public
{
    public static class Utility
    {
        public static string ConvertDateToPersianDate( DateTime dateTime )
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            string hour =
                persianCalendar.GetHour(dateTime) > 12 ? (persianCalendar.GetHour(dateTime) - 12 ).ToString("00") : persianCalendar.GetHour(dateTime).ToString("00");
            string persianDate =
                $"{persianCalendar.GetYear(dateTime)}" +
                $"/{persianCalendar.GetMonth(dateTime).ToString("00")}" +
                $"/{persianCalendar.GetDayOfMonth(dateTime).ToString("00")}" +
                $" {hour}:{persianCalendar.GetMinute(dateTime).ToString("00")}";
            return persianDate;


        }
    }
}
