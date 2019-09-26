using System;
using System.ComponentModel;
using System.IO;

namespace ContosoUniversity.Common.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Extension method used to remove the minute & second components from a date.
        /// Most helpful when 
        /// </summary>
        /// <param name="date">A DateTime</param>
        /// <returns>A datetime with the minute and second components set to 0.</returns>
        /// <example>
        /// <code>
        /// var myDate = DateTime(2000, 07, 15, 12, 30, 55);
        /// var myDateTruncated = myDate.TruncateMinutesAndSeconds();
        /// </code>
        /// </example>
        public static DateTime TruncateMinutesAndSeconds(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
        }


        /// <summary>
        /// Extension method used to determine if one date falls within a date range.
        /// </summary>
        /// <param name="currentDate">Date to be evaluated</param>
        /// <param name="beginDate">Begin (or start date) of date range</param>
        /// <param name="endDate">End date of date range</param>
        /// <param name="remoteTimeComponent">Optional; Will remote time component from currentDate.</param>
        /// <returns>A boolean whether the date falls within the range or not.</returns>
        public static bool IsDateInDateRange(this DateTime currentDate, DateTime beginDate, DateTime endDate, bool remoteTimeComponent = true)
        {
            if (beginDate > endDate)
            {
                throw new InvalidEnumArgumentException($"Invalid date range arguments. Begin date '{beginDate}' is after end date {endDate}.");
            }

            if (!remoteTimeComponent)
            {
                return (currentDate >= beginDate && currentDate <= endDate);
            }

            currentDate = currentDate.Date;
            beginDate = beginDate.Date;
            endDate = endDate.Date;

            return (currentDate >= beginDate && currentDate <= endDate);
        }
    }
}
