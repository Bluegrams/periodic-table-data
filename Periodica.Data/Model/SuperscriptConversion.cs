using System;
using System.Collections.Generic;

namespace Bluegrams.Periodica.Data
{
    /// <summary>
    /// Converts digits to superscript.
    /// </summary>
    public static class SuperscriptConversion
    {
        public static readonly Dictionary<int, char> SuperscriptNumbers = new Dictionary<int, char>()
        {
            {0, '\u2070'},
            {1, '\u00b9'},
            {2, '\u00b2'},
            {3, '\u00b3'},
            {4, '\u2074'},
            {5, '\u2075'},
            {6, '\u2076'},
            {7, '\u2077'},
            {8, '\u2078'},
            {9, '\u2079'},
        };

        /// <summary>
        /// Converts every digit of the given number to a superscript char.
        /// </summary>
        /// <returns>A string containing the superscript chars.</returns>
        public static string ToSuperscript(int number)
        {
            string superscript = "";
            while (number > 0)
            {
                int digit = number % 10;
                superscript = SuperscriptNumbers[digit] + superscript;
                number /= 10;
            }
            return superscript;
        }
    }
}