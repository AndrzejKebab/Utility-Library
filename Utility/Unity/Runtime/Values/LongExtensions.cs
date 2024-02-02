using UnityEngine;

namespace UtilityLibrary.Unity.Runtime.Values
{
    public static partial class LongExtensions
    {
        public static long AtLeast(this long value, long min) => MathfExtensions.Max(value, min);
        public static long AtMost(this long value, long max) => MathfExtensions.Min(value, max);
        
        public static bool Approx(this long f1, long f2) => Mathf.Approximately(f1, f2);
    }
}