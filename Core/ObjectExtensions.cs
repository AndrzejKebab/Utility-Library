using System;
using System.ComponentModel;
using System.Globalization;

namespace UtilityLibrary.Core
{
	public static class ObjectExtensions
	{
		#region Null
		/// <summary>
		/// Checks if the object is null.
		/// </summary>
		/// <param name="obj">The object to check.</param>
		/// <returns>True if the object is null, false otherwise.</returns>
		public static bool IsNull(this object obj)
		{
			var result = ReferenceEquals(obj, null);
			return result;
		}

		/// <summary>
		/// Checks if the object is not null.
		/// </summary>
		/// <param name="obj">The object to check.</param>
		/// <returns>True if the object is not null, false otherwise.</returns>
		public static bool IsNotNull(this object obj)
		{
			var result = !ReferenceEquals(obj, null);
			return result;
		}
		#endregion

		#region Type
		/// <summary>
		/// Casts the object to the specified type.
		/// </summary>
		/// <param name="obj">The object to cast.</param>
		/// <returns>The object cast to the specified type, or the default value for the type if the cast fails.</returns>
		public static T CastType<T>(this object obj)
		{
			try
			{
				var result = (T)obj.CastType(typeof(T));
				return result;
			}
			catch
			{
				var result = default(T);
				return result;
			}
		}

		/// <summary>
		/// Casts the object to the specified type.
		/// </summary>
		/// <param name="obj">The object to cast.</param>
		/// <param name="type">The type to cast to.</param>
		/// <returns>The object cast to the specified type, or the default value for the type if the cast fails.</returns>
		public static object CastType(this object obj, Type type)
		{
			try
			{
				var result = Convert.ChangeType(obj, type, CultureInfo.InvariantCulture);
				return result;
			}
			catch (Exception)
			{
				var result = type.DefaultValue();
				return result;
			}
		}

		/// <summary>
		/// Converts the object to the specified type.
		/// </summary>
		/// <param name="obj">The object to convert.</param>
		/// <param name="defaultValue">The value to return if the conversion fails.</param>
		/// <returns>The object converted to the specified type, or the default value if the conversion fails.</returns>
		public static T ConvertTo<T>(this object obj, T defaultValue = default(T))
		{
			if (obj != null)
			{
				var targetType = typeof(T);

				if (obj.GetType() == targetType) return (T)obj;

				var converter = TypeDescriptor.GetConverter(obj);
				if (converter.CanConvertTo(targetType))
				{
					return (T)converter.ConvertTo(obj, targetType);
				}

				converter = TypeDescriptor.GetConverter(targetType);
				if (converter.CanConvertFrom(obj.GetType()))
				{
					return (T)converter.ConvertFrom(obj);
				}
			}

			return defaultValue;
		}

		/// <summary>
		/// Checks if the object can be converted to the specified type.
		/// </summary>
		/// <param name="obj">The object to check.</param>
		/// <returns>True if the object can be converted to the specified type, false otherwise.</returns>
		public static bool CanConvertTo<T>(this object obj)
		{
			if (obj != null)
			{
				var targetType = typeof(T);

				var converter = TypeDescriptor.GetConverter(obj);
				if (converter.CanConvertTo(targetType))
				{
					return true;
				}

				converter = TypeDescriptor.GetConverter(targetType);
				if (converter.CanConvertFrom(obj.GetType()))
				{
					return true;
				}
			}

			return false;
		}
		#endregion

		#region As
		/// <summary>
		/// Converts the object to a string.
		/// </summary>
		/// <param name="obj">The object to convert.</param>
		/// <returns>The object as a string, or null if the object is null.</returns>
		public static string AsString(this object obj)
		{
			var result = ReferenceEquals(obj, null) ? null : $"{obj}";
			return result;
		}

		/// <summary>
		/// Converts the object to a string using the specified format provider.
		/// </summary>
		/// <param name="obj">The object to convert.</param>
		/// <param name="formatProvider">The format provider to use.</param>
		/// <returns>The object as a string using the specified format provider.</returns>
		public static string AsString(this object obj, IFormatProvider formatProvider)
		{
			var result = string.Format(formatProvider, "{0}", obj);
			return result;
		}

		/// <summary>
		/// Converts the object to a string using the invariant culture.
		/// </summary>
		/// <param name="obj">The object to convert.</param>
		/// <returns>The object as a string using the invariant culture.</returns>
		public static string AsInvariantString(this object obj)
		{
			var result = string.Format(CultureInfo.InvariantCulture, "{0}", obj);
			return result;
		}

		/// <summary>
		/// Converts the object to an integer.
		/// </summary>
		/// <param name="obj">The object to convert.</param>
		/// <returns>The object as an integer, or the default value for integers if the conversion fails.</returns>
		public static int AsInt(this object obj)
		{
			var result = obj.CastType<int>();
			return result;
		}

		/// <summary>
		/// Converts the object to a long.
		/// </summary>
		/// <param name="obj">The object to convert.</param>
		/// <returns>The object as a long, or the default value for longs if the conversion fails.</returns>
		public static long AsLong(this object obj)
		{
			var result = obj.CastType<long>();
			return result;
		}

		/// <summary>
		/// Converts the object to a short.
		/// </summary>
		/// <param name="obj">The object to convert.</param>
		/// <returns>The object as a short, or the default value for shorts if the conversion fails.</returns>
		public static short AsShort(this object obj)
		{
			var result = obj.CastType<short>();
			return result;
		}

		/// <summary>
		/// Converts the object to a float.
		/// </summary>
		/// <param name="obj">The object to convert.</param>
		/// <returns>The object as a float, or the default value for floats if the conversion fails.</returns>
		public static float AsFloat(this object obj)
		{
			var result = obj.CastType<float>();
			return result;
		}

		/// <summary>
		/// Converts the object to a double.
		/// </summary>
		/// <param name="obj">The object to convert.</param>
		/// <returns>The object as a double, or the default value for doubles if the conversion fails.</returns>
		public static double AsDouble(this object obj)
		{
			var result = obj.CastType<double>();
			return result;
		}

		/// <summary>
		/// Converts the object to a decimal.
		/// </summary>
		/// <param name="obj">The object to convert.</param>
		/// <returns>The object as a decimal, or the default value for decimals if the conversion fails.</returns>
		public static decimal AsDecimal(this object obj)
		{
			var result = obj.CastType<decimal>();
			return result;
		}
		#endregion
	}
}