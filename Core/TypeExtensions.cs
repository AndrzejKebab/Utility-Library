using System;

namespace UtilityLibrary.Core
{
	public static class TypeExtensions
	{
		#region Default
		/// <summary>
		/// Gets the default value of the specified type.
		/// </summary>
		/// <param name="type">The type to get the default value for.</param>
		/// <returns>The default value for the specified type. For value types, this is usually the equivalent of 'new T()', and for reference types, this is null.</returns>
		public static object DefaultValue(this Type type)
		{
			return type.IsValueType ? Activator.CreateInstance(type) : null;
		}

		/// <summary>
		/// Determines whether the specified type is a nullable type.
		/// </summary>
		/// <param name="type">The type to check.</param>
		/// <returns><c>True</c> if the specified type is a nullable type; otherwise, <c>False</c>.</returns>
		public static bool IsNullableType(this Type type)
		{
			if (!type.IsPrimitive && !type.IsValueType)
			{
				return !type.IsEnum;
			}

			return false;
		}
		#endregion

		#region Numeric
		/// <summary>
		/// Checks if the specified type is a numeric type.
		/// </summary>
		/// <param name="type">The type to check.</param>
		/// <returns>True if the type is numeric; otherwise, false.</returns>
		public static bool IsNumericType(this Type type)
		{
			switch (Type.GetTypeCode(type))
			{
				case TypeCode.Byte:
				case TypeCode.SByte:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
				case TypeCode.Decimal:
				case TypeCode.Double:
				case TypeCode.Single:
					return true;
				case TypeCode.Object:
					if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
					{
						return Nullable.GetUnderlyingType(type).IsNumericType();
					}
					return false;
				default:
					return false;
			}
		}
		#endregion
	}
}