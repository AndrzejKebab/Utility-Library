using UnityEngine;

namespace UtilityLibrary.Unity.Runtime.Values
{
    public static partial class ShortExtensions
    {
        public static short AtLeast(this short value, short min) => MathfExtensions.Max(value, min);
        public static short AtMost(this short value, short max) => MathfExtensions.Min(value, max);
        
        public static bool Approx(this short f1, short f2) => Mathf.Approximately(f1, f2);
    }
}