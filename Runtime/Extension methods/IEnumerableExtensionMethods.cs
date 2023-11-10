using System.Collections.Generic;
using System;
using System.Linq;

namespace Dacen.ExtensionMethods.IEnumerables
{
    public static class ExtensionMethods_IEnumerables
    {
        /// <summary>
        /// Checks if the IEnumerable contains at least one duplicate
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerable elements</typeparam>
        /// <param name="enumerable">The IEnumerable to check</param>
        /// <returns>True if the IEnumerable contains at least one duplicate, otherwise false</returns>
        public static bool HasDuplicates<T>(this IEnumerable<T> enumerable) => enumerable.Count() != enumerable.Distinct().Count();

        /// <summary>
        /// Checks if the IEnumerable contains at least one null value
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerable elements</typeparam>
        /// <param name="enumerable">The IEnumerable to check</param>
        /// <returns>True if the IEnumerable contains at least one null value, otherwise false</returns>
        public static bool HasNull<T>(this IEnumerable<T> enumerable) => enumerable.Any(e => e == null);

        /// <summary>
        /// Gets a random element
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerable elements</typeparam>
        /// <param name="enumerable">The IEnumerable to get a random element from</param>
        /// <returns>A random element from the IEnumerable</returns>
        public static T GetRandom<T>(this IEnumerable<T> enumerable) => enumerable.ElementAt(UnityEngine.Random.Range(0, enumerable.Count()));

        /// <summary>
        /// Returns the index of the first element that is equal to the passed element
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerable elements</typeparam>
        /// <param name="enumerable">The IEnumerable to get the index from</param>
        /// <param name="element">The element to get the index for</param>
        /// <returns>The index of the first element that is equal to the passed element</returns>
        public static int IndexOf<T>(this IEnumerable<T> enumerable, T element)
        {
            int count = enumerable.Count();
            for (int i = 0; i < count; i++)
                if (enumerable.ElementAt(i).Equals(element))
                    return i;
            return -1;
        }

        /// <summary>
        /// Creates a string that lists all the elements of this IEnumerable (Example: E1, E2 and E3)
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerable elements</typeparam>
        /// <param name="enumerable">The IEnumerable to create the string for</param>
        /// <param name="toString">The method to convert each element to a string (e.ToString() is used if null)</param>
        /// <param name="separator">The separator used between each element</param>
        /// <param name="lastSeparator">The separator used between the last element and the one before</param>
        /// <returns></returns>
        public static string ToEnumerationString<T>(this IEnumerable<T> enumerable, Func<T, string> toString = null, string separator = " and ", string lastSeparator = ", ")
        {
            string enumerationString = "";
            toString ??= t => t.ToString();
            int count = 0;

            foreach (T element in enumerable)
            {
                if (count == 0)
                    enumerationString += element;
                else if (count == enumerable.Count() - 1)
                    enumerationString += separator + element;
                else
                    enumerationString += lastSeparator + element;
                count++;
            }
            return enumerationString;
        }

        /// <summary>
        /// Checks if the IEnumerable shares at least one element with another IEnumerable
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerable elements</typeparam>
        /// <param name="enumerable1">IEnumerable 1</param>
        /// <param name="enumerable2">IEnumerable 2</param>
        /// <returns>True if the IEnumerables share at least one element with each other, otherwise false</returns>
        public static bool SharesElementsWith<T>(this IEnumerable<T> enumerable1, IEnumerable<T> enumerable2)
        {
            foreach (T element in enumerable1)
                if (enumerable2.Contains(element))
                    return true;

            return false;
        }
    }
}