using UnityEngine;
using UnityEngine.Rendering;

namespace UtilityLibrary.Unity.Runtime
{
    public static class VolumeExtensions
    {
        #region LoadVolumeProfile
        /// <summary>
        /// Loads a VolumeProfile from a specified path and assigns it to the Volume instance.
        /// </summary>
        /// <param name="volume">The Volume instance to which the VolumeProfile should be assigned.</param>
        /// <param name="path">The path from where the VolumeProfile should be loaded.</param>
        public static void LoadVolumeProfile(this Volume volume, string path) 
        {
            var profile = Resources.Load<VolumeProfile>(path);
            volume.profile = profile;
        }
        #endregion
    }
}