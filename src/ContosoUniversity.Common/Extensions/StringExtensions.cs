using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Common.Extensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// Should turn a comma delimited list of numbers into a list of numbers
        /// </summary>
        /// <param name="numbersString"></param>
        /// <returns></returns>
        public static IEnumerable<int> ToIntegerList(this string numbersString)
        {
            var numberArray = numbersString.Split(',');
            var numberList = new List<int>();
            foreach (var numberString in numberArray)
            {
                if (int.TryParse(numberString, out var number))
                    numberList.Add(number);
            }
            return numberList;
        }
        

        /// <summary>
        /// Trims a string to the desired length. 
        /// Think of it as a super substring method that handles null values a heck of a lot better than substring does.
        /// </summary>
        /// <param name="source">String to perform the action against</param>
        /// <param name="maxLength">Max length of the string to be returned</param>
        /// <param name="returnEmptyWhenNull">Will the method return an emtpy string when source is null.</param>
        /// <returns></returns>
        public static string TrimToMax(this string source, int maxLength, bool returnEmptyWhenNull = false)
        {
            if (source == null)
            {
                return returnEmptyWhenNull ? string.Empty : null;
            }

            return source.Length > maxLength ? source.Substring(0, maxLength) : source;
        }


    }
}
