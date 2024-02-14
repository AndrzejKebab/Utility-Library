using System;
using System.Collections.Generic;

namespace UtilityLibrary.Core
{
    public static class ICollectionExtensions
    {
        #region Null / Empty
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            var result = collection == null || collection.Count == 0;
            return result;
        }

        public static bool IsEmpty<T>(this ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new NullReferenceException();
            }

            var result = collection.Count == 0;
            return result;
        }
		#endregion

		#region Add Unique
		/// <summary>
		/// Adds a unique item to the collection. If the item already exists, it will not be added.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to add the item to.</param>
		/// <param name="value">The item to add.</param>
		/// <returns>True if the item already exists in the collection; otherwise, false.</returns>
		public static bool AddUnique<T>(this ICollection<T> collection, T value)
		{
			var alreadyHas = collection.Contains(value);
			if (!alreadyHas)
			{
				collection.Add(value);
			}
			return alreadyHas;
		}

		/// <summary>
		/// Adds a range of unique items to the collection. If an item already exists, it will not be added.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to add the items to.</param>
		/// <param name="values">The items to add.</param>
		/// <returns>The number of items that already existed in the collection.</returns>
		public static int AddRangeUnique<T>(this ICollection<T> collection, IEnumerable<T> values)
		{
			var count = 0;
			foreach (var value in values)
			{
				if (collection.AddUnique(value))
				{
					count++;
				}
			}
			return count;
		}
		#endregion
	}
}