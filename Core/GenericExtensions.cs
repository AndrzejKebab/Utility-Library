using System;

namespace UtilityLibrary.Core
{
	public static class GenericExtensions
	{
		#region Null / Empty
		/// <summary>
		/// Checks if the value is null.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <returns>True if the value is null, false otherwise.</returns>
		public static bool IsNull<T>(this T value)
		{
			var result = ReferenceEquals(value, null);
			return result;
		}

		/// <summary>
		/// Checks if the value is not null.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <returns>True if the value is not null, false otherwise.</returns>
		public static bool IsNotNull<T>(this T value)
		{
			var result = !ReferenceEquals(value, null);
			return result;
		}

		/// <summary>
		/// Checks if the value is the default value for its type.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <returns>True if the value is the default value for its type, false otherwise.</returns>
		public static bool IsEmpty<T>(this T value) where T : struct
		{
			var result = value.Equals(default(T));
			return result;
		}

		/// <summary>
		/// Checks if the value is not the default value for its type.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <returns>True if the value is not the default value for its type, false otherwise.</returns>
		public static bool IsNotEmpty<T>(this T value) where T : struct
		{
			var result = value.IsEmpty() == false;
			return result;
		}

		/// <summary>
		/// Converts the value to a nullable type.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <returns>The value as a nullable type, or null if the value is the default value for its type.</returns>
		public static T? ToNullable<T>(this T value) where T : struct
		{
			var result = value.IsEmpty() ? null : (T?)value;
			return result;
		}
		#endregion

		#region Equal
		/// <summary>
		/// Checks if the value is equal to any of the provided values.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="values">The values to compare to.</param>
		/// <returns>True if the value is equal to any of the provided values, false otherwise.</returns>
		public static bool EqualsAny<T>(this T value, params T[] values)
		{
			if (values == null) return false;
			for (var i = 0; i < values.Length; i++)
			{
				var arg = values[i];
				if (value.Equals(arg)) return true;
			}

			return false;
		}

		/// <summary>
		/// Checks if the value is not equal to any of the provided values.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="values">The values to compare to.</param>
		/// <returns>True if the value is not equal to any of the provided values, false otherwise.</returns>
		public static bool EqualsNone<T>(this T value, params T[] values)
		{
			var result = value.EqualsAny(values) == false;
			return result;
		}
		#endregion

		#region Flag
		/// <summary>
		/// Checks if the value has all the specified flags.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="flags">The flags to check for.</param>
		/// <returns>True if the value has all the specified flags, false otherwise.</returns>
		public static bool HasFlags<T>(this T value, params T[] flags) where T : struct, IComparable, IFormattable, IConvertible
		{
			if (!typeof(T).IsEnum) throw new ArgumentException("variable must be an Enum", nameof(value));
			foreach (var flag in flags)
			{
				if (!Enum.IsDefined(typeof(T), flag))
				{
					return false;
				}

				var numFlag = Convert.ToUInt64(flag);
				if ((Convert.ToUInt64(value) & numFlag) != numFlag)
				{
					return false;
				}
			}

			return true;
		}
		#endregion
	}
}