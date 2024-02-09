using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
	public static class ParticleSystemExtensions
	{
		/// <summary>
		/// Gets the duration of the particle system.
		/// </summary>
		/// <remarks>
		/// This method calculates the duration of a ParticleSystem instance. If the emission of the ParticleSystem is not enabled, it returns 0.
		/// If the ParticleSystem is set to loop and allowLoop is false, it returns -1. Otherwise, it calculates the duration based on the start delay,
		/// start lifetime, and the duration of the ParticleSystem.
		/// </remarks>
		/// <param name="particle">The ParticleSystem instance to get the duration from.</param>
		/// <param name="allowLoop">Whether to allow looping. Default is false.</param>
		/// <returns>The duration of the ParticleSystem. If allowLoop is false and the ParticleSystem is looping, returns -1.</returns>
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
		/// Enables or disables the emission of particles in a ParticleSystem.
		/// </summary>
		/// <param name="particleSystem">The ParticleSystem instance to enable or disable emission.</param>
		/// <param name="enabled">True to enable emission, false to disable.</param>
		public static void SetActiveEmission(this ParticleSystem particleSystem, bool enabled)
		{
			var emission = particleSystem.emission;
			emission.enabled = enabled;
		}

		#region Emission Rate
		/// <summary>
		/// Gets the constant maximum emission rate of particles in a ParticleSystem.
		/// </summary>
		/// <param name="particleSystem">The ParticleSystem instance to get the emission rate from.</param>
		/// <returns>The constant maximum emission rate of particles.</returns>
		public static float GetEmissionRate(this ParticleSystem particleSystem)
		{
			return particleSystem.emission.rateOverTime.constantMax;
		}
		
		/// <summary>
		/// Sets the constant maximum emission rate of particles in a ParticleSystem.
		/// </summary>
		/// <param name="particleSystem">The ParticleSystem instance to set the emission rate.</param>
		/// <param name="emissionRate">The new constant maximum emission rate of particles.</param>
		public static void SetEmissionRate(this ParticleSystem particleSystem, float emissionRate)
		{
			var emission = particleSystem.emission;
			var rate = emission.rateOverTime;
			rate.constantMax = emissionRate;
			emission.rateOverTime = rate;
		}
		#endregion
	}
}