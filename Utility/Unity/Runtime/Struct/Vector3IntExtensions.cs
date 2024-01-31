using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class Vector3IntExtensions
    {
        #region Deconstruct
        /// <summary>
        /// Deconstructs a Vector3Int instance into its individual components.
        /// </summary>
        /// <param name="vector">The Vector3Int instance.</param>
        /// <param name="x">The x component of the Vector3Int.</param>
        /// <param name="y">The y component of the Vector3Int.</param>
        /// <param name="z">The z component of the Vector3Int.</param>
        public static void Deconstruct(in this Vector3Int vector, out int x, out int y, out int z)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }
        #endregion
        
        #region With
        /// <summary>
        /// Creates a new Vector3Int instance with the specified components, or the original components if not specified.
        /// </summary>
        /// <param name="vector">The original Vector3Int instance.</param>
        /// <param name="x">The x component of the new Vector3Int. If null, the x component of the original Vector3Int is used.</param>
        /// <param name="y">The y component of the new Vector3Int. If null, the y component of the original Vector3Int is used.</param>
        /// <param name="z">The z component of the new Vector3Int. If null, the z component of the original Vector3Int is used.</param>
        /// <returns>A new Vector3Int instance with the specified components.</returns>
        public static Vector3Int With(in this Vector3Int vector, int? x = null, int? y = null, int? z = null)
        {
            var result = new Vector3Int(x ?? vector.x, y ?? vector.y, z ?? vector.z);
            return result;
        }
        #endregion

        #region Distance
        /// <summary>
        /// Calculates the distance from a Vector3Int to a point.
        /// </summary>
        /// <param name="vector">The Vector3Int instance.</param>
        /// <param name="point">The point to calculate the distance to.</param>
        /// <returns>The distance from the Vector3Int to the point.</returns>
        public static float Distance2Point(this Vector3Int vector, Vector3Int point)
        {
            var result = Vector3Int.Distance(vector, point);
            return result;
        }

        /// <summary>
        /// Calculates the shortest distance from a Vector3 to a line segment.
        /// </summary>
        /// <param name="vector">The Vector3 instance.</param>
        /// <param name="linePoint1">The first point of the line segment.</param>
        /// <param name="linePoint2">The second point of the line segment.</param>
        /// <returns>The shortest distance from the Vector3 to the line segment.</returns>
        public static float Distance2Line(Vector3Int vector, Vector3Int linePoint1, Vector3Int linePoint2)
        {
            float space;
            var a = Vector3Int.Distance(linePoint1, linePoint2);
            var b = Vector3Int.Distance(linePoint1, vector);
            var c = Vector3Int.Distance(linePoint2, vector);
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
        /// Clamps the components of a Vector3Int between specified minimum and maximum values.
        /// </summary>
        /// <param name="vector">The Vector3Int instance.</param>
        /// <param name="min">The minimum value to clamp the components to.</param>
        /// <param name="max">The maximum value to clamp the components to.</param>
        /// <returns>The clamped Vector3Int.</returns>
        public static Vector3Int Clamp(this Vector3Int vector, int min, int max)
        {
            vector.x = Mathf.Clamp(vector.x, min, max);
            vector.y = Mathf.Clamp(vector.y, min, max);
            vector.z = Mathf.Clamp(vector.z, min, max);
            return vector;
        }

        /// <summary>
        /// Clamps the components of a Vector3Int between specified minimum and maximum vectors.
        /// </summary>
        /// <param name="vector">The Vector3Int instance.</param>
        /// <param name="min">The minimum vector to clamp the components to.</param>
        /// <param name="max">The maximum vector to clamp the components to.</param>
        /// <returns>The clamped Vector3Int.</returns>
        public static Vector3Int Clamp(this Vector3Int vector, Vector3Int min, Vector3Int max)
        {
            vector.x = Mathf.Clamp(vector.x, min.x, max.x);
            vector.y = Mathf.Clamp(vector.y, min.y, max.y);
            vector.z = Mathf.Clamp(vector.z, min.z, max.z);
            return vector;
        }
        #endregion

        #region Flip
        /// <summary>
        /// Flips a Vector3Int in all directions.
        /// </summary>
        /// <param name="vector">The Vector3Int instance.</param>
        /// <returns>The flipped Vector3Int.</returns>
        public static Vector3Int Flip(this Vector3Int vector)
        {
            vector = -vector;
            return vector;
        }

        /// <summary>
        /// Flips a Vector3Int in the x direction.
        /// </summary>
        /// <param name="vector">The Vector3Int instance.</param>
        /// <returns>The flipped Vector3Int.</returns>
        public static Vector3Int FlipX(this Vector3Int vector)
        {
            vector.x = -vector.x;
            return vector;
        }

        /// <summary>
        /// Flips a Vector3Int in the y direction.
        /// </summary>
        /// <param name="vector">The Vector3Int instance.</param>
        /// <returns>The flipped Vector3Int.</returns>
        public static Vector3Int FlipY(this Vector3Int vector)
        {
            vector.y = -vector.y;
            return vector;
        }

        /// <summary>
        /// Flips a Vector3Int in the z direction.
        /// </summary>
        /// <param name="vector">The Vector3Int instance.</param>
        /// <returns>The flipped Vector3Int.</returns>
        public static Vector3Int FlipZ(this Vector3Int vector)
        {
            vector.z = -vector.z;
            return vector;
        }
        #endregion

        #region XYZ -> Vector2Int
        /// <summary>
        /// Returns a Vector2Int with the x and y components of a Vector3Int.
        /// </summary>
        /// <param name="vector">The Vector3Int instance.</param>
        /// <returns>A Vector2Int with the x and y components of the Vector3Int.</returns>
        public static Vector2Int GetXy(this Vector3Int vector)
        {
            var result = new Vector2Int(vector.x, vector.y);
            return result;
        }

        /// <summary>
        /// Returns a Vector2Int with the y and z components of a Vector3Int.
        /// </summary>
        /// <param name="vector">The Vector3Int instance.</param>
        /// <returns>A Vector2Int with the y and z components of the Vector3Int.</returns>
        public static Vector2Int GetYz(this Vector3Int vector)
        {
            var result = new Vector2Int(vector.y, vector.z);
            return result;
        }

        /// <summary>
        /// Returns a Vector2Int with the x and z components of a Vector3Int.
        /// </summary>
        /// <param name="vector">The Vector3Int instance.</param>
        /// <returns>A Vector2Int with the x and z components of the Vector3Int.</returns>
        public static Vector2Int GetXz(this Vector3Int vector)
        {
            var result = new Vector2Int(vector.x, vector.z);
            return result;
        }
        #endregion
    }
}