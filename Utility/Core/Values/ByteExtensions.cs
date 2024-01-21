using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UtilityLibrary.Core
{
	public static partial class ByteExtensions
	{
		#region Odd / Even
		public static bool IsEven(this byte value) => value % 2 == 0;
		public static bool IsOdd(this byte value) => value % 2 == 1;
		#endregion
		
		#region Convert To
		public static int ToInt(this byte[] bytes, int startIndex = 0)
		{
			return BitConverter.ToInt32(bytes, startIndex);
		}

		public static long ToLong(this byte[] bytes, int startIndex = 0)
		{
			return BitConverter.ToInt64(bytes, startIndex);
		}

		public static char ToChar(this byte[] bytes, int startIndex = 0)
		{
			return BitConverter.ToChar(bytes, startIndex);
		}

		public static float ToFloat(this byte[] bytes, int startIndex = 0)
		{
			return BitConverter.ToSingle(bytes, startIndex);
		}

		public static double ToDouble(this byte[] bytes, int startIndex = 0)
		{
			return BitConverter.ToDouble(bytes, startIndex);
		}

		public static bool ToBoolean(this byte[] bytes, int startIndex = 0)
		{
			return BitConverter.ToBoolean(bytes, startIndex);
		}

		public static string ToString(this byte[] bytes, int startIndex = 0)
		{
			return BitConverter.ToString(bytes, startIndex);
		}

		/// <summary>
		/// Converts a byte array to a specified type.
		/// </summary>
		/// <typeparam name="T">The type to convert to.</typeparam>
		/// <param name="bytes">The byte array to convert.</param>
		/// <returns>The converted object of the specified type.</returns>
		public static T ToType<T>(this byte[] bytes)
		{
			using (var ms = new MemoryStream())
			{
				ms.Write(bytes, 0, bytes.Length);
				var bf = new BinaryFormatter();
				ms.Position = 0;
				var x = bf.Deserialize(ms);
				return (T)x;
			}
		}
		#endregion
	}
}