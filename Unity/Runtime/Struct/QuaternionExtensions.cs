using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class QuaternionExtensions
    {
        #region Deconstruct
        /// <summary>
        /// Deconstructs a Quaternion instance into its individual components.
        /// </summary>
        /// <param name="quaternion">The Quaternion instance.</param>
        /// <param name="x">The x component of the Quaternion.</param>
        /// <param name="y">The y component of the Quaternion.</param>
        /// <param name="z">The z component of the Quaternion.</param>
        /// <param name="w">The w component of the Quaternion.</param>
        public static void Deconstruct(in this Quaternion quaternion, out float x, out float y, out float z, out float w)
        {
            x = quaternion.x;
            y = quaternion.y;
            z = quaternion.z;
            w = quaternion.w;
        }
        #endregion

        #region With
        /// <summary>
        /// Creates a new Quaternion instance with the specified components, or the original components if not specified.
        /// </summary>
        /// <param name="quaternion">The original Quaternion instance.</param>
        /// <param name="x">The x component of the new Quaternion. If null, the x component of the original Quaternion is used.</param>
        /// <param name="y">The y component of the new Quaternion. If null, the y component of the original Quaternion is used.</param>
        /// <param name="z">The z component of the new Quaternion. If null, the z component of the original Quaternion is used.</param>
        /// <param name="w">The w component of the new Quaternion. If null, the w component of the original Quaternion is used.</param>
        /// <returns>A new Quaternion instance with the specified components.</returns>
        public static Quaternion With(in this Quaternion quaternion, float? x = null, float? y = null, float? z = null, float? w = null)
        {
            var result = new Quaternion(x ?? quaternion.x, y ?? quaternion.y, z ?? quaternion.z, w ?? quaternion.w);
            return result;
        }

        /// <summary>
        /// Creates a new Quaternion instance with the specified Euler angles, or the original Euler angles if not specified.
        /// </summary>
        /// <param name="quaternion">The original Quaternion instance.</param>
        /// <param name="x">The x component of the new Quaternion's Euler angles. If null, the x component of the original Quaternion's Euler angles is used.</param>
        /// <param name="y">The y component of the new Quaternion's Euler angles. If null, the y component of the original Quaternion's Euler angles is used.</param>
        /// <param name="z">The z component of the new Quaternion's Euler angles. If null, the z component of the original Quaternion's Euler angles is used.</param>
        /// <returns>A new Quaternion instance with the specified Euler angles.</returns>
        public static Quaternion WithEuler(this Quaternion quaternion, float? x = null, float? y = null, float? z = null)
        {
            var e = quaternion.eulerAngles;
            var result = Quaternion.Euler(x ?? e.x, y ?? e.y, z ?? e.z);
            return result;
        }

        /// <summary>
        /// Creates a new Quaternion instance with the specified angle and axis, or the original angle and axis if not specified.
        /// </summary>
        /// <param name="quaternion">The original Quaternion instance.</param>
        /// <param name="angle">The angle of the new Quaternion. If null, the angle of the original Quaternion is used.</param>
        /// <param name="axis">The axis of the new Quaternion. If null, the axis of the original Quaternion is used.</param>
        /// <returns>A new Quaternion instance with the specified angle and axis.</returns>
        public static Quaternion WithAngleAxis(this Quaternion quaternion, float? angle = null, in Vector3? axis = null)
        {
            quaternion.ToAngleAxis(out var selfAngle, out var selfAxis);
            var result = Quaternion.AngleAxis(angle ?? selfAngle, axis ?? selfAxis);
            return result;
        }
        #endregion

        #region Math
        /// <summary>
        /// Raises a Quaternion to a specified power.
        /// </summary>
        /// <param name="quaternion">The Quaternion instance.</param>
        /// <param name="power">The power to raise the Quaternion to.</param>
        /// <returns>The Quaternion raised to the specified power.</returns>
        public static Quaternion Pow(this Quaternion quaternion, float power)
        {
            var inputMagnitude = quaternion.Magnitude();
            var nHat = new Vector3(quaternion.x, quaternion.y, quaternion.z).normalized;
            var vectorBit = new Quaternion(nHat.x, nHat.y, nHat.z, 0).ScalarMultiply(power * Mathf.Acos(quaternion.w / inputMagnitude)).Exp();
            var result = vectorBit.ScalarMultiply(Mathf.Pow(inputMagnitude, power));
            return result;
        }

        /// <summary>
        /// Calculates the exponential of a Quaternion.
        /// </summary>
        /// <param name="quaternion">The Quaternion instance.</param>
        /// <returns>The exponential of the Quaternion.</returns>
        public static Quaternion Exp(this Quaternion quaternion)
        {
            var inputA = quaternion.w;
            var inputV = new Vector3(quaternion.x, quaternion.y, quaternion.z);
            var outputA = Mathf.Exp(inputA) * Mathf.Cos(inputV.magnitude);
            var outputV = Mathf.Exp(inputA) * (inputV.normalized * Mathf.Sin(inputV.magnitude));
            var result = new Quaternion(outputV.x, outputV.y, outputV.z, outputA);
            return result;
        }

        /// <summary>
        /// Calculates the magnitude of a Quaternion.
        /// </summary>
        /// <param name="quaternion">The Quaternion instance.</param>
        /// <returns>The magnitude of the Quaternion.</returns>
        public static float Magnitude(this Quaternion quaternion)
        {
            var result = Mathf.Sqrt(quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w);
            return result;
        }

        /// <summary>
        /// Multiplies a Quaternion by a scalar.
        /// </summary>
        /// <param name="quaternion">The Quaternion instance.</param>
        /// <param name="scalar">The scalar to multiply the Quaternion by.</param>
        /// <returns>The Quaternion multiplied by the scalar.</returns>
        public static Quaternion ScalarMultiply(this Quaternion quaternion, float scalar)
        {
            var result = new Quaternion(quaternion.x * scalar, quaternion.y * scalar, quaternion.z * scalar, quaternion.w * scalar);
            return result;
        }
        #endregion
    }
}