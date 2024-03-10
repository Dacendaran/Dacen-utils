using UnityEngine;

namespace Dacen.ExtensionMethods.Arrays
{
    public static class ExtensionMethods_Arrays
    {
        /// <summary>
        /// Gets unique random elements
        /// </summary>
        /// <typeparam name="T">Type of the array elements</typeparam>
        /// <param name="array">The array to get random elements from</param>
        /// <param name="amount">The amount of random elements to get (gets clamped to the length of the array)</param>
        /// <returns>Random elements from the array</returns>
        public static T[] GetRandom<T>(this T[] array, int amount)
        {
            amount = Mathf.Clamp(amount, 1, array.Length);
            int[] indexes = new int[array.Length];
            indexes.Fill();
            indexes.Shuffle();

            T[] randomElements = new T[amount];
            for (int i = 0; i < amount; i++)
                randomElements[i] = array[indexes[i]];

            return randomElements;
        }

        /// <summary>
        /// Performs the Fisher-Yates-shuffle on the array
        /// </summary>
        /// <typeparam name="T">Type of the array elements</typeparam>
        /// <param name="array">The array to shuffle</param>
        public static void Shuffle<T>(this T[] array)
        {
            int n = array.Length - 1;
            while (n > 1)
            {
                int k = UnityEngine.Random.Range(0, n);
                T value = array[k];
                array[k] = array[n];
                array[n] = value;
                n--;
            }
        }

        /// <summary>
        /// Fills the array with counting numbers
        /// </summary>
        /// <param name="array">The array to fill</param>
        /// <param name="start">The number to start with (so the number for index 0)</param>
        public static void Fill(this int[] array, int start = 0)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = i + start;
        }

        /// <summary>
        /// Same as <see cref="Fill(int[], int)"/>, but also returns the array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static int[] Filled(this int[] array, int start = 0)
        {
            this.Fill(start);
            return this;
        }

		/// <summary>
		/// Fills the array with one value
		/// </summary>
		/// <typeparam name="T">Type of the array elements</typeparam>
		/// <param name="array">The array to fill</param>
		/// <param name="value">The value to fill the array with</param>
		public static void Fill<T>(this T[] array, T value)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }

		/// <summary>
		/// Fills the 2D array with one value
		/// </summary>
		/// <typeparam name="T">Type of the array elements</typeparam>
		/// <param name="twoDimArray">The array to fill</param>
		/// <param name="value">The value to fill the array with</param>
		public static void Fill<T>(this T[,] twoDimArray, T value)
        {
            for(int x = 0; x < twoDimArray.GetLength(0); x++)
            {
                for(int y = 0; y < twoDimArray.GetLength(1); y++)
                {
                    twoDimArray[x, y] = value;
                }
            }
        }

		/// <summary>
		/// Fills the 3D array with one value
		/// </summary>
		/// <typeparam name="T">Type of the array elements</typeparam>
		/// <param name="twoDimArray">The array to fill</param>
		/// <param name="value">The value to fill the array with</param>
		public static void Fill<T>(this T[,,] twoDimArray, T value)
		{
			for (int x = 0; x < twoDimArray.GetLength(0); x++)
			{
				for (int y = 0; y < twoDimArray.GetLength(1); y++)
				{
					for(int z = 0; z < twoDimArray.GetLength(2); z++)
                    {
						twoDimArray[x, y, z] = value;
					}
				}
			}
		}
	}
}