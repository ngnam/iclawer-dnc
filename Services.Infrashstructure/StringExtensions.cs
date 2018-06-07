using System.Collections.Generic;
using System.Linq;

namespace Services.Infrashstructure
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Linq-able string.Join(), ersetzt aber das letzte Aufzählungszeichen mit " und "
        /// Also: "rot, grün und gelb" statt "rot, grün, gelb"
        /// </summary>
        /// <param name="items"></param>
        /// <param name="separator">Aufzählungszeichen</param>
        /// <returns></returns>
        public static string Itemize(this IEnumerable<string> items, string separator = ", ")
        {
            const string whitespace = " ";
            var itemArray = items.ToArray();
            if (itemArray.Length == 0)
            {
                return string.Empty;
            }
            var enumeration = string.Join(separator, itemArray, 0, itemArray.Length - 1);
            return enumeration + whitespace + "&" + whitespace + itemArray[itemArray.Length - 1];
        }

        public static string Left(this string text, int count)
        {
            return string.IsNullOrEmpty(text) || text.Length <= count ? text : text.Substring(0, count);
        }

        /// <summary>
        /// Damit kann String.Join() direkt in Linq-Statements eingesetzt werden
        /// </summary>
        /// <param name="items"></param>
        /// <param name="separator">Aufzählungszeichen</param>
        /// <returns></returns>
        public static string StringJoin(this IEnumerable<string> items, string separator = ", ")
        {
            return string.Join(separator, items.Where(str => !string.IsNullOrWhiteSpace(str)));
        }

        /// <summary>
        /// Prepare a string to be used as a key: ToLower()
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string NormalizeAsKey(this string str)
        {
            return str?.ToLowerInvariant();
        }
    }
}
