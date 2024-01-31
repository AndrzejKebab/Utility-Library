using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class RayExtensions
    {
        /// <summary>
        /// Deconstructs a Ray instance into its origin and direction vectors.
        /// </summary>
        /// <param name="ray">The Ray instance.</param>
        /// <param name="origin">The origin vector of the Ray.</param>
        /// <param name="direction">The direction vector of the Ray.</param>
        public static void Deconstruct(this Ray ray, out Vector3 origin, out Vector3 direction)
        {
            origin = ray.origin;
            direction = ray.direction;
        }

        /// <summary>
        /// Creates a new Ray instance with the specified origin and direction vectors, or the original vectors if not specified.
        /// </summary>
        /// <param name="ray">The original Ray instance.</param>
        /// <param name="origin">The origin vector of the new Ray. If null, the origin vector of the original Ray is used.</param>
        /// <param name="direction">The direction vector of the new Ray. If null, the direction vector of the original Ray is used.</param>
        /// <returns>A new Ray instance with the specified origin and direction vectors.</returns>
        public static Ray With(this Ray ray, in Vector3? origin = null, in Vector3? direction = null)
        {
            var result = new Ray(origin ?? ray.origin, direction ?? ray.direction);
            return result;
        }
    }
}