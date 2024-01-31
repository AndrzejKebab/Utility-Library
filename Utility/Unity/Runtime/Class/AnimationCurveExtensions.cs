using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
	/// <summary>
	/// Provides extension methods for the AnimationCurve class.
	/// </summary>
	public static class AnimationCurveExtensions
	{
		/// <summary>
		/// Checks if the animation curve is looping.
		/// </summary>
		/// <param name="animationCurve">The animation curve to check.</param>
		/// <returns>True if the animation curve is looping, false otherwise.</returns>
		public static bool IsLooping(this AnimationCurve animationCurve)
		{
			var result = animationCurve != null && (animationCurve.postWrapMode.Equals(WrapMode.Loop) || animationCurve.postWrapMode.Equals(WrapMode.PingPong));
			return result;
		}

		/// <summary>
		/// Gets the maximum value of the animation curve.
		/// </summary>
		/// <param name="animationCurve">The animation curve to get the maximum value from.</param>
		/// <returns>The maximum value of the animation curve.</returns>
		public static float GetMaxValue(this AnimationCurve animationCurve)
		{
			var ret = float.MinValue;
			var frames = animationCurve.keys;
			for (var i = 0; i < frames.Length; i++)
			{
				var frame = frames[i];
				var value = frame.value;
				if (value > ret)
				{
					ret = value;
				}
			}

			return ret;
		}

		/// <summary>
		/// Gets the minimum value of the animation curve.
		/// </summary>
		/// <param name="animationCurve">The animation curve to get the minimum value from.</param>
		/// <returns>The minimum value of the animation curve.</returns>
		public static float GetMinValue(this AnimationCurve animationCurve)
		{
			var ret = float.MaxValue;
			var frames = animationCurve.keys;
			for (var i = 0; i < frames.Length; i++)
			{
				var frame = frames[i];
				var value = frame.value;
				if (value < ret)
				{
					ret = value;
				}
			}

			return ret;
		}

		/// <summary>
		/// Reverses the animation curve.
		/// </summary>
		/// <param name="animationCurve">The animation curve to reverse.</param>
		public static void Reverse(this AnimationCurve animationCurve)
		{
			var keys = animationCurve.keys;
			var newKeys = new Keyframe[keys.Length];

			for (var i = 0; i < keys.Length; i++)
			{
				var key = keys[i];
				newKeys[keys.Length - 1 - i] = new Keyframe(1f - key.time, key.value, -key.outTangent, -key.inTangent);
			}

			animationCurve.keys = newKeys;
		}
	}
}