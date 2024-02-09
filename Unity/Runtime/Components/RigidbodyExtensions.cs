using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class RigidbodyExtensions
    {
        #region Clear
        /// <summary>
        /// Clears the momentum of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        public static void ClearMomentum(this Rigidbody rigidbody)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
        #endregion
        
        #region Position
        #region Set
        /// <summary>
        /// Sets the x position of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="x">The x position.</param>
        public static void SetPositionX(this Rigidbody rigidbody, float x)
        {
            var position = rigidbody.position;
            position.x = x;
            rigidbody.position = position;
        }
        
        /// <summary>
        /// Sets the y position of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="y">The y position.</param>
        public static void SetPositionY(this Rigidbody rigidbody, float y)
        {
            var position = rigidbody.position;
            position.y = y;
            rigidbody.position = position;
        }
        
        /// <summary>
        /// Sets the z position of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="z">The z position.</param>
        public static void SetPositionZ(this Rigidbody rigidbody, float z)
        {
            var position = rigidbody.position;
            position.z = z;
            rigidbody.position = position;
        }
        #endregion
        
        #region Get
        /// <summary>
        /// Gets the x position of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <returns>The x position.</returns>
        public static float GetPositionX(this Rigidbody rigidbody)
        {
            return rigidbody.position.x;
        }
        
        /// <summary>
        /// Gets the y position of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <returns>The y position.</returns>
        public static float GetPositionY(this Rigidbody rigidbody)
        {
            return rigidbody.position.y;
        }
        
        /// <summary>
        /// Gets the z position of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <returns>The z position.</returns>
        public static float GetPositionZ(this Rigidbody rigidbody)
        {
            return rigidbody.position.z;
        }
        #endregion
        #endregion
        
        #region Rotation
        #region Get
        /// <summary>
        /// Gets the x rotation of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <returns>The x rotation.</returns>
        public static float GetRotationX(this Rigidbody rigidbody)
        {
            return rigidbody.rotation.x;
        }
        
        /// <summary>
        /// Gets the y rotation of the Transform instance.
        /// </summary>
        /// <param name="rigidbody">The Transform instance.</param>
        /// <returns>The y rotation.</returns>
        public static float GetRotationY(this Transform rigidbody)
        {
            return rigidbody.rotation.y;
        }
        
        /// <summary>
        /// Gets the z rotation of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <returns>The z rotation.</returns>
        public static float GetRotationZ(this Rigidbody rigidbody)
        {
            return rigidbody.rotation.z;
        }
        
        /// <summary>
        /// Gets the w rotation of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <returns>The w rotation.</returns>
        public static float GetRotationW(this Rigidbody rigidbody)
        {
            return rigidbody.rotation.w;
        }
        #endregion
        
        #region Set
        /// <summary>
        /// Sets the x rotation of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="x">The x rotation.</param>
        public static void SetRotationX(this Rigidbody rigidbody, float x)
        {
            var rotation = rigidbody.rotation;
            rotation.x = x;
            rigidbody.rotation = rotation;
        }
        
        /// <summary>
        /// Sets the y rotation of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="y">The y rotation.</param>
        public static void SetRotationY(this Rigidbody rigidbody, float y)
        {
            var rotation = rigidbody.rotation;
            rotation.y = y;
            rigidbody.rotation = rotation;
        }
        
        /// <summary>
        /// Sets the z rotation of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="z">The z rotation.</param>
        public static void SetRotationZ(this Rigidbody rigidbody, float z)
        {
            var rotation = rigidbody.rotation;
            rotation.z = z;
            rigidbody.rotation = rotation;
        }
        
        /// <summary>
        /// Sets the w rotation of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="w">The w rotation.</param>
        public static void SetRotationW(this Rigidbody rigidbody, float w)
        {
            var rotation = rigidbody.rotation;
            rotation.w = w;
            rigidbody.rotation = rotation;
        }
        #endregion
        #endregion
        
        #region EulerAngles
        #region Set
        /// <summary>
        /// Sets the x component of the Euler angles of the Rigidbody instance.
        /// </summary>
        /// <param name="transform">The Rigidbody instance.</param>
        /// <param name="x">The x component of the Euler angles.</param>
        public static void SetEulerAnglesX(this Rigidbody transform, float x)
        {
            var eulerAngles = transform.rotation.eulerAngles;
            eulerAngles.x = x;
            transform.rotation = Quaternion.Euler(eulerAngles);
        }
        
        /// <summary>
        /// Sets the y component of the Euler angles of the Rigidbody instance.
        /// </summary>
        /// <param name="transform">The Rigidbody instance.</param>
        /// <param name="y">The y component of the Euler angles.</param>
        public static void SetEulerAnglesY(this Rigidbody transform, float y)
        {
            var eulerAngles = transform.rotation.eulerAngles;
            eulerAngles.y = y;
            transform.rotation = Quaternion.Euler(eulerAngles);
        }
        
        /// <summary>
        /// Sets the z component of the Euler angles of the Rigidbody instance.
        /// </summary>
        /// <param name="transform">The Rigidbody instance.</param>
        /// <param name="z">The z component of the Euler angles.</param>
        public static void SetEulerAnglesZ(this Rigidbody transform, float z)
        {
            var eulerAngles = transform.rotation.eulerAngles;
            eulerAngles.z = z;
            transform.rotation = Quaternion.Euler(eulerAngles);
        }
        #endregion
        
        #region Get
        /// <summary>
        /// Gets the x component of the Euler angles of the Rigidbody instance.
        /// </summary>
        /// <param name="transform">The Rigidbody instance.</param>
        /// <returns>The x component of the Euler angles.</returns>
        public static float GetEulerAnglesX(this Rigidbody transform)
        {
            return transform.rotation.eulerAngles.x;
        }
        
        /// <summary>
        /// Gets the y component of the Euler angles of the Rigidbody instance.
        /// </summary>
        /// <param name="transform">The Rigidbody instance.</param>
        /// <returns>The y component of the Euler angles.</returns>
        public static float GetEulerAnglesY(this Rigidbody transform)
        {
            return transform.rotation.eulerAngles.y;
        }
        
        /// <summary>
        /// Gets the z component of the Euler angles of the Rigidbody instance.
        /// </summary>
        /// <param name="transform">The Rigidbody instance.</param>
        /// <returns>The z component of the Euler angles.</returns>
        public static float GetEulerAnglesZ(this Rigidbody transform)
        {
            return transform.rotation.eulerAngles.z;
        }
        #endregion
        #endregion
        
        #region Velocity
        #region Set
        /// <summary>
        /// Sets the x component of the velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="x">The x component of the velocity.</param>
        public static void SetVelocityX(this Rigidbody rigidbody, float x)
        {
            var velocity = rigidbody.velocity;
            velocity.x = x;
            rigidbody.velocity = velocity;
        }
        
        /// <summary>
        /// Sets the y component of the velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="y">The y component of the velocity.</param>
        public static void SetVelocityY(this Rigidbody rigidbody, float y)
        {
            var velocity = rigidbody.velocity;
            velocity.y = y;
            rigidbody.velocity = velocity;
        }
        
        /// <summary>
        /// Sets the z component of the velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="z">The z component of the velocity.</param>
        public static void SetVelocityZ(this Rigidbody rigidbody, float z)
        {
            var velocity = rigidbody.velocity;
            velocity.z = z;
            rigidbody.velocity = velocity;
        }
        #endregion
        
        #region Get
        /// <summary>
        /// Gets the x component of the velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <returns>The x component of the velocity.</returns>
        public static float GetVelocityX(this Rigidbody rigidbody)
        {
            return rigidbody.velocity.x;
        }
        
        /// <summary>
        /// Gets the y component of the velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <returns>The y component of the velocity.</returns>
        public static float GetVelocityY(this Rigidbody rigidbody)
        {
            return rigidbody.velocity.y;
        }
        
        /// <summary>
        /// Gets the z component of the velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <returns>The z component of the velocity.</returns>
        public static float GetVelocityZ(this Rigidbody rigidbody)
        {
            return rigidbody.velocity.z;
        }
        #endregion
        
        #region Add
        /// <summary>
        /// Adds to the x component of the velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="x">The x component to add to the velocity.</param>
        public static void AddVelocityX(this Rigidbody rigidbody, float x)
        {
            var velocity = rigidbody.velocity;
            velocity.x += x;
            rigidbody.velocity = velocity;
        }
        
        /// <summary>
        /// Adds to the y component of the velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="y">The y component to add to the velocity.</param>
        public static void AddVelocityY(this Rigidbody rigidbody, float y)
        {
            var velocity = rigidbody.velocity;
            velocity.y += y;
            rigidbody.velocity = velocity;
        }
        
        /// <summary>
        /// Adds to the z component of the velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="z">The z component to add to the velocity.</param>
        public static void AddVelocityZ(this Rigidbody rigidbody, float z)
        {
            var velocity = rigidbody.velocity;
            velocity.z += z;
            rigidbody.velocity = velocity;
        }
        #endregion
        #endregion
        
        #region AngularVelocity
        #region Set
        /// <summary>
        /// Sets the x component of the angular velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="x">The x component of the angular velocity.</param>
        public static void SetAngularVelocityX(this Rigidbody rigidbody, float x)
        {
            var angularVelocity = rigidbody.angularVelocity;
            angularVelocity.x = x;
            rigidbody.angularVelocity = angularVelocity;
        }
        
        /// <summary>
        /// Sets the y component of the angular velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="y">The y component of the angular velocity.</param>
        public static void SetAngularVelocityY(this Rigidbody rigidbody, float y)
        {
            var angularVelocity = rigidbody.angularVelocity;
            angularVelocity.y = y;
            rigidbody.angularVelocity = angularVelocity;
        }
        
        /// <summary>
        /// Sets the z component of the angular velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="z">The z component of the angular velocity.</param>
        public static void SetAngularVelocityZ(this Rigidbody rigidbody, float z)
        {
            var angularVelocity = rigidbody.angularVelocity;
            angularVelocity.z = z;
            rigidbody.angularVelocity = angularVelocity;
        }
        #endregion
        
        #region Get
        /// <summary>
        /// Gets the x component of the angular velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <returns>The x component of the angular velocity.</returns>
        public static float GetAngularVelocityX(this Rigidbody rigidbody)
        {
            return rigidbody.angularVelocity.x;
        }
        
        /// <summary>
        /// Gets the y component of the angular velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <returns>The y component of the angular velocity.</returns>
        public static float GetAngularVelocityY(this Rigidbody rigidbody)
        {
            return rigidbody.angularVelocity.y;
        }
        
        /// <summary>
        /// Gets the z component of the angular velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <returns>The z component of the angular velocity.</returns>
        public static float GetAngularVelocityZ(this Rigidbody rigidbody)
        {
            return rigidbody.angularVelocity.z;
        }
        #endregion
        
        #region Add
        /// <summary>
        /// Adds to the x component of the angular velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="x">The x component to add to the angular velocity.</param>
        public static void AddAngularVelocityX(this Rigidbody rigidbody, float x)
        {
            var angularVelocity = rigidbody.angularVelocity;
            angularVelocity.x += x;
            rigidbody.angularVelocity = angularVelocity;
        }
        
        /// <summary>
        /// Adds to the y component of the angular velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="y">The y component to add to the angular velocity.</param>
        public static void AddAngularVelocityY(this Rigidbody rigidbody, float y)
        {
            var angularVelocity = rigidbody.angularVelocity;
            angularVelocity.y += y;
            rigidbody.angularVelocity = angularVelocity;
        }
        
        /// <summary>
        /// Adds to the z component of the angular velocity of the Rigidbody instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody instance.</param>
        /// <param name="z">The z component to add to the angular velocity.</param>
        public static void AddAngularVelocityZ(this Rigidbody rigidbody, float z)
        {
            var angularVelocity = rigidbody.angularVelocity;
            angularVelocity.z += z;
            rigidbody.angularVelocity = angularVelocity;
        }
        #endregion
        #endregion
    }
}