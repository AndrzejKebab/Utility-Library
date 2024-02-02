using System;
using System.Collections.Generic;

namespace UtilityLibrary.Core
{
    public static class ArrayExtensions
    {
		internal static Random Rand = new();

		#region Null / Empty
		public static bool IsNullOrEmpty(this Array array) => array == null || array.Length == 0;

        public static bool IsEmpty(this Array array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }
            var result = array.Length == 0;
            return result;
        }
		#endregion

		#region Index
		/// <summary>
		/// Checks if the given index is within the bounds of the array.
		/// </summary>
		/// <param name="array">The array to check.</param>
		/// <param name="index">The index to check.</param>
		/// <returns>True if the index is within the bounds of the array; otherwise, false.</returns>
		public static bool WithinIndex(this Array array, int index)
			=> array != null && index >= 0 && index < array.Length;

		/// <summary>
		/// Checks if the given index is within the bounds of the specified dimension of the array.
		/// </summary>
		/// <param name="array">The array to check.</param>
		/// <param name="index">The index to check.</param>
		/// <param name="dimension">The zero-based dimension of the array to check.</param>
		/// <returns>True if the index is within the bounds of the specified dimension of the array; otherwise, false.</returns>
		public static bool WithinIndex(this Array array, int index, int dimension)
			=> array != null && index >= array.GetLowerBound(dimension) && index <= array.GetUpperBound(dimension);
		
		/// <summary>
		/// Calculates the flattened index for a two-dimensional array.
		/// </summary>
		/// <param name="array">The two-dimensional array.</param>
		/// <param name="x">The index along the first dimension.</param>
		/// <param name="y">The index along the second dimension.</param>
		/// <returns>The flattened index.</returns>
		public static int FlattenIndex(this Array array, int x, int y) => y * array.GetLength(0) + x;
		
		/// <summary>
		/// Calculates the flattened index for a three-dimensional array.
		/// </summary>
		/// <param name="array">The three-dimensional array.</param>
		/// <param name="x">The index along the first dimension.</param>
		/// <param name="y">The index along the second dimension.</param>
		/// <param name="z">The index along the third dimension.</param>
		/// <returns>The flattened index.</returns>
		public static int FlattenIndex(this Array array, int x, int y, int z) 
			=> (x + y * array.GetLength(0) + z * array.GetLength(0) * array.GetLength(2));
		#endregion

		#region Flatten / Unflatten
		public static T[] FlattenFrom2D<T>(T[,] input)
		{
			int width = input.GetLength(0);
			int height = input.GetLength(1);
			var flattened = new T[width * height];

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					flattened[y * width + x] = input[x, y];
				}
			}

			return flattened;
		}


		public static T[,] UnflattenTo2D<T>(T[] input, int width, int height)
		{
			T[,] unflattened = new T[width, height];

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					unflattened[x, y] = input[y * width + x];

				}
			}

			return unflattened;
		}
		#endregion

		#region Swap
		/// <summary>
		/// Swaps the elements at the specified indices in the array.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array to perform the swap operation on.</param>
		/// <param name="index1">The first index of the element to swap.</param>
		/// <param name="index2">The second index of the element to swap.</param>
		/// <returns>The array after the swap operation.</returns>
		public static T[] Swap<T>(this T[] array, int index1, int index2)
		{
			(array[index1], array[index2]) = (array[index2], array[index1]);
			return array;
		}
		#endregion

		#region Find
		/// <summary>
		/// Finds all elements in the array that match the conditions defined by the specified predicate.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array to search.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> delegate that defines the conditions of the elements to search for.</param>
		/// <returns>A List containing all elements that match the conditions defined by the specified predicate, if found; otherwise, an empty List.</returns>
		public static List<T> Find<T>(this T[] array, Predicate<T> predicate)
		{
			var ret = new List<T>();
			for (var i = 0; i < array.Length; i++)
			{
				var item = array[i];
				if (predicate(item))
				{
					ret.Add(item);
				}
			}
			return ret;
		}

		/// <summary>
		/// Searches for the specified object and returns the index of its first occurrence in a one-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The one-dimensional array to search.</param>
		/// <param name="item">The object to locate in the array.</param>
		/// <returns>The index of the first occurrence of item within the entire array, if found; otherwise, -1.</returns>
		public static int IndexOf<T>(this T[] array, object item)
		{
			var index = 0;
			foreach (var i in array)
			{
				if (item.Equals(i)) break;
				index++;
			}
			if (index >= array.Length) index = -1;
			return index;
		}
		#endregion

		#region Combine
		/// <summary>
		/// Combines two arrays into one.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the arrays.</typeparam>
		/// <param name="array">The first array.</param>
		/// <param name="other">The second array to combine with the first array.</param>
		/// <returns>A new array that includes elements from both input arrays.</returns>
		public static T[] CombineArray<T>(this T[] array, T[] other)
		{
			if (array == default(T[]) || other == default(T[])) return array;
			var initialSize = array.Length;
			Array.Resize<T>(ref array, initialSize + other.Length);
			Array.Copy(other, other.GetLowerBound(0), array, initialSize, other.Length);
			return array;
		}
		#endregion

		#region Clear
		/// <summary>
		/// Clears the value at the specified index in the array.
		/// </summary>
		/// <param name="array">The array to clear the value from.</param>
		/// <param name="index">The index of the value to clear.</param>
		/// <returns>The array after the value has been cleared.</returns>
		public static Array ClearAt(this Array array, int index)
		{
			if (array == null) return null;
			if (index >= 0 && index < array.Length)
			{
				Array.Clear(array, index, 1);
			}
			return array;
		}

		/// <summary>
		/// Clears the value at the specified index in the array.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array to clear the value from.</param>
		/// <param name="index">The index of the value to clear.</param>
		/// <returns>The array after the value has been cleared.</returns>
		public static T[] ClearAt<T>(this T[] array, int index)
		{
			if (array == null) return null;
			if (index >= 0 && index < array.Length)
			{
				array[index] = default(T);
			}
			return array;
		}

		/// <summary>
		/// Clears all values in the array.
		/// </summary>
		/// <param name="array">The array to clear the values from.</param>
		/// <returns>The array after all values have been cleared.</returns>
		public static Array ClearAll(this Array array)
		{
			if (array != null)
			{
				Array.Clear(array, 0, array.Length);
			}
			return array;
		}

		/// <summary>
		/// Clears all values in the array.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array to clear the values from.</param>
		/// <returns>The array after all values have been cleared.</returns>
		public static T[] ClearAll<T>(this T[] array)
		{
			if (array == null) return null;
			for (var i = array.GetLowerBound(0); i <= array.GetUpperBound(0); ++i)
			{
				array[i] = default(T);
			}
			return array;
		}
		#endregion

		#region Block Copy
		/// <summary>
		/// Copies a specified number of elements from a source array starting at a particular offset to a new array.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The source array.</param>
		/// <param name="index">The zero-based index in the source array at which copying begins.</param>
		/// <param name="length">The number of elements to copy.</param>
		/// <returns>A new array containing the copied elements.</returns>
		public static T[] BlockCopy<T>(this T[] array, int index, int length) => BlockCopy(array, index, length, false);

		/// <summary>
		/// Copies a specified number of elements from a source array starting at a particular offset to a new array.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The source array.</param>
		/// <param name="index">The zero-based index in the source array at which copying begins.</param>
		/// <param name="length">The number of elements to copy.</param>
		/// <param name="padToLength">If true, the returned array will be of the specified length, even if there are not enough elements in the source array to fill it.</param>
		/// <returns>A new array containing the copied elements.</returns>
		public static T[] BlockCopy<T>(this T[] array, int index, int length, bool padToLength)
		{
			if (array == null)
			{
				throw new NullReferenceException();
			}

			var n = length;
			T[] result = null;
			if (array.Length < index + length)
			{
				n = array.Length - index;
				if (padToLength)
				{
					result = new T[length];
				}
			}

			if (result == null) result = new T[n];
			Array.Copy(array, index, result, 0, n);
			return result;
		}

		/// <summary>
		/// Copies elements from a source array into a collection of arrays, each of a specified length.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The source array.</param>
		/// <param name="count">The length of each output array.</param>
		/// <param name="padToLength">If true, each output array will be of the specified length, even if there are not enough elements in the source array to fill it.</param>
		/// <returns>A collection of arrays containing the copied elements.</returns>
		public static IEnumerable<T[]> BlockCopy<T>(this T[] array, int count, bool padToLength = false)
		{
			for (var i = 0; i < array.Length; i += count)
			{
				yield return array.BlockCopy(i, count, padToLength);
			}
		}
		#endregion

		#region Convert
		/// <summary>
		/// Converts an array of a specific type to an array of objects.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array to convert.</param>
		/// <returns>An array of objects containing the elements of the original array.</returns>
		public static object[] AsObjects<T>(this T[] array)
		{
			var result = new object[array.Length];
			for (var i = 0; i < array.Length; i++)
			{
				result[i] = array[i];
			}
			return result;
		}
		#endregion

		#region Sort
		/// <summary>
		/// Sorts the elements in the entire array using the specified comparison.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The one-dimensional array to sort.</param>
		/// <param name="comparison">The comparison to use when comparing elements.</param>
		/// <returns>The sorted array.</returns>
		public static T[] Sort<T>(this T[] array, Comparison<T> comparison)
		{
			if (comparison == null)
			{
				throw new ArgumentNullException();
			}

			if (array.Length == 0)
			{
				return array;
			}

			Array.Sort(array, comparison);
			return array;
		}

		/// <summary>
		/// Sorts a range of elements in the array using the specified comparer.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The one-dimensional array to sort.</param>
		/// <param name="index">The zero-based starting index of the range to sort.</param>
		/// <param name="length">The length of the range to sort.</param>
		/// <param name="comparer">The comparer to use when comparing elements.</param>
		/// <returns>The sorted array.</returns>
		public static T[] Sort<T>(this T[] array, int index, int length, IComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException();
			}

			if (array.Length == 0)
			{
				return array;
			}

			Array.Sort(array, index, length, comparer);
			return array;
		}

		/// <summary>
		/// Sorts the elements in the array in random order.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The one-dimensional array to sort.</param>
		/// <returns>The array with elements in random order.</returns>
		public static T[] RandSort<T>(this T[] array)
		{
			var count = array.Length * 3;
			for (var i = 0; i < count; i++)
			{
				var index1 = Rand.Next(0, array.Length);
				var item1 = array[index1];
				var index2 = Rand.Next(0, array.Length);
				var item2 = array[index2];
				var temp = item2;
				array[index2] = item1;
				array[index1] = temp;
			}

			return array;
		}
		#endregion
	}
}