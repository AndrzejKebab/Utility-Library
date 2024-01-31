using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
	public static class ParticleSystemExtensions
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
	}
}