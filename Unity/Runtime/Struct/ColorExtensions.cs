using System;
using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class ColorExtensions
    {
        #region Deconstruct
        
        /// <summary>
        /// Deconstructs a Color instance into its red, green, and blue components.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <param name="r">The red component of the Color.</param>
        /// <param name="g">The green component of the Color.</param>
        /// <param name="b">The blue component of the Color.</param>
        public static void Deconstruct(in this Color color, out float r, out float g, out float b)
        {
            r = color.r;
            g = color.g;
            b = color.b;
        }
        
        /// <summary>
        /// Deconstructs a Color instance into its red, green, blue, and alpha components.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <param name="r">The red component of the Color.</param>
        /// <param name="g">The green component of the Color.</param>
        /// <param name="b">The blue component of the Color.</param>
        /// <param name="a">The alpha component of the Color.</param>
        public static void Deconstruct(in this Color color, out float r, out float g, out float b, out float a)
        {
            r = color.r;
            g = color.g;
            b = color.b;
            a = color.a;
        }
        
        /// <summary>
        /// Deconstructs a Color32 instance into its red, green, and blue components.
        /// </summary>
        /// <param name="color">The Color32 instance.</param>
        /// <param name="r">The red component of the Color32.</param>
        /// <param name="g">The green component of the Color32.</param>
        /// <param name="b">The blue component of the Color32.</param>
        public static void Deconstruct(in this Color32 color, out byte r, out byte g, out byte b)
        {
            r = color.r;
            g = color.g;
            b = color.b;
        }
        
        /// <summary>
        /// Deconstructs a Color32 instance into its red, green, blue, and alpha components.
        /// </summary>
        /// <param name="color">The Color32 instance.</param>
        /// <param name="r">The red component of the Color32.</param>
        /// <param name="g">The green component of the Color32.</param>
        /// <param name="b">The blue component of the Color32.</param>
        /// <param name="a">The alpha component of the Color32.</param>
        public static void Deconstruct(in this Color32 color, out byte r, out byte g, out byte b, out byte a)
        {
            r = color.r;
            g = color.g;
            b = color.b;
            a = color.a;
        }
        #endregion

        #region With
        /// <summary>
        /// Creates a new Color instance with the specified red, green, blue, and alpha components, or the original components if not specified.
        /// </summary>
        /// <param name="color">The original Color instance.</param>
        /// <param name="r">The red component of the new Color. If null, the red component of the original Color is used.</param>
        /// <param name="g">The green component of the new Color. If null, the green component of the original Color is used.</param>
        /// <param name="b">The blue component of the new Color. If null, the blue component of the original Color is used.</param>
        /// <param name="a">The alpha component of the new Color. If null, the alpha component of the original Color is used.</param>
        /// <returns>A new Color instance with the specified red, green, blue, and alpha components.</returns>
        public static Color With(in this Color color, float? r = null, float? g = null, float? b = null, float? a = null)
        {
            var result = new Color(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);
            return result;
        }
        
        /// <summary>
        /// Creates a new Color32 instance with the specified red, green, blue, and alpha components, or the original components if not specified.
        /// </summary>
        /// <param name="color">The original Color32 instance.</param>
        /// <param name="r">The red component of the new Color32. If null, the red component of the original Color32 is used.</param>
        /// <param name="g">The green component of the new Color32. If null, the green component of the original Color32 is used.</param>
        /// <param name="b">The blue component of the new Color32. If null, the blue component of the original Color32 is used.</param>
        /// <param name="a">The alpha component of the new Color32. If null, the alpha component of the original Color32 is used.</param>
        /// <returns>A new Color32 instance with the specified red, green, blue, and alpha components.</returns>
        public static Color32 With(in this Color32 color, byte? r = null, byte? g = null, byte? b = null, byte? a = null)
        {
            var result = new Color32(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);
            return result;
        }
        #endregion
        
        #region RGB
        /// <summary>
        /// Sets the red component of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <param name="r">The red component to set.</param>
        /// <returns>The Color instance with the new red component.</returns>
        public static Color SetR(this ref Color color, float r)
        {
            r = Mathf.Clamp01(r);
            color.r = r;
            return color;
        }
        
        /// <summary>
        /// Sets the green component of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <param name="g">The green component to set.</param>
        /// <returns>The Color instance with the new green component.</returns>
        public static Color SetG(this ref Color color, float g)
        {
            g = Mathf.Clamp01(g);
            color = new Color(color.r, g, color.b, color.a);
            return color;
        }
        
        /// <summary>
        /// Sets the blue component of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <param name="b">The blue component to set.</param>
        /// <returns>The Color instance with the new blue component.</returns>
        public static Color SetB(this ref Color color, float b)
        {
            b = Mathf.Clamp01(b);
            color = new Color(color.r, color.g, b, color.a);
            return color;
        }
        
        /// <summary>
        /// Sets the alpha component of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <param name="a">The alpha component to set.</param>
        /// <returns>The Color instance with the new alpha component.</returns>
        public static Color SetA(this ref Color color, float a)
        {
            a = Mathf.Clamp01(a);
            color.a = a;
            return color;
        }
        
        /// <summary>
        /// Gets the RGB value of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <returns>The RGB value of the Color instance.</returns>
        public static int GetRgbValue(this Color color)
        {
            var r = (int) (color.r * 255);
            var g = (int) (color.g * 255);
            var b = (int) (color.b * 255);
            return r * 255 * 255 + g * 255 + b;
        }
        #endregion
        
        #region HSV
        /// <summary>
        /// Gets the hue of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <returns>The hue of the Color instance.</returns>
        public static float GetH(this Color color)
        {
            Color.RGBToHSV(color, out var h, out _, out _);
            return h;
        }
        
        /// <summary>
        /// Gets the saturation of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <returns>The saturation of the Color instance.</returns>
        public static float GetS(this Color color)
        {
            Color.RGBToHSV(color, out _, out var s, out _);
            return s;
        }
        
        /// <summary>
        /// Gets the value of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <returns>The value of the Color instance.</returns>
        public static float GetV(this Color color)
        {
            Color.RGBToHSV(color, out _, out _, out var v);
            return v;
        }
        
        /// <summary>
        /// Sets the hue of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <param name="h">The hue to set.</param>
        /// <returns>The Color instance with the new hue.</returns>
        public static Color SetH(this ref Color color, float h)
        {
            Color.RGBToHSV(color, out _, out var ts, out var tv);
            var tc = Color.HSVToRGB(h, ts, tv);
            color.r = tc.r;
            color.g = tc.g;
            color.b = tc.b;
            return color;
        }
        
        /// <summary>
        /// Sets the saturation of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <param name="s">The saturation to set.</param>
        /// <returns>The Color instance with the new saturation.</returns>
        public static Color SetS(this ref Color color, float s)
        {
            Color.RGBToHSV(color, out var th, out _, out var tv);
            var tc = Color.HSVToRGB(th, s, tv);
            color.r = tc.r;
            color.g = tc.g;
            color.b = tc.b;
            return color;
        }
        
        /// <summary>
        /// Sets the value of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <param name="v">The value to set.</param>
        /// <returns>The Color instance with the new value.</returns>
        public static Color SetV(this ref Color color, float v)
        {
            Color.RGBToHSV(color, out var th, out var ts, out _);
            var tc = Color.HSVToRGB(th, ts, v);
            color.r = tc.r;
            color.g = tc.g;
            color.b = tc.b;
            return color;
        }
        
        /// <summary>
        /// Sets the hue, saturation, and value of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <param name="h">The hue to set.</param>
        /// <param name="s">The saturation to set.</param>
        /// <param name="v">The value to set.</param>
        /// <returns>The Color instance with the new hue, saturation, and value.</returns>
        public static Color SetHsv(this ref Color color, float h, float s, float v)
        {
            var tc = Color.HSVToRGB(h, s, v);
            color.r = tc.r;
            color.g = tc.g;
            color.b = tc.b;
            return color;
        }
        #endregion
        
        #region Color SDR
        /// <summary>
        /// Gets the complementary color of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <param name="inverseAlpha">Whether to inverse the alpha component or not. Default is false.</param>
        /// <returns>The complementary color of the Color instance.</returns>
        public static Color ComplementaryColor(this Color color, bool inverseAlpha = false)
        {
            var result = new Color(
                1f - color.r,
                1f - color.g,
                1f - color.b,
                inverseAlpha ? 1f - color.a : color.a);
            return result;
        }
        
        /// <summary>
        /// Gets the gray level of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <returns>The gray level of the Color instance.</returns>
        public static float GrayLevel(this Color color)
        {
            var result = (color.r + color.g + color.b) / 3f;
            return result;
        }
        
        /// <summary>
        /// Gets the perceived brightness of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <returns>The perceived brightness of the Color instance.</returns>
        public static float GetPerceivedBrightness(this Color color)
        {
            var result = Mathf.Sqrt(
                0.241f * color.r * color.r +
                0.691f * color.g * color.g +
                0.068f * color.b * color.b);
            return result;
        }
        #endregion
        
        #region ARGB32
        /// <summary>
        /// Converts a Color instance to a 32-bit ARGB value.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <returns>A 32-bit unsigned integer representing the ARGB value of the Color instance.</returns>
        public static uint ToArgb32(this Color color)
        {
            var result = ((uint)(color.a * 255) << 24)
                         | ((uint)(color.r * 255) << 16)
                         | ((uint)(color.g * 255) << 8)
                         | ((uint)(color.b * 255));
            return result;
        }

        /// <summary>
        /// Converts a 32-bit ARGB value to a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <param name="argb32">The 32-bit ARGB value.</param>
        /// <returns>A Color instance representing the ARGB value.</returns>
        public static Color FromArgb32(this ref Color color, uint argb32)
        {
            var result = new Color(
                ((argb32 >> 16) & 0xFF) / 255f,
                ((argb32 >> 8) & 0xFF) / 255f,
                ((argb32) & 0xFF) / 255f,
                ((argb32 >> 24) & 0xFF) / 255f);
            return result;
        }
        #endregion

        #region Normalize
        /// <summary>
        /// Normalizes the RGB components of a Color instance.
        /// </summary>
        /// <param name="color">The Color instance.</param>
        /// <returns>The Color instance with normalized RGB components.</returns>
        public static Color Normalize(this ref Color color)
        {
            var vector = new Vector3(color.r, color.g, color.b).normalized;
            color.r = vector.x;
            color.g = vector.y;
            color.b = vector.z;
            return color;
        }
        #endregion
        
        #region Clamp
        /// <summary>
        /// Clamps the RGBA components of a Color instance between specified minimum and maximum values.
        /// </summary>
        /// <param name="value">The Color instance.</param>
        /// <param name="min">The minimum value for the RGBA components.</param>
        /// <param name="max">The maximum value for the RGBA components.</param>
        /// <returns>The Color instance with clamped RGBA components.</returns>
        public static Color Clamp(this ref Color value, float min, float max)
        {
            var result = new Color(
                Mathf.Clamp(value.r, min, max),
                Mathf.Clamp(value.g, min, max),
                Mathf.Clamp(value.b, min, max),
                Mathf.Clamp(value.a, min, max)
            );
            return result;
        }
        
        /// <summary>
        /// Clamps the RGBA components of a Color instance between specified minimum and maximum Color values.
        /// </summary>
        /// <param name="value">The Color instance.</param>
        /// <param name="min">The minimum Color value for the RGBA components.</param>
        /// <param name="max">The maximum Color value for the RGBA components.</param>
        /// <returns>The Color instance with clamped RGBA components.</returns>
        public static Color Clamp(this ref Color value, Color min, Color max)
        {
            float t;
            if (min.r > max.r)
            {
                t = min.r;
                min.r = max.r;
                max.r = t;
            }
        
            if (min.g > max.g)
            {
                t = min.g;
                min.g = max.g;
                max.g = t;
            }
        
            if (min.b > max.b)
            {
                t = min.b;
                min.b = max.b;
                max.b = t;
            }
        
            if (min.a > max.a)
            {
                t = min.a;
                min.a = max.a;
                max.a = t;
            }
        
            var result = new Color(
                Mathf.Clamp(value.r, min.r, max.r),
                Mathf.Clamp(value.g, min.g, max.g),
                Mathf.Clamp(value.b, min.b, max.b),
                Mathf.Clamp(value.a, min.a, max.a)
            );
        
            return result;
        }
        #endregion
    }
}