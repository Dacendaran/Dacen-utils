using Dacen.ExtensionMethods.IEnumerables;
using Dacen.ExtensionMethods.Arrays;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Dacen.ExtensionMethods.Lists
{
    public static class ExtensionMethods_Lists
    {
        /// <summary>
        /// Gets unique random elements
        /// </summary>
        /// <typeparam name="T">Type of the list elements</typeparam>
        /// <param name="list">The list to get random elements from</param>
        /// <param name="amount">The amount of random elements to get (gets clamped to the count of the list)</param>
        /// <returns>Random elements from the list</returns>
        public static T[] GetRandom<T>(this List<T> list, int amount)
        {
            amount = Mathf.Clamp(amount, 1, list.Count);
			int[] indexes = new int[list.Count];
			indexes.Fill();
			indexes.Shuffle();

			T[] randomElements = new T[amount];
            for (int i = 0; i < amount; i++)
                randomElements[i] = list[indexes[i]];

            return randomElements;
        }

        /// <summary>
        /// Returns a random element from the list and removes it from the list
        /// </summary>
        /// <typeparam name="T">Type of the list elements</typeparam>
        /// <param name="list">The list to cut a random element from</param>
        /// <returns>The random element that was removed from the list</returns>
        public static T CutRandom<T>(this List<T> list)
        {
            T randomElement = list.GetRandom();
            list.Remove(randomElement);
            return randomElement;
        }

        public static T[] CutRandom<T>(this List<T> list, int amount)
        {
			if (amount > list.Count)
			{
				throw new Exception($"Amount of elements to cut ({amount}) is higher than number of elements in the list ({list.Count})");
			}

            T[] randomElements = list.GetRandom(amount);
            foreach(T randomElement in randomElements)
            {
                list.Remove(randomElement);
            }
            return randomElements;
		}

		/// <summary>
		/// Removes the first element from a list and returns it
		/// </summary>
		/// <typeparam name="T">Type of the list elements</typeparam>
		/// <param name="list">The list to return the first element from</param>
		/// <returns>The first element from the list</returns>
		public static T CutFirst<T>(this List<T> list)
        {
            T cutElement = list.First();
            list.RemoveAt(0);
            return cutElement;
        }

        /// <summary>
        /// Removes multiple elements from the list, starting from index 0, and returns them
        /// </summary>
        /// <typeparam name="T">Type of the list elements</typeparam>
        /// <param name="list">The list to cut elements from</param>
        /// <param name="amount">The amount of elements to cut</param>
        /// <returns>The elements that were removed from the list</returns>
        public static T[] Cut<T>(this List<T> list, int amount)
        {
            T[] cutElements = list.GetRange(0, amount).ToArray();
            list.RemoveRange(0, amount);
            return cutElements;
        }

		/// <summary>
		/// Removes a random element from the list
		/// </summary>
		/// <typeparam name="T">Type of the list elements</typeparam>
		/// <param name="list">The list to remove a random element from</param>
		public static void RemoveRandom<T>(this List<T> list)
		{
            int randomIndex = UnityEngine.Random.Range(0, list.Count);
            list.RemoveAt(randomIndex);
		}

        public static void RemoveRandom<T>(this List<T> list, int amount)
        {
            if(amount > list.Count)
            {
                throw new Exception($"Amount of elements to remove ({amount}) is higher than number of elements in the list ({list.Count})");
            }

            T[] randomElements = list.GetRandom(2);
            foreach(T element in randomElements)
            {
                list.Remove(element);
            }
        }

		/// <summary>
		/// Performs the Fisher-Yates-shuffle on the list
		/// </summary>
		/// <typeparam name="T">Type of the list elements</typeparam>
		/// <param name="list">The list to shuffle</param>
		public static void Shuffle<T>(this List<T> list)
        {
            int n = list.Count - 1;
            while (n > 1)
            {
                int k = UnityEngine.Random.Range(0, n);
				(list[n], list[k]) = (list[k], list[n]);
				n--;
            }
        }

        /// <summary>
        /// Add an item to the list if all current items inside the list meet a condition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item">The new item to add</param>
        /// <param name="predicate">The condition the current items have to meet</param>
        public static void AddIfAll<T>(this List<T> list, T item, Func<T, bool> predicate)
        {
			if (list.All(predicate))
			{
				list.Add(item);
			}
		}

		/// <summary>
		/// Removes an element at an index from a list and adds it to another list
		/// </summary>
		/// <typeparam name="T">Type of the list elements</typeparam>
		/// <param name="list">The list to remove the element from</param>
		/// <param name="index">The index of the element that should be moved</param>
		/// <param name="listToMoveTo">The list the element should be moved to</param>
		public static void MoveElementAtIndex<T>(this List<T> list, int index, List<T> listToMoveTo)
        {
            T element = list.ElementAt(index);
            list.RemoveAt(index);
            listToMoveTo.Add(element);
        }
	}
}