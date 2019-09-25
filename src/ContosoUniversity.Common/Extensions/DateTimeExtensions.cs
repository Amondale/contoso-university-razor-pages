using System;

namespace ContosoUniversity.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime TruncateMinutesAndSeconds(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
        }
    }
}
