using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class Vector3Extension
    {
        #region Deconstruct
        /// <summary>
        /// Deconstructs a Vector3 instance into its individual components.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <param name="x">The x component of the Vector3.</param>
        /// <param name="y">The y component of the Vector3.</param>
        /// <param name="z">The z component of the Vector3.</param>
        public static void Deconstruct(in this Vector3 vector, out float x, out float y, out float z)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }
        #endregion
        
        #region With
        /// <summary>
        /// Creates a new Vector3 instance with the specified components, or the original components if not specified.
        /// </summary>
        /// <param name="vector">The original Vector3 instance.</param>
        /// <param name="x">The x component of the new Vector3. If null, the x component of the original Vector3 is used.</param>
        /// <param name="y">The y component of the new Vector3. If null, the y component of the original Vector3 is used.</param>
        /// <param name="z">The z component of the new Vector3. If null, the z component of the original Vector3 is used.</param>
        /// <returns>A new Vector3 instance with the specified components.</returns>
        public static Vector3 With(in this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            var result = new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
            return result;
        }
        #endregion

        #region Distance
        /// <summary>
        /// Calculates the distance from a Vector3 to a point.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <param name="point">The point to calculate the distance to.</param>
        /// <returns>The distance from the Vector3 to the point.</returns>
        public static float Distance2Point(this Vector3 vector, Vector3 point)
        {
            var result = Vector3.Distance(vector, point);
            return result;
        }

        /// <summary>
        /// Calculates the shortest distance from a Vector3 to a line segment.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <param name="linePoint1">The first point of the line segment.</param>
        /// <param name="linePoint2">The second point of the line segment.</param>
        /// <returns>The shortest distance from the Vector3 to the line segment.</returns>
        public static float Distance2Line(Vector2 vector, Vector2 linePoint1, Vector2 linePoint2)
        {
            float space;
            var a = Vector2.Distance(linePoint1, linePoint2);
            var b = Vector2.Distance(linePoint1, vector);
            var c = Vector2.Distance(linePoint2, vector);
            if (c <= 1e-6 || b <= 1e-6)
            {
                space = 0;
                return space;
            }

            if (a <= 1e-6)
            {
                space = b;
                return space;
            }

            if (c * c >= a * a + b * b)
            {
                space = b;
                return space;
            }

            if (b * b >= a * a + c * c)
            {
                space = c;
                return space;
            }

            var p = (a + b + c) / 2;
            var s = Mathf.Sqrt(p * (p - a) * (p - b) * (p - c));
            space = 2 * s / a;
            return space;
        }
        #endregion

        #region Clamp
        /// <summary>
        /// Clamps the components of a Vector3 between 0 and 1.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <returns>The clamped Vector3.</returns>
        public static Vector3 Clamp01(this Vector3 vector)
        {
            vector = vector.Clamp(0f, 1f);
            return vector;
        }

        /// <summary>
        /// Clamps the components of a Vector3 between specified minimum and maximum values.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <param name="min">The minimum value to clamp the components to.</param>
        /// <param name="max">The maximum value to clamp the components to.</param>
        /// <returns>The clamped Vector3.</returns>
        public static Vector3 Clamp(this Vector3 vector, float min, float max)
        {
            vector.x = Mathf.Clamp(vector.x, min, max);
            vector.y = Mathf.Clamp(vector.y, min, max);
            vector.z = Mathf.Clamp(vector.z, min, max);
            return vector;
        }

        /// <summary>
        /// Clamps the components of a Vector3 between specified minimum and maximum vectors.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <param name="min">The minimum vector to clamp the components to.</param>
        /// <param name="max">The maximum vector to clamp the components to.</param>
        /// <returns>The clamped Vector3.</returns>
        public static Vector3 Clamp(this Vector3 vector, Vector3 min, Vector3 max)
        {
            vector.x = Mathf.Clamp(vector.x, min.x, max.x);
            vector.y = Mathf.Clamp(vector.y, min.y, max.y);
            vector.z = Mathf.Clamp(vector.z, min.z, max.z);
            return vector;
        }
        #endregion

        #region Flip
        /// <summary>
        /// Flips a Vector3 in all directions.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <returns>The flipped Vector3.</returns>
        public static Vector3 Flip(this Vector3 vector)
        {
            vector = -vector;
            return vector;
        }

        /// <summary>
        /// Flips a Vector3 in the x direction.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <returns>The flipped Vector3.</returns>
        public static Vector3 FlipX(this Vector3 vector)
        {
            vector.x = -vector.x;
            return vector;
        }

        /// <summary>
        /// Flips a Vector3 in the y direction.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <returns>The flipped Vector3.</returns>
        public static Vector3 FlipY(this Vector3 vector)
        {
            vector.y = -vector.y;
            return vector;
        }

        /// <summary>
        /// Flips a Vector3 in the z direction.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <returns>The flipped Vector3.</returns>
        public static Vector3 FlipZ(this Vector3 vector)
        {
            vector.z = -vector.z;
            return vector;
        }
        #endregion

        #region XYZ -> Vector2
        /// <summary>
        /// Returns a Vector2 with the x and y components of a Vector3.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <returns>A Vector2 with the x and y components of the Vector3.</returns>
        public static Vector2 GetXy(this Vector3 vector)
        {
            var result = new Vector2(vector.x, vector.y);
            return result;
        }

        /// <summary>
        /// Returns a Vector2 with the y and z components of a Vector3.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <returns>A Vector2 with the y and z components of the Vector3.</returns>
        public static Vector2 GetYz(this Vector3 vector)
        {
            var result = new Vector2(vector.y, vector.z);
            return result;
        }

        /// <summary>
        /// Returns a Vector2 with the x and z components of a Vector3.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <returns>A Vector2 with the x and z components of the Vector3.</returns>
        public static Vector2 GetXz(this Vector3 vector)
        {
            var result = new Vector2(vector.x, vector.z);
            return result;
        }
        #endregion

        #region Rotate
        /// <summary>
        /// Rotates a point around a pivot by specified Euler angles.
        /// </summary>
        /// <param name="point">The point to rotate.</param>
        /// <param name="pivot">The pivot point for the rotation.</param>
        /// <param name="eulerAngles">The Euler angles to rotate the point by.</param>
        /// <returns>The rotated point.</returns>
        public static Vector3 RotateAroundPivot(this Vector3 point, Vector3 pivot, Vector3 eulerAngles)
        {
            var dir = point - pivot;
            dir = Quaternion.Euler(eulerAngles) * dir;
            return dir + pivot;
        }

        /// <summary>
        /// Rotates a point around a pivot by a specified Quaternion rotation.
        /// </summary>
        /// <param name="point">The point to rotate.</param>
        /// <param name="pivot">The pivot point for the rotation.</param>
        /// <param name="rotation">The Quaternion rotation to rotate the point by.</param>
        /// <returns>The rotated point.</returns>
        public static Vector3 RotateAroundPivot(this Vector3 point, Vector3 pivot, Quaternion rotation)
        {
            var dir = point - pivot;
            dir = rotation * dir;
            return dir + pivot;
        }
        #endregion

        /// <summary>
        /// Checks if a Vector3 contains NaN values.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <returns>True if the Vector3 contains NaN values, false otherwise.</returns>
        public static bool IsNaN(this Vector3 vector)
        {
            return float.IsNaN(vector.x) || float.IsNaN(vector.y) || float.IsNaN(vector.z);
        }
    }
}