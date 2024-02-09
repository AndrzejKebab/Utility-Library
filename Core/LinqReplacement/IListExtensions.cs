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

		#region Min / Max
		/// <summary>
		/// Returns the minimum item in the list based on the IComparable interface.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The <see cref="IList{T}"/> to find the minimum item in.</param>
		/// <returns>The item with the minimum value in the list.</returns>
		public static T Min<T>(this IList<T> list) where T : IComparable
		{
		    return Min(list, i => i);
		}
		
		/// <summary>
		/// Returns the minimum item in the list based on a key selector function.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The <see cref="IList{T}"/> to find the minimum item in.</param>
		/// <param name="keyGetter">A function to extract the comparison key from each element.</param>
		/// <returns>The item with the minimum value in the list.</returns>
		public static T Min<T>(this IList<T> list, Func<T, IComparable> keyGetter) where T : IComparable
		{
		    if (list == null || list.Count == 0) return default;
		    var listCount = list.Count;
		    var min = keyGetter(list[0]);
		    var index = 0;
		    for (var i = 1; i < listCount; i++)
		    {
		        var current = keyGetter(list[i]);
		        if (current.CompareTo(min) < 0)
		        {
		            min = current;
		            index = i;
		        }
		    }
		
		    return list[index];
		}
		
		/// <summary>
		/// Returns the maximum item in the list based on the IComparable interface.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The <see cref="IList{T}"/> to find the maximum item in.</param>
		/// <returns>The item with the maximum value in the list.</returns>
		public static T Max<T>(this IList<T> list) where T : IComparable
		{
		    return Max(list, i => i);
		}
		
		/// <summary>
		/// Returns the maximum item in the list based on a key selector function.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The <see cref="IList{T}"/> to find the maximum item in.</param>
		/// <param name="keyGetter">A function to extract the comparison key from each element.</param>
		/// <returns>The item with the maximum value in the list.</returns>
		public static T Max<T>(this IList<T> list, Func<T, IComparable> keyGetter) where T : IComparable
		{
		    if (list == null || list.Count == 0) return default;
		    var listCount = list.Count;
		    var max = keyGetter(list[0]);
		    var index = 0;
		    for (var i = 1; i < listCount; i++)
		    {
		        var current = keyGetter(list[i]);
		        if (current.CompareTo(max) > 0)
		        {
		            max = current;
		            index = i;
		        }
		    }
		
		    return list[index];
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
		
		#region To List
		/// <summary>
		/// Converts the elements of an IList to another type and returns a List containing the converted elements.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <typeparam name="TResult">The type of the value returned by the selector function.</typeparam>
		/// <param name="list">The IList to convert.</param>
		/// <param name="selector">A transform function to apply to each element.</param>
		/// <returns>A List of TResult whose elements are the result of invoking the transform function on each element of source.</returns>
		public static List<TResult> ToList<T, TResult>(this IList<T> list, Func<T, TResult> selector)
		{
		    var result = new List<TResult>();
		    var count = list.Count;
		    for (var i = 0; i < count; i++)
		    {
		        var item = list[i];
		        var value = selector(item);
		        result.Add(value);
		    }
		
		    return result;
		}
		#endregion
		
		#region To Dictionary
		/// <summary>
		/// Converts the elements of an IList to a Dictionary using a provided key selector function.
		/// </summary>
		/// <typeparam name="TKey">The type of the key returned by the key selector function.</typeparam>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="list">The IList to convert.</param>
		/// <param name="getKeyFunc">A function to extract a key from each element.</param>
		/// <returns>A Dictionary of TKey and T whose elements are the result of invoking the key selector function on each element of source.</returns>
		public static Dictionary<TKey, T> ToDictionary<TKey, T>(this IList<T> list, Func<T, TKey> getKeyFunc)
		{
		    var result = new Dictionary<TKey, T>();
		    if (list == null) return result;
		    var count = list.Count;
		    for (var i = 0; i < count; i++)
		    {
		        var item = list[i];
		        result.Add(getKeyFunc(item), item);
		    }
		
		    return result;
		}
		
		/// <summary>
		/// Converts the elements of an IList to a Dictionary using provided key and value selector functions.
		/// </summary>
		/// <typeparam name="TKey">The type of the key returned by the key selector function.</typeparam>
		/// <typeparam name="TValue">The type of the value returned by the value selector function.</typeparam>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="list">The IList to convert.</param>
		/// <param name="getKeyFunc">A function to extract a key from each element.</param>
		/// <param name="getValueFunc">A function to extract a value from each element.</param>
		/// <returns>A Dictionary of TKey and TValue whose elements are the result of invoking the key and value selector functions on each element of source.</returns>
		public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue, T>(this IList<T> list, Func<T, TKey> getKeyFunc, Func<T, TValue> getValueFunc)
		{
		    var result = new Dictionary<TKey, TValue>();
		    if (list == null) return result;
		    var count = list.Count;
		    for (var i = 0; i < count; i++)
		    {
		        var item = list[i];
		        result.Add(getKeyFunc(item), getValueFunc(item));
		    }
		
		    return result;
		}
		#endregion
	}
}