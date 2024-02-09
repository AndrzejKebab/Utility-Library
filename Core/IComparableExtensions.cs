using System;

namespace UtilityLibrary.Core
{
	public static class IComparableExtensions
	{
		/// <summary>
		/// Determines whether the specified value is between the lower and upper bounds.
		/// </summary>
		/// <param name="value">The value to compare.</param>
		/// <param name="lowerBound">The lower bound.</param>
		/// <param name="upperBound">The upper bound.</param>
		/// <param name="includeLowerBound">if set to <c>true</c> [include lower bound].</param>
		/// <param name="includeUpperBound">if set to <c>true</c> [include upper bound].</param>
		/// <returns><c>true</c> if the specified value is between the bounds; otherwise, <c>false</c>.</returns>
		/// <exception cref="ArgumentNullException">value is null.</exception>
		public static bool Between<T>(this T value, T lowerBound, T upperBound, bool includeLowerBound = false, bool includeUpperBound = false) where T : IComparable<T>
		{
			if (value == null) throw new ArgumentNullException();
			var lowerCompareResult = value.CompareTo(lowerBound);
			var upperCompareResult = value.CompareTo(upperBound);
			var result = (includeLowerBound && lowerCompareResult == 0) ||
							  (includeUpperBound && upperCompareResult == 0) ||
							  (lowerCompareResult > 0 && upperCompareResult < 0);
			return result;
		}

		/// <summary>
		/// Clamps the specified value within the min and max range.
		/// </summary>
		/// <param name="value">The value to clamp.</param>
		/// <param name="min">The minimum value.</param>
		/// <param name="max">The maximum value.</param>
		/// <returns>The clamped value.</returns>
		/// <exception cref="ArgumentNullException">value is null.</exception>
		public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
		{
			if (value == null) throw new ArgumentNullException();
			var result = value.LessThan(min) ? min : value.GreaterThan(max) ? max : value;
			return result;
		}

		/// <summary>
		/// Determines whether the specified value is less than the other specified value.
		/// </summary>
		/// <param name="value">The value to compare.</param>
		/// <param name="other">The other value to compare.</param>
		/// <returns><c>true</c> if the specified value is less than the other value; otherwise, <c>false</c>.</returns>
		/// <exception cref="ArgumentNullException">value is null.</exception>
		public static bool LessThan<T>(this T value, T other) where T : IComparable<T>
		{
			if (value == null) throw new ArgumentNullException();
			var result = value.CompareTo(other) < 0;
			return result;
		}

		/// <summary>
		/// Determines whether the specified value is less than or equal to the other specified value.
		/// </summary>
		/// <param name="value">The value to compare.</param>
		/// <param name="other">The other value to compare.</param>
		/// <returns><c>true</c> if the specified value is less than or equal to the other value; otherwise, <c>false</c>.</returns>
		/// <exception cref="ArgumentNullException">value is null.</exception>
		public static bool LessOrEqual<T>(this T value, T other) where T : IComparable<T>
		{
			if (value == null) throw new ArgumentNullException();
			var result = value.CompareTo(other) <= 0;
			return result;
		}

		/// <summary>
		/// Determines whether the specified value is greater than the other specified value.
		/// </summary>
		/// <param name="value">The value to compare.</param>
		/// <param name="other">The other value to compare.</param>
		/// <returns><c>true</c> if the specified value is greater than the other value; otherwise, <c>false</c>.</returns>
		/// <exception cref="ArgumentNullException">value is null.</exception>
		public static bool GreaterThan<T>(this T value, T other) where T : IComparable<T>
		{
			if (value == null) throw new ArgumentNullException();
			var result = value.CompareTo(other) > 0;
			return result;
		}

		/// <summary>
		/// Determines whether the specified value is greater than or equal to the other specified value.
		/// </summary>
		/// <param name="value">The value to compare.</param>
		/// <param name="other">The other value to compare.</param>
		/// <returns><c>true</c> if the specified value is greater than or equal to the other value; otherwise, <c>false</c>.</returns>
		/// <exception cref="ArgumentNullException">value is null.</exception>
		public static bool GreaterOrEqual<T>(this T value, T other) where T : IComparable<T>
		{
			if (value == null) throw new ArgumentNullException();
			var result = value.CompareTo(other) >= 0;
			return result;
		}
	}
}