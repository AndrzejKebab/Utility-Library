using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
	public static partial class MeshFilterExtensions
	{
		/// <summary>
		/// Gets the bounds of the mesh filter.
		/// </summary>
		/// <param name="meshFilter">The mesh filter to get the bounds from.</param>
		/// <param name="includeChildren">Whether to include the bounds of child mesh filters. Default is true.</param>
		/// <returns>The bounds of the mesh filter. If includeChildren is true, the bounds encapsulate the bounds of child mesh filters.</returns>
		public static Bounds GetBounds(this MeshFilter meshFilter, bool includeChildren = true)
		{
			if (includeChildren)
			{
				var center = meshFilter.transform.position;
				var bounds = new Bounds(center, Vector3.zero);
				var meshFilters = meshFilter.gameObject.GetComponentsInChildren<MeshFilter>();
				if (meshFilters.Length == 0) return bounds;
				foreach (var filter in meshFilters)
				{
					if (filter.mesh != null)
					{
						bounds.Encapsulate(filter.mesh.bounds);
					}
				}

				return bounds;
			}
			else
			{
				return meshFilter.mesh.bounds;
			}
		}
	}
}