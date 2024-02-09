using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UtilityLibrary.Unity.Runtime
{
    public static class TransformExtensions
    {
        #region Position
        #region Get
        /// <summary>
        /// Gets the x position of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the position from.</param>
        /// <returns>The x position of the transform.</returns>
        public static float GetPositionX(this Transform transform)
        {
            return transform.position.x;
        }

        /// <summary>
        /// Gets the y position of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the position from.</param>
        /// <returns>The y position of the transform.</returns>
        public static float GetPositionY(this Transform transform)
        {
            return transform.position.y;
        }

        /// <summary>
        /// Gets the z position of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the position from.</param>
        /// <returns>The z position of the transform.</returns>
        public static float GetPositionZ(this Transform transform)
        {
            return transform.position.z;
        }

        /// <summary>
        /// Gets the x and y positions of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the position from.</param>
        /// <returns>A Vector2 containing the x and y positions of the transform.</returns>
        public static Vector2 GetPositionXY(this Transform transform)
        {
            var position = transform.position;
            return new Vector2(position.x, position.y);
        }

        /// <summary>
        /// Gets the x and z positions of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the position from.</param>
        /// <returns>A Vector2 containing the x and z positions of the transform.</returns>
        public static Vector2 GetPositionXZ(this Transform transform)
        {
            var position = transform.position;
            return new Vector2(position.x, position.z);
        }

        /// <summary>
        /// Gets the y and z positions of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the position from.</param>
        /// <returns>A Vector2 containing the y and z positions of the transform.</returns>
        public static Vector2 GetPositionYZ(this Transform transform)
        {
            var position = transform.position;
            return new Vector2(position.y, position.z);
        }
        #endregion
        
        #region Set
        /// <summary>
        /// Sets the x position of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x position.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetPositionX(this Transform transform, float x)
        {
            var position = transform.position;
            position.x = x;
            transform.position = position;
            return transform;
        }

        /// <summary>
        /// Sets the y position of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="y">The new y position.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetPositionY(this Transform transform, float y)
        {
            var position = transform.position;
            position.y = y;
            transform.position = position;
            return transform;
        }

        /// <summary>
        /// Sets the z position of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="z">The new z position.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetPositionZ(this Transform transform, float z)
        {
            var position = transform.position;
            position.z = z;
            transform.position = position;
            return transform;
        }

        /// <summary>
        /// Sets the x and y positions of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x position.</param>
        /// <param name="y">The new y position.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetPositionXY(this Transform transform, float x, float y)
        {
            var position = transform.position;
            position.x = x;
            position.y = y;
            transform.position = position;
            return transform;
        }

        /// <summary>
        /// Sets the x and z positions of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x position.</param>
        /// <param name="z">The new z position.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetPositionXZ(this Transform transform, float x, float z)
        {
            var position = transform.position;
            position.x = x;
            position.z = z;
            transform.position = position;
            return transform;
        }

        /// <summary>
        /// Sets the y and z positions of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="y">The new y position.</param>
        /// <param name="z">The new z position.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetPositionYZ(this Transform transform, float y, float z)
        {
            var position = transform.position;
            position.y = y;
            position.z = z;
            transform.position = position;
            return transform;
        }
        #endregion
        #endregion

        #region Rotation
        #region Set
        /// <summary>
        /// Sets the x component of the rotation quaternion of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the rotation quaternion.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetRotationX(this Transform transform, float x)
        {
            var rotation = transform.rotation;
            rotation.x = x;
            transform.rotation = rotation;
            return transform;
        }

        /// <summary>
        /// Sets the y component of the rotation quaternion of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="y">The new y component of the rotation quaternion.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetRotationY(this Transform transform, float y)
        {
            var rotation = transform.rotation;
            rotation.y = y;
            transform.rotation = rotation;
            return transform;
        }

        /// <summary>
        /// Sets the z component of the rotation quaternion of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="z">The new z component of the rotation quaternion.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetRotationZ(this Transform transform, float z)
        {
            var rotation = transform.rotation;
            rotation.z = z;
            transform.rotation = rotation;
            return transform;
        }

        /// <summary>
        /// Sets the w component of the rotation quaternion of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="w">The new w component of the rotation quaternion.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetRotationW(this Transform transform, float w)
        {
            var rotation = transform.rotation;
            rotation.w = w;
            transform.rotation = rotation;
            return transform;
        }
        #endregion
        
        #region Get
        /// <summary>
        /// Gets the x component of the rotation quaternion of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the rotation from.</param>
        /// <returns>The x component of the rotation quaternion.</returns>
        public static float GetRotationX(this Transform transform)
        {
            return transform.rotation.x;
        }

        /// <summary>
        /// Gets the y component of the rotation quaternion of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the rotation from.</param>
        /// <returns>The y component of the rotation quaternion.</returns>
        public static float GetRotationY(this Transform transform)
        {
            return transform.rotation.y;
        }

        /// <summary>
        /// Gets the z component of the rotation quaternion of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the rotation from.</param>
        /// <returns>The z component of the rotation quaternion.</returns>
        public static float GetRotationZ(this Transform transform)
        {
            return transform.rotation.z;
        }

        /// <summary>
        /// Gets the w component of the rotation quaternion of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the rotation from.</param>
        /// <returns>The w component of the rotation quaternion.</returns>
        public static float GetRotationW(this Transform transform)
        {
            return transform.rotation.w;
        }
        #endregion
        #endregion

        #region EulerAngles
        #region Get
        /// <summary>
        /// Gets the x component of the Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the Euler angles from.</param>
        /// <returns>The x component of the Euler angles.</returns>
        public static float GetEulerAnglesX(this Transform transform)
        {
            return transform.eulerAngles.x;
        }

        /// <summary>
        /// Gets the y component of the Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the Euler angles from.</param>
        /// <returns>The y component of the Euler angles.</returns>
        public static float GetEulerAnglesY(this Transform transform)
        {
            return transform.eulerAngles.y;
        }

        /// <summary>
        /// Gets the z component of the Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the Euler angles from.</param>
        /// <returns>The z component of the Euler angles.</returns>
        public static float GetEulerAnglesZ(this Transform transform)
        {
            return transform.eulerAngles.z;
        }

        /// <summary>
        /// Gets the x and y components of the Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the Euler angles from.</param>
        /// <returns>A Vector2 containing the x and y components of the Euler angles.</returns>
        public static Vector2 GetEulerAnglesXY(this Transform transform)
        {
            var eulerAngles = transform.eulerAngles;
            return new Vector2(eulerAngles.x, eulerAngles.y);
        }

        /// <summary>
        /// Gets the x and z components of the Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the Euler angles from.</param>
        /// <returns>A Vector2 containing the x and z components of the Euler angles.</returns>
        public static Vector2 GetEulerAnglesXZ(this Transform transform)
        {
            var eulerAngles = transform.eulerAngles;
            return new Vector2(eulerAngles.x, eulerAngles.z);
        }

        /// <summary>
        /// Gets the y and z components of the Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the Euler angles from.</param>
        /// <returns>A Vector2 containing the y and z components of the Euler angles.</returns>
        public static Vector2 GetEulerAnglesYZ(this Transform transform)
        {
            var eulerAngles = transform.eulerAngles;
            return new Vector2(eulerAngles.y, eulerAngles.z);
        }
        #endregion
        
        #region Set
        /// <summary>
        /// Sets the x component of the Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the Euler angles.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetEulerAnglesX(this Transform transform, float x)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.x = x;
            transform.eulerAngles = eulerAngles;
            return transform;
        }

        /// <summary>
        /// Sets the y component of the Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="y">The new y component of the Euler angles.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetEulerAnglesY(this Transform transform, float y)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.y = y;
            transform.eulerAngles = eulerAngles;
            return transform;
        }

        /// <summary>
        /// Sets the z component of the Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="z">The new z component of the Euler angles.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetEulerAnglesZ(this Transform transform, float z)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.z = z;
            transform.eulerAngles = eulerAngles;
            return transform;
        }

        /// <summary>
        /// Sets the x and y components of the Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the Euler angles.</param>
        /// <param name="y">The new y component of the Euler angles.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetEulerAnglesXY(this Transform transform, float x, float y)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.x = x;
            eulerAngles.y = y;
            transform.eulerAngles = eulerAngles;
            return transform;
        }

        /// <summary>
        /// Sets the x and z components of the Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the Euler angles.</param>
        /// <param name="z">The new z component of the Euler angles.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetEulerAnglesXZ(this Transform transform, float x, float z)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.x = x;
            eulerAngles.z = z;
            transform.eulerAngles = eulerAngles;
            return transform;
        }

        /// <summary>
        /// Sets the y and z components of the Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="y">The new y component of the Euler angles.</param>
        /// <param name="z">The new z component of the Euler angles.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetEulerAnglesYZ(this Transform transform, float y, float z)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.y = y;
            eulerAngles.z = z;
            transform.eulerAngles = eulerAngles;
            return transform;
        }
        #endregion
        #endregion

        #region LocalPosition
        #region Get
        /// <summary>
        /// Gets the x component of the local position of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local position from.</param>
        /// <returns>The x component of the local position.</returns>
        public static float GetLocalPositionX(this Transform transform)
        {
            return transform.localPosition.x;
        }

        /// <summary>
        /// Gets the y component of the local position of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local position from.</param>
        /// <returns>The y component of the local position.</returns>
        public static float GetLocalPositionY(this Transform transform)
        {
            return transform.localPosition.y;
        }

        /// <summary>
        /// Gets the z component of the local position of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local position from.</param>
        /// <returns>The z component of the local position.</returns>
        public static float GetLocalPositionZ(this Transform transform)
        {
            return transform.localPosition.z;
        }

        /// <summary>
        /// Gets the x and y components of the local position of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local position from.</param>
        /// <returns>A Vector2 containing the x and y components of the local position.</returns>
        public static Vector2 GetLocalPositionXY(this Transform transform)
        {
            var localPosition = transform.localPosition;
            return new Vector2(localPosition.x, localPosition.y);
        }

        /// <summary>
        /// Gets the x and z components of the local position of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local position from.</param>
        /// <returns>A Vector2 containing the x and z components of the local position.</returns>
        public static Vector2 GetLocalPositionXZ(this Transform transform)
        {
            var localPosition = transform.localPosition;
            return new Vector2(localPosition.x, localPosition.z);
        }

        /// <summary>
        /// Gets the y and z components of the local position of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local position from.</param>
        /// <returns>A Vector2 containing the y and z components of the local position.</returns>
        public static Vector2 GetLocalPositionYZ(this Transform transform)
        {
            var localPosition = transform.localPosition;
            return new Vector2(localPosition.y, localPosition.z);
        }
        #endregion
        
        #region Set
        /// <summary>
        /// Sets the x component of the local position of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the local position.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalPositionX(this Transform transform, float x)
        {
            var localPosition = transform.localPosition;
            localPosition.x = x;
            transform.localPosition = localPosition;
            return transform;
        }

        /// <summary>
        /// Sets the y component of the local position of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="y">The new y component of the local position.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalPositionY(this Transform transform, float y)
        {
            var localPosition = transform.localPosition;
            localPosition.y = y;
            transform.localPosition = localPosition;
            return transform;
        }

        /// <summary>
        /// Sets the z component of the local position of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="z">The new z component of the local position.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalPositionZ(this Transform transform, float z)
        {
            var localPosition = transform.localPosition;
            localPosition.z = z;
            transform.localPosition = localPosition;
            return transform;
        }

        /// <summary>
        /// Sets the x and y components of the local position of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the local position.</param>
        /// <param name="y">The new y component of the local position.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalPositionXY(this Transform transform, float x, float y)
        {
            var localPosition = transform.localPosition;
            localPosition.x = x;
            localPosition.y = y;
            transform.localPosition = localPosition;
            return transform;
        }

        /// <summary>
        /// Sets the x and z components of the local position of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the local position.</param>
        /// <param name="z">The new z component of the local position.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalPositionXZ(this Transform transform, float x, float z)
        {
            var localPosition = transform.localPosition;
            localPosition.x = x;
            localPosition.z = z;
            transform.localPosition = localPosition;
            return transform;
        }

        /// <summary>
        /// Sets the y and z components of the local position of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="y">The new y component of the local position.</param>
        /// <param name="z">The new z component of the local position.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalPositionYZ(this Transform transform, float y, float z)
        {
            var localPosition = transform.localPosition;
            localPosition.y = y;
            localPosition.z = z;
            transform.localPosition = localPosition;
            return transform;
        }
        #endregion
        #endregion

        #region LocalRotation
        #region Get
        /// <summary>
        /// Gets the x component of the local rotation of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local rotation from.</param>
        /// <returns>The x component of the local rotation.</returns>
        public static float GetLocalRotationX(this Transform transform)
        {
            return transform.localRotation.x;
        }

        /// <summary>
        /// Gets the y component of the local rotation of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local rotation from.</param>
        /// <returns>The y component of the local rotation.</returns>
        public static float GetLocalRotationY(this Transform transform)
        {
            return transform.localRotation.y;
        }

        /// <summary>
        /// Gets the z component of the local rotation of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local rotation from.</param>
        /// <returns>The z component of the local rotation.</returns>
        public static float GetLocalRotationZ(this Transform transform)
        {
            return transform.localRotation.z;
        }

        /// <summary>
        /// Gets the w component of the local rotation of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local rotation from.</param>
        /// <returns>The w component of the local rotation.</returns>
        public static float GetLocalRotationW(this Transform transform)
        {
            return transform.localRotation.w;
        }
        #endregion
        
        #region Set
        /// <summary>
        /// Sets the x component of the local rotation of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the local rotation.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalRotationX(this Transform transform, float x)
        {
            var localRotation = transform.localRotation;
            localRotation.x = x;
            transform.localRotation = localRotation;
            return transform;
        }

        /// <summary>
        /// Sets the y component of the local rotation of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="y">The new y component of the local rotation.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalRotationY(this Transform transform, float y)
        {
            var localRotation = transform.localRotation;
            localRotation.y = y;
            transform.localRotation = localRotation;
            return transform;
        }

        /// <summary>
        /// Sets the z component of the local rotation of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="z">The new z component of the local rotation.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalRotationZ(this Transform transform, float z)
        {
            var localRotation = transform.localRotation;
            localRotation.z = z;
            transform.localRotation = localRotation;
            return transform;
        }

        /// <summary>
        /// Sets the w component of the local rotation of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="w">The new w component of the local rotation.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalRotationW(this Transform transform, float w)
        {
            var localRotation = transform.localRotation;
            localRotation.w = w;
            transform.localRotation = localRotation;
            return transform;
        }
        #endregion
        #endregion

        #region LocalEulerAngles
        #region Get
        /// <summary>
        /// Gets the x component of the local Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local Euler angles from.</param>
        /// <returns>The x component of the local Euler angles.</returns>
        public static float GetLocalEulerAnglesX(this Transform transform)
        {
            return transform.localEulerAngles.x;
        }

        /// <summary>
        /// Gets the y component of the local Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local Euler angles from.</param>
        /// <returns>The y component of the local Euler angles.</returns>
        public static float GetLocalEulerAnglesY(this Transform transform)
        {
            return transform.localEulerAngles.y;
        }

        /// <summary>
        /// Gets the z component of the local Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local Euler angles from.</param>
        /// <returns>The z component of the local Euler angles.</returns>
        public static float GetLocalEulerAnglesZ(this Transform transform)
        {
            return transform.localEulerAngles.z;
        }

        /// <summary>
        /// Gets the x and y components of the local Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local Euler angles from.</param>
        /// <returns>A Vector2 containing the x and y components of the local Euler angles.</returns>
        public static Vector2 GetLocalEulerAnglesXY(this Transform transform)
        {
            var localEulerAngles = transform.localEulerAngles;
            return new Vector2(localEulerAngles.x, localEulerAngles.y);
        }

        /// <summary>
        /// Gets the x and z components of the local Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local Euler angles from.</param>
        /// <returns>A Vector2 containing the x and z components of the local Euler angles.</returns>
        public static Vector2 GetLocalEulerAnglesXZ(this Transform transform)
        {
            var localEulerAngles = transform.localEulerAngles;
            return new Vector2(localEulerAngles.x, localEulerAngles.z);
        }

        /// <summary>
        /// Gets the y and z components of the local Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local Euler angles from.</param>
        /// <returns>A Vector2 containing the y and z components of the local Euler angles.</returns>
        public static Vector2 GetLocalEulerAnglesYZ(this Transform transform)
        {
            var localEulerAngles = transform.localEulerAngles;
            return new Vector2(localEulerAngles.y, localEulerAngles.z);
        }
        #endregion
        
        #region Set
        /// <summary>
        /// Sets the x component of the local Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the local Euler angles.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalEulerAnglesX(this Transform transform, float x)
        {
            var localEulerAngles = transform.localEulerAngles;
            localEulerAngles.x = x;
            transform.localEulerAngles = localEulerAngles;
            return transform;
        }

        /// <summary>
        /// Sets the y component of the local Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="y">The new y component of the local Euler angles.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalEulerAnglesY(this Transform transform, float y)
        {
            var localEulerAngles = transform.localEulerAngles;
            localEulerAngles.y = y;
            transform.localEulerAngles = localEulerAngles;
            return transform;
        }

        /// <summary>
        /// Sets the z component of the local Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="z">The new z component of the local Euler angles.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalEulerAnglesZ(this Transform transform, float z)
        {
            var localEulerAngles = transform.localEulerAngles;
            localEulerAngles.z = z;
            transform.localEulerAngles = localEulerAngles;
            return transform;
        }

        /// <summary>
        /// Sets the x and y components of the local Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the local Euler angles.</param>
        /// <param name="y">The new y component of the local Euler angles.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalEulerAnglesXY(this Transform transform, float x, float y)
        {
            var localEulerAngles = transform.localEulerAngles;
            localEulerAngles.x = x;
            localEulerAngles.y = y;
            transform.localEulerAngles = localEulerAngles;
            return transform;
        }

        /// <summary>
        /// Sets the x and z components of the local Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the local Euler angles.</param>
        /// <param name="z">The new z component of the local Euler angles.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalEulerAnglesXZ(this Transform transform, float x, float z)
        {
            var localEulerAngles = transform.localEulerAngles;
            localEulerAngles.x = x;
            localEulerAngles.z = z;
            transform.localEulerAngles = localEulerAngles;
            return transform;
        }

        /// <summary>
        /// Sets the y and z components of the local Euler angles of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="y">The new y component of the local Euler angles.</param>
        /// <param name="z">The new z component of the local Euler angles.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalEulerAnglesYZ(this Transform transform, float y, float z)
        {
            var localEulerAngles = transform.localEulerAngles;
            localEulerAngles.y = y;
            localEulerAngles.z = z;
            transform.localEulerAngles = localEulerAngles;
            return transform;
        }
        #endregion
        #endregion

        #region LocalScale
        #region Get
        /// <summary>
        /// Gets the x component of the local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local scale from.</param>
        /// <returns>The x component of the local scale.</returns>
        public static float GetLocalScaleX(this Transform transform)
        {
            return transform.localScale.x;
        }

        /// <summary>
        /// Gets the y component of the local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local scale from.</param>
        /// <returns>The y component of the local scale.</returns>
        public static float GetLocalScaleY(this Transform transform)
        {
            return transform.localScale.y;
        }

        /// <summary>
        /// Gets the z component of the local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local scale from.</param>
        /// <returns>The z component of the local scale.</returns>
        public static float GetLocalScaleZ(this Transform transform)
        {
            return transform.localScale.z;
        }

        /// <summary>
        /// Gets the x and y components of the local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local scale from.</param>
        /// <returns>A Vector2 containing the x and y components of the local scale.</returns>
        public static Vector2 GetLocalScaleXY(this Transform transform)
        {
            var localScale = transform.localScale;
            return new Vector2(localScale.x, localScale.y);
        }

        /// <summary>
        /// Gets the x and z components of the local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local scale from.</param>
        /// <returns>A Vector2 containing the x and z components of the local scale.</returns>
        public static Vector2 GetLocalScaleXZ(this Transform transform)
        {
            var localScale = transform.localScale;
            return new Vector2(localScale.x, localScale.z);
        }

        /// <summary>
        /// Gets the y and z components of the local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve the local scale from.</param>
        /// <returns>A Vector2 containing the y and z components of the local scale.</returns>
        public static Vector2 GetLocalScaleYZ(this Transform transform)
        {
            var localScale = transform.localScale;
            return new Vector2(localScale.y, localScale.z);
        }
        #endregion
        
        #region Set
        /// <summary>
        /// Sets the x component of the local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the local scale.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalScaleX(this Transform transform, float x)
        {
            var localScale = transform.localScale;
            localScale.x = x;
            transform.localScale = localScale;
            return transform;
        }

        /// <summary>
        /// Sets the y component of the local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="y">The new y component of the local scale.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalScaleY(this Transform transform, float y)
        {
            var localScale = transform.localScale;
            localScale.y = y;
            transform.localScale = localScale;
            return transform;
        }

        /// <summary>
        /// Sets the z component of the local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="z">The new z component of the local scale.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalScaleZ(this Transform transform, float z)
        {
            var localScale = transform.localScale;
            localScale.z = z;
            transform.localScale = localScale;
            return transform;
        }

        /// <summary>
        /// Sets the x and y components of the local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the local scale.</param>
        /// <param name="y">The new y component of the local scale.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalScaleXY(this Transform transform, float x, float y)
        {
            var localScale = transform.localScale;
            localScale.x = x;
            localScale.y = y;
            transform.localScale = localScale;
            return transform;
        }

        /// <summary>
        /// Sets the x and z components of the local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="x">The new x component of the local scale.</param>
        /// <param name="z">The new z component of the local scale.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalScaleXZ(this Transform transform, float x, float z)
        {
            var localScale = transform.localScale;
            localScale.x = x;
            localScale.z = z;
            transform.localScale = localScale;
            return transform;
        }

        /// <summary>
        /// Sets the y and z components of the local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="y">The new y component of the local scale.</param>
        /// <param name="z">The new z component of the local scale.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalScaleYZ(this Transform transform, float y, float z)
        {
            var localScale = transform.localScale;
            localScale.y = y;
            localScale.z = z;
            transform.localScale = localScale;
            return transform;
        }

        /// <summary>
        /// Sets the local scale of the transform to a uniform value.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="uniformScale">The new scale for all components.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalScale(this Transform transform, float uniformScale)
        {
            transform.localScale = new Vector3(uniformScale, uniformScale, uniformScale);
            return transform;
        }

        /// <summary>
        /// Sets the local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="uniformScale">The new scale for all components.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetLocalScale(this Transform transform, Vector3 uniformScale)
        {
            transform.localScale = uniformScale;
            return transform;
        }
        #endregion

        #region Flip
        /// <summary>
        /// Flips the local scale of the transform along the specified axes.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="flipX">Whether to flip the x component of the local scale.</param>
        /// <param name="flipY">Whether to flip the y component of the local scale.</param>
        /// <param name="flipZ">Whether to flip the z component of the local scale.</param>
        public static void Flip(this Transform transform, bool flipX = true, bool flipY = true, bool flipZ = true)
        {
            var localScale = transform.localScale;
            if (flipX)
            {
                localScale.x = -localScale.x;
            }

            if (flipY)
            {
                localScale.y = -localScale.y;
            }

            if (flipZ)
            {
                localScale.z = -localScale.z;
            }

            transform.localScale = localScale;
        }
        #endregion

        #region ScaleBy
        /// <summary>
        /// Scales the transform by the given scale vector.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="scale">The scale to apply.</param>
        public static void ScaleBy(this Transform transform, Vector3 scale)
        {
            transform.localScale = Vector3.Scale(transform.localScale, scale);
        }
        #endregion
        #endregion

        #region CounteractLocalScale
        /// <summary>
        /// Counteracts the local scale of the transform by setting it to the inverse of the parent's scale.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <returns>The new local scale of the transform.</returns>
        public static Vector3 CounteractLocalScale(this Transform transform)
        {
            transform.localScale = CounteractLocalScaleRecursively(transform, Vector3.one);
            return transform.localScale;
        }

        /// <summary>
        /// Counteracts the local scale of the transform by setting it to the inverse of the parent's scale, scaled by a given vector.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="scaleTo">The scale to apply after counteracting the parent's scale.</param>
        /// <returns>The new local scale of the transform.</returns>
        public static Vector3 CounteractLocalScale(this Transform transform, Vector3 scaleTo)
        {
            transform.localScale = CounteractLocalScaleRecursively(transform, scaleTo);
            return transform.localScale;
        }

        /// <summary>
        /// Recursively counteracts the local scale of the transform and its parents.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="scale">The scale to apply after counteracting the parent's scale.</param>
        /// <returns>The new local scale of the transform.</returns>
        private static Vector3 CounteractLocalScaleRecursively(Transform transform, Vector3 scale)
        {
            while (true)
            {
                if (transform.parent == null) return scale;
                var scaleParent = transform.parent.localScale;
                var result = new Vector3(scale.x / scaleParent.x, scale.y / scaleParent.y, scale.z / scaleParent.z);
                transform = transform.parent;
                scale = result;
            }
        }
        #endregion

        #region Reset
        /// <summary>
        /// Resets the position of the transform to the origin (0, 0, 0).
        /// </summary>
        /// <param name="transform">The transform to reset.</param>
        /// <returns>The reset transform.</returns>
        public static Transform ResetPosition(this Transform transform)
        {
            transform.position = Vector3.zero;
            return transform;
        }

        /// <summary>
        /// Resets the local position of the transform to the origin (0, 0, 0).
        /// </summary>
        /// <param name="transform">The transform to reset.</param>
        /// <returns>The reset transform.</returns>
        public static Transform ResetLocalPosition(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            return transform;
        }

        /// <summary>
        /// Resets the rotation of the transform to the identity rotation (no rotation).
        /// </summary>
        /// <param name="transform">The transform to reset.</param>
        /// <returns>The reset transform.</returns>
        public static Transform ResetRotation(this Transform transform)
        {
            transform.rotation = Quaternion.identity;
            return transform;
        }

        /// <summary>
        /// Resets the local rotation of the transform to the identity rotation (no rotation).
        /// </summary>
        /// <param name="transform">The transform to reset.</param>
        /// <returns>The reset transform.</returns>
        public static Transform ResetLocalRotation(this Transform transform)
        {
            transform.localRotation = Quaternion.identity;
            return transform;
        }

        /// <summary>
        /// Resets the local scale of the transform to one (no scale).
        /// </summary>
        /// <param name="transform">The transform to reset.</param>
        /// <returns>The reset transform.</returns>
        public static Transform ResetLocalScale(this Transform transform)
        {
            transform.localScale = Vector3.one;
            return transform;
        }

        /// <summary>
        /// Resets the position, rotation, and scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to reset.</param>
        /// <returns>The reset transform.</returns>
        public static Transform Reset(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            return transform;
        }

        /// <summary>
        /// Resets the local position, local rotation, and local scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to reset.</param>
        /// <returns>The reset transform.</returns>
        public static Transform ResetLocal(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            return transform;
        }

        /// <summary>
        /// Sets the parent of the transform and resets its local position, local rotation, and local scale.
        /// </summary>
        /// <param name="transform">The transform to modify.</param>
        /// <param name="parent">The new parent of the transform.</param>
        /// <returns>The modified transform.</returns>
        public static Transform SetParentAndResetLocal(this Transform transform, Transform parent)
        {
            transform.SetParent(parent);
            transform.ResetLocal();
            return transform;
        }
        #endregion

        #region LookAt2D
        /// <summary>
        /// Rotates the transform to look at a target Transform in 2D space.
        /// </summary>
        /// <param name="transform">The transform to rotate.</param>
        /// <param name="target">The target Transform to look at.</param>
        public static void LookAt2D(this Transform transform, Transform target)
        {
            transform.LookAt2D((Vector2)target.position);
        }

        /// <summary>
        /// Rotates the transform to look at a target position in 3D space.
        /// </summary>
        /// <param name="transform">The transform to rotate.</param>
        /// <param name="worldPosition">The target position to look at.</param>
        public static void LookAt2D(this Transform transform, Vector3 worldPosition)
        {
            transform.LookAt2D((Vector2)worldPosition);
        }

        /// <summary>
        /// Rotates the transform to look at a target position in 2D space.
        /// </summary>
        /// <param name="transform">The transform to rotate.</param>
        /// <param name="target">The target position to look at.</param>
        /// <returns>The rotated transform.</returns>
        public static void LookAt2D(this Transform transform, Vector2 target)
        {
            var direction = target - (Vector2)transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        #endregion

        #region Children
        /// <summary>
        /// Retrieves all the children of a given Transform.
        /// </summary>
        /// <remarks>
        /// This method can be used with LINQ to perform operations on all child Transforms. For example,
        /// you could use it to find all children with a specific tag, to disable all children, etc.
        /// Transform implements IEnumerable and the GetEnumerator method which returns an IEnumerator of all its children.
        /// </remarks>
        /// <param name="parent">The Transform to retrieve children from.</param>
        /// <returns>An IEnumerable&lt;Transform&gt; containing all the child Transforms of the parent.</returns>
        public static IEnumerable<Transform> Children(this Transform parent)
        {
            foreach (Transform child in parent)
            {
                yield return child;
            }
        }

        /// <summary>
        /// Destroys all children of a given Transform immediately.
        /// </summary>
        /// <remarks>
        /// This method uses the ForeachChild extension method to iterate over each child of the parent Transform and destroy it.
        /// </remarks>
        /// <param name="parent">The Transform to destroy children from.</param>
        public static void DestroyChildrenImmediate(this Transform parent)
        {
            parent.ForeachChild(child => child.DestroyImmediate());
        }

        /// <summary>
        /// Enables all children of a given Transform.
        /// </summary>
        /// <remarks>
        /// This method uses the ForeachChild extension method to iterate over each child of the parent Transform and enable it.
        /// </remarks>
        /// <param name="parent">The Transform to enable children from.</param>
        public static void EnableChildren(this Transform parent)
        {
            parent.ForeachChild(child => child.gameObject.SetActive(true));
        }

        /// <summary>
        /// Disables all children of a given Transform.
        /// </summary>
        /// <remarks>
        /// This method uses the ForeachChild extension method to iterate over each child of the parent Transform and disable it.
        /// </remarks>
        /// <param name="parent">The Transform to disable children from.</param>
        public static void DisableChildren(this Transform parent)
        {
            parent.ForeachChild(child => child.gameObject.SetActive(false));
        }
        #endregion

        #region Component
        /// <summary>
        /// Retrieves or adds a component of a specified type to the transform.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="transform">The transform to retrieve or add the component to.</param>
        /// <returns>The retrieved or added component.</returns>
        public static T GetOrAddComponent<T>(this Transform transform) where T : Component
        {
            var component = transform.GetComponent<T>();
            if (!component) component = transform.gameObject.AddComponent<T>();

            return component;
        }

        /// <summary>
        /// Retrieves or adds a component of a specified type to the transform.
        /// </summary>
        /// <param name="transform">The transform to retrieve or add the component to.</param>
        /// <param name="type">The type of the component.</param>
        /// <returns>The retrieved or added component.</returns>
        public static Component GetOrAddComponent(this Transform transform, Type type)
        {
            var component = transform.GetComponent(type);
            if (!component) component = transform.gameObject.AddComponent(type);

            return component;
        }

        /// <summary>
        /// Tries to get a component of a specified type from the transform or its ancestors.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="context">The transform to retrieve the component from.</param>
        /// <param name="target">The retrieved component.</param>
        /// <returns>True if the component was found, false otherwise.</returns>
        public static bool TryGetComponentInHierarchy<T>(this Transform context, out T target)
            where T : class
        {
            for (var ancestor = context; ancestor; ancestor = ancestor.parent)
            {
                if (ancestor.TryGetComponent(out target))
                {
                    return true;
                }
            }

            for (int i = 0; i < context.childCount; i++)
            {
                if (context.GetChild(i).TryGetComponentInChildren(out target))
                {
                    return true;
                }
            }

            target = default;
            return false;
        }

        #region Parent
        /// <summary>
        /// Finds a component of a specified type in the transform or its ancestors.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="transform">The transform to retrieve the component from.</param>
        /// <returns>The retrieved component, or null if not found.</returns>
        public static T FindComponentInParents<T>(this Transform transform) where T : Component
        {
            var component = transform.GetComponent<T>();
            if (component != null)
            {
                return component;
            }

            return transform.parent != null ? FindComponentInParents<T>(transform.parent) : null;
        }
        #endregion

        #region Child
        /// <summary>
        /// Retrieves all children of the transform that have a component of a specified type.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="transform">The transform to retrieve the children from.</param>
        /// <returns>A list of children with the specified component.</returns>
        public static List<T> GetAllChild<T>(this Transform transform) where T : Component
        {
            var children = new List<T>();
            for (var i = 0; i < transform.childCount; i++)
            {
                var com = transform.GetChild(i).GetComponent<T>();
                if (com) children.Add(com);
            }

            return children;
        }

        /// <summary>
        /// Finds a child of the transform with a specified name.
        /// </summary>
        /// <param name="transform">The transform to retrieve the child from.</param>
        /// <param name="name">The name of the child.</param>
        /// <param name="includeInactive">Whether to include inactive children.</param>
        /// <returns>The child with the specified name, or null if not found.</returns>
        public static Transform FindInAllChildFuzzy(this Transform transform, string name, bool includeInactive = false)
        {
            var list = transform.GetComponentsInChildren<Transform>(includeInactive);
            for (var i = 0; i < list.Length; i++)
            {
                var t = list[i];
                if (t.gameObject.name.IndexOf(name, StringComparison.Ordinal) >= 0)
                {
                    return t;
                }
            }

            return null;
        }

        /// <summary>
        /// Finds a child of the transform with a specified name.
        /// </summary>
        /// <param name="transform">The transform to retrieve the child from.</param>
        /// <param name="name">The name of the child.</param>
        /// <param name="includeInactive">Whether to include inactive children.</param>
        /// <returns>The child with the specified name, or null if not found.</returns>
        public static Transform FindInAllChild(this Transform transform, string name, bool includeInactive = false)
        {
            var list = transform.GetComponentsInChildren<Transform>(includeInactive);
            for (var i = 0; i < list.Length; i++)
            {
                var t = list[i];
                if (t.gameObject.name == name)
                {
                    return t;
                }
            }

            return null;
        }

        /// <summary>
        /// Performs an action on each child of the transform.
        /// </summary>
        /// <param name="transform">The transform to perform the action on its children.</param>
        /// <param name="action">The action to perform.</param>
        /// <returns>The transform.</returns>
        public static Transform ForeachChild(this Transform transform, Action<Transform> action)
        {
            if (transform == null || transform.childCount == 0) return transform;
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                action?.Invoke(transform.GetChild(i));
            }

            return transform;
        }

        /// <summary>
        /// Updates the children of the transform based on a specified count and updater function.
        /// </summary>
        /// <param name="transform">The transform to update its children.</param>
        /// <param name="count">The number of children to update.</param>
        /// <param name="updater">The function to update the children.</param>
        /// <returns>The transform.</returns>
        public static Transform UpdateChild(this Transform transform, int count, Action<int, Transform> updater)
        {
            if (transform.childCount == 0) return transform;
            var prefab = transform.GetChild(0).gameObject;

            var i = 0;
            for (; i < transform.childCount && i < count; i++)
            {
                var child = transform.GetChild(i);
                child.gameObject.SetActive(true);
                updater(i, child);
            }

            if (count > transform.childCount)
            {
                for (; i < count; i++)
                {
                    var obj = Object.Instantiate(prefab, transform);
                    obj.gameObject.SetActive(true);
                    updater(i, obj.transform);
                }
            }
            else if (transform.childCount > count)
            {
                for (; i < transform.childCount; i++)
                {
                    var obj = transform.GetChild(i);
                    obj.gameObject.SetActive(false);
                }
            }

            return transform;
        }

        /// <summary>
        /// Destroys all children of the transform.
        /// </summary>
        /// <param name="transform">The transform to destroy its children.</param>
        /// <returns>The transform.</returns>
        public static Transform DestroyChildren(this Transform transform)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                transform.GetChild(i).Destroy();
            }

            return transform;
        }
        #endregion
        #endregion

        #region ScreenPosition
        /// <summary>
        /// Calculates the screen position of the transform.
        /// </summary>
        /// <param name="transform">The transform to calculate the screen position for.</param>
        /// <returns>A Vector2 representing the screen position of the transform.</returns>
        public static Vector2 ScreenPosition(this Transform transform)
        {
            var screenPos = Camera.main!.WorldToScreenPoint(transform.position);
            return (new Vector2(screenPos.x, screenPos.y));
        }

        /// <summary>
        /// Calculates the screen position ratio of the transform.
        /// </summary>
        /// <param name="transform">The transform to calculate the screen position ratio for.</param>
        /// <returns>A Vector2 representing the screen position ratio of the transform.</returns>
        public static Vector2 ScreenPositionRatio(this Transform transform)
        {
            var screenPos = transform.ScreenPosition();
            var ratio = new Vector2(screenPos.x / Screen.width, screenPos.y / Screen.height);
            return ratio;
        }
        #endregion

        #region Copy
        /// <summary>
        /// Copies the transform values from a source transform to the current transform.
        /// </summary>
        /// <param name="transform">The transform to copy values to.</param>
        /// <param name="src">The source transform to copy values from.</param>
        /// <param name="isWordSpace">If true, copies the world position and rotation. If false, copies the local position and rotation.</param>
        /// <returns>The transform with copied values.</returns>
        public static Transform CopyTransform(this Transform transform, Transform src, bool isWordSpace)
        {
            if (isWordSpace)
            {
                transform.position = src.position;
                transform.rotation = src.rotation;
            }
            else
            {
                transform.localPosition = src.localPosition;
                transform.localRotation = src.localRotation;
            }

            transform.localScale = src.localScale;
            return transform;
        }
        #endregion

        #region Path
        /// <summary>
        /// Retrieves the path of the transform in the hierarchy.
        /// </summary>
        /// <param name="transform">The transform to retrieve the path for.</param>
        /// <returns>A string representing the path of the transform in the hierarchy.</returns>
        public static string Path(this Transform transform)
        {
            var go = transform.gameObject;
            var path = "/" + go.name;
            while (go.transform.parent != null)
            {
                go = go.transform.parent.gameObject;
                path = "/" + go.name + path;
            }

            return path;
        }

        /// <summary>
        /// Retrieves the full path of the transform in the hierarchy, including the transform's name.
        /// </summary>
        /// <param name="transform">The transform to retrieve the full path for.</param>
        /// <returns>A string representing the full path of the transform in the hierarchy.</returns>
        public static string PathFull(this Transform transform)
        {
            return transform.Path() + "/" + transform.name;
        }

        /// <summary>
        /// Retrieves the root transform of the current transform.
        /// </summary>
        /// <param name="go">The transform to retrieve the root for.</param>
        /// <returns>The root transform of the current transform.</returns>
        public static Transform Root(this Transform go)
        {
            var current = go;
            Transform result;
            do
            {
                var trans = current.parent;
                result = trans != null ? trans : current;
                current = trans;
            } while (current != null);

            return result;
        }

        /// <summary>
        /// Calculates the depth of the transform in the hierarchy.
        /// </summary>
        /// <param name="transform">The transform to calculate the depth for.</param>
        /// <returns>An integer representing the depth of the transform in the hierarchy.</returns>
        public static int Depth(this Transform transform)
        {
            var depth = 0;
            var current = transform;
            do
            {
                current = current.parent;
                if (current != null)
                {
                    depth++;
                }
            } while (current != null);

            return depth;
        }
        #endregion

        #region Is InView
        /// <summary>
        /// Determines whether the transform is within the view of the specified camera.
        /// </summary>
        /// <param name="transform">The transform to check.</param>
        /// <param name="camera">The camera to check the view for.</param>
        /// <returns>True if the transform is in the view of the camera, false otherwise.</returns>
        public static bool IsInView(this Transform transform, Camera camera)
        {
            var worldPos = transform.position;
            var camTransform = camera.transform;
            var viewPos = camera.WorldToViewportPoint(worldPos);
            var dir = (worldPos - camTransform.position).normalized;
            var dot = Vector3.Dot(camTransform.forward, dir);
            if (dot > 0 && viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}