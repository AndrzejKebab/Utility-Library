using UnityEngine;

namespace UtilityLibrary.Unity.Runtime.Values
{
    public static partial class DecimalExtensions
    {
        public static decimal AtLeast(this decimal value, decimal min) => MathfExtensions.Max(value, min);
        public static decimal AtMost(this decimal value, decimal max) => MathfExtensions.Min(value, max);
    }
}