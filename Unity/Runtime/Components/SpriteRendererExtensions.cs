using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class SpriteRendererExtensions
    {
        /// <summary>
        /// Sets the alpha component of the color of the SpriteRenderer.
        /// </summary>
        /// <param name="spriteRenderer">The SpriteRenderer instance.</param>
        /// <param name="alpha">The alpha component of the color.</param>
        public static void SetColorA(this SpriteRenderer spriteRenderer, float alpha)
        {
            var color = spriteRenderer.color;
            var newColor = new Color(color.r, color.g, color.b, alpha);
            spriteRenderer.color = newColor;
        }

        /// <summary>
        /// Sets the red component of the color of the SpriteRenderer.
        /// </summary>
        /// <param name="spriteRenderer">The SpriteRenderer instance.</param>
        /// <param name="red">The red component of the color.</param>
        public static void SetColorR(this SpriteRenderer spriteRenderer, float red)
        {
            var color = spriteRenderer.color;
            var newColor = new Color(red, color.g, color.b, color.a);
            spriteRenderer.color = newColor;
        }

        /// <summary>
        /// Sets the green component of the color of the SpriteRenderer.
        /// </summary>
        /// <param name="spriteRenderer">The SpriteRenderer instance.</param>
        /// <param name="green">The green component of the color.</param>
        public static void SetColorG(this SpriteRenderer spriteRenderer, float green)
        {
            var color = spriteRenderer.color;
            var newColor = new Color(color.r, green, color.b, color.a);
            spriteRenderer.color = newColor;
        }

        /// <summary>
        /// Sets the blue component of the color of the SpriteRenderer.
        /// </summary>
        /// <param name="spriteRenderer">The SpriteRenderer instance.</param>
        /// <param name="blue">The blue component of the color.</param>
        public static void SetColorB(this SpriteRenderer spriteRenderer, float blue)
        {
            var color = spriteRenderer.color;
            var newColor = new Color(color.r, color.g, blue, color.a);
            spriteRenderer.color = newColor;
        }
    }
}