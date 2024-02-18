using Unity.Mathematics;

namespace UtilityLibrary.Unity.Runtime
{
    public static class Int3Extensions
    {
        public static int Flatten(this int3 size, int x, int y, int z) => y * size.x * size.z + z * size.x + x;
        public static int Flatten(this int3 size, int3 index) => index.y * size.x * size.z + index.z * size.x + index.x;
        public static half4 ToHalf4(this int3 v) => new((half)v.x, (half)v.y, (half)v.z, (half)0);
        public static int CubedSize(this int3 size) => (2 * size.x + 1) * (2 * size.y + 1) * (2 * size.z + 1);
        public static int SqrMagnitude(this int3 value) => (value.x * value.x) +
                                                           (value.y * value.y) +
                                                           (value.z * value.z);
    }
}