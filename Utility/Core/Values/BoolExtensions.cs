namespace UtilityLibrary.Core
{
	public static partial class BoolExtensions
	{
		#region Logic 
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
		/// Performs a logical AND operation on the first boolean value and the logical NOT of the second boolean value.
		/// </summary>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">The second boolean value.</param>
		/// <returns>The result of the logical AND operation.</returns>
		public static bool AndNot(this bool boolean, bool other)
		{
			return boolean && !other;
		}

		/// <summary>
		/// Performs a logical OR operation on the first boolean value and the logical NOT of the second boolean value.
		/// </summary>
		/// <param name="boolean">The first boolean value.</param>
		/// <param name="other">The second boolean value.</param>
		/// <returns>The result of the logical OR operation.</returns>
		public static bool OrNot(this bool boolean, bool other)
		{
			return boolean || !other;
		}

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
	}
}