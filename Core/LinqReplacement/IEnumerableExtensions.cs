using System;
using System.Collections.Generic;

namespace UtilityLibrary.Core.LinqReplacement
{
    public static class IEnumerableExtensions
    {
		#region Any
		/// <summary>
		/// Determines whether a sequence contains any elements.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to check for emptiness.</param>
		/// <returns><c>True</c> if the source sequence contains any elements; otherwise, <c>False</c>.</returns>
		public static bool Any<T>(this IEnumerable<T> source)
		{
			if (source == null) return false;
			using (var enumerator = source.GetEnumerator())
			{
				if (enumerator.MoveNext()) return true;
			}
			return false;
		}

		/// <summary>
		/// Determines whether any element of a sequence satisfies a condition.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> whose elements to apply the predicate to.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns><c>True</c> if any elements in the source sequence pass the test in the specified predicate; otherwise, <c>False</c>.</returns>
		public static bool Any<T>(this IEnumerable<T> source, Predicate<T> predicate)
		{
			if (source == null) return false;
			foreach (var item in source)
			{
				if (predicate(item)) return true;
			}
			return false;
		}
        #endregion

        #region First / Last
        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to return the first element of.</param>
        /// <returns>The first element in the specified sequence or a default value if the sequence contains no elements.</returns>
        public static T First<T>(this IEnumerable<T> source)
		{
			if (source == null) return default(T);
			foreach (var item in source)
			{
				return item;
			}
			return default(T);
		}

		/// <summary>
		/// Returns the first specified number of elements from a sequence.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to return the first elements from.</param>
		/// <param name="count">The number of elements to return.</param>
		/// <returns>A list containing the first specified number of elements from the source sequence.</returns>
		public static IList<T> First<T>(this IEnumerable<T> source, int count)
		{
			if (source == null) return null;
			var result = new List<T>();
			var counter = 0;
			foreach (var item in source)
			{
				result.Add(item);
				counter++;
				if (counter >= count) break;
			}
			return result;
		}

		/// <summary>
		/// Returns the last element of a sequence, or a default value if the sequence contains no elements.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to return the last element of.</param>
		/// <returns>The last element in the specified sequence or a default value if the sequence contains no elements.</returns>
		public static T Last<T>(this IEnumerable<T> source)
		{
			if (source == null) return default(T);
			var result = default(T);
			foreach (var item in source)
			{
				result = item;
			}
			return result;
		}

		/// <summary>
		/// Returns the last specified number of elements from a sequence.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to return the last elements from.</param>
		/// <param name="count">The number of elements to return.</param>
		/// <returns>A list containing the last specified number of elements from the source sequence.</returns>
		public static IList<T> Last<T>(this IEnumerable<T> source, int count)
		{
			if (source == null) return null;
			var result = new List<T>();
			var sum = 0;
			foreach (var _ in source)
			{
				sum++;
			}

			var counter = 0;
			foreach (var item in source)
			{
				counter++;
				if (counter > sum - count)
				{
					result.Add(item);
				}
			}
			return result;
		}
		#endregion
		
		#region Min / Max
		/// <summary>
		/// Returns the minimum item in the source sequence based on a key selector function.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <typeparam name="TValue">The type of the value to compare.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to find the minimum item in.</param>
		/// <param name="keyGetter">A function to extract the comparison key from each element.</param>
		/// <param name="minValue">The minimum value found in the sequence.</param>
		/// <returns>The item with the minimum value in the source sequence.</returns>
		public static T Min<T, TValue>(this IEnumerable<T> source, Func<T, TValue> keyGetter, out TValue minValue)
		    where TValue : IComparable
		{
		    T minItem = default;
		    minValue = default(TValue);
		    foreach (var item in source)
		    {
		        if (item == null) continue;
		        var itemValue = keyGetter(item);
		        if ((minItem != null) && (itemValue.CompareTo(minValue) >= 0)) continue;
		        minValue = itemValue;
		        minItem = item;
		    }
		
		    return minItem;
		}
		
		/// <summary>
		/// Returns the minimum item in the source sequence based on a selector function.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <typeparam name="TValue">The type of the value to compare.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to find the minimum item in.</param>
		/// <param name="selector">A function to extract the comparison key from each element.</param>
		/// <returns>The item with the minimum value in the source sequence.</returns>
		public static T Min<T, TValue>(this IEnumerable<T> source, Func<T, TValue> selector)
		    where TValue : IComparable
		{
		    var result = source.Min(selector, out _);
		    return result;
		}
		
		/// <summary>
		/// Returns the maximum item in the source sequence based on a key selector function.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <typeparam name="TValue">The type of the value to compare.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to find the maximum item in.</param>
		/// <param name="selector">A function to extract the comparison key from each element.</param>
		/// <param name="maxValue">The maximum value found in the sequence.</param>
		/// <returns>The item with the maximum value in the source sequence.</returns>
		public static T Max<T, TValue>(this IEnumerable<T> source, Func<T, TValue> selector, out TValue maxValue)
		    where TValue : IComparable<TValue>
		{
		    T maxItem = default;
		    maxValue = default(TValue);
		    foreach (var item in source)
		    {
		        if (item == null) continue;
		        var itemValue = selector(item);
		        if ((maxItem != null) && (itemValue.CompareTo(maxValue) <= 0)) continue;
		        maxValue = itemValue;
		        maxItem = item;
		    }
		
		    return maxItem;
		}
		
		/// <summary>
		/// Returns the maximum item in the source sequence based on a selector function.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <typeparam name="TValue">The type of the value to compare.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to find the maximum item in.</param>
		/// <param name="keyGetter">A function to extract the comparison key from each element.</param>
		/// <returns>The item with the maximum value in the source sequence.</returns>
		public static T Max<T, TValue>(this IEnumerable<T> source, Func<T, TValue> keyGetter)
		    where TValue : IComparable<TValue>
		{
		    var result = source.Max(keyGetter, out _);
		    return result;
		}
		
		#endregion
		
		#region Select
		/// <summary>
		/// Projects each element of a sequence into a new form.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <typeparam name="TResult">The type of the value returned by the selector function.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to project.</param>
		/// <param name="selector">A transform function to apply to each element.</param>
		/// <param name="allowNull">A boolean value to determine whether null values are allowed.</param>
		/// <returns>An <see cref="IEnumerable{TResult}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
		public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector, bool allowNull = true)
		{
		    foreach (var item in source)
		    {
		        var select = selector(item);
		        if (allowNull || !Equals(select, default(T)))
		        {
		            yield return select;
		        }
		    }
		}
		#endregion
		
		#region To Array
		/// <summary>
		/// Creates an array from an IEnumerable.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to create an array from.</param>
		/// <returns>An array that contains the elements from the input sequence.</returns>
		public static T[] ToArray<T>(this IEnumerable<T> source)
		{
			var list = new List<T>();
			foreach (var item in source)
			{
				list.Add(item);
			}
			return list.ToArray();
		}
		#endregion

		#region To List
		/// <summary>
		/// Converts an IEnumerable to a List.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to be converted to a List.</param>
		/// <returns>A List that contains elements from the input sequence.</returns>
		public static List<T> ToList<T>(this IEnumerable<T> source)
		{
			var list = new List<T>();
			foreach (var item in source)
			{
				list.Add(item);
			}
			return list;
		}
		#endregion
	}
}