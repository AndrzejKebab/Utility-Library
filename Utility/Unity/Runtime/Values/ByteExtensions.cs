using UnityEngine;

namespace UtilityLibrary.Unity.Runtime.Values
{
    public static partial class ByteExtensions
    {
        public static byte AtLeast(this byte value, byte min) => MathfExtensions.Max(value, min);
        public static byte AtMost(this byte value, byte max) => MathfExtensions.Min(value, max);
        
        public static bool Approx(this byte f1, byte f2) => Mathf.Approximately(f1, f2);
    }
}