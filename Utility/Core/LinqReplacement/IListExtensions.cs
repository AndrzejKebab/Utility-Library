using System;
using System.Collections.Generic;

namespace UtilityLibrary.Core.LinqReplacement
{
	public static partial class IListExtensions
	{
		#region First / Last
		/// <summary>
		/// Returns the first element of a list, or a default value if the list is null or empty.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="list">The list to return the first element of.</param>
		/// <returns>The first element of the list, or a default value if the list is null or empty.</returns>
		public static T First<T>(this IList<T> list)
		{
			var result = list != null && list.Count > 0 ? list[0] : default(T);
			return result;
		}

		/// <summary>
		/// Returns the first element of a list that satisfies a specified condition, or a default value if no such element is found.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="list">The list to search for an element that satisfies the condition.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>The first element that satisfies the condition, or a default value if no such element is found.</returns>
		public static T First<T>(this IList<T> list, Predicate<T> predicate)
		{
			var count = list.Count;
			for (var i = 0; i < count; i++)
			{
				var item = list[i];
				if (predicate(item)) return item;
			}
			return default(T);
		}

		/// <summary>
		/// Returns a specified number of contiguous elements from the start of a list, optionally filtering the elements with a predicate.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="list">The list to return elements from.</param>
		/// <param name="count">The number of elements to return.</param>
		/// <param name="predicate">A function to test each element for a condition. If this parameter is null, all elements are considered to satisfy the condition.</param>
		/// <returns>A list containing the specified number of elements from the start of the list that satisfy the condition.</returns>
		public static List<T> First<T>(this IList<T> list, int count, Predicate<T> predicate = null)
		{
			if (list == null) return null;
			var result = new List<T>();
			var listCount = list.Count;
			for (var i = 0; result.Count < count && i < listCount; i++)
			{
				var item = list[i];
				if (predicate != null)
				{
					if (predicate(item))
					{
						result.Add(item);
					}
				}
				else
				{
					result.Add(item);
				}
			}
			return result;
		}

		/// <summary>
		/// Returns the last element of a list, or a default value if the list is null or empty.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="list">The list to return the last element of.</param>
		/// <returns>The last element of the list, or a default value if the list is null or empty.</returns>
		public static T Last<T>(this IList<T> list)
		{
			var result = list != null && list.Count > 0 ? list[list.Count - 1] : default(T);
			return result;
		}

		/// <summary>
		/// Returns the last element of a list that satisfies a specified condition, or a default value if no such element is found.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="list">The list to search for an element that satisfies the condition.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>The last element that satisfies the condition, or a default value if no such element is found.</returns>
		public static T Last<T>(this IList<T> list, Predicate<T> predicate)
		{
			for (var i = list.Count - 1; i >= 0; i--)
			{
				var item = list[i];
				if (predicate(item)) return item;
			}
			return default(T);
		}

		/// <summary>
		/// Returns a specified number of contiguous elements from the end of a list, optionally filtering the elements with a predicate.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="list">The list to return elements from.</param>
		/// <param name="count">The number of elements to return.</param>
		/// <param name="predicate">A function to test each element for a condition. If this parameter is null, all elements are considered to satisfy the condition.</param>
		/// <returns>A list containing the specified number of elements from the end of the list that satisfy the condition.</returns>
		public static List<T> Last<T>(this IList<T> list, int count, Predicate<T> predicate = null)
		{
			if (list == null) return null;
			var result = new List<T>();
			for (var i = list.Count - 1; result.Count < count && i >= 0; i--)
			{
				var item = list[i];
				if (predicate != null)
				{
					if (predicate(item))
					{
						result.Add(item);
					}
				}
				else
				{
					result.Add(item);
				}
			}
			return result;
		}
		#endregion

		#region Contains
		/// <summary>
		/// Determines whether a list contains elements that satisfy a specified condition.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="list">The list to search for an element that satisfies the condition.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>True if the list contains an element that satisfies the condition; otherwise, false.</returns>
		public static bool Contains<T>(this IList<T> list, Predicate<T> predicate)
		{
			var count = list.Count;
			for (var i = 0; i < count; i++)
			{
				var temp = list[i];
				if (predicate(temp)) return true;
			}
			return false;
		}
		#endregion
	}
}