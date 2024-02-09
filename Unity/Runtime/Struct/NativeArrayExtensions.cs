using Unity.Collections;

namespace UtilityLibrary.Unity.Runtime
{
    public static class NativeArrayExtensions
    {
        #region Flatten Array
        #region Indexing
        /// <summary>
        /// Calculates the flattened index for a two-dimensional array.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional array.</param>
        /// <param name="x">The index along the first dimension.</param>
        /// <param name="y">The index along the second dimension.</param>
        /// <param name="width">The width of the two-dimensional array.</param>
        /// <returns>The flattened index.</returns>
        public static int FlattenIndex<T>(this NativeArray<T> array, int x, int y, int width) where T : struct
        {
            return y * width + x;
        }
    
        /// <summary>
        /// Calculates the flattened index for a three-dimensional array.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional array.</param>
        /// <param name="x">The index along the first dimension.</param>
        /// <param name="y">The index along the second dimension.</param>
        /// <param name="z">The index along the third dimension.</param>
        /// <param name="width">The width of the three-dimensional array.</param>
        /// <param name="height">The height of the three-dimensional array.</param>
        /// <returns>The flattened index.</returns>
        public static int FlattenIndex<T>(this NativeArray<T> array, int x, int y, int z, int width, int height) where T : struct
            => x + y * width + z * width * height;
    
        /// <summary>
        /// Calculates the flattened index for a three-dimensional array.
        /// This method assumes that the original three-dimensional array was a cube, with equal width, height, and depth.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional array.</param>
        /// <param name="x">The index along the first dimension.</param>
        /// <param name="y">The index along the second dimension.</param>
        /// <param name="z">The index along the third dimension.</param>
        /// <param name="size">The size (width, height, and depth) of the original three-dimensional array.</param>
        /// <returns>The flattened index.</returns>
        public static int FlattenIndex<T>(this NativeArray<T> array, int x, int y, int z, int size) where T : struct
            => x + y * size + z * size * size;
        #endregion

        #region Get At Index
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
        #endregion

        #region Set At Index
        /// <summary>
        /// Sets the value at the specified 2D index in a flattened array.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional array to set the value in.</param>
        /// <param name="width">The width of the original two-dimensional array.</param>
        /// <param name="x">The x-coordinate in the original two-dimensional array.</param>
        /// <param name="y">The y-coordinate in the original two-dimensional array.</param>
        /// <param name="value">The value to set at the specified index.</param>
        public static void SetAtFlatIndex<T>(this NativeArray<T> array, int width, int x, int y, T value) where T : struct
        {
            array[y * width + x] = value;
        }
        
        /// <summary>
        /// Sets the value at the specified 3D index in a flattened array.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional array to set the value in.</param>
        /// <param name="width">The width of the original three-dimensional array.</param>
        /// <param name="height">The height of the original three-dimensional array.</param>
        /// <param name="x">The x-coordinate in the original three-dimensional array.</param>
        /// <param name="y">The y-coordinate in the original three-dimensional array.</param>
        /// <param name="z">The z-coordinate in the original three-dimensional array.</param>
        /// <param name="value">The value to set at the specified index.</param>
        public static void SetAtFlatIndex<T>(this NativeArray<T> array, int width, int height, int x, int y, int z, T value) where T : struct
        {
            array[x + y * width + z * width * height] = value;
        }
        
        /// <summary>
        /// Sets the value at the specified 3D index in a flattened array.
        /// This method assumes that the original three-dimensional array was a cube, with equal width, height, and depth.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional array to set the value in.</param>
        /// <param name="size">The size (width, height, and depth) of the original three-dimensional array.</param>
        /// <param name="x">The x-coordinate in the original three-dimensional array.</param>
        /// <param name="y">The y-coordinate in the original three-dimensional array.</param>
        /// <param name="z">The z-coordinate in the original three-dimensional array.</param>
        /// <param name="value">The value to set at the specified index.</param>
        public static void SetAtFlatIndex<T>(this NativeArray<T> array, int size, int x, int y, int z, T value) where T : struct
        {
            array[x + y * size + z * size * size] = value;
        }
        #endregion
        #endregion
    }
}