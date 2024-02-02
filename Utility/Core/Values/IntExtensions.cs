using System;
using System.Collections;
using System.Collections.Generic;

namespace UtilityLibrary.Core
{
	public static partial class IntExtensions
	{
		public static float PercentageOf(this int part, int whole)
		{
			if (whole == 0) return 0;
			return (float)part / whole;
		}
		
		#region Clamp
        public static int ClampMin0(this int value) => ClampMin(value, 0);
        public static int ClampMin(this int value, int min) => value < min ? min : value;
        public static int ClampMax0(this int value) => ClampMax(value, 0);
        public static int ClampMax(this int value, int max) => value > max ? max : value;
        public static int Clamp01(this int value) => Clamp(value, 0, 1);

        public static int Clamp(this int value, int min, int max)
        {
            value = value < min ? min : value;
            value = value > max ? max : value;
            return value;
        }
        #endregion

        #region Abs
        public static int Abs(this int value) => value = Math.Abs(value);

        public static IEnumerable<int> Abs(this IEnumerable<int> value)
        {
            foreach (var d in value)
            {
                yield return d.Abs();
            }
        }
        #endregion

		#region Range
		/// <summary>
		/// Determines whether an integer value is within a specified range.
		/// </summary>
		/// <param name="value">The integer value to check.</param>
		/// <param name="min">The minimum value of the range.</param>
		/// <param name="max">The maximum value of the range.</param>
		/// <returns>True if the integer value is within the range; otherwise, false.</returns>
		public static bool IsInRange(this int value, int min, int max) => value >= min && value <= max;

		/// <summary>
		/// Returns an integer value if it is within a specified range; otherwise, returns a default value.
		/// </summary>
		/// <param name="value">The integer value to check.</param>
		/// <param name="minValue">The minimum value of the range.</param>
		/// <param name="maxValue">The maximum value of the range.</param>
		/// <param name="defaultValue">The default value to return if the integer value is not within the range.</param>
		/// <returns>The integer value if it is within the range; otherwise, the default value.</returns>
		public static double InRange(this int value, int minValue, int maxValue, int defaultValue)
			=> value.IsInRange(minValue, maxValue) ? value : defaultValue;
		
		/// <summary>
		/// Determines whether an integer is within the valid index range of a list.
		/// </summary>
		/// /// <param name="value">The integer value to check.</param>
		/// <param name="list">The list for which to check the index range.</param>
		/// <returns>True if the integer is within the valid index range of the list; otherwise, false.</returns>
		public static bool IsInRangeOf(this int value, IList list) => value.IsInRange(0, list.Count - 1);
		#endregion

        #region Odd / Even
        public static bool IsEven(this int i) => i % 2 == 0;
        public static bool IsOdd(this int i) => i % 2 == 1;
        #endregion

		#region Index
		/// <summary>
		/// Returns the array index corresponding to the integer value.
		/// </summary>
		/// <param name="value">The integer value.</param>
		/// <returns>The array index. If the integer value is 0, returns 0; otherwise, returns the integer value.</returns>
		public static int GetArrayIndex(this int value) => value == 0 ? 0 : value;

		/// <summary>
		/// Determines whether an integer value is a valid index in a specified array.
		/// </summary>
		/// <param name="value">The integer value to check.</param>
		/// <param name="arrayToCheck">The array in which to check the index.</param>
		/// <returns>True if the integer value is a valid index in the array; otherwise, false.</returns>
		public static bool IsIndexInArray(this int value, Array arrayToCheck)
		{
			var result = value.GetArrayIndex().IsInRange(arrayToCheck.GetLowerBound(0), arrayToCheck.GetUpperBound(0));
			return result;
		}
		#endregion
	}
}