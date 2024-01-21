using System.Collections.Generic;

namespace UtilityLibrary.Core
{
    public static class HashSetExtensions
    {
		/// <summary>
		/// Adds a range of elements to the end of the HashSet.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the HashSet.</typeparam>
		/// <param name="hashSet">The HashSet to add the elements to.</param>
		/// <param name="range">The collection whose elements should be added to the end of the HashSet.</param>
		public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> range)
		{
			foreach (var item in range)
			{
				hashSet.Add(item);
			}
		}
	}
}