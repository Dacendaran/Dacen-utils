using System.Collections.Generic;
using System.Linq;

namespace Dacen.ExtensionMethods.Dictionaries
{
    public static class ExtensionMethods_Dictionaries
    {
        /// <summary>
        /// Adds an element to the list that serves as a value in this dictionary.
        /// If the passed key doesn't exist in the dictionary yet, adds a KeyValuePair for it first
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of this dictionary</typeparam>
        /// <typeparam name="TList">The type of the list elements in this dictionary</typeparam>
        /// <param name="dictionary">The dictionary to add the passed element to</param>
        /// <param name="key">The key for the list the passed element should be added to</param>
        /// <param name="listElement">The element to add to a list in the dictionary</param>
        public static void AddSafely<TKey, TList>(this Dictionary<TKey, List<TList>> dictionary, TKey key, TList listElement)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key].Add(listElement);
            else
                dictionary.Add(key, new List<TList>() { listElement });
        }

        /// <summary>
        /// Checks if the dictionary contains all the passed keys
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in this dictionary</typeparam>
        /// <typeparam name="TValue">The type of the values in this dictionary</typeparam>
        /// <param name="dictionary">The dictionary to check for keys</param>
        /// <param name="keys">The keys the dictionary should have</param>
        /// <returns>True if the dictionary contains all the passed keys, otherwise false</returns>
        public static bool ContainsKeys<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey[] keys) => keys.All(k => dictionary.ContainsKey(k));
    }
}