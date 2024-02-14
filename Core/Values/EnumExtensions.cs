using System;
using System.ComponentModel;

namespace UtilityLibrary.Core
{
    public static class EnumExtensions
    {
		#region Flag
		/// <summary>
		/// Clears a specific flag from an enumeration value.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumValue">The enumeration value.</param>
		/// <param name="flag">The flag to clear.</param>
		/// <returns>The enumeration value with the flag cleared.</returns>
		public static T ClearFlag<T>(this T enumValue, T flag) where T : Enum
		{
			var result = ClearFlags(enumValue, flag);
			return result;
		}

		/// <summary>
		/// Clears specific flags from an enumeration value.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumValue">The enumeration value.</param>
		/// <param name="flags">The flags to clear.</param>
		/// <returns>The enumeration value with the flags cleared.</returns>
		public static T ClearFlags<T>(this T enumValue, params T[] flags) where T : Enum
		{
			var value = Convert.ToInt32(enumValue);
			foreach (var flag in flags)
			{
				value &= ~Convert.ToInt32(flag);
			}
			var result = (T)Enum.Parse(enumValue.GetType(), value.ToString());
			return result;
		}

		/// <summary>
		/// Sets a specific flag in an enumeration value.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumValue">The enumeration value.</param>
		/// <param name="flag">The flag to set.</param>
		/// <returns>The enumeration value with the flag set.</returns>
		public static T SetFlag<T>(this T enumValue, T flag) where T : Enum
		{
			var result = SetFlags(enumValue, flag);
			return result;
		}

		/// <summary>
		/// Sets specific flags in an enumeration value.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumValue">The enumeration value.</param>
		/// <param name="flags">The flags to set.</param>
		/// <returns>The enumeration value with the flags set.</returns>
		public static T SetFlags<T>(this T enumValue, params T[] flags) where T : Enum
		{
			var value = Convert.ToInt32(enumValue);
			foreach (var flag in flags)
			{
				value |= Convert.ToInt32(flag);
			}
			var result = (T)Enum.Parse(enumValue.GetType(), value.ToString());
			return result;
		}

		/// <summary>
		/// Checks if an enumeration value contains a specific flag.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumValue">The enumeration value.</param>
		/// <param name="flag">The flag to check for.</param>
		/// <returns>True if the enumeration value contains the flag; otherwise, false.</returns>
		public static bool ContainsFlag<T>(this T enumValue, T flag) where T : Enum
		{
			var value = Convert.ToInt32(enumValue);
			var index = 1 << Convert.ToInt32(flag);
			var result = (value & index) == index;
			return result;
		}
		#endregion

		#region String
		/// <summary>
		/// Converts a string to an enumeration value of a specified type.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumValue">The enumeration value.</param>
		/// <param name="strValue">The string to convert.</param>
		/// <returns>The enumeration value that corresponds to the string, or the default enumeration value if the string is not defined in the enumeration.</returns>
		public static T FromString<T>(this T enumValue, string strValue) where T : Enum
		{
			if (!Enum.IsDefined(typeof(T), strValue))
			{
				return default(T);
			}
			var result = (T)Enum.Parse(typeof(T), strValue);
			return result;
		}

		/// <summary>
		/// Tries to convert a string to an enumeration value of a specified type.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumValue">The enumeration value.</param>
		/// <param name="strValue">The string to convert.</param>
		/// <param name="returnValue">When this method returns, contains the enumeration value that corresponds to the string, if the conversion succeeded, or the default enumeration value if the conversion failed.</param>
		/// <returns>True if the string was converted successfully; otherwise, false.</returns>
		public static bool TryParse<T>(this T enumValue, string strValue, out T returnValue) where T : Enum
		{
			returnValue = default(T);
			if (!Enum.IsDefined(typeof(T), strValue)) return false;
			var converter = TypeDescriptor.GetConverter(typeof(T));
			returnValue = (T)converter.ConvertFromString(strValue);
			return true;
		}
		#endregion

		#region Index
		/// <summary>
		/// Returns the index of a specific integer value in an enumeration.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumValue">The enumeration value.</param>
		/// <param name="intValue">The integer value to find.</param>
		/// <returns>The index of the integer value in the enumeration, or -1 if the value is not found.</returns>
		public static int EnumIndex<T>(this T enumValue, int intValue) where T : Enum
		{
			var index = 0;
			foreach (var value in Enum.GetValues(typeof(T)))
			{
				if ((int)value == intValue)
				{
					return index;
				}
				++index;
			}
			return -1;
		}

		/// <summary>
		/// Returns the index of a specific byte value in an enumeration.
		/// </summary>
		/// <typeparam name="T">The enumeration type.</typeparam>
		/// <param name="enumValue">The enumeration value.</param>
		/// <param name="byteValue">The byte value to find.</param>
		/// <returns>The index of the byte value in the enumeration, or -1 if the value is not found.</returns>
		public static int EnumIndex<T>(this T enumValue, byte byteValue) where T : Enum
		{
			var index = 0;
			foreach (var value in Enum.GetValues(typeof(T)))
			{
				if ((byte)value == byteValue)
				{
					return index;
				}
				++index;
			}
			return -1;
		}
		#endregion
    }
}