using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UtilityLibrary.Unity.Runtime
{
    public static class UnityObjectExtension
    {
        #region Find
        /// <summary>
        /// Finds all objects of a specified type in the scene.
        /// </summary>
        /// <returns>An array of objects of the specified type.</returns>
        public static Object[] FindObjects(Type type)
        {
#if UNITY_2023_1_OR_NEWER
		return Object.FindObjectsByType(type, FindObjectsSortMode.None);
#else
            return Object.FindObjectsOfType(type);
#endif
        }

        /// <summary>
        /// Finds all objects of a specified type in the scene.
        /// </summary>
        /// <returns>An array of objects of the specified type.</returns>
        public static T[] FindObjects<T>() where T : Object
        {
#if UNITY_2023_1_OR_NEWER
		return Object.FindObjectsByType<T>(FindObjectsSortMode.None);
#else
            return Object.FindObjectsOfType<T>();
#endif
        }
        #endregion

        #region Destroy
        /// <summary>
        /// Destroys the given Unity Object.
        /// </summary>
        /// <remarks>
        /// This method is an extension method for the Unity Object class. It provides a way to destroy an Object
        /// immediately if the application is not playing (in the Unity Editor), or normally if the application is playing.
        /// </remarks>
        /// <param name="obj">The Unity Object to destroy.</param>
        public static void Destroy(this Object obj)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                Object.DestroyImmediate(obj);
                return;
            }
#endif
            Object.Destroy(obj);
        }
        
        /// <summary>
        /// Destroys the object immediately using <see cref="Object.DestroyImmediate"/>.
        /// </summary>
        /// <param name="obj">The object to destroy immediately.</param>
        public static void DestroyImmediate(this Object obj) => Object.DestroyImmediate(obj);
        #endregion
    }
}