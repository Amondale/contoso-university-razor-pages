using System;
using System.Linq;

namespace ContosoUniversity.Common
{
    /// <summary>
    /// Utility class for creating strings containing random characters of a particular length.
    /// </summary>
    public static class StringGenerator
    {
        private static readonly Random Random = new Random();

        private static readonly char[] Chars =
            Enumerable
                .Range('A', 'Z' - 'A' + 1)
                .Select(x => (char)x)
                .Where(c => !char.IsControl(c))
                .ToArray();

        private static char RandomChar() => Chars[Random.Next(0, Chars.Length)];

        /// <summary>
        /// Generates a string with a random set of characters. 
        /// </summary>
        /// <param name="length">The desired string length to be returned</param>
        /// <returns></returns>
        public static string GenerateRandomString(int length)
        {
            /*
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(RandomChar());
            }
            return stringBuilder.ToString();
            */

            var chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = RandomChar();
            }
            return new string(chars);
        }
    }
}
