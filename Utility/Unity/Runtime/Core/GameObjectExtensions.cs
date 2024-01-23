using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UtilityLibrary.Unity.Runtime
{
	public static partial class GameObjectExtensions
    {
		#region Prefab
		/// <summary>
		/// Checks if the GameObject is a prefab.
		/// </summary>
		/// <param name="gameObject">The GameObject to check.</param>
		/// <returns>True if the GameObject is a prefab, false otherwise.</returns>
		public static bool IsPrefab(this GameObject gameObject)
		{
			var result = gameObject.scene.name == null;
			return result;
		}
		#endregion

		#region HasComponent
		/// <summary>
		/// Checks if the GameObject has a specified component type.
		/// </summary>
		/// <typeparam name="T">The type of component to check for.</typeparam>
		/// <param name="gameObject">The GameObject to check.</param>
		/// <returns>True if the GameObject has the specified component type, false otherwise.</returns>
		public static bool HasComponent<T>(this GameObject gameObject)
		{
			var result = gameObject.GetComponent<T>() != null;
			return result;
		}

		/// <summary>
		/// Checks if the GameObject has a Rigidbody component.
		/// </summary>
		/// <param name="gameObject">The GameObject to check.</param>
		/// <returns>True if the GameObject has a Rigidbody component, false otherwise.</returns>
		public static bool HasRigidbody(this GameObject gameObject)
		{
			var result = gameObject.GetComponent<Rigidbody>() != null;
			return result;
		}

		/// <summary>
		/// Checks if the GameObject has an Animation component.
		/// </summary>
		/// <param name="gameObject">The GameObject to check.</param>
		/// <returns>True if the GameObject has an Animation component, false otherwise.</returns>
		public static bool HasAnimation(this GameObject gameObject)
		{
			var result = gameObject.GetComponent<Animation>() != null;
			return result;
		}

		/// <summary>
		/// Checks if the GameObject has an Animator component.
		/// </summary>
		/// <param name="gameObject">The GameObject to check.</param>
		/// <returns>True if the GameObject has an Animator component, false otherwise.</returns>
		public static bool HasAnimator(this GameObject gameObject)
		{
			var result = gameObject.GetComponent<Animator>() != null;
			return result;
		}
		#endregion

		#region Component
		/// <summary>
		/// Attempts to get a component of type T from the GameObject.
		/// </summary>
		/// <typeparam name="T">The type of component to get.</typeparam>
		/// <param name="gameObject">The GameObject to get the component from.</param>
		/// <param name="outComponent">The resulting component if found.</param>
		/// <returns>True if the component is found, false otherwise.</returns>
		public static bool TryGetComponent<T>(this GameObject gameObject, out T outComponent)
		{
			outComponent = gameObject.GetComponent<T>();
			var result = outComponent != null;
			return result;
		}

		/// <summary>
		/// Attempts to get a component of type T from the GameObject or its ancestors.
		/// </summary>
		/// <typeparam name="T">The type of component to get.</typeparam>
		/// <param name="gameObject">The GameObject to search.</param>
		/// <param name="outComponent">The resulting component if found.</param>
		/// <returns>True if the component is found, false otherwise.</returns>
		public static bool TryGetComponentInParent<T>(this GameObject gameObject, out T outComponent)
		{
			outComponent = gameObject.GetComponentInParent<T>();
			var result = outComponent != null;
			return result;
		}

		/// <summary>
		/// Attempts to get a component of type T from the GameObject or its descendants.
		/// </summary>
		/// <typeparam name="T">The type of component to get.</typeparam>
		/// <param name="gameObject">The GameObject to search.</param>
		/// <param name="outComponent">The resulting component if found.</param>
		/// <returns>True if the component is found, false otherwise.</returns>
		public static bool TryGetComponentInChildren<T>(this GameObject gameObject, out T outComponent)
		{
			outComponent = gameObject.GetComponentInChildren<T>();
			var result = outComponent != null;
			return result;
		}

		/// <summary>
		/// Gets or adds a component of type T to the GameObject.
		/// </summary>
		/// <typeparam name="T">The type of component to get or add.</typeparam>
		/// <param name="gameObject">The GameObject to get or add the component to.</param>
		/// <returns>The resulting component.</returns>
		public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
		{
			T component = gameObject.GetComponent<T>();
			if (!component) component = gameObject.AddComponent<T>();

			return component;
		}

		/// <summary>
		/// Gets or adds a component of the specified type to the GameObject.
		/// </summary>
		/// <param name="gameObject">The GameObject to get or add the component to.</param>
		/// <param name="type">The type of component to get or add.</param>
		/// <returns>The resulting component.</returns>
		public static Component GetOrAddComponent(this GameObject gameObject, Type type)
		{
			var component = gameObject.GetComponent(type);
			if (!component) component = gameObject.AddComponent(type);

			return component;
		}

		/// <summary>
		/// Destroys a component of type T on the GameObject.
		/// </summary>
		/// <typeparam name="T">The type of component to destroy.</typeparam>
		/// <param name="gameObject">The GameObject to destroy the component on.</param>
		/// <returns>True if the component was destroyed, false otherwise.</returns>
		public static bool DestroyComponent<T>(this GameObject gameObject) where T : Component
		{
			var component = gameObject.GetComponent<T>();
			if (component == null) return false;
			Object.DestroyImmediate(component);
			return true;
		}

		/// <summary>
		/// Destroys a component of the specified type on the GameObject.
		/// </summary>
		/// <param name="gameObject">The GameObject to destroy the component on.</param>
		/// <param name="type">The type of component to destroy.</param>
		/// <returns>True if the component was destroyed, false otherwise.</returns>
		public static bool DestroyComponent(this GameObject gameObject, Type type)
		{
			var component = gameObject.GetComponent(type);
			if (component == null) return false;
			Object.DestroyImmediate(component);
			return true;
		}

		/// <summary>
		/// Searches for a component of type T with the specified name in the GameObject's descendants.
		/// </summary>
		/// <typeparam name="T">The type of component to search for.</typeparam>
		/// <param name="gameObject">The GameObject to search.</param>
		/// <param name="searchName">The name of the component to search for.</param>
		/// <returns>The first matching component, or null if not found.</returns>
		public static T SearchComponent<T>(this GameObject gameObject, string searchName) where T : Component
		{
			var gos = gameObject.GetComponentsInChildren<T>(true);
			var length = gos.Length;
			for (var i = 0; i < length; i++)
			{
				var local = gos[i];
				if (searchName == local.name)
				{
					return local;
				}
			}

			return null;
		}

		/// <summary>
		/// Finds a component of type T in the GameObject's ancestors.
		/// </summary>
		/// <typeparam name="T">The type of component to find.</typeparam>
		/// <param name="gameObject">The GameObject to search.</param>
		/// <returns>The first matching component, or null if not found.</returns>
		public static T FindComponentInParents<T>(this GameObject gameObject) where T : Component
		{
			var component = gameObject.GetComponent<T>();
			if (component != null)
			{
				return component;
			}

			return gameObject.transform.parent != null ? FindComponentInParents<T>(gameObject.transform.parent.gameObject) : null;
		}

		/// <summary>
		/// Finds a component of the specified type in the GameObject's ancestors.
		/// </summary>
		/// <param name="gameObject">The GameObject to search.</param>
		/// <param name="type">The type of component to find.</param>
		/// <returns>The first matching component, or null if not found.</returns>
		public static Component FindComponentInParents(this GameObject gameObject, Type type)
		{
			var component = gameObject.GetComponent(type);
			if (component != null)
			{
				return component;
			}

			return gameObject.transform.parent != null ? FindComponentInParents(gameObject.transform.parent.gameObject, type) : null;
		}
		#endregion

		#region Path
		/// <summary>
		/// Creates child GameObjects based on the provided path name.
		/// </summary>
		/// <param name="gameObject">The parent GameObject.</param>
		/// <param name="pathName">The path name to create child GameObjects.</param>
		/// <param name="splitChar">The character used to split the pathName (default is '/').</param>
		/// <returns>An array of created child GameObjects.</returns>
		public static GameObject[] CreateChild(this GameObject gameObject, string pathName, char splitChar = '/')
		{
			GameObject obj2 = null;
			var list = new List<GameObject>();
			var separator = new char[] { splitChar };
			for (var i = 0; i < pathName.Split(separator).Length; i++)
			{
				var str = pathName.Split(separator)[i];
				var item = new GameObject(str);
				list.Add(item);
				if (obj2 != null)
				{
					item.transform.SetParent(obj2.transform);
				}

				obj2 = item;
			}

			list[0].transform.SetParent(gameObject.transform);
			return list.ToArray();
		}

		/// <summary>
		/// Gets the path of the GameObject in the scene hierarchy.
		/// </summary>
		/// <param name="gameObject">The GameObject to get the path for.</param>
		/// <returns>The path of the GameObject in the scene hierarchy.</returns>
		public static string Path(this GameObject gameObject)
		{
			var path = "/" + gameObject.name;
			while (gameObject.transform.parent != null)
			{
				gameObject = gameObject.transform.parent.gameObject;
				path = "/" + gameObject.name + path;
			}

			return path;
		}

		/// <summary>
		/// Gets the full path of the GameObject in the scene hierarchy, including the GameObject's name.
		/// </summary>
		/// <param name="gameObject">The GameObject to get the full path for.</param>
		/// <returns>The full path of the GameObject in the scene hierarchy.</returns>
		public static string PathFull(this GameObject gameObject)
		{
			return gameObject.Path() + "/" + gameObject.name;
		}

		/// <summary>
		/// Gets the root GameObject in the hierarchy of the provided GameObject.
		/// </summary>
		/// <param name="go">The GameObject to find the root for.</param>
		/// <returns>The root GameObject in the hierarchy.</returns>
		public static GameObject Root(this GameObject go)
		{
			var current = go;
			GameObject result;
			do
			{
				var trans = current.transform.parent;
				if (trans != null)
				{
					result = trans.gameObject;
					current = trans.gameObject;
				}
				else
				{
					result = current;
					current = null;
				}
			} while (current != null);

			return result;
		}

		/// <summary>
		/// Gets the depth of the GameObject in the hierarchy.
		/// </summary>
		/// <param name="go">The GameObject to find the depth for.</param>
		/// <returns>The depth of the GameObject in the hierarchy.</returns>
		public static int Depth(this GameObject go)
		{
			var depth = 0;
			var current = go.transform;
			do
			{
				current = current.transform.parent;
				if (current != null)
				{
					depth++;
				}
			} while (current != null);

			return depth;
		}
		#endregion

		#region Layer
		/// <summary>
		/// Checks if the GameObject's layer is included in a specific layer index.
		/// </summary>
		/// <param name="gameObject">The GameObject to check.</param>
		/// <param name="otherLayerIndex">The layer index to check against.</param>
		/// <returns>True if the GameObject's layer is included, false otherwise.</returns>
		public static bool ContainLayer(this GameObject gameObject, int otherLayerIndex)
		{
			var value = 1 << gameObject.layer;
			var result = (value & otherLayerIndex) > 0;
			return result;
		}

		/// <summary>
		/// Checks if the GameObject's layer is included in a specific LayerMask.
		/// </summary>
		/// <param name="gameObject">The GameObject to check.</param>
		/// <param name="otherLayerMask">The LayerMask to check against.</param>
		/// <returns>True if the GameObject's layer is included, false otherwise.</returns>
		public static bool ContainLayer(this GameObject gameObject, LayerMask otherLayerMask)
		{
			var value = 1 << gameObject.layer;
			var result = (value & otherLayerMask.value) > 0;
			return result;
		}

		/// <summary>
		/// Checks if the GameObject's layer is included in all specified LayerMasks.
		/// </summary>
		/// <param name="gameObject">The GameObject to check.</param>
		/// <param name="otherLayerMasks">The array of LayerMasks to check against.</param>
		/// <returns>True if the GameObject's layer is included in all specified LayerMasks, false otherwise.</returns>
		public static bool ContainLayers(this GameObject gameObject, params LayerMask[] otherLayerMasks)
		{
			foreach (var layerMask in otherLayerMasks)
			{
				var result = gameObject.ContainLayer(layerMask);
				if (!result) return false;
			}
			return true;
		}

		/// <summary>
		/// Checks if the GameObject's layer is included in at least one of the specified LayerMasks.
		/// </summary>
		/// <param name="gameObject">The GameObject to check.</param>
		/// <param name="otherLayerMasks">The array of LayerMasks to check against.</param>
		/// <returns>True if the GameObject's layer is included in at least one of the specified LayerMasks, false otherwise.</returns>
		public static bool ContainOneOfLayers(this GameObject gameObject, params LayerMask[] otherLayerMasks)
		{
			foreach (var layerMask in otherLayerMasks)
			{
				var result = gameObject.ContainLayer(layerMask);
				if (result) return true;
			}
			return false;
		}

		/// <summary>
		/// Sets the layer of the GameObject using the provided LayerMask.
		/// </summary>
		/// <param name="gameObject">The GameObject to set the layer for.</param>
		/// <param name="layerMask">The LayerMask specifying the new layer.</param>
		public static void SetLayer(this GameObject gameObject, LayerMask layerMask)
		{
			gameObject.layer = layerMask.GetLayerIndex();
		}

		/// <summary>
		/// Sets the layer of the GameObject and its children using the provided LayerMask.
		/// </summary>
		/// <param name="gameObject">The GameObject to set the layer for.</param>
		/// <param name="layerMask">The LayerMask specifying the new layer.</param>
		public static void SetLayerRecursion(this GameObject gameObject, LayerMask layerMask)
		{
			gameObject.layer = layerMask.GetLayerIndex();
			foreach (Transform child in gameObject.transform)
			{
				SetLayerRecursion(child.gameObject, layerMask);
			}
		}

		/// <summary>
		/// Sets the layer of the GameObject and its children using the provided layer index.
		/// </summary>
		/// <param name="gameObject">The GameObject to set the layer for.</param>
		/// <param name="layerIndex">The new layer index.</param>
		public static void SetLayerRecursion(this GameObject gameObject, int layerIndex)
		{
			gameObject.layer = layerIndex;
			foreach (Transform child in gameObject.transform)
			{
				SetLayerRecursion(child.gameObject, layerIndex);
			}
		}
		#endregion

		#region Tag
		/// <summary>
		/// Sets the tag of the GameObject.
		/// </summary>
		/// <param name="gameObject">The GameObject to set the tag for.</param>
		/// <param name="tag">The new tag.</param>
		public static void SetTag(this GameObject gameObject, string tag)
		{
			gameObject.tag = tag;
		}

		/// <summary>
		/// Sets the tag of the GameObject and its children.
		/// </summary>
		/// <param name="gameObject">The GameObject to set the tag for.</param>
		/// <param name="tag">The new tag.</param>
		public static void SetTagRecursion(this GameObject gameObject, string tag)
		{
			gameObject.tag = tag;
			foreach (Transform child in gameObject.transform)
			{
				SetTagRecursion(child.gameObject, tag);
			}
		}
		#endregion

		#region Particle
		/// <summary>
		/// Gets the duration of the ParticleSystem on the GameObject.
		/// </summary>
		/// <param name="gameObject">The GameObject with the ParticleSystem.</param>
		/// <param name="includeChildren">Include ParticleSystems in children.</param>
		/// <param name="includeInactive">Include inactive ParticleSystems.</param>
		/// <param name="allowLoop">Consider looping duration.</param>
		/// <returns>The duration of the ParticleSystem(s).</returns>
		public static float GetParticleDuration(this GameObject gameObject, bool includeChildren = true, bool includeInactive = false, bool allowLoop = false)
		{
			if (includeChildren)
			{
				var particles = gameObject.GetComponentsInChildren<ParticleSystem>(includeInactive);
				var duration = -1f;
				for (var i = 0; i < particles.Length; i++)
				{
					var ps = particles[i];
					var time = ps.GetDuration(allowLoop);
					if (time > duration)
					{
						duration = time;
					}
				}

				return duration;
			}
			else
			{
				var ps = gameObject.GetComponent<ParticleSystem>();
				if (ps != null)
				{
					return ps.GetDuration(allowLoop);
				}
				else
				{
					return -1f;
				}
			}
		}
		#endregion

		#region Trail Renderer
		/// <summary>
		/// Gets the maximum time of TrailRenderer(s) on the GameObject.
		/// </summary>
		/// <param name="gameObject">The GameObject with TrailRenderer(s).</param>
		/// <returns>The maximum time of TrailRenderer(s).</returns>
		public static float GetTrailRendererTime(this GameObject gameObject)
		{
			var trailRendererArray = gameObject.GetComponentsInChildren<TrailRenderer>();
			var duration = 0f;
			for (var i = 0; i < trailRendererArray.Length; i++)
			{
				var trailRenderer = trailRendererArray[i];
				var time = trailRenderer.time;
				if (time > duration)
				{
					duration = time;
				}
			}

			return duration;
		}
		#endregion

		#region Bounds
		/// <summary>
		/// Gets the bounding box of the GameObject.
		/// </summary>
		/// <param name="gameObject">The GameObject to get the bounds for.</param>
		/// <param name="includeChildren">Include bounds of children.</param>
		/// <returns>The bounding box of the GameObject.</returns>
		public static Bounds GetBounds(this GameObject gameObject, bool includeChildren = true)
		{
			var renderer = gameObject.GetComponent<Renderer>();
			if (renderer != null)
			{
				return renderer.GetBounds(includeChildren);
			}

			var meshFilter = gameObject.GetComponent<MeshFilter>();
			if (meshFilter != null)
			{
				return meshFilter.GetBounds(includeChildren);
			}

			var bounds = new Bounds(gameObject.transform.position, Vector3.zero);
			return bounds;
		}
		#endregion
	}
}