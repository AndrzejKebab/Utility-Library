#if ENABLED_UNITY_MATHEMATICS
using Unity.Mathematics;

namespace UtilityLibrary.Unity.Runtime.Values
{
    public static partial class HalfExtensions
    {
        public static half AtLeast(this half value, half max) => MathfExtensions.Max(value, max);
        public static half AtMost(this half value, half max) => MathfExtensions.Min(value, max);
    }
}
#endif