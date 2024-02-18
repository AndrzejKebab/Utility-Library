using UnityEngine;

namespace UtilityLibrary.Unity.Runtime.Values
{
    public static partial class IntExtensions
    {
        public static int AtLeast(this int value, int min) => Mathf.Max(value, min);
        public static int AtMost(this int value, int max) => Mathf.Min(value, max);
        public static int CubedSize(this int num) => (2 * num + 1) * (2 * num + 1) * (2 * num + 1);
        public static int CubedSizeY(this int num, int y) => (2 * num + 1) * (2 * num + 1) * (2 * y + 1);
        public static int Size(this Vector3Int vec) => vec.x * vec.y * vec.z;
        public static bool Approx(this int f1, int f2) => Mathf.Approximately(f1, f2);
    }
}