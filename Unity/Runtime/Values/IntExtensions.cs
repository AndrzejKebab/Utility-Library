using UnityEngine;

namespace UtilityLibrary.Unity.Runtime.Values
{
    public static partial class IntExtensions
    {
        public static int AtLeast(this int value, int min) => Mathf.Max(value, min);
        public static int AtMost(this int value, int max) => Mathf.Min(value, max);
        
        public static bool Approx(this int f1, int f2) => Mathf.Approximately(f1, f2);
    }
}