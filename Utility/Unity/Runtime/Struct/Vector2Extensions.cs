using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class Vector2Extension
    {
        #region Deconstruct
        /// <summary>
        /// Deconstructs a Vector2 instance into its individual components.
        /// </summary>
        /// <param name="vector">The Vector2 instance.</param>
        /// <param name="x">The x component of the Vector2.</param>
        /// <param name="y">The y component of the Vector2.</param>
        public static void Deconstruct(in this Vector2 vector, out float x, out float y)
        {
            x = vector.x;
            y = vector.y;
        }
        #endregion

        #region With
        /// <summary>
        /// Creates a new Vector2 instance with the specified components, or the original components if not specified.
        /// </summary>
        /// <param name="vector">The original Vector2 instance.</param>
        /// <param name="x">The x component of the new Vector2. If null, the x component of the original Vector2 is used.</param>
        /// <param name="y">The y component of the new Vector2. If null, the y component of the original Vector2 is used.</param>
        /// <returns>A new Vector2 instance with the specified components.</returns>
        public static Vector2 With(in this Vector2 vector, float? x = null, float? y = null)
        {
            var result = new Vector2(x ?? vector.x, y ?? vector.y);
            return result;
        }
        #endregion

        #region Distance
        /// <summary>
        /// Calculates the shortest distance from a Vector2 to a line segment.
        /// </summary>
        /// <param name="vector">The Vector2 instance.</param>
        /// <param name="linePoint1">The first point of the line segment.</param>
        /// <param name="linePoint2">The second point of the line segment.</param>
        /// <returns>The shortest distance from the Vector2 to the line segment.</returns>
        public static float Distance2Line(this Vector2 vector, Vector2 linePoint1, Vector2 linePoint2)
        {
            var vec1 = vector - linePoint1;
            var vec2 = linePoint2 - linePoint1;
            var project = Vector3.Project(vec1, vec2);
            var dis = Mathf.Sqrt(Mathf.Pow(Vector3.Magnitude(vec1), 2) - Mathf.Pow(Vector3.Magnitude(project), 2));
            return dis;
        }
        #endregion

        #region Rotate
        /// <summary>
        /// Rotates a point around an origin point by a specified angle along a specified axis.
        /// </summary>
        /// <param name="origin">The origin point for the rotation.</param>
        /// <param name="point">The point to rotate.</param>
        /// <param name="axis">The axis to rotate the point along.</param>
        /// <param name="angle">The angle to rotate the point by.</param>
        /// <returns>The rotated point.</returns>
        public static Vector2 Rotate(this Vector2 origin, Vector2 point, Vector2 axis, float angle)
        {
            var quaternion = Quaternion.AngleAxis(angle, axis);
            var offset = origin - point;
            offset = quaternion * offset;
            var result = point + offset;
            return result;
        }
        #endregion

        #region Flip
        /// <summary>
        /// Flips a Vector2 in both the x and y directions.
        /// </summary>
        /// <param name="vector">The Vector2 instance.</param>
        /// <returns>The flipped Vector2.</returns>
        public static Vector2 Flip(this Vector2 vector)
        {
            vector = -vector;
            return vector;
        }

        /// <summary>
        /// Flips a Vector2 in the x direction.
        /// </summary>
        /// <param name="vector">The Vector2 instance.</param>
        /// <returns>The flipped Vector2.</returns>
        public static Vector2 FlipX(this Vector2 vector)
        {
            vector.x = -vector.x;
            return vector;
        }

        /// <summary>
        /// Flips a Vector2 in the y direction.
        /// </summary>
        /// <param name="vector">The Vector2 instance.</param>
        /// <returns>The flipped Vector2.</returns>
        public static Vector2 FlipY(this Vector2 vector)
        {
            vector.y = -vector.y;
            return vector;
        }
        #endregion

        #region Clamp
        /// <summary>
        /// Clamps the components of a Vector2 between 0 and 1.
        /// </summary>
        /// <param name="vector">The Vector2 instance.</param>
        /// <returns>The clamped Vector2.</returns>
        public static Vector2 Clamp01(this Vector2 vector)
        {
            vector = vector.Clamp(0f, 1f);
            return vector;
        }

        /// <summary>
        /// Clamps the components of a Vector2 between specified minimum and maximum values.
        /// </summary>
        /// <param name="vector">The Vector2 instance.</param>
        /// <param name="min">The minimum value to clamp the components to.</param>
        /// <param name="max">The maximum value to clamp the components to.</param>
        /// <returns>The clamped Vector2.</returns>
        public static Vector2 Clamp(this Vector2 vector, float min, float max)
        {
            vector.x = Mathf.Clamp(vector.x, min, max);
            vector.y = Mathf.Clamp(vector.y, min, max);
            return vector;
        }

        /// <summary>
        /// Clamps the components of a Vector2 between specified minimum and maximum vectors.
        /// </summary>
        /// <param name="vector">The Vector2 instance.</param>
        /// <param name="min">The minimum vector to clamp the components to.</param>
        /// <param name="max">The maximum vector to clamp the components to.</param>
        /// <returns>The clamped Vector2.</returns>
        public static Vector2 Clamp(this Vector2 vector, Vector2 min, Vector2 max)
        {
            vector.x = Mathf.Clamp(vector.x, min.x, max.x);
            vector.y = Mathf.Clamp(vector.y, min.y, max.y);
            return vector;
        }

        #endregion
        /// <summary>
        /// Checks if a Vector2 contains NaN values.
        /// </summary>
        /// <param name="vector">The Vector2 instance.</param>
        /// <returns>True if the Vector2 contains NaN values, false otherwise.</returns>
        public static bool IsNaN(this Vector2 vector)
        {
            return float.IsNaN(vector.x) || float.IsNaN(vector.y);
        }
    }
}