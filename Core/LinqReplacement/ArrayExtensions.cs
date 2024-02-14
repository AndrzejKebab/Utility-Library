using System;

namespace UtilityLibrary.Core.LinqReplacement
{
	public static class ArrayExtensions
	{
		#region First / Last
		/// <summary>
		/// Returns the first element of an array, or a default value if the array contains no elements.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array to return the first element of.</param>
		/// <returns>The first element in the specified array or a default value if the array contains no elements.</returns>
		public static T First<T>(this T[] array)
		{
			return array.Length == 0 ? default(T) : array[0];
		}

		/// <summary>
		/// Returns the first element of an array that satisfies a specified condition, or a default value if no such element is found.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array to search for an element that satisfies the condition.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>The first element that satisfies the condition, or a default value if no such element is found.</returns>
		public static T First<T>(this T[] array, Predicate<T> predicate)
		{
			for (var i = 0; i < array.Length; i++)
			{
				var item = array[i];
				if (predicate(item))
				{
					return item;
				}
			}
			return default(T);
		}

		/// <summary>
		/// Returns the last element of an array, or a default value if the array contains no elements.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array to return the last element of.</param>
		/// <returns>The last element in the specified array or a default value if the array contains no elements.</returns>
		public static T Last<T>(this T[] array)
		{
			return array.Length == 0 ? default(T) : array[^1];
		}

		/// <summary>
		/// Returns the last element of an array that satisfies a specified condition, or a default value if no such element is found.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array to search for an element that satisfies the condition.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>The last element that satisfies the condition, or a default value if no such element is found.</returns>
		public static T Last<T>(this T[] array, Predicate<T> predicate)
		{
			for (var i = array.Length - 1; i >= 0; i--)
			{
				var item = array[i];
				if (predicate(item))
				{
					return item;
				}
			}
			return default(T);
		}
		#endregion

		#region Contains
		/// <summary>
		/// Determines whether an array contains a specific value.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array to search for the value.</param>
		/// <param name="item">The value to locate in the array.</param>
		/// <returns>True if the array contains an element that equals the specified value; otherwise, false.</returns>
		public static bool Contains<T>(this T[] array, T item)
		{
			for (var i = 0; i < array.Length; i++)
			{
				var temp = array[i];
				if (temp.Equals(item)) return true;
			}
			return false;
		}

		/// <summary>
		/// Determines whether an array contains elements that satisfy a specified condition.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array to search for elements that satisfy the condition.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>True if the array contains an element that satisfies the condition; otherwise, false.</returns>
		public static bool Contains<T>(this T[] array, Predicate<T> predicate)
		{
			for (var i = 0; i < array.Length; i++)
			{
				var temp = array[i];
				if (predicate(temp)) return true;
			}
			return false;
		}
		#endregion
	}
}