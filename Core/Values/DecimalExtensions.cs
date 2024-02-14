using System;
using System.Collections.Generic;

namespace UtilityLibrary.Core
{
    public static class DecimalExtensions
    {
	    public static decimal PercentageOf(this decimal part, decimal whole)
	    {
		    if (whole == 0) return 0;
		    return part / whole;
	    }
	    
		#region Abs
		public static decimal Abs(this decimal value) => Math.Abs(value);

		public static IEnumerable<decimal> Abs(this IEnumerable<decimal> value)
		{
			foreach (var d in value)
			{
				yield return d.Abs();
			}
		}
		#endregion

		#region Round
		/// <summary>
		/// Rounds a decimal value to a specified number of decimal points.
		/// </summary>
		/// <param name="value">The decimal value to round.</param>
		/// <param name="decimalPoints">The number of decimal points to round to.</param>
		/// <returns>The rounded decimal value.</returns>
		public static decimal RoundDecimalPoints(this decimal value, int decimalPoints) => Math.Round(value, decimalPoints);

		/// <summary>
		/// Rounds a decimal value to two decimal points.
		/// </summary>
		/// <param name="value">The decimal value to round.</param>
		/// <returns>The rounded decimal value.</returns>
		public static decimal RoundToTwoDecimalPoints(this decimal value) => Math.Round(value, 2);
		#endregion
	}
}