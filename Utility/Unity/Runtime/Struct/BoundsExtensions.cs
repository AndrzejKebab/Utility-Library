using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class BoundsExtensions
    {
        #region Deconstruct
        /// <summary>
        /// Deconstructs a Bounds instance into its center and size components.
        /// </summary>
        /// <param name="bounds">The Bounds instance.</param>
        /// <param name="center">The center of the Bounds.</param>
        /// <param name="size">The size of the Bounds.</param>
        public static void Deconstruct(this Bounds bounds, out Vector3 center, out Vector3 size)
        {
            center = bounds.center;
            size = bounds.size;
        }

        /// <summary>
        /// Deconstructs a Bounds instance into its center, size, min, and max components.
        /// </summary>
        /// <param name="bounds">The Bounds instance.</param>
        /// <param name="center">The center of the Bounds.</param>
        /// <param name="size">The size of the Bounds.</param>
        /// <param name="min">The minimum point of the Bounds.</param>
        /// <param name="max">The maximum point of the Bounds.</param>
        public static void Deconstruct(this Bounds bounds, out Vector3 center, out Vector3 size, out Vector3 min, out Vector3 max)
        {
            center = bounds.center;
            size = bounds.size;
            min = bounds.min;
            max = bounds.max;
        }
        #endregion

        #region With
        /// <summary>
        /// Creates a new Bounds instance with the specified center and size, or the original center and size if not specified.
        /// </summary>
        /// <param name="bounds">The original Bounds instance.</param>
        /// <param name="center">The center of the new Bounds. If null, the center of the original Bounds is used.</param>
        /// <param name="size">The size of the new Bounds. If null, the size of the original Bounds is used.</param>
        /// <returns>A new Bounds instance with the specified center and size.</returns>
        public static Bounds With(this Bounds bounds, in Vector3? center = null, in Vector3? size = null)
        {
            var result = new Bounds(center ?? bounds.center, size ?? bounds.size);
            return result;
        }
        #endregion
    }
}