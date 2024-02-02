using System;
using System.Collections.Generic;

namespace UtilityLibrary.Core
{
    public static partial class FloatExtensions
    {
	    public static float PercentageOf(this float part, float whole)
	    {
		    if (whole == 0) return 0;
		    return part / whole;
	    }
	    
		#region Abs
		public static float Abs(this float value) => Math.Abs(value);

		public static IEnumerable<float> Abs(this IEnumerable<float> value)
		{
			foreach (var d in value)
			{
				yield return d.Abs();
			}
		}
		#endregion

		#region Clamp
		public static float ClampMin0(this float value) => ClampMin(value, 0);
        public static float ClampMin(this float value, float min) => value < min ? min : value;
        public static float ClampMax0(this float value) => ClampMax(value, 0);
        public static float ClampMax(this float value, float max) => value > max ? max : value;
        public static float Clamp01(this float value) => Clamp(value, 0, 1);

        public static float Clamp(this float value, float min, float max)
        {
            value = value < min ? min : value;
            value = value > max ? max : value;
            return value;
        }
        #endregion

		#region Round
		/// <summary>
		/// Rounds a decimal value to a specified number of decimal points.
		/// </summary>
		/// <param name="value">The decimal value to round.</param>
		/// <param name="decimalPoints">The number of decimal points to round to.</param>
		/// <returns>The rounded decimal value.</returns>
		public static float RoundDecimalPoints(this float value, int decimalPoints) => (float)Math.Round(value, decimalPoints);

		/// <summary>
		/// Rounds a decimal value to two decimal points.
		/// </summary>
		/// <param name="value">The decimal value to round.</param>
		/// <returns>The rounded decimal value.</returns>
		public static float RoundToTwoDecimalPoints(this float value) => (float)Math.Round(value, 2);
		#endregion

		#region Range
		/// <summary>
		/// Determines whether a float value is in a specified range.
		/// </summary>
		/// <param name="value">The float value to check.</param>
		/// <param name="minValue">The minimum value of the range.</param>
		/// <param name="maxValue">The maximum value of the range.</param>
		/// <returns>True if the float value is in the range; otherwise, false.</returns>
		public static bool IsInRange(this float value, float minValue, float maxValue) => value >= minValue && value <= maxValue;

		/// <summary>
		/// Returns a float value if it is in a specified range; otherwise, returns a default value.
		/// </summary>
		/// <param name="value">The float value to check.</param>
		/// <param name="minValue">The minimum value of the range.</param>
		/// <param name="maxValue">The maximum value of the range.</param>
		/// <param name="defaultValue">The default value to return if the float value is not in the range.</param>
		/// <returns>The float value if it is in the range; otherwise, the default value.</returns>
		public static double InRange(this float value, float minValue, float maxValue, float defaultValue)
			=> value.IsInRange(minValue, maxValue) ? value : defaultValue;
		#endregion

		#region TimeSpan
		/// <summary>
		/// Converts a float value to a TimeSpan representing days.
		/// </summary>
		/// <param name="value">The float value to convert.</param>
		/// <returns>A TimeSpan that represents the specified number of days.</returns>
		public static TimeSpan ToDays(this float value) => TimeSpan.FromDays(value);

		/// <summary>
		/// Converts a float value to a TimeSpan representing hours.
		/// </summary>
		/// <param name="value">The float value to convert.</param>
		/// <returns>A TimeSpan that represents the specified number of hours.</returns>
		public static TimeSpan ToHours(this float value) => TimeSpan.FromHours(value);

		/// <summary>
		/// Converts a float value to a TimeSpan representing minutes.
		/// </summary>
		/// <param name="value">The float value to convert.</param>
		/// <returns>A TimeSpan that represents the specified number of minutes.</returns>
		public static TimeSpan ToMinutes(this float value) => TimeSpan.FromMinutes(value);

		/// <summary>
		/// Converts a float value to a TimeSpan representing seconds.
		/// </summary>
		/// <param name="value">The float value to convert.</param>
		/// <returns>A TimeSpan that represents the specified number of seconds.</returns>
		public static TimeSpan ToSeconds(this float value) => TimeSpan.FromSeconds(value);

		/// <summary>
		/// Converts a float value to a TimeSpan representing milliseconds.
		/// </summary>
		/// <param name="value">The float value to convert.</param>
		/// <returns>A TimeSpan that represents the specified number of milliseconds.</returns>
		public static TimeSpan ToMilliseconds(this float value) => TimeSpan.FromMilliseconds(value);
		#endregion
	}
}