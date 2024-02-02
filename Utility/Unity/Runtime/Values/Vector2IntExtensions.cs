using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class Vector2IntExtension
    {
        #region Deconstruct
        /// <summary>
        /// Deconstructs a Vector2Int instance into its individual components.
        /// </summary>
        /// <param name="vector">The Vector2Int instance.</param>
        /// <param name="x">The x component of the Vector2Int.</param>
        /// <param name="y">The y component of the Vector2Int.</param>
        public static void Deconstruct(in this Vector2Int vector, out int x, out int y)
        {
            x = vector.x;
            y = vector.y;
        }
        #endregion

        #region With
        /// <summary>
        /// Creates a new Vector2Int instance with the specified components, or the original components if not specified.
        /// </summary>
        /// <param name="vector">The original Vector2Int instance.</param>
        /// <param name="x">The x component of the new Vector2Int. If null, the x component of the original Vector2Int is used.</param>
        /// <param name="y">The y component of the new Vector2Int. If null, the y component of the original Vector2Int is used.</param>
        /// <returns>A new Vector2Int instance with the specified components.</returns>
        public static Vector2Int With(in this Vector2Int vector, int? x = null, int? y = null)
        {
            var result = new Vector2Int(x ?? vector.x, y ?? vector.y);
            return result;
        }
        #endregion

        #region Add
        /// <summary>
        /// Adds specified values to the x, y, and z components of a Vector2Int.
        /// </summary>
        /// <returns>A new Vector2Int instance with the updated components.</returns>
        public static Vector2Int Add(this Vector2Int vector, int x = 0, int y = 0)
        {
            return new Vector2Int(vector.x + x, vector.y + y);
        }
        #endregion
        
        #region Flip
        /// <summary>
        /// Flips a Vector2Int in both the x and y directions.
        /// </summary>
        /// <param name="vector">The Vector2Int instance.</param>
        /// <returns>The flipped Vector2Int.</returns>
        public static Vector2Int Flip(this Vector2Int vector)
        {
            vector = -vector;
            return vector;
        }

        /// <summary>
        /// Flips a Vector2Int in the x direction.
        /// </summary>
        /// <param name="vector">The Vector2Int instance.</param>
        /// <returns>The flipped Vector2Int.</returns>
        public static Vector2Int FlipX(this Vector2Int vector)
        {
            vector.x = -vector.x;
            return vector;
        }

        /// <summary>
        /// Flips a Vector2Int in the y direction.
        /// </summary>
        /// <param name="vector">The Vector2Int instance.</param>
        /// <returns>The flipped Vector2Int.</returns>
        public static Vector2Int FlipY(this Vector2Int vector)
        {
            vector.y = -vector.y;
            return vector;
        }
        #endregion

        #region Clamp
        /// <summary>
        /// Clamps the components of a Vector2Int between specified minimum and maximum values.
        /// </summary>
        /// <param name="vector">The Vector2Int instance.</param>
        /// <param name="min">The minimum value to clamp the components to.</param>
        /// <param name="max">The maximum value to clamp the components to.</param>
        /// <returns>The clamped Vector2Int.</returns>
        public static Vector2Int Clamp(this Vector2Int vector, int min, int max)
        {
            vector.x = Mathf.Clamp(vector.x, min, max);
            vector.y = Mathf.Clamp(vector.y, min, max);
            return vector;
        }

        /// <summary>
        /// Clamps the components of a Vector2Int between specified minimum and maximum vectors.
        /// </summary>
        /// <param name="vector">The Vector2Int instance.</param>
        /// <param name="min">The minimum vector to clamp the components to.</param>
        /// <param name="max">The maximum vector to clamp the components to.</param>
        /// <returns>The clamped Vector2Int.</returns>
        public static Vector2Int Clamp(this Vector2Int vector, Vector2Int min, Vector2Int max)
        {
            vector.x = Mathf.Clamp(vector.x, min.x, max.x);
            vector.y = Mathf.Clamp(vector.y, min.y, max.y);
            return vector;
        }
        #endregion
    }
}