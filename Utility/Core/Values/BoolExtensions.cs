using System;

namespace UtilityLibrary.Core
{
	public static partial class BoolExtensions
	{
		#region Logic
		#region And
		/// <summary>
		/// Performs a logical AND operation on two boolean values.
		/// </summary>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">The second boolean value.</param>
		/// <returns>The result of the logical AND operation.</returns>
		public static bool And(this bool boolean, bool other)
		{
			return boolean && other;
		}

		/// <summary>
		/// Performs a logical AND operation on the first boolean value and a function returning a boolean.
		/// </summary>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function returning a boolean.</param>
		/// <returns>The result of the logical AND operation.</returns>
		public static bool And(this bool boolean, Func<bool> other)
		{
			return other != null && boolean && other();
		}

		/// <summary>
		/// Performs a logical AND operation on the first boolean value and a function taking one parameter and returning a boolean.
		/// </summary>
		/// <typeparam name="T">Type of the parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking one parameter and returning a boolean.</param>
		/// <param name="value">The parameter for the function.</param>
		/// <returns>The result of the logical AND operation.</returns>
		public static bool And<T>(this bool boolean, Func<T, bool> other, T value)
		{
			return other != null && boolean && other(value);
		}

		/// <summary>
		/// Performs a logical AND operation on the first boolean value and functions taking two parameters and returning a boolean.
		/// </summary>
		/// <typeparam name="T1">Type of the first parameter for the function.</typeparam>
		/// <typeparam name="T2">Type of the second parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking two parameters and returning a boolean.</param>
		/// <param name="value1">The first parameter for the function.</param>
		/// <param name="value2">The second parameter for the function.</param>
		/// <returns>The result of the logical AND operation.</returns>
		public static bool And<T1, T2>(this bool boolean, Func<T1, T2, bool> other, T1 value1, T2 value2)
		{
			return other != null && boolean && other(value1, value2);
		}

		/// <summary>
		/// Performs a logical AND operation on the first boolean value and functions taking three parameters and returning a boolean.
		/// </summary>
		/// <typeparam name="T1">Type of the first parameter for the function.</typeparam>
		/// <typeparam name="T2">Type of the second parameter for the function.</typeparam>
		/// <typeparam name="T3">Type of the third parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking three parameters and returning a boolean.</param>
		/// <param name="value1">The first parameter for the function.</param>
		/// <param name="value2">The second parameter for the function.</param>
		/// <param name="value3">The third parameter for the function.</param>
		/// <returns>The result of the logical AND operation.</returns>
		public static bool And<T1, T2, T3>(this bool boolean, Func<T1, T2, T3, bool> other, T1 value1, T2 value2, T3 value3)
		{
			return other != null && boolean && other(value1, value2, value3);
		}

		/// <summary>
		/// Performs a logical AND operation on the first boolean value and functions taking four parameters and returning a boolean.
		/// </summary>
		/// <typeparam name="T1">Type of the first parameter for the function.</typeparam>
		/// <typeparam name="T2">Type of the second parameter for the function.</typeparam>
		/// <typeparam name="T3">Type of the third parameter for the function.</typeparam>
		/// <typeparam name="T4">Type of the fourth parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking four parameters and returning a boolean.</param>
		/// <param name="value1">The first parameter for the function.</param>
		/// <param name="value2">The second parameter for the function.</param>
		/// <param name="value3">The third parameter for the function.</param>
		/// <param name="value4">The fourth parameter for the function.</param>
		/// <returns>The result of the logical AND operation.</returns>
		public static bool And<T1, T2, T3, T4>(this bool boolean, Func<T1, T2, T3, T4, bool> other, T1 value1, T2 value2, T3 value3, T4 value4)
		{
			return other != null && boolean && other(value1, value2, value3, value4);
		}

		/// <summary>
		/// Performs a logical AND operation on the first boolean value and functions taking five parameters and returning a boolean.
		/// </summary>
		/// <typeparam name="T1">Type of the first parameter for the function.</typeparam>
		/// <typeparam name="T2">Type of the second parameter for the function.</typeparam>
		/// <typeparam name="T3">Type of the third parameter for the function.</typeparam>
		/// <typeparam name="T4">Type of the fourth parameter for the function.</typeparam>
		/// <typeparam name="T5">Type of the fifth parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking five parameters and returning a boolean.</param>
		/// <param name="value1">The first parameter for the function.</param>
		/// <param name="value2">The second parameter for the function.</param>
		/// <param name="value3">The third parameter for the function.</param>
		/// <param name="value4">The fourth parameter for the function.</param>
		/// <param name="value5">The fifth parameter for the function.</param>
		/// <returns>The result of the logical AND operation.</returns>
		public static bool And<T1, T2, T3, T4, T5>(this bool boolean, Func<T1, T2, T3, T4, T5, bool> other, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
		{
			return other != null && boolean && other(value1, value2, value3, value4, value5);
		}
		#endregion

		#region AndNot
		/// <summary>
		/// Performs a logical AND NOT operation on two boolean values.
		/// </summary>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">The second boolean value.</param>
		/// <returns>The result of the logical AND NOT operation.</returns>
		public static bool AndNot(this bool boolean, bool other)
		{
			return boolean && !other;
		}

		/// <summary>
		/// Performs a logical AND NOT operation on the first boolean value and a function returning a boolean.
		/// </summary>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function returning a boolean.</param>
		/// <returns>The result of the logical AND NOT operation.</returns>
		public static bool AndNot(this bool boolean, Func<bool> other)
		{
			return other != null && boolean && !other();
		}

		/// <summary>
		/// Performs a logical AND NOT operation on the first boolean value and a function taking one parameter and returning a boolean.
		/// </summary>
		/// <typeparam name="T">Type of the parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking one parameter and returning a boolean.</param>
		/// <param name="value">The parameter for the function.</param>
		/// <returns>The result of the logical AND NOT operation.</returns>
		public static bool AndNot<T>(this bool boolean, Func<T, bool> other, T value)
		{
			return other != null && boolean && !other(value);
		}

		/// <summary>
		/// Performs a logical AND NOT operation on the first boolean value and functions taking two to five parameters and returning a boolean.
		/// </summary>
		/// <typeparam name="T1">Type of the first parameter for the function.</typeparam>
		/// <typeparam name="T2">Type of the second parameter for the function.</typeparam>
		/// <typeparam name="T3">Type of the third parameter for the function.</typeparam>
		/// <typeparam name="T4">Type of the fourth parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking two to five parameters and returning a boolean.</param>
		/// <param name="value1">The first parameter for the function.</param>
		/// <param name="value2">The second parameter for the function.</param>
		/// <param name="value3">The third parameter for the function.</param>
		/// <param name="value4">The fourth parameter for the function.</param>
		/// <returns>The result of the logical AND NOT operation.</returns>
		public static bool AndNot<T1, T2, T3, T4>(this bool boolean, Func<T1, T2, T3, T4, bool> other, T1 value1, T2 value2, T3 value3, T4 value4)
		{
			return other != null && boolean && !other(value1, value2, value3, value4);
		}

		/// <summary>
		/// Performs a logical AND NOT operation on the first boolean value and functions taking five parameters and returning a boolean.
		/// </summary>
		/// <typeparam name="T1">Type of the first parameter for the function.</typeparam>
		/// <typeparam name="T2">Type of the second parameter for the function.</typeparam>
		/// <typeparam name="T3">Type of the third parameter for the function.</typeparam>
		/// <typeparam name="T4">Type of the fourth parameter for the function.</typeparam>
		/// <typeparam name="T5">Type of the fifth parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking five parameters and returning a boolean.</param>
		/// <param name="value1">The first parameter for the function.</param>
		/// <param name="value2">The second parameter for the function.</param>
		/// <param name="value3">The third parameter for the function.</param>
		/// <param name="value4">The fourth parameter for the function.</param>
		/// <param name="value5">The fifth parameter for the function.</param>
		/// <returns>The result of the logical AND NOT operation.</returns>
		public static bool AndNot<T1, T2, T3, T4, T5>(this bool boolean, Func<T1, T2, T3, T4, T5, bool> other, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
		{
			return other != null && boolean && !other(value1, value2, value3, value4, value5);
		}
		#endregion

		#region Or
		/// <summary>
		/// Performs a logical OR operation on two boolean values.
		/// </summary>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">The second boolean value.</param>
		/// <returns>The result of the logical OR operation.</returns>
		public static bool Or(this bool boolean, bool other)
		{
			return boolean || other;
		}

		/// <summary>
		/// Performs a logical OR operation on the first boolean value and a function returning a boolean.
		/// </summary>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function returning a boolean.</param>
		/// <returns>The result of the logical OR operation.</returns>
		public static bool Or(this bool boolean, Func<bool> other)
		{
			return other == null ? boolean : boolean || other();
		}

		/// <summary>
		/// Performs a logical OR operation on the first boolean value and a function taking one parameter and returning a boolean.
		/// </summary>
		/// <typeparam name="T">Type of the parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking one parameter and returning a boolean.</param>
		/// <param name="value">The parameter for the function.</param>
		/// <returns>The result of the logical OR operation.</returns>
		public static bool Or<T>(this bool boolean, Func<T, bool> other, T value)
		{
			return other == null ? boolean : boolean || other(value);
		}

		/// <summary>
		/// Performs a logical OR operation on the first boolean value and functions taking two parameters and returning a boolean.
		/// </summary>
		/// <typeparam name="T1">Type of the first parameter for the function.</typeparam>
		/// <typeparam name="T2">Type of the second parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking two parameters and returning a boolean.</param>
		/// <param name="value1">The first parameter for the function.</param>
		/// <param name="value2">The second parameter for the function.</param>
		/// <returns>The result of the logical OR operation.</returns>
		public static bool Or<T1, T2>(this bool boolean, Func<T1, T2, bool> other, T1 value1, T2 value2)
		{
			return other == null ? boolean : boolean || other(value1, value2);
		}

		/// <summary>
		/// Performs a logical OR operation on the first boolean value and functions taking three parameters and returning a boolean.
		/// </summary>
		/// <typeparam name="T1">Type of the first parameter for the function.</typeparam>
		/// <typeparam name="T2">Type of the second parameter for the function.</typeparam>
		/// <typeparam name="T3">Type of the third parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking three parameters and returning a boolean.</param>
		/// <param name="value1">The first parameter for the function.</param>
		/// <param name="value2">The second parameter for the function.</param>
		/// <param name="value3">The third parameter for the function.</param>
		/// <returns>The result of the logical OR operation.</returns>
		public static bool Or<T1, T2, T3>(this bool boolean, Func<T1, T2, T3, bool> other, T1 value1, T2 value2, T3 value3)
		{
			return other == null ? boolean : boolean || other(value1, value2, value3);
		}

		/// <summary>
		/// Performs a logical OR operation on the first boolean value and functions taking four parameters and returning a boolean.
		/// </summary>
		/// <typeparam name="T1">Type of the first parameter for the function.</typeparam>
		/// <typeparam name="T2">Type of the second parameter for the function.</typeparam>
		/// <typeparam name="T3">Type of the third parameter for the function.</typeparam>
		/// <typeparam name="T4">Type of the fourth parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking four parameters and returning a boolean.</param>
		/// <param name="value1">The first parameter for the function.</param>
		/// <param name="value2">The second parameter for the function.</param>
		/// <param name="value3">The third parameter for the function.</param>
		/// <param name="value4">The fourth parameter for the function.</param>
		/// <returns>The result of the logical OR operation.</returns>
		public static bool Or<T1, T2, T3, T4>(this bool boolean, Func<T1, T2, T3, T4, bool> other, T1 value1, T2 value2, T3 value3, T4 value4)
		{
			return other == null ? boolean : boolean || other(value1, value2, value3, value4);
		}

		/// <summary>
		/// Performs a logical OR operation on the first boolean value and functions taking five parameters and returning a boolean.
		/// </summary>
		/// <typeparam name="T1">Type of the first parameter for the function.</typeparam>
		/// <typeparam name="T2">Type of the second parameter for the function.</typeparam>
		/// <typeparam name="T3">Type of the third parameter for the function.</typeparam>
		/// <typeparam name="T4">Type of the fourth parameter for the function.</typeparam>
		/// <typeparam name="T5">Type of the fifth parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking five parameters and returning a boolean.</param>
		/// <param name="value1">The first parameter for the function.</param>
		/// <param name="value2">The second parameter for the function.</param>
		/// <param name="value3">The third parameter for the function.</param>
		/// <param name="value4">The fourth parameter for the function.</param>
		/// <param name="value5">The fifth parameter for the function.</param>
		/// <returns>The result of the logical OR operation.</returns>
		public static bool Or<T1, T2, T3, T4, T5>(this bool boolean, Func<T1, T2, T3, T4, T5, bool> other, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
		{
			return other == null ? boolean : boolean || other(value1, value2, value3, value4, value5);
		}
		#endregion

		#region OrNot
		/// <summary>
		/// Performs a logical OR NOT operation on two boolean values.
		/// </summary>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">The second boolean value.</param>
		/// <returns>The result of the logical OR NOT operation.</returns>
		public static bool OrNot(this bool boolean, bool other)
		{
			return boolean || !other;
		}

		/// <summary>
		/// Performs a logical OR NOT operation on the first boolean value and a function returning a boolean.
		/// </summary>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function returning a boolean.</param>
		/// <returns>The result of the logical OR NOT operation.</returns>
		public static bool OrNot(this bool boolean, Func<bool> other)
		{
			return other == null ? boolean : boolean || !other();
		}

		/// <summary>
		/// Performs a logical OR NOT operation on the first boolean value and a function taking one parameter and returning a boolean.
		/// </summary>
		/// <typeparam name="T">Type of the parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking one parameter and returning a boolean.</param>
		/// <param name="value">The parameter for the function.</param>
		/// <returns>The result of the logical OR NOT operation.</returns>
		public static bool OrNot<T>(this bool boolean, Func<T, bool> other, T value)
		{
			return other == null ? boolean : boolean || !other(value);
		}

		/// <summary>
		/// Performs a logical OR NOT operation on the first boolean value and functions taking two to five parameters and returning a boolean.
		/// </summary>
		/// <typeparam name="T1">Type of the first parameter for the function.</typeparam>
		/// <typeparam name="T2">Type of the second parameter for the function.</typeparam>
		/// <typeparam name="T3">Type of the third parameter for the function.</typeparam>
		/// <typeparam name="T4">Type of the fourth parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking two to five parameters and returning a boolean.</param>
		/// <param name="value1">The first parameter for the function.</param>
		/// <param name="value2">The second parameter for the function.</param>
		/// <param name="value3">The third parameter for the function.</param>
		/// <param name="value4">The fourth parameter for the function.</param>
		/// <returns>The result of the logical OR NOT operation.</returns>
		public static bool OrNot<T1, T2, T3, T4>(this bool boolean, Func<T1, T2, T3, T4, bool> other, T1 value1, T2 value2, T3 value3, T4 value4)
		{
			return other == null ? boolean : boolean || !other(value1, value2, value3, value4);
		}

		/// <summary>
		/// Performs a logical OR NOT operation on the first boolean value and functions taking five parameters and returning a boolean.
		/// </summary>
		/// <typeparam name="T1">Type of the first parameter for the function.</typeparam>
		/// <typeparam name="T2">Type of the second parameter for the function.</typeparam>
		/// <typeparam name="T3">Type of the third parameter for the function.</typeparam>
		/// <typeparam name="T4">Type of the fourth parameter for the function.</typeparam>
		/// <typeparam name="T5">Type of the fifth parameter for the function.</typeparam>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">A function taking five parameters and returning a boolean.</param>
		/// <param name="value1">The first parameter for the function.</param>
		/// <param name="value2">The second parameter for the function.</param>
		/// <param name="value3">The third parameter for the function.</param>
		/// <param name="value4">The fourth parameter for the function.</param>
		/// <param name="value5">The fifth parameter for the function.</param>
		/// <returns>The result of the logical OR NOT operation.</returns>
		public static bool OrNot<T1, T2, T3, T4, T5>(this bool boolean, Func<T1, T2, T3, T4, T5, bool> other, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
		{
			return other == null ? boolean : boolean || !other(value1, value2, value3, value4, value5);
		}
		#endregion

		#region Xor
		/// <summary>
		/// Performs a logical XOR operation on two boolean values.
		/// </summary>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">The second boolean value.</param>
		/// <returns>The result of the logical XOR operation.</returns>
		public static bool Xor(this bool boolean, bool other)
		{
			return boolean ^ other;
		}
		#endregion
		#endregion
	}
}