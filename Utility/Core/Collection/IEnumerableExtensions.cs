using System;
using System.Collections.Generic;
using System.Linq;

namespace UtilityLibrary.Core
{
    public static partial class IEnumerableExtensions
    {
        #region Null / Empty
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) => source == null || !source.Any();

        public static bool IsEmpty<T>(this IEnumerable<T> source) => !source.Any();

        public static bool IsNotEmpty<T>(this IEnumerable<T> source) => source.Any();
		#endregion

		#region Find
		/// <summary>
		/// Determines whether the collection contains elements that match the conditions defined by the specified predicate.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the source.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to search for a match in.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> delegate that defines the conditions of the elements to search for.</param>
		/// <returns>The first element in the collection that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type T.</returns>
		public static T Has<T>(this IEnumerable<T> source, Predicate<T> predicate)
		{
			foreach (var item in source)
			{
				if (predicate(item)) return item;
			}
			return default(T);
		}

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire <see cref="IEnumerable{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the source.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to search for a match in.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.</param>
		/// <returns>The first element in the collection that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type T.</returns>
		public static T Find<T>(this IEnumerable<T> source, Predicate<T> predicate)
		{
			var ret = default(T);
			foreach (var item in source)
			{
				if (predicate(item))
				{
					ret = item;
					break;
				}
			}
			return ret;
		}

		/// <summary>
		/// Retrieves all the elements that match the conditions defined by the specified predicate.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the source.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to search for a match in.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> delegate that defines the conditions of the elements to search for.</param>
		/// <returns>A <see cref="List{T}"/> containing all the elements that match the conditions defined by the specified predicate, if found; otherwise, an empty <see cref="List{T}"/>.</returns>
		public static List<T> FindAll<T>(this IEnumerable<T> source, Predicate<T> predicate)
		{
			var list = new List<T>();
			foreach (var item in source)
			{
				if (predicate(item)) list.Add(item);
			}
			return list;
		}
		#endregion

		#region Except / Without
		/// <summary>
		/// Produces the set difference of two sequences by using the default equality comparer to compare values.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the input sequences.</typeparam>
		/// <param name="source">An <see cref="IEnumerable{T}"/> whose elements that are not also in second will be returned.</param>
		/// <param name="args">An array of <see cref="IEnumerable{T}"/> whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence.</param>
		/// <returns>A sequence that contains the set difference of the elements of two sequences.</returns>
		public static IEnumerable<T> Except<T>(this IEnumerable<T> source, params T[] args) 
            => source.Except((IEnumerable<T>)args);

		/// <summary>
		/// Filters a sequence of values based on a predicate. In this case, the predicate is a function that identifies the item that should be excluded.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <param name="source">An <see cref="IEnumerable{T}"/> to filter.</param>
		/// <param name="item">The item to exclude from the source sequence.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that do not match the input item.</returns>
		public static IEnumerable<TSource> Without<TSource>(this IEnumerable<TSource> source, TSource item)
			=> source.Where(testItem => !testItem.Equals(item));
		#endregion

		#region Convert to
		/// <summary>
		/// Converts a sequence of value tuples to a Dictionary.
		/// </summary>
		/// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
		/// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
		/// <param name="values">The sequence of value tuples to convert.</param>
		/// <returns>A Dictionary that contains keys and values extracted from the input sequence.</returns>
		public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey, TValue)> values)
			=> values.ToDictionary(value => value.Item1, value => value.Item2);
		#endregion

		#region Compare
		/// <summary>
		/// Determines whether two sequences are equivalent by comparing their elements by using default equality comparer.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the input sequences.</typeparam>
		/// <param name="source">An <see cref="IEnumerable{T}"/> to compare to target.</param>
		/// <param name="target">An <see cref="IEnumerable{T}"/> to compare to the source sequence.</param>
		/// <returns>true if the two source sequences are of equal length and their corresponding elements compare as equal; otherwise, false.</returns>
		public static bool IsEquivalentTo<T>(this IEnumerable<T> source, IEnumerable<T> target)
		{
			if (source.Count() != target.Count())
			{
				return false;
			}

			foreach (var element in source)
			{
				if (!target.Contains(element))
				{
					return false;
				}
			}
			return true;
		}
		#endregion

		#region HashSet
		public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source) => new HashSet<T>(source);
        #endregion
    }
}