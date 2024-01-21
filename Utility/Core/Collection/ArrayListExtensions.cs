using System;
using System.Collections;

namespace UtilityLibrary.Core
{
    public static class ArrayListExtensions
    {
        #region Null / Empty
        public static bool IsNullOrEmpty(this ArrayList arrayList)
        {
            var result = arrayList == null || arrayList.Count == 0;
            return result;
        }

        public static bool IsEmpty(this ArrayList arrayList)
        {
            if (arrayList == null)
            {
                throw new NullReferenceException();
            }

            var result = arrayList.Count == 0;
            return result;
        }
		#endregion

		#region First / Last
		/// <summary>
		/// Retrieves the first element of the ArrayList.
		/// </summary>
		/// <param name="arrayList">The ArrayList to retrieve the first element from.</param>
		/// <returns>The first element in the ArrayList, or null if the ArrayList is null or empty.</returns>
		public static object First(this ArrayList arrayList)
		{
			var result = arrayList != null && arrayList.Count > 0 ? arrayList[0] : null;
			return result;
		}

		/// <summary>
		/// Retrieves the first element of the ArrayList and casts it to the specified type.
		/// </summary>
		/// <typeparam name="T">The type to cast the element to.</typeparam>
		/// <param name="arrayList">The ArrayList to retrieve the first element from.</param>
		/// <returns>The first element in the ArrayList cast to the specified type, or the default value of the type if the ArrayList is null or empty.</returns>
		public static T First<T>(this ArrayList arrayList)
		{
			var result = arrayList != null && arrayList.Count > 0 ? (T)arrayList[0] : default(T);
			return result;
		}

		/// <summary>
		/// Retrieves the last element of the ArrayList.
		/// </summary>
		/// <param name="arrayList">The ArrayList to retrieve the last element from.</param>
		/// <returns>The last element in the ArrayList, or null if the ArrayList is null or empty.</returns>
		public static object Last(this ArrayList arrayList)
		{
			var result = arrayList != null && arrayList.Count > 0 ? arrayList[arrayList.Count - 1] : null;
			return result;
		}

		/// <summary>
		/// Retrieves the last element of the ArrayList and casts it to the specified type.
		/// </summary>
		/// <typeparam name="T">The type to cast the element to.</typeparam>
		/// <param name="arrayList">The ArrayList to retrieve the last element from.</param>
		/// <returns>The last element in the ArrayList cast to the specified type, or the default value of the type if the ArrayList is null or empty.</returns>
		public static T Last<T>(this ArrayList arrayList)
		{
			var result = arrayList != null && arrayList.Count > 0 ? (T)arrayList[arrayList.Count - 1] : default(T);
			return result;
		}
		#endregion
	}
}