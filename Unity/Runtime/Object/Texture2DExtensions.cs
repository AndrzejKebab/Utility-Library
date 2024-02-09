using System.IO;
using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class Texture2DExtensions
    {
        #region Load File
        /// <summary>
        /// Loads a Texture2D from a file.
        /// </summary>
        /// <param name="texture2D">The Texture2D instance.</param>
        /// <param name="path">The path to the file.</param>
        public static void LoadFromFile(this Texture2D texture2D, string path)
        {
            var bytes = File.ReadAllBytes(path);
            texture2D.LoadImage(bytes);
        }
        #endregion

        #region Save File
        /// <summary>
        /// Saves a Texture2D to a file.
        /// </summary>
        /// <param name="texture2D">The Texture2D instance.</param>
        /// <param name="path">The path to the file.</param>
        public static void SaveToFile(this Texture2D texture2D, string path)
        {
            SaveToFilePng(texture2D, path);
        }

        /// <summary>
        /// Saves a Texture2D to a EXR file.
        /// </summary>
        /// <param name="texture2D">The Texture2D instance.</param>
        /// <param name="path">The path to the file.</param>
        public static void SaveToFileExr(this Texture2D texture2D, string path)
        {
            var bytes = texture2D.EncodeToEXR();
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// Saves a Texture2D to a TGA file.
        /// </summary>
        /// <param name="texture2D">The Texture2D instance.</param>
        /// <param name="path">The path to the file.</param>
        public static void SaveToFileTga(this Texture2D texture2D, string path)
        {
            var bytes = texture2D.EncodeToTGA();
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// Saves a Texture2D to a JPG file.
        /// </summary>
        /// <param name="texture2D">The Texture2D instance.</param>
        /// <param name="path">The path to the file.</param>
        public static void SaveToFileJpg(this Texture2D texture2D, string path)
        {
            var bytes = texture2D.EncodeToJPG();
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// Saves a Texture2D to a PNG file.
        /// </summary>
        /// <param name="texture2D">The Texture2D instance.</param>
        /// <param name="path">The path to the file.</param>
        public static void SaveToFilePng(this Texture2D texture2D, string path)
        {
            var bytes = texture2D.EncodeToPNG();
            File.WriteAllBytes(path, bytes);
        }
        #endregion
    }
}