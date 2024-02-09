using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class BoundsIntExtensions
    {
        #region Deconstruct
        /// <summary>
        /// Deconstructs a BoundsInt instance into its minimum point and size components.
        /// </summary>
        /// <param name="bounds">The BoundsInt instance.</param>
        /// <param name="xMin">The minimum x-coordinate of the BoundsInt.</param>
        /// <param name="yMin">The minimum y-coordinate of the BoundsInt.</param>
        /// <param name="zMin">The minimum z-coordinate of the BoundsInt.</param>
        /// <param name="sizeX">The size of the BoundsInt along the x-axis.</param>
        /// <param name="sizeY">The size of the BoundsInt along the y-axis.</param>
        /// <param name="sizeZ">The size of the BoundsInt along the z-axis.</param>
        public static void Deconstruct(this BoundsInt bounds, out int xMin, out int yMin, out int zMin, out int sizeX, out int sizeY, out int sizeZ)
        {
            xMin = bounds.xMin;
            yMin = bounds.yMin;
            zMin = bounds.zMin;
            sizeX = bounds.size.x;
            sizeY = bounds.size.y;
            sizeZ = bounds.size.z;
        }

        /// <summary>
        /// Deconstructs a BoundsInt instance into its position and size components.
        /// </summary>
        /// <param name="bounds">The BoundsInt instance.</param>
        /// <param name="position">The position of the BoundsInt.</param>
        /// <param name="size">The size of the BoundsInt.</param>
        public static void Deconstruct(this BoundsInt bounds, out Vector3Int position, out Vector3Int size)
        {
            position = bounds.position;
            size = bounds.size;
        }

        /// <summary>
        /// Deconstructs a BoundsInt instance into its position, size, min, and max components.
        /// </summary>
        /// <param name="bounds">The BoundsInt instance.</param>
        /// <param name="position">The position of the BoundsInt.</param>
        /// <param name="size">The size of the BoundsInt.</param>
        /// <param name="min">The minimum point of the BoundsInt.</param>
        /// <param name="max">The maximum point of the BoundsInt.</param>
        public static void Deconstruct(this BoundsInt bounds, out Vector3Int position, out Vector3Int size, out Vector3Int min, out Vector3Int max)
        {
            position = bounds.position;
            size = bounds.size;
            min = bounds.min;
            max = bounds.max;
        }
        #endregion

        #region With
        /// <summary>
        /// Creates a new BoundsInt instance with the specified position and size, or the original position and size if not specified.
        /// </summary>
        /// <param name="bounds">The original BoundsInt instance.</param>
        /// <param name="position">The position of the new BoundsInt. If null, the position of the original BoundsInt is used.</param>
        /// <param name="size">The size of the new BoundsInt. If null, the size of the original BoundsInt is used.</param>
        /// <returns>A new BoundsInt instance with the specified position and size.</returns>
        public static BoundsInt With(this BoundsInt bounds, in Vector3Int? position = null, in Vector3Int? size = null)
        {
            var result = new BoundsInt(position ?? bounds.position, size ?? bounds.size);
            return result;
        }
        #endregion
    }
}