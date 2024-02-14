using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace UtilityLibrary.Core
{
	public static class TaskAwaiterExtensions
	{
		/// <summary>
		/// Gets a TaskAwaiter that completes after a specified time period.
		/// </summary>
		/// <param name="timeSpan">The time period to wait.</param>
		/// <returns>A TaskAwaiter that completes after the specified time period.</returns>
		public static TaskAwaiter GetAwaiter(this TimeSpan timeSpan)
		{
			return Task.Delay(timeSpan).GetAwaiter();
		}

		/// <summary>
		/// Gets a TaskAwaiter that completes after a specified number of seconds.
		/// </summary>
		/// <param name="seconds">The number of seconds to wait.</param>
		/// <returns>A TaskAwaiter that completes after the specified number of seconds.</returns>
		public static TaskAwaiter GetAwaiter(this int seconds)
		{
			return Task.Delay(TimeSpan.FromSeconds(seconds)).GetAwaiter();
		}

		/// <summary>
		/// Gets a TaskAwaiter that completes after a specified number of seconds.
		/// </summary>
		/// <param name="seconds">The number of seconds to wait.</param>
		/// <returns>A TaskAwaiter that completes after the specified number of seconds.</returns>
		public static TaskAwaiter GetAwaiter(this float seconds)
		{
			return Task.Delay(TimeSpan.FromSeconds(seconds)).GetAwaiter();
		}
	}
}