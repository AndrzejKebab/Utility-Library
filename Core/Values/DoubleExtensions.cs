using System;
using System.Collections.Generic;

namespace UtilityLibrary.Core
{
	public static class DoubleExtensions
	{
		public static double PercentageOf(this double part, double whole)
		{
			if (whole == 0) return 0;
			return part / whole;
		}
		
		#region Abs
		public static double Abs(this double value) => Math.Abs(value);

		public static IEnumerable<double> Abs(this IEnumerable<double> value)
		{
			foreach (var d in value)
			{
				yield return d.Abs();
			}
		}
		#endregion

		#region Round
		/// <summary>
		/// Rounds a double value to a specified number of decimal points.
		/// </summary>
		/// <param name="value">The double value to round.</param>
		/// <param name="decimalPoints">The number of decimal points to round to.</param>
		/// <returns>The rounded double value.</returns>
		public static double RoundDecimalPoints(this double value, int decimalPoints) => Math.Round(value, decimalPoints);

		/// <summary>
		/// Rounds a double value to two decimal points.
		/// </summary>
		/// <param name="value">The double value to round.</param>
		/// <returns>The rounded double value.</returns>
		public static double RoundToTwoDecimalPoints(this double value) => Math.Round(value, 2);
		#endregion

		#region Range
		/// <summary>
		/// Determines whether a double value is within a specified range.
		/// </summary>
		/// <param name="value">The double value to check.</param>
		/// <param name="minValue">The minimum value of the range.</param>
		/// <param name="maxValue">The maximum value of the range.</param>
		/// <returns>True if the double value is within the range; otherwise, false.</returns>
		public static bool IsInRange(this double value, double minValue, double maxValue) => value >= minValue && value <= maxValue;

		/// <summary>
		/// Returns a double value if it is within a specified range; otherwise, returns a default value.
		/// </summary>
		/// <param name="value">The double value to check.</param>
		/// <param name="minValue">The minimum value of the range.</param>
		/// <param name="maxValue">The maximum value of the range.</param>
		/// <param name="defaultValue">The default value to return if the double value is not within the range.</param>
		/// <returns>The double value if it is within the range; otherwise, the default value.</returns>
		public static double InRange(this double value, double minValue, double maxValue, double defaultValue)
			=> value.IsInRange(minValue, maxValue) ? value : defaultValue;
		#endregion

		#region TimeSpan
		public static TimeSpan ToDays(this double value) => TimeSpan.FromDays(value);
        public static TimeSpan ToHours(this double value) => TimeSpan.FromHours(value);
        public static TimeSpan ToMinutes(this double value) => TimeSpan.FromMinutes(value);
        public static TimeSpan ToSeconds(this double value) => TimeSpan.FromSeconds(value);
        public static TimeSpan ToMilliseconds(this double value) => TimeSpan.FromMilliseconds(value);
        #endregion
	}
}