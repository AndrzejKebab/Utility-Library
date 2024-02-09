using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class Ray2DExtensions
    {
        /// <summary>
        /// Deconstructs a Ray2D instance into its origin and direction vectors.
        /// </summary>
        /// <param name="ray">The Ray2D instance.</param>
        /// <param name="origin">The origin vector of the Ray2D.</param>
        /// <param name="direction">The direction vector of the Ray2D.</param>
        public static void Deconstruct(this Ray2D ray, out Vector3 origin, out Vector3 direction)
        {
            origin = ray.origin;
            direction = ray.direction;
        }

        /// <summary>
        /// Creates a new Ray2D instance with the specified origin and direction vectors, or the original vectors if not specified.
        /// </summary>
        /// <param name="ray">The original Ray2D instance.</param>
        /// <param name="origin">The origin vector of the new Ray2D. If null, the origin vector of the original Ray2D is used.</param>
        /// <param name="direction">The direction vector of the new Ray2D. If null, the direction vector of the original Ray2D is used.</param>
        /// <returns>A new Ray2D instance with the specified origin and direction vectors.</returns>
        public static Ray2D With(this Ray2D ray, in Vector3? origin = null, in Vector3? direction = null)
        {
            var result = new Ray2D(origin ?? ray.origin, direction ?? ray.direction);
            return result;
        }
    }
}