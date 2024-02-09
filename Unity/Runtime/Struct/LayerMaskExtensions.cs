using System.Collections.Generic;
using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
	public static class LayerMaskExtensions
	{
		/// <summary>
		/// Checks if the layer mask contains the other layer mask.
		/// </summary>
		/// <param name="layerMask">The layer mask to check.</param>
		/// <param name="otherLayerMask">The other layer mask to check for.</param>
		/// <returns>True if the layer mask contains the other layer mask, false otherwise.</returns>
		public static bool Contains(this LayerMask layerMask, LayerMask otherLayerMask)
		{
			var value = 1 << layerMask.value;
			var result = (value & otherLayerMask.value) > 0;
			return result;
		}

		/// <summary>
		/// Checks if the layer mask contains the specified layer index.
		/// </summary>
		/// <param name="layerMask">The layer mask to check.</param>
		/// <param name="layerIndex">The layer index to check for.</param>
		/// <returns>True if the layer mask contains the layer index, false otherwise.</returns>
		public static bool Contains(this LayerMask layerMask, int layerIndex)
		{
			return (layerMask.value & (1 << layerIndex)) > 0;
		}

		/// <summary>
		/// Gets the layer index of the layer mask.
		/// </summary>
		/// <param name="layerMask">The layer mask to get the layer index from.</param>
		/// <returns>The layer index of the layer mask, or -1 if an error occurred.</returns>
		public static int GetLayerIndex(this LayerMask layerMask)
		{
			var i = 0;
			while (layerMask.value >> i != 0x1)
			{
				i++;
				if (i <= 32) continue;
				Debug.LogError("Get LayerMask Index Error");
				return -1;
			}

			return i;
		}

		/// <summary>
		/// Inverts the layer mask.
		/// </summary>
		/// <param name="layerMask">The layer mask to invert.</param>
		/// <returns>The inverted layer mask.</returns>
		public static LayerMask Inverse(this LayerMask layerMask)
		{
			return ~layerMask;
		}

		/// <summary>
		/// Adds the specified layers to the layer mask.
		/// </summary>
		/// <param name="layerMask">The layer mask to add to.</param>
		/// <param name="name">The names of the layers to add.</param>
		/// <returns>The layer mask with the added layers.</returns>
		public static LayerMask AddToMask(this LayerMask layerMask, params string[] name)
		{
			return layerMask | NameToMask(name);
		}

		/// <summary>
		/// Removes the specified layers from the layer mask.
		/// </summary>
		/// <param name="layerMask">The layer mask to remove from.</param>
		/// <param name="name">The names of the layers to remove.</param>
		/// <returns>The layer mask with the removed layers.</returns>
		public static LayerMask RemoveFromMask(this LayerMask layerMask, params string[] name)
		{
			var invertedOriginal = ~layerMask;
			return ~(invertedOriginal | NameToMask(name));
		}

		/// <summary>
		/// Converts the layer mask to an array of layer names.
		/// </summary>
		/// <param name="layerMask">The layer mask to convert.</param>
		/// <returns>An array of layer names.</returns>
		public static string[] MaskToNames(this LayerMask layerMask)
		{
			var output = new List<string>();

			for (var i = 0; i < 32; ++i)
			{
				var shifted = 1 << i;
				if ((layerMask & shifted) != shifted) continue;
				var layerName = LayerMask.LayerToName(i);
				if (!string.IsNullOrEmpty(layerName))
				{
					output.Add(layerName);
				}
			}

			return output.ToArray();
		}

		/// <summary>
		/// Converts the layer mask to a string.
		/// </summary>
		/// <param name="layerMask">The layer mask to convert.</param>
		/// <returns>A string representation of the layer mask.</returns>
		public static string MaskToString(this LayerMask layerMask)
		{
			return MaskToString(layerMask, ", ");
		}

		/// <summary>
		/// Converts the layer mask to a string with the specified delimiter.
		/// </summary>
		/// <param name="layerMask">The layer mask to convert.</param>
		/// <param name="delimiter">The delimiter to use.</param>
		/// <returns>A string representation of the layer mask with the specified delimiter.</returns>
		public static string MaskToString(this LayerMask layerMask, string delimiter)
		{
			return string.Join(delimiter, MaskToNames(layerMask));
		}

		/// <summary>
		/// Converts the specified layer names to a layer mask.
		/// </summary>
		/// <param name="layerNames">The layer names to convert.</param>
		/// <returns>A layer mask that represents the specified layer names.</returns>
		internal static LayerMask NameToMask(params string[] layerNames)
		{
			var ret = (LayerMask)0;
			for (var i = 0; i < layerNames.Length; i++)
			{
				var nameTemp = layerNames[i];
				ret |= (1 << LayerMask.NameToLayer(nameTemp));
			}

			return ret;
		}
	}
}