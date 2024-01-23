using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
	public static partial class ParticleSystemExtensions
	{
		/// <summary>
		/// Gets the duration of the particle system.
		/// </summary>
		/// <param name="particle">The particle system to get the duration from.</param>
		/// <param name="allowLoop">Whether to allow looping. Default is false.</param>
		/// <returns>The duration of the particle system. If allowLoop is false and the particle system is looping, returns -1.</returns>
		public static float GetDuration(this ParticleSystem particle, bool allowLoop = false)
		{
			if (!particle.emission.enabled) return 0f;
			if (particle.main.loop && !allowLoop)
			{
				return -1f;
			}
			if (particle.emission.rateOverTime.GetMinValue() <= 0)
			{
				return particle.main.startDelay.GetMaxValue() + particle.main.startLifetime.GetMaxValue();
			}
			else
			{
				return particle.main.startDelay.GetMaxValue() + Mathf.Max(particle.main.duration, particle.main.startLifetime.GetMaxValue());
			}
		}

		/// <summary>
		/// Gets the maximum value of the MinMaxCurve.
		/// </summary>
		/// <param name="minMaxCurve">The MinMaxCurve to get the maximum value from.</param>
		/// <returns>The maximum value of the MinMaxCurve.</returns>
		public static float GetMaxValue(this ParticleSystem.MinMaxCurve minMaxCurve)
		{
			switch (minMaxCurve.mode)
			{
				case ParticleSystemCurveMode.Constant:
					return minMaxCurve.constant;
				case ParticleSystemCurveMode.Curve:
					return minMaxCurve.curve.GetMaxValue();
				case ParticleSystemCurveMode.TwoConstants:
					return minMaxCurve.constantMax;
				case ParticleSystemCurveMode.TwoCurves:
					var ret1 = minMaxCurve.curveMin.GetMaxValue();
					var ret2 = minMaxCurve.curveMax.GetMaxValue();
					return ret1 > ret2 ? ret1 : ret2;
			}
			return -1f;
		}

		/// <summary>
		/// Gets the minimum value of the MinMaxCurve.
		/// </summary>
		/// <param name="minMaxCurve">The MinMaxCurve to get the minimum value from.</param>
		/// <returns>The minimum value of the MinMaxCurve.</returns>
		public static float GetMinValue(this ParticleSystem.MinMaxCurve minMaxCurve)
		{
			switch (minMaxCurve.mode)
			{
				case ParticleSystemCurveMode.Constant:
					return minMaxCurve.constant;
				case ParticleSystemCurveMode.Curve:
					return minMaxCurve.curve.GetMinValue();
				case ParticleSystemCurveMode.TwoConstants:
					return minMaxCurve.constantMin;
				case ParticleSystemCurveMode.TwoCurves:
					var ret1 = minMaxCurve.curveMin.GetMinValue();
					var ret2 = minMaxCurve.curveMax.GetMinValue();
					return ret1 < ret2 ? ret1 : ret2;
			}
			return -1f;
		}
	}
}