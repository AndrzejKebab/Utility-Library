using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class CameraExtensions
    {
        #region Viewport
        /// <summary>
        /// Calculates and returns viewport extents with an optional margin. Useful for calculating a frustum for culling.
        /// </summary>
        /// <param name="camera">The camera object this method extends.</param>
        /// <param name="viewportMargin">Optional margin to be applied to viewport extents. Default is 0.2, 0.2.</param>
        /// <returns>Viewport extents as a Vector2 after applying the margin.</returns>
        public static Vector2 GetViewportExtentsWithMargin(this Camera camera, Vector2? viewportMargin = null) 
        {
            var margin = viewportMargin ?? new Vector2(0.2f, 0.2f);

            Vector2 result;
            var halfFieldOfView = camera.fieldOfView * 0.5f * Mathf.Deg2Rad;
            result.y = camera.nearClipPlane * Mathf.Tan(halfFieldOfView);
            result.x = result.y * camera.aspect + margin.x;
            result.y += margin.y;
            return result;
        }
        #endregion
        
        #region Coordinate
        /// <summary>
        /// Converts a screen point to a world point, ignoring the depth component.
        /// </summary>
        /// <param name="camera">The camera to perform the conversion with.</param>
        /// <param name="position">The screen position to convert.</param>
        /// <returns>The converted world position.</returns>
        public static Vector3 ScreenToWorldPointIgnoreDeep(this Camera camera, Vector3 position)
        {
            var deep = camera.transform.position.z;
            var result = camera.ScreenToWorldPoint(new Vector3(position.x, position.y, deep));
            return result;
        }
        #endregion

        #region Meter / Pixel
        /// <summary>
        /// Calculates the size of a meter in pixels for an orthographic camera.
        /// </summary>
        /// <param name="orthographicCamera">The orthographic camera to perform the calculation with.</param>
        /// <returns>The size of a meter in pixels.</returns>
        public static float MetersPerPixel(this Camera orthographicCamera)
        {
            var result = orthographicCamera.orthographicSize * 2 / Screen.height;
            return result;
        }

        /// <summary>
        /// Calculates the size of a pixel in meters for an orthographic camera.
        /// </summary>
        /// <param name="orthographicCamera">The orthographic camera to perform the calculation with.</param>
        /// <returns>The size of a pixel in meters.</returns>
        public static float PixelsPerMeter(this Camera orthographicCamera)
        {
            var result = Screen.height * 0.5f / orthographicCamera.orthographicSize;
            return result;
        }
        #endregion

        #region Capture
        /// <summary>
        /// Captures the current view of the camera as a Texture2D.
        /// </summary>
        /// <param name="camera">The camera to capture the view from.</param>
        /// <returns>The captured view as a Texture2D.</returns>
        public static Texture2D Capture(this Camera camera)
        {
            var texture = camera.Capture(new Rect(0, 0, Screen.width, Screen.height));
            return texture;
        }

        /// <summary>
        /// Captures a portion of the current view of the camera as a Texture2D.
        /// </summary>
        /// <param name="camera">The camera to capture the view from.</param>
        /// <param name="rect">The portion of the view to capture.</param>
        /// <returns>The captured view as a Texture2D.</returns>
        public static Texture2D Capture(this Camera camera, Rect rect)
        {
            var renderTexture = new RenderTexture(Screen.width, Screen.height, 0);
            camera.targetTexture = renderTexture;
            camera.Render();
            RenderTexture.active = renderTexture;
            var screenShot = new Texture2D((int) rect.width, (int) rect.height, TextureFormat.RGB24, false);
            screenShot.ReadPixels(rect, 0, 0);
            screenShot.Apply();
            camera.targetTexture = null;
            RenderTexture.active = null;
            Object.Destroy(renderTexture);

            return screenShot;
        }
        #endregion

        #region Size
        /// <summary>
        /// Converts a size in pixels to a size in world units.
        /// </summary>
        /// <param name="camera">The camera to perform the conversion with.</param>
        /// <param name="pixelSize">The size in pixels to convert.</param>
        /// <param name="clipPlane">The distance from the camera at which the conversion should be performed.</param>
        /// <returns>The converted size in world units.</returns>
        public static float ScreenToWorldSize(this Camera camera, float pixelSize, float clipPlane)
        {
            float result;
            if (camera.orthographic)
            {
                result = pixelSize * camera.orthographicSize * 2f / camera.pixelHeight;
            }
            else
            {
                result = pixelSize * clipPlane * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad) * 2f / camera.pixelHeight;
            }

            return result;
        }

        /// <summary>
        /// Converts a size in world units to a size in pixels.
        /// </summary>
        /// <param name="camera">The camera to perform the conversion with.</param>
        /// <param name="worldSize">The size in world units to convert.</param>
        /// <param name="clipPlane">The distance from the camera at which the conversion should be performed.</param>
        /// <returns>The converted size in pixels.</returns>
        public static float WorldToScreenSize(this Camera camera, float worldSize, float clipPlane)
        {
            float result;
            if (camera.orthographic)
            {
                result = worldSize * camera.pixelHeight * 0.5f / camera.orthographicSize;
            }
            else
            {
                result = worldSize * camera.pixelHeight * 0.5f / (clipPlane * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad));
            }

            return result;
        }
        #endregion

        #region Clip Plane
        /// <summary>
        /// Calculates the clip plane for the camera at a given point.
        /// </summary>
        /// <param name="camera">The camera to calculate the clip plane for.</param>
        /// <param name="point">The point at which to calculate the clip plane.</param>
        /// <param name="normal">The normal of the clip plane.</param>
        /// <returns>The calculated clip plane.</returns>
        public static Vector4 GetClipPlane(this Camera camera, Vector3 point, Vector3 normal)
        {
            var wtoc = camera.worldToCameraMatrix;
            point = wtoc.MultiplyPoint(point);
            normal = wtoc.MultiplyVector(normal).normalized;
            var result = new Vector4(normal.x, normal.y, normal.z, -Vector3.Dot(point, normal));
            return result;
        }
        #endregion

        #region ZBuffer
        /// <summary>
        /// Gets the parameters of the Z buffer for the camera.
        /// </summary>
        /// <param name="camera">The camera to get the Z buffer parameters for.</param>
        /// <returns>The parameters of the Z buffer.</returns>
        public static Vector4 GetZBufferParams(this Camera camera)
        {
            double f = camera.farClipPlane;
            double n = camera.nearClipPlane;

            var rn = 1f / n;
            var rf = 1f / f;
            var fpn = f / n;

            var result = SystemInfo.usesReversedZBuffer
                ? new Vector4((float) (fpn - 1.0), 1f, (float) (rn - rf), (float) rf)
                : new Vector4((float) (1.0 - fpn), (float) fpn, (float) (rf - rn), (float) rn);
            return result;
        }
        #endregion
    }
}