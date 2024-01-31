using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class MatrixExtensions
    {
        #region Deconstruct

        /// <summary>
        /// Deconstructs a Matrix4x4 instance into its column vectors.
        /// </summary>
        /// <param name="matrix">The Matrix4x4 instance.</param>
        /// <param name="column0">The first column vector of the Matrix4x4.</param>
        /// <param name="column1">The second column vector of the Matrix4x4.</param>
        /// <param name="column2">The third column vector of the Matrix4x4.</param>
        /// <param name="column3">The fourth column vector of the Matrix4x4.</param>
        public static void Deconstruct(this Matrix4x4 matrix,
                               out Vector4 column0, out Vector4 column1,
                               out Vector4 column2, out Vector4 column3)
        {
            column0 = matrix.GetColumn(0); column1 = matrix.GetColumn(1);
            column2 = matrix.GetColumn(2); column3 = matrix.GetColumn(3);
        }

        /// <summary>
        /// Deconstructs a Matrix4x4 instance into its individual elements.
        /// </summary>
        /// <param name="matrix">The Matrix4x4 instance.</param>
        /// <param name="m00">The element at the first row and first column of the Matrix4x4.</param>
        /// <param name="m01">The element at the first row and second column of the Matrix4x4.</param>
        /// <param name="m02">The element at the first row and third column of the Matrix4x4.</param>
        /// <param name="m03">The element at the first row and fourth column of the Matrix4x4.</param>
        /// <param name="m10">The element at the second row and first column of the Matrix4x4.</param>
        /// <param name="m11">The element at the second row and second column of the Matrix4x4.</param>
        /// <param name="m12">The element at the second row and third column of the Matrix4x4.</param>
        /// <param name="m13">The element at the second row and fourth column of the Matrix4x4.</param>
        /// <param name="m20">The element at the third row and first column of the Matrix4x4.</param>
        /// <param name="m21">The element at the third row and second column of the Matrix4x4.</param>
        /// <param name="m22">The element at the third row and third column of the Matrix4x4.</param>
        /// <param name="m23">The element at the third row and fourth column of the Matrix4x4.</param>
        /// <param name="m30">The element at the fourth row and first column of the Matrix4x4.</param>
        /// <param name="m31">The element at the fourth row and second column of the Matrix4x4.</param>
        /// <param name="m32">The element at the fourth row and third column of the Matrix4x4.</param>
        /// <param name="m33">The element at the fourth row and fourth column of the Matrix4x4.</param>
        public static void Deconstruct(in this Matrix4x4 matrix,
                                       out float m00, out float m01, out float m02, out float m03,
                                       out float m10, out float m11, out float m12, out float m13,
                                       out float m20, out float m21, out float m22, out float m23,
                                       out float m30, out float m31, out float m32, out float m33)
        {
            m00 = matrix.m00; m01 = matrix.m01; m02 = matrix.m02; m03 = matrix.m03;
            m10 = matrix.m10; m11 = matrix.m11; m12 = matrix.m12; m13 = matrix.m13;
            m20 = matrix.m20; m21 = matrix.m21; m22 = matrix.m22; m23 = matrix.m23;
            m30 = matrix.m30; m31 = matrix.m31; m32 = matrix.m32; m33 = matrix.m33;
        }
        #endregion

        #region With

        /// <summary>
        /// Creates a new Matrix4x4 instance with the specified column vectors, or the original column vectors if not specified.
        /// </summary>
        /// <param name="matrix">The original Matrix4x4 instance.</param>
        /// <param name="column0">The first column vector of the new Matrix4x4. If null, the first column vector of the original Matrix4x4 is used.</param>
        /// <param name="column1">The second column vector of the new Matrix4x4. If null, the second column vector of the original Matrix4x4 is used.</param>
        /// <param name="column2">The third column vector of the new Matrix4x4. If null, the third column vector of the original Matrix4x4 is used.</param>
        /// <param name="column3">The fourth column vector of the new Matrix4x4. If null, the fourth column vector of the original Matrix4x4 is used.</param>
        /// <returns>A new Matrix4x4 instance with the specified column vectors.</returns>
        public static Matrix4x4 With(this Matrix4x4 matrix,
                             in Vector4? column0 = null, in Vector4? column1 = null,
                             in Vector4? column2 = null, in Vector4? column3 = null)
        {
            var result = new Matrix4x4(
                column0 ?? matrix.GetColumn(0), column1 ?? matrix.GetColumn(1),
                column2 ?? matrix.GetColumn(2), column3 ?? matrix.GetColumn(3)
            );
            return result;
        }

        /// <summary>
        /// Creates a new Matrix4x4 instance with the specified elements, or the original elements if not specified.
        /// </summary>
        /// <param name="matrix">The original Matrix4x4 instance.</param>
        /// <param name="m00">The element at the first row and first column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m01">The element at the first row and second column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m02">The element at the first row and third column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m03">The element at the first row and fourth column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m10">The element at the second row and first column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m11">The element at the second row and second column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m12">The element at the second row and third column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m13">The element at the second row and fourth column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m20">The element at the third row and first column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m21">The element at the third row and second column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m22">The element at the third row and third column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m23">The element at the third row and fourth column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m30">The element at the fourth row and first column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m31">The element at the fourth row and second column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m32">The element at the fourth row and third column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <param name="m33">The element at the fourth row and fourth column of the new Matrix4x4. If null, the corresponding element of the original Matrix4x4 is used.</param>
        /// <returns>A new Matrix4x4 instance with the specified elements.</returns>
        public static Matrix4x4 With(in this Matrix4x4 matrix,
                                     float? m00 = null, float? m01 = null, float? m02 = null, float? m03 = null,
                                     float? m10 = null, float? m11 = null, float? m12 = null, float? m13 = null,
                                     float? m20 = null, float? m21 = null, float? m22 = null, float? m23 = null,
                                     float? m30 = null, float? m31 = null, float? m32 = null, float? m33 = null)
        {
            var result = new Matrix4x4
            {
                m00 = m00 ?? matrix.m00,
                m01 = m01 ?? matrix.m01,
                m02 = m02 ?? matrix.m02,
                m03 = m03 ?? matrix.m03,
                m10 = m10 ?? matrix.m10,
                m11 = m11 ?? matrix.m11,
                m12 = m12 ?? matrix.m12,
                m13 = m13 ?? matrix.m13,
                m20 = m20 ?? matrix.m20,
                m21 = m21 ?? matrix.m21,
                m22 = m22 ?? matrix.m22,
                m23 = m23 ?? matrix.m23,
                m30 = m30 ?? matrix.m30,
                m31 = m31 ?? matrix.m31,
                m32 = m32 ?? matrix.m32,
                m33 = m33 ?? matrix.m33
            };
            return result;
        }
        #endregion
    }
}