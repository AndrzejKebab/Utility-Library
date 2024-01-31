using UnityEngine;
using UnityEngine.Rendering;

namespace UtilityLibrary.Unity.Runtime
{
    public static class ShaderExtensions
    {
        /// <summary>
        /// Checks if the Shader contains a specific property.
        /// </summary>
        /// <param name="shader">The Shader instance.</param>
        /// <param name="propertyName">The name of the property to check.</param>
        /// <returns>True if the Shader contains the property, false otherwise.</returns>
        public static bool ContainsProperty(this Shader shader, string propertyName)
        {
            if (propertyName.EndsWith("_ST")) propertyName = propertyName.Replace("_ST", "");
            for (var i = 0; i < shader.GetPropertyCount(); i++)
            {
                var name = shader.GetPropertyName(i);
                if (name == propertyName) return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the Shader contains a specific property of a specific type.
        /// </summary>
        /// <param name="shader">The Shader instance.</param>
        /// <param name="propertyName">The name of the property to check.</param>
        /// <param name="propertyType">The type of the property to check.</param>
        /// <returns>True if the Shader contains the property of the specified type, false otherwise.</returns>
        public static bool ContainsProperty(this Shader shader, string propertyName, ShaderPropertyType propertyType)
        {
            if (propertyName.EndsWith("_ST")) propertyName = propertyName.Replace("_ST", "");
            for (var i = 0; i < shader.GetPropertyCount(); i++)
            {
                var name = shader.GetPropertyName(i);
                var type = shader.GetPropertyType(i);
                if (name == propertyName && type == propertyType) return true;
            }

            return false;
        }
    }
}