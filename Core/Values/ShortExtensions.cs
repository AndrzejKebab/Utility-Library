using System;
using System.Collections.Generic;

namespace UtilityLibrary.Core
{
	public static partial class ShortExtensions
	{
		public static float PercentageOf(this short part, short whole)
		{
			if (whole == 0) return 0;
			return (float)part / whole;
		}
		
		#region Abs
		public static short Abs(this short value) => Math.Abs(value);

		public static IEnumerable<short> Abs(this IEnumerable<short> value)
		{
			foreach (var d in value)
			{
				yield return d.Abs();
			}
		}
		#endregion

		#region Range
		/// <summary>
		/// Determines whether a number is in a specified range.
		/// </summary>
		/// <param name="value">The number to check.</param>
		/// <param name="minValue">The minimum value of the range.</param>
		/// <param name="maxValue">The maximum value of the range.</param>
		/// <returns>True if the number is in the range; otherwise, false.</returns>
		public static bool IsInRange(this short value, short minValue, short maxValue) => value >= minValue && value <= maxValue;

		/// <summary>
		/// Returns a number if it is in a specified range; otherwise, returns a default value.
		/// </summary>
		/// <param name="value">The number to check.</param>
		/// <param name="minValue">The minimum value of the range.</param>
		/// <param name="maxValue">The maximum value of the range.</param>
		/// <param name="defaultValue">The default value to return if the number is not in the range.</param>
		/// <returns>The number if it is in the range; otherwise, the default value.</returns>
		public static double InRange(this short value, short minValue, short maxValue, short defaultValue)
			=> value.IsInRange(minValue, maxValue) ? value : defaultValue;
		#endregion

		#region Odd / Even
		public static bool IsEven(this short value) => value % 2 == 0;
		public static bool IsOdd(this short value) => value % 2 == 1;
		#endregion
	}
}