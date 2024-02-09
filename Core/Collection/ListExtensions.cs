using System;
using System.Collections.Generic;
using UtilityLibrary.Core.LinqReplacement;


namespace UtilityLibrary.Core
{
    public static partial class ListExtensions
    {
		/// <summary>
		/// Removes duplicate elements from a list.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the list. The type needs to implement the IEquatable<T> interface.</typeparam>
		/// <param name="list">The list to remove duplicate elements from.</param>
		public static void RemoveDuplicates<T>(this IList<T> list) where T : IEquatable<T>
		{
			if (list.Count <= 1) return;
			list = list.Distinct().ToList();
		}
    }
}