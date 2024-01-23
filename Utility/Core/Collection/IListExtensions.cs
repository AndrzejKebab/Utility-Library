using System;
using System.Collections.Generic;
using UtilityLibrary.Core.LinqReplacement;

namespace UtilityLibrary.Core
{
    public static partial class IListExtensions
    {
		internal static Random Rand = new Random();

        #region Null / Empty
        public static bool IsNullOrEmpty<T>(this IList<T> list) => list == null || list.Count == 0;
        
        public static bool IsEmpty<T>(this IList<T> list)
        {
            if (list == null)
            {
                throw new NullReferenceException();
            }

            var result = list.Count == 0;
            return result;
        }
		#endregion

		#region Switch
		/// <summary>
		/// Swaps the elements at the specified indices in the list.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list in which to swap elements.</param>
		/// <param name="index1">The index of the first element to swap.</param>
		/// <param name="index2">The index of the second element to swap.</param>
		/// <returns>The list after swapping the elements.</returns>
		public static IList<T> Swap<T>(this IList<T> list, int index1, int index2)
		{
			(list[index1], list[index2]) = (list[index2], list[index1]);
			return list;
		}
		#endregion

		#region Add / Insert
		/// <summary>
		/// Adds an item to the list if it is not already present.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to add the item to.</param>
		/// <param name="item">The item to add to the list.</param>
		/// <returns>True if the item was added to the list; otherwise, false.</returns>
		public static bool AddUnique<T>(this IList<T> list, T item)
		{
			if (!list.Contains(item))
			{
				list.Add(item);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Inserts an item into the list at the specified index, if it is not already present.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to insert the item into.</param>
		/// <param name="index">The zero-based index at which to insert the item.</param>
		/// <param name="item">The item to insert into the list.</param>
		/// <returns>True if the item was inserted into the list; otherwise, false.</returns>
		public static bool InsertUnique<T>(this IList<T> list, int index, T item)
		{
			if (list.Contains(item)) return false;
			list.Insert(index, item);
			return true;
		}

		/// <summary>
		/// Inserts a range of items into the list at the specified index, skipping any items that are already present.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to insert the items into.</param>
		/// <param name="startIndex">The zero-based index at which to start inserting the items.</param>
		/// <param name="items">The items to insert into the list.</param>
		/// <returns>The number of items that were inserted into the list.</returns>
		public static int InsertRangeUnique<T>(this IList<T> list, int startIndex, IEnumerable<T> items)
		{
			var index = startIndex;
			var count = 0;
			foreach (var item in items)
			{
				if (list.Contains(item)) continue;
				list.Insert(index, item);
				count++;
				index++;
			}

			return count;
		}
		#endregion

		#region Get
		/// <summary>
		/// Tries to get a value from the list.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to get the value from.</param>
		/// <param name="value">The value to get from the list.</param>
		/// <returns>The value if it is found in the list; otherwise, the default value for type T.</returns>
		public static T TryGetValue<T>(this IList<T> list, T value)
		{
			var index = list.IndexOf(value);
			var result = index < 0 ? default(T) : value;
			return result;
		}

		/// <summary>
		/// Gets a value from the list and removes it.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to get the value from and remove it.</param>
		/// <param name="value">The value to get from the list and remove it.</param>
		/// <returns>The value if it is found in the list; otherwise, null.</returns>
		public static T GetAndRemove<T>(this IList<T> list, T value)
		{
			var result = TryGetValue(list, value);
			if (result != null) list.Remove(result);
			return result;
		}

		/// <summary>
		/// Gets a value from the list at a specific index and removes it.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to get the value from and remove it.</param>
		/// <param name="index">The index at which to get the value from the list and remove it.</param>
		/// <returns>The value at the specified index if the index is valid; otherwise, the default value for type T.</returns>
		public static T GetAndRemove<T>(this IList<T> list, int index)
		{
			if (index > list.Count - 1) return default(T);
			var result = list[index];
			list.RemoveAt(index);
			return result;
		}
		#endregion

		#region Before / After
		/// <summary>
		/// Gets the item before the specified item in the list.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to get the item from.</param>
		/// <param name="item">The item to get the preceding item of.</param>
		/// <returns>The item before the specified item in the list, or the default value for type T if the specified item is the first item in the list.</returns>
		public static T Before<T>(this IList<T> list, T item)
		{
			var index = list.IndexOf(item);
			var result = index < 1 ? default(T) : list[index - 1];
			return result;
		}

		/// <summary>
		/// Gets the item after the specified item in the list.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to get the item from.</param>
		/// <param name="item">The item to get the following item of.</param>
		/// <returns>The item after the specified item in the list, or the default value for type T if the specified item is the last item in the list.</returns>
		public static T After<T>(this IList<T> list, T item)
		{
			var index = list.IndexOf(item);
			var result = index > list.Count - 2 ? default(T) : list[index + 1];
			return result;
		}
		#endregion

		#region Find
		/// <summary>
		/// Finds the first item in the list that matches the specified predicate.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to search.</param>
		/// <param name="predicate">The predicate to match items against.</param>
		/// <returns>The first item that matches the predicate, or the default value for type T if no items match.</returns>
		public static T Find<T>(this IList<T> list, Predicate<T> predicate)
		{
			var result = default(T);
			var count = list.Count;
			for (var i = 0; i < count; i++)
			{
				var item = list[i];
				if (predicate(item))
				{
					result = item;
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Finds all items in the list that match the specified predicate.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to search.</param>
		/// <param name="predicate">The predicate to match items against.</param>
		/// <returns>A list of all items that match the predicate.</returns>
		public static List<T> FindAll<T>(this IList<T> list, Predicate<T> predicate)
		{
			var result = new List<T>();
			var count = list.Count;
			for (var i = 0; i < count; i++)
			{
				var item = list[i];
				if (predicate(item)) result.Add(item);
			}

			return result;
		}
		#endregion

		#region Move Up / Down
		/// <summary>
		/// Moves an item up in the list by a specified number of steps.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to move the item in.</param>
		/// <param name="item">The item to move up in the list.</param>
		/// <param name="step">The number of steps to move the item up by. The default is 1.</param>
		/// <returns>True if the item was moved up; otherwise, false.</returns>
		public static bool MoveUp<T>(this IList<T> list, T item, int step = 1)
		{
			if (list == null || !list.Contains(item) || step < 1) return false;
			var index = list.IndexOf(item);
			if (index <= step - 1) return false;
			list.Remove(item);
			list.Insert(index - step, item);
			return true;
		}

		/// <summary>
		/// Moves an item down in the list by a specified number of steps.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to move the item in.</param>
		/// <param name="item">The item to move down in the list.</param>
		/// <param name="step">The number of steps to move the item down by. The default is 1.</param>
		/// <returns>True if the item was moved down; otherwise, false.</returns>
		public static bool MoveDown<T>(this IList<T> list, T item, int step = 1)
		{
			if (list == null || !list.Contains(item) || step < 1) return false;
			var index = list.IndexOf(item);
			if (index >= list.Count - step) return false;
			list.Remove(item);
			list.Insert(index + step, item);
			return true;
		}
		#endregion

		#region Remove
		/// <summary>
		/// Removes repeated items from the start of the list.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to remove items from.</param>
		/// <param name="persistOne">If true, one instance of the repeated item will be left in the list; otherwise, all instances will be removed.</param>
		/// <returns>The list after removing the repeated items.</returns>
		public static IList<T> RemoveStartRepeat<T>(this IList<T> list, bool persistOne = true)
		{
			var first = list.First();
			if (first == null) return list;
			var remove = false;
			var index = 1;
			var count = list.Count;
			while (index < count && list[index].Equals(first))
			{
				var temp = list[index];
				if (temp.Equals(first))
				{
					remove = true;
					list.RemoveAt(index);
				}
			}

			if (remove && !persistOne)
			{
				list.RemoveAt(0);
			}
			return list;
		}

		/// <summary>
		/// Removes repeated items from the end of the list.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to remove items from.</param>
		/// <param name="persistOne">If true, one instance of the repeated item will be left in the list; otherwise, all instances will be removed.</param>
		/// <returns>The list after removing the repeated items.</returns>
		public static IList<T> RemoveEndRepeat<T>(this IList<T> list, bool persistOne = true)
		{
			var last = list.Last();
			if (last == null) return list;
			var remove = false;
			var count = list.Count;
			for (var i = count - 2; i >= 0; i--)
			{
				var temp = list[i];
				if (temp.Equals(last))
				{
					remove = true;
					list.RemoveAt(i + 1);
				}
			}

			if (remove && !persistOne)
			{
				list.RemoveAt(count - 1);
			}
			return list;
		}

		/// <summary>
		/// Removes duplicate items from the list.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list.</typeparam>
		/// <param name="list">The list to remove duplicates from.</param>
		/// <returns>The list after removing the duplicate items.</returns>
		public static IList<T> Distinct<T>(this IList<T> list)
		{
			var ret = new List<T>();
			var count = list.Count;
			for (var i = 0; i < count; i++)
			{
				var temp = list[i];
				if (!ret.Contains(temp))
				{
					ret.Add(temp);
				}
			}

			list.Clear();
			var retCount = ret.Count;
			for (var i = 0; i < retCount; i++)
			{
				var temp = ret[i];
				list.Add(temp);
			}
			return list;
		}
		#endregion

		#region Random
		/// <summary>
		/// Returns a random item from the list.
		/// </summary>
		/// <typeparam name="T">The type of items in the list.</typeparam>
		/// <param name="list">The list to get a random item from.</param>
		/// <returns>A random item from the list, or the default value for the type if the list is empty.</returns>
		public static T Random<T>(this IList<T> list)
		{
			var result = list.Count > 0 ? list[Rand.Next(0, list.Count)] : default(T);
			return result;
		}

		/// <summary>
		/// Returns a random item from the list that matches a predicate.
		/// </summary>
		/// <typeparam name="T">The type of items in the list.</typeparam>
		/// <param name="list">The list to get a random item from.</param>
		/// <param name="predicate">A function to test each item for a condition.</param>
		/// <returns>A random item from the list that matches the predicate, or the default value for the type if no items match the predicate.</returns>
		public static T Random<T>(this IList<T> list, Predicate<T> predicate)
		{
			var indexes = new List<int>();
			var count = list.Count;
			for (var i = 0; i < count; i++)
			{
				if (predicate(list[i]))
				{
					indexes.Add(i);
				}
			}

			if (indexes.Count == 0) return default(T);
			var randIndex = indexes.Random();
			var result = list[randIndex];
			return result;
		}

		/// <summary>
		/// Returns a specified number of random items from the list.
		/// </summary>
		/// <typeparam name="T">The type of items in the list.</typeparam>
		/// <param name="list">The list to get random items from.</param>
		/// <param name="count">The number of random items to get.</param>
		/// <param name="allowRepeat">Whether to allow the same item to be chosen more than once.</param>
		/// <returns>A list of random items from the list.</returns>
		public static List<T> Random<T>(this IList<T> list, int count, bool allowRepeat = false)
		{
			var result = new List<T>();
			var listCount = list.Count;
			if (count > listCount)
			{
				throw new IndexOutOfRangeException();
			}

			for (var i = 0; i < count; i++)
			{
				var item = list[Rand.Next(0, listCount)];
				if (!allowRepeat && result.Contains(item))
				{
					i--;
					continue;
				}

				result.Add(item);
			}

			return result;
		}

		/// <summary>
		/// Returns a random item from the list, with the probability of choosing each item proportional to its weight.
		/// </summary>
		/// <typeparam name="T">The type of items in the list.</typeparam>
		/// <param name="list">The list to get a random item from.</param>
		/// <param name="weightGetter">A function to get the weight of each item.</param>
		/// <returns>A random item from the list, chosen with probability proportional to its weight.</returns>
		public static T Random<T>(this IList<T> list, Func<T, int> weightGetter)
		{
			var weightCount = 0;
			for (var i = 0; i < list.Count; i++)
			{
				weightCount += weightGetter(list[i]);
			}

			var rand = Rand.Next(0, weightCount + 1);
			weightCount = 0;
			var index = -1;
			do
			{
				weightCount += weightGetter(list[index + 1]);
				index++;
			} while (weightCount < rand);

			var result = list[index];
			return result;
		}

		/// <summary>
		/// Returns a specified number of random items from the list, with the probability of choosing each item proportional to its weight.
		/// </summary>
		/// <typeparam name="T">The type of items in the list.</typeparam>
		/// <param name="list">The list to get random items from.</param>
		/// <param name="weightGetter">A function to get the weight of each item.</param>
		/// <param name="count">The number of random items to get.</param>
		/// <returns>A list of random items from the list, chosen with probability proportional to their weights.</returns>
		public static List<T> Random<T>(this IList<T> list, Func<T, int> weightGetter, int count)
		{
			var listCount = list.Count;
			var result = new List<T>();
			do
			{
				var item = list.Random(weightGetter);
				if (result.Contains(item)) continue;
				result.Add(item);
			} while (result.Count < count && result.Count < listCount);

			return result;
		}

		/// <summary>
		/// Returns a random item from the list, with the probability of choosing each item proportional to its weight.
		/// </summary>
		/// <typeparam name="T">The type of items in the list.</typeparam>
		/// <param name="list">The list to get a random item from.</param>
		/// <param name="weightGetter">A function to get the weight of each item.</param>
		/// <returns>A random item from the list, chosen with probability proportional to its weight.</returns>
		public static T Random<T>(this IList<T> list, Func<T, float> weightGetter)
		{
			var weightCount = 0f;
			for (var i = 0; i < list.Count; i++)
			{
				weightCount += weightGetter(list[i]);
			}

			var rand = (float)Rand.NextDouble() * weightCount;
			weightCount = 0;
			var index = -1;
			do
			{
				weightCount += weightGetter(list[index + 1]);
				index++;
			} while (weightCount < rand);

			var result = list[index];
			return result;
		}

		/// <summary>
		/// Returns a specified number of random items from the list, with the probability of choosing each item proportional to its weight.
		/// </summary>
		/// <typeparam name="T">The type of items in the list.</typeparam>
		/// <param name="list">The list to get random items from.</param>
		/// <param name="weightGetter">A function to get the weight of each item.</param>
		/// <param name="count">The number of random items to get.</param>
		/// <returns>A list of random items from the list, chosen with probability proportional to their weights.</returns>
		public static List<T> Random<T>(this IList<T> list, Func<T, float> weightGetter, int count)
		{
			var listCount = list.Count;
			var result = new List<T>();
			do
			{
				var item = list.Random(weightGetter);
				if (result.Contains(item)) continue;
				result.Add(item);
			} while (result.Count < count && result.Count < listCount);

			return result;
		}
		#endregion
	}
}