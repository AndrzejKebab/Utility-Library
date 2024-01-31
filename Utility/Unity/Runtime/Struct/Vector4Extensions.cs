using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class Vector4IntExtension
    {
        #region Deconstruct & With
        /// <summary>
        /// Deconstructs a Vector4 instance into its individual components.
        /// </summary>
        /// <param name="vector">The Vector4 instance.</param>
        /// <param name="x">The x component of the Vector4.</param>
        /// <param name="y">The y component of the Vector4.</param>
        /// <param name="z">The z component of the Vector4.</param>
        /// <param name="w">The w component of the Vector4.</param>
        public static void Deconstruct(in this Vector4 vector, out float x, out float y, out float z, out float w)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
            w = vector.w;
        }

        /// <summary>
        /// Creates a new Vector4 instance with the specified components, or the original components if not specified.
        /// </summary>
        /// <param name="vector">The original Vector4 instance.</param>
        /// <param name="x">The x component of the new Vector4. If null, the x component of the original Vector4 is used.</param>
        /// <param name="y">The y component of the new Vector4. If null, the y component of the original Vector4 is used.</param>
        /// <param name="z">The z component of the new Vector4. If null, the z component of the original Vector4 is used.</param>
        /// <param name="w">The w component of the new Vector4. If null, the w component of the original Vector4 is used.</param>
        /// <returns>A new Vector4 instance with the specified components.</returns>
        public static Vector4 With(in this Vector4 vector, float? x = null, float? y = null, float? z = null, float? w = null)
        {
            var result = new Vector4(x ?? vector.x, y ?? vector.y, z ?? vector.z, w ?? vector.w);
            return result;
        }
        #endregion

        /// <summary>
        /// Checks if a Vector4 contains NaN values.
        /// </summary>
        /// <param name="vector">The Vector4 instance.</param>
        /// <returns>True if the Vector4 contains NaN values, false otherwise.</returns>
        public static bool IsNaN(this Vector4 vector)
        {
            return float.IsNaN(vector.x) || float.IsNaN(vector.y) || float.IsNaN(vector.z) || float.IsNaN(vector.w);
        }
    }
}