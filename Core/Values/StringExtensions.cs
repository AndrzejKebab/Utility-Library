using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace UtilityLibrary.Core
{
	public static class StringExtensions
	{
		#region Null / Empty / WhiteSpace
		/// <summary>
		/// Checks if the string is null or empty.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <returns><c>True</c> if the string is null or empty; otherwise, <c>False</c>.</returns>
		public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

		/// <summary>
		/// Checks if the string is not null or empty.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <returns><c>True</c> if the string is null or empty; otherwise, <c>False</c>.</returns>
		public static bool IsNotNullOrEmpty(this string value) => !string.IsNullOrEmpty(value);

		/// <summary>
		/// Checks if the string is empty or contains only white-space characters.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <returns><c>True</c> if the string is empty or contains only white-space characters; otherwise, <c>False</c>.</returns>
		public static bool IsEmptyOrWhiteSpace(this string value)
		{
			if (value.IsEmpty()) return true;
			for (var i = 0; i < value.Length; i++)
			{
				var c = value[i];
				if (!char.IsWhiteSpace(c))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Checks if the string is not empty and does not contain only white-space characters.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <returns><c>True</c> if the string is not empty and does not contain only white-space characters; otherwise, <c>False</c>.</returns>
		public static bool IsNotEmptyOrWhiteSpace(this string value) => value.IsEmptyOrWhiteSpace() == false;

		/// <summary>
		/// Returns the string if it is not empty and does not contain only white-space characters; otherwise, returns the default value.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <param name="defaultValue">The default value to return if the string is empty or contains only white-space characters.</param>
		/// <returns>The string if it is not empty and does not contain only white-space characters; otherwise, the default value.</returns>
		public static string IfEmptyOrWhiteSpace(this string value, string defaultValue)
			=> value.IsEmptyOrWhiteSpace() ? defaultValue : value;
		#endregion

		#region Convert To
		/// <summary>
		/// Checks if the string can be converted to a boolean.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <returns><c>True</c> if the string can be converted to a boolean; otherwise, <c>False</c>.</returns>
		public static bool IsBoolean(this string value) => bool.TryParse(value, out _);

		/// <summary>
		/// Converts the string to a boolean.
		/// </summary>
		/// <param name="value">The string to convert.</param>
		/// <returns>The boolean value of the string.</returns>
		public static bool AsBoolean(this string value) => bool.Parse(value);

		/// <summary>
		/// Checks if the string can be converted to a short.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <returns><c>True</c> if the string can be converted to a short; otherwise, <c>False</c>.</returns>
		public static bool IsShort(this string value) => short.TryParse(value, out _);

		/// <summary>
		/// Converts the string to a short.
		/// </summary>
		/// <param name="value">The string to convert.</param>
		/// <returns>The short value of the string.</returns>
		public static short AsShort(this string value) => short.Parse(value, CultureInfo.InvariantCulture);

		/// <summary>
		/// Checks if the string can be converted to an integer.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <returns><c>True</c> if the string can be converted to an integer; otherwise, <c>False</c>.</returns>
		public static bool IsInt(this string value) => int.TryParse(value, out _);

		/// <summary>
		/// Converts the string to an integer.
		/// </summary>
		/// <param name="value">The string to convert.</param>
		/// <returns>The integer value of the string.</returns>
		public static int AsInt(this string value) => int.Parse(value, CultureInfo.InvariantCulture);

		/// <summary>
		/// Checks if the string can be converted to a long.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <returns><c>True</c> if the string can be converted to a long; otherwise, <c>False</c>.</returns>
		public static bool IsLong(this string value) => long.TryParse(value, out _);

		/// <summary>
		/// Converts the string to a long.
		/// </summary>
		/// <param name="value">The string to convert.</param>
		/// <returns>The long value of the string.</returns>
		public static long AsLong(this string value) => long.Parse(value, CultureInfo.InvariantCulture);

		/// <summary>
		/// Checks if the string can be converted to a float.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <returns><c>True</c> if the string can be converted to a float; otherwise, <c>False</c>.</returns>
		public static bool IsFloat(this string value) => float.TryParse(value, out _);

		/// <summary>
		/// Converts the string to a float.
		/// </summary>
		/// <param name="value">The string to convert.</param>
		/// <returns>The float value of the string.</returns>
		public static float AsFloat(this string value) => float.Parse(value, CultureInfo.InvariantCulture);

		/// <summary>
		/// Checks if the string can be converted to a double.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <returns><c>True</c> if the string can be converted to a double; otherwise, <c>False</c>.</returns>
		public static bool IsDouble(this string value) => double.TryParse(value, out _);

		/// <summary>
		/// Converts the string to a double.
		/// </summary>
		/// <param name="value">The string to convert.</param>
		/// <returns>The double value of the string.</returns>
		public static double AsDouble(this string value) => double.Parse(value, CultureInfo.InvariantCulture);

		/// <summary>
		/// Checks if the string can be converted to a decimal.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <returns><c>True</c> if the string can be converted to a decimal; otherwise, <c>False</c>.</returns>
		public static bool IsDecimal(this string value) => decimal.TryParse(value, out _);

		/// <summary>
		/// Converts the string to a decimal.
		/// </summary>
		/// <param name="value">The string to convert.</param>
		/// <returns>The decimal value of the string.</returns>
		public static decimal AsDecimal(this string value) => decimal.Parse(value, CultureInfo.InvariantCulture);
		#endregion

		#region Trim
		/// <summary>
		/// Trims the string to a maximum length.
		/// </summary>
		/// <param name="value">The string to trim.</param>
		/// <param name="maxLength">The maximum length of the string.</param>
		/// <returns>The trimmed string if it exceeds the maximum length; otherwise, the original string.</returns>
		public static string TrimToMaxLength(this string value, int maxLength)
		{
			var result = value == null || value.Length <= maxLength ? value : value.Substring(0, maxLength);
			return result;
		}

		/// <summary>
		/// Trims the string to a maximum length and appends a suffix if the string exceeds the maximum length.
		/// </summary>
		/// <param name="value">The string to trim.</param>
		/// <param name="maxLength">The maximum length of the string.</param>
		/// <param name="suffix">The suffix to append if the string exceeds the maximum length.</param>
		/// <returns>The trimmed string with the suffix appended if it exceeds the maximum length; otherwise, the original string.</returns>
		public static string TrimToMaxLength(this string value, int maxLength, string suffix)
		{
			var result = value == null || value.Length <= maxLength ? value : string.Concat(value.Substring(0, maxLength), suffix);
			return result;
		}
		#endregion

		#region Contains
		/// <summary>
		/// Determines whether a string contains a specified substring, according to the rules of a specified string comparison.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <param name="comparisonValue">The substring to seek.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules for the string comparison.</param>
		/// <returns><c>True</c> if the string contains the specified substring; otherwise, <c>False</c>.</returns>
		public static bool Contains(this string value, string comparisonValue, StringComparison comparisonType)
			=> value.IndexOf(comparisonValue, comparisonType) != -1;

		/// <summary>
		/// Determines whether a string contains any of the specified substrings.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <param name="values">The substrings to seek.</param>
		/// <returns><c>True</c> if the string contains any of the specified substrings; otherwise, <c>False</c>.</returns>
		public static bool ContainsAny(this string value, params string[] values)
			=> value.ContainsAny(StringComparison.CurrentCulture, values);

		/// <summary>
		/// Determines whether a string contains any of the specified substrings, according to the rules of a specified string comparison.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules for the string comparison.</param>
		/// <param name="values">The substrings to seek.</param>
		/// <returns><c>True</c> if the string contains any of the specified substrings; otherwise, <c>False</c>.</returns>
		public static bool ContainsAny(this string value, StringComparison comparisonType, params string[] values)
		{
			for (var i = 0; i < values.Length; i++)
			{
				var str = values[i];
				if (Contains(value, str, comparisonType)) return true;
			}
			return false;
		}

		/// <summary>
		/// Determines whether a string contains all of the specified substrings.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <param name="values">The substrings to seek.</param>
		/// <returns><c>True</c> if the string contains all of the specified substrings; otherwise, <c>False</c>.</returns>
		public static bool ContainsAll(this string value, params string[] values)
			=> value.ContainsAll(StringComparison.CurrentCulture, values);

		/// <summary>
		/// Determines whether a string contains all of the specified substrings, according to the rules of a specified string comparison.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules for the string comparison.</param>
		/// <param name="values">The substrings to seek.</param>
		/// <returns><c>True</c> if the string contains all of the specified substrings; otherwise, <c>False</c>.</returns>
		public static bool ContainsAll(this string value, StringComparison comparisonType, params string[] values)
		{
			for (var i = 0; i < values.Length; i++)
			{
				var str = values[i];
				if (Contains(value, str, comparisonType)) return true;
			}
			return false;
		}

		/// <summary>
		/// Determines whether a string equals any of the specified strings, according to the rules of a specified string comparison.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules for the string comparison.</param>
		/// <param name="values">The strings to compare.</param>
		/// <returns><c>True</c> if the string equals any of the specified strings; otherwise, <c>False</c>.</returns>
		public static bool EqualsAny(this string value, StringComparison comparisonType, params string[] values)
		{
			for (var i = 0; i < values.Length; i++)
			{
				var str = values[i];
				if (value.Equals(str, comparisonType)) return true;
			}
			return false;
		}
		#endregion

		#region Remove
		/// <summary>
		/// Removes all occurrences of the specified characters from the string.
		/// </summary>
		/// <param name="value">The string to remove characters from.</param>
		/// <param name="chars">The characters to remove.</param>
		/// <returns>The string with all occurrences of the specified characters removed.</returns>
		public static string Remove(this string value, params char[] chars)
		{
			var result = value;
			if (!string.IsNullOrEmpty(result) && chars != null)
			{
				Array.ForEach(chars, c => result = result.Remove(c.ToString()));
			}
			return result;
		}

		/// <summary>
		/// Removes all occurrences of the specified strings from the string.
		/// </summary>
		/// <param name="value">The string to remove substrings from.</param>
		/// <param name="strings">The substrings to remove.</param>
		/// <returns>The string with all occurrences of the specified substrings removed.</returns>
		public static string Remove(this string value, params string[] strings)
		{
			for (var i = 0; i < strings.Length; i++)
			{
				var str = strings[i];
				value = value.Replace(str, string.Empty);
			}
			return value;
		}
		#endregion

		#region Replace
		/// <summary>
		/// Replaces all occurrences of a set of strings in this instance with another specified string.
		/// </summary>
		/// <param name="value">The string to replace in.</param>
		/// <param name="oldValues">The strings to be replaced.</param>
		/// <param name="newValue">The string to replace all occurrences of the oldValues.</param>
		/// <returns>A new string that is identical to the input string, except that the new string has replaced the old strings.</returns>
		public static string ReplaceAll(this string value, IEnumerable<string> oldValues, string newValue)
		{
			var stringBuilder = new StringBuilder(value);
			foreach (var oldValue in oldValues)
			{
				stringBuilder.Replace(oldValue, newValue);
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Replaces all occurrences of a set of strings in this instance with a set of replacement strings.
		/// </summary>
		/// <param name="value">The string to replace in.</param>
		/// <param name="oldValues">The strings to be replaced.</param>
		/// <param name="newValues">The strings to replace all occurrences of the oldValues.</param>
		/// <returns>A new string that is identical to the input string, except that the new strings have replaced the old strings.</returns>
		public static string ReplaceAll(this string value, IEnumerable<string> oldValues, IEnumerable<string> newValues)
		{
			var stringBuilder = new StringBuilder(value);
			var newValueEnum = newValues.GetEnumerator();
			foreach (var old in oldValues)
			{
				if (!newValueEnum.MoveNext()) throw new ArgumentOutOfRangeException(nameof(newValues), "newValues sequence is shorter than oldValues sequence");
				stringBuilder.Replace(old, newValueEnum.Current ?? throw new InvalidOperationException());
			}
			if (newValueEnum.MoveNext()) throw new ArgumentOutOfRangeException(nameof(newValues), "newValues sequence is longer than oldValues sequence");
			newValueEnum.Dispose();
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Replaces all strings in this instance that match a specified regular expression with a specified replacement string.
		/// </summary>
		/// <param name="value">The string to replace in.</param>
		/// <param name="regexPattern">The regular expression pattern to match.</param>
		/// <param name="replaceValue">The replacement string.</param>
		/// <returns>A new string that is identical to the input string, except that the replacement string has replaced the matched strings.</returns>
		public static string ReplaceWith(this string value, string regexPattern, string replaceValue)
			=> ReplaceWith(value, regexPattern, replaceValue, RegexOptions.None);

		/// <summary>
		/// Replaces all strings in this instance that match a specified regular expression with a specified replacement string, using specified options.
		/// </summary>
		/// <param name="value">The string to replace in.</param>
		/// <param name="regexPattern">The regular expression pattern to match.</param>
		/// <param name="replaceValue">The replacement string.</param>
		/// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
		/// <returns>A new string that is identical to the input string, except that the replacement string has replaced the matched strings.</returns>
		public static string ReplaceWith(this string value, string regexPattern, string replaceValue, RegexOptions options)
			=> Regex.Replace(value, regexPattern, replaceValue, options);
		#endregion
		
		#region Formart
		/// <summary>
		/// Converts the first character of the string to uppercase.
		/// </summary>
		/// <param name="value">The string to convert.</param>
		/// <returns>The string with the first character converted to uppercase. If the string is empty or contains only white-space characters, returns an empty string.</returns>
		public static string ToUpperFirstLetter(this string value)
		{
			if (value.IsEmptyOrWhiteSpace()) return string.Empty;
			var valueChars = value.ToCharArray();
			valueChars[0] = char.ToUpper(valueChars[0]);
			var result = new string(valueChars);
			return result;
		}

		/// <summary>
		/// Converts the string to title case using the current culture.
		/// </summary>
		/// <param name="value">The string to convert.</param>
		/// <returns>The string converted to title case.</returns>
		public static string ToTitleCase(this string value) => ToTitleCase(value, CultureInfo.CurrentCulture);

		/// <summary>
		/// Converts the string to title case using the specified culture.
		/// </summary>
		/// <param name="value">The string to convert.</param>
		/// <param name="cultureInfo">The culture to use for the conversion.</param>
		/// <returns>The string converted to title case.</returns>
		public static string ToTitleCase(this string value, CultureInfo cultureInfo) => cultureInfo.TextInfo.ToTitleCase(value);

		/// <summary>
		/// Inserts a space before each uppercase character in the string.
		/// </summary>
		/// <param name="value">The string to process.</param>
		/// <returns>The processed string with a space before each uppercase character.</returns>
		public static string SpaceOnUpper(this string value) 
			=> Regex.Replace(value, "([A-Z])(?=[a-z])|(?<=[a-z])([A-Z]|[0-9]+)", " $1$2").TrimStart();
		#endregion

		#region Like
		/// <summary>
		/// Checks if the string matches any of the provided patterns.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <param name="patterns">The patterns to match against.</param>
		/// <returns><c>True</c> if the string matches any of the patterns, otherwise <c>False</c>.</returns>
		public static bool IsLikeAny(this string value, params string[] patterns)
		{
			for (var i = 0; i < patterns.Length; i++)
			{
				var pattern = patterns[i];
				if (IsLike(value, pattern)) return true;
			}
			return false;
		}

		/// <summary>
		/// Checks if the string matches the provided pattern.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <param name="pattern">The pattern to match against.</param>
		/// <returns><c>True</c> if the string matches the pattern, otherwise <c>False</c>.</returns>
		public static bool IsLike(this string value, string pattern)
		{
			if (value == pattern) return true;
			if (pattern[0] == '*' && pattern.Length > 1)
			{
				for (var index = 0; index < value.Length; index++)
				{
					if (value.Substring(index).IsLike(pattern.Substring(1)))
					{
						return true;
					}
				}
			}
			else if (pattern[0] == '*')
			{
				return true;
			}
			else if (pattern[0] == value[0])
			{
				return value.Substring(1).IsLike(pattern.Substring(1));
			}
			return false;
		}
		#endregion

		#region Check Type
		/// <summary>
		/// Checks if the string represents a number.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <returns><c>True</c> if the string represents a number, otherwise <c>False</c>.</returns>
		public static bool IsNumber(this string value)
		{
			var result = !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"\d+");
			return result;
		}
		#endregion

		#region Reverse
		/// <summary>
		/// Reverses the order of the characters in the string.
		/// </summary>
		/// <param name="value">The string to reverse.</param>
		/// <returns>The string with the characters in reverse order. If the string is empty or contains only one character, returns the original string.</returns>
		public static string Reverse(this string value)
		{
			if (value.IsEmpty() || (value.Length == 1))
			{
				return value;
			}

			var chars = value.ToCharArray();
			Array.Reverse(chars);
			var result = new string(chars);
			return result;
		}
		#endregion

		#region Regex
		/// <summary>
		/// Checks if the string matches the given pattern.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <param name="pattern">The pattern to match.</param>
		/// <returns>True if the string matches the pattern, false otherwise.</returns>
		public static bool IsMatch(this string value, string pattern)
		{
			var result = value != null && Regex.IsMatch(value, pattern);
			return result;
		}

		/// <summary>
		/// Checks if the string matches the given Regex.
		/// </summary>
		/// <param name="value">The string to check.</param>
		/// <param name="regex">The Regex to match.</param>
		/// <returns>True if the string matches the Regex, false otherwise.</returns>
		public static bool IsMatch(this string value, Regex regex)
		{
			var result = value != null && regex.IsMatch(value);
			return result;
		}

		/// <summary>
		/// Returns the first match of the pattern in the string.
		/// </summary>
		/// <param name="value">The string to search.</param>
		/// <param name="pattern">The pattern to match.</param>
		/// <returns>The first match of the pattern in the string.</returns>
		public static string Match(this string value, string pattern)
		{
			var result = value == null ? "" : Regex.Match(value, pattern).Value;
			return result;
		}

		/// <summary>
		/// Returns the first match of the Regex in the string.
		/// </summary>
		/// <param name="value">The string to search.</param>
		/// <param name="regex">The Regex to match.</param>
		/// <returns>The first match of the Regex in the string.</returns>
		public static string Match(this string value, Regex regex)
		{
			var result = value == null ? "" : regex.Match(value).Value;
			return result;
		}

		/// <summary>
		/// Returns all matches of the pattern in the string.
		/// </summary>
		/// <param name="value">The string to search.</param>
		/// <param name="regexPattern">The pattern to match.</param>
		/// <returns>All matches of the pattern in the string.</returns>
		public static MatchCollection Matches(this string value, string regexPattern)
		{
			var result = Matches(value, regexPattern, RegexOptions.None);
			return result;
		}

		/// <summary>
		/// Returns all matches of the pattern in the string with the specified options.
		/// </summary>
		/// <param name="value">The string to search.</param>
		/// <param name="regexPattern">The pattern to match.</param>
		/// <param name="options">The options to use when matching.</param>
		/// <returns>All matches of the pattern in the string with the specified options.</returns>
		public static MatchCollection Matches(this string value, string regexPattern, RegexOptions options)
		{
			var result = Regex.Matches(value, regexPattern, options);
			return result;
		}

		/// <summary>
		/// Returns all match values of the pattern in the string.
		/// </summary>
		/// <param name="value">The string to search.</param>
		/// <param name="regexPattern">The pattern to match.</param>
		/// <returns>All match values of the pattern in the string.</returns>
		public static IEnumerable<string> MatchValues(this string value, string regexPattern)
		{
			var result = MatchValues(value, regexPattern, RegexOptions.None);
			return result;
		}

		/// <summary>
		/// Returns all match values of the pattern in the string with the specified options.
		/// </summary>
		/// <param name="value">The string to search.</param>
		/// <param name="regexPattern">The pattern to match.</param>
		/// <param name="options">The options to use when matching.</param>
		/// <returns>All match values of the pattern in the string with the specified options.</returns>
		public static IEnumerable<string> MatchValues(this string value, string regexPattern, RegexOptions options)
		{
			foreach (Match match in Matches(value, regexPattern, options))
			{
				if (match.Success) yield return match.Value;
			}
		}
		#endregion
	}
}