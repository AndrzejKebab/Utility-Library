using Unity.Collections;

namespace UtilityLibrary.Unity.Runtime
{
    public static class NativeArrayExtensions
    {
        /// <summary>
        /// Retrieves the element at the specified 2D index in a flattened array.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional array to retrieve the element from.</param>
        /// <param name="width">The width of the original two-dimensional array.</param>
        /// <param name="x">The x-coordinate in the original two-dimensional array.</param>
        /// <param name="y">The y-coordinate in the original two-dimensional array.</param>
        /// <returns>The element at the specified 2D index in the flattened array.</returns>
        public static T GetAtFlatIndex<T>(this NativeArray<T> array, int width, int x, int y) where T : struct
        {
            return array[y * width + x];
        }

        /// <summary>
        /// Retrieves the element at the specified 3D index in a flattened array.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional array to retrieve the element from.</param>
        /// <param name="width">The width of the original three-dimensional array.</param>
        /// <param name="height">The height of the original three-dimensional array.</param>
        /// <param name="x">The x-coordinate in the original three-dimensional array.</param>
        /// <param name="y">The y-coordinate in the original three-dimensional array.</param>
        /// <param name="z">The z-coordinate in the original three-dimensional array.</param>
        /// <returns>The element at the specified 3D index in the flattened array.</returns>
        public static T GetAtFlatIndex<T>(this NativeArray<T> array, int width, int height, int x, int y, int z) where T : struct
        {
            return array[x + y * width + z * width * height];
        }
        
        /// <summary>
        /// Retrieves the element at the specified 3D index in a flattened array.
        /// This method assumes that the original three-dimensional array was a cube, with equal width, height, and depth.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional array to retrieve the element from.</param>
        /// <param name="size">The size (width, height, and depth) of the original three-dimensional array.</param>
        /// <param name="x">The x-coordinate in the original three-dimensional array.</param>
        /// <param name="y">The y-coordinate in the original three-dimensional array.</param>
        /// <param name="z">The z-coordinate in the original three-dimensional array.</param>
        /// <returns>The element at the specified 3D index in the flattened array.</returns>
        public static T GetAtFlatIndex<T>(this NativeArray<T> array, int size, int x, int y, int z) where T : struct
        {
            return array[x + y * size + z * size * size];
        }
    }
}