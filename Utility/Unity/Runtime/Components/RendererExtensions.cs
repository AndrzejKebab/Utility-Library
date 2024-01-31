using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
	public static class RendererExtensions
	{
		/// <summary>
		/// Checks if the renderer is visible from the specified camera.
		/// </summary>
		/// <param name="renderer">The renderer to check.</param>
		/// <param name="camera">The camera to check visibility from.</param>
		/// <returns>True if the renderer is visible from the camera, false otherwise.</returns>
		public static bool IsVisible(this Renderer renderer, Camera camera)
		{
			var planes = GeometryUtility.CalculateFrustumPlanes(camera);
			return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
		}

		/// <summary>
		/// Gets the bounds of the renderer.
		/// </summary>
		/// <param name="renderer">The renderer to get the bounds from.</param>
		/// <param name="includeChildren">Whether to include the bounds of child renderers. Default is true.</param>
		/// <returns>The bounds of the renderer. If includeChildren is true, the bounds encapsulate the bounds of child renderers.</returns>
		public static Bounds GetBounds(this Renderer renderer, bool includeChildren = true)
		{
			if (includeChildren)
			{
				var center = renderer.transform.position;
				var bounds = new Bounds(center, Vector3.zero);
				var rendererList = renderer.gameObject.GetComponentsInChildren<Renderer>();
				if (rendererList.Length == 0) return bounds;
				foreach (var r in rendererList)
				{
					bounds.Encapsulate(r.bounds);
				}
				return bounds;
			}
			else
			{
				return renderer.bounds;
			}
		}

		/// <summary>
		/// Gets the material at the specified index.
		/// </summary>
		/// <param name="renderer">The renderer to get the material from.</param>
		/// <param name="materialIndex">The index of the material to get.</param>
		/// <returns>The material at the specified index, or null if the index is out of range.</returns>
		public static Material GetMaterial(this Renderer renderer, int materialIndex)
		{
			if (materialIndex < 0 || materialIndex >= renderer.sharedMaterials.Length) return null;
			return Application.isPlaying ? renderer.materials[materialIndex] : renderer.sharedMaterials[materialIndex];
		}
	}
}