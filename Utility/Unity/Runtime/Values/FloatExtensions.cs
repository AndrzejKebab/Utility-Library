using UnityEngine;

namespace UtilityLibrary.Unity.Runtime.Values
{
    public static partial class FloatExtensions
    {
        public static float AtLeast(this float value, float min) => Mathf.Max(value, min);
        public static float AtMost(this float value, float max) => Mathf.Min(value, max);
        
        public static bool Approx(this float f1, float f2) => Mathf.Approximately(f1, f2);
    }
}