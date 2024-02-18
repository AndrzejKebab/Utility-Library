using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace UtilityLibrary.Unity.Runtime
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    public struct sbyte4 : IEquatable<sbyte4>, IFormattable
    {
        public sbyte x, y, z, w;

        public static readonly sbyte4 Zero = new(0, 0, 0, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte x, sbyte y, sbyte z, sbyte w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(sbyte4 rhs)
        {
            return x == rhs.x && y == rhs.y && z == rhs.z && w == rhs.w;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object o)
        {
            return o is sbyte4 converted && Equals(converted);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("sbyte4({0}, {1}, {2}, {3})", x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("sbyte4({0}, {1}, {2}, {3})", x.ToString(format, formatProvider),
                y.ToString(format, formatProvider), z.ToString(format, formatProvider),
                w.ToString(format, formatProvider));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator +(sbyte4 lhs, sbyte4 rhs)
        {
            return new sbyte4((sbyte)(lhs.x + rhs.x), (sbyte)(lhs.y + rhs.y), (sbyte)(lhs.z + rhs.z),
                (sbyte)(lhs.w + rhs.w));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator *(sbyte4 lhs, sbyte4 rhs)
        {
            return new sbyte4((sbyte)(lhs.x * rhs.x), (sbyte)(lhs.y * rhs.y), (sbyte)(lhs.z * rhs.z),
                (sbyte)(lhs.w * rhs.w));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator *(sbyte4 lhs, sbyte rhs)
        {
            return new sbyte4((sbyte)(lhs.x * rhs), (sbyte)(lhs.y * rhs), (sbyte)(lhs.z * rhs),
                (sbyte)(lhs.w * rhs));
        }

        /// <summary>Returns the sbyte element at a specified index.</summary>
        public unsafe sbyte this[int index]
        {
            get
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if ((uint)index >= 4)
                    throw new ArgumentException("index must be between[0...3]");
#endif
                fixed (sbyte4* array = &this)
                {
                    return ((sbyte*)array)[index];
                }
            }
            set
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if ((uint)index >= 4)
                    throw new ArgumentException("index must be between[0...2]");
#endif
                fixed (sbyte* array = &x)
                {
                    array[index] = value;
                }
            }
        }

        internal sealed class DebuggerProxy
        {
            public sbyte x;
            public sbyte y;
            public sbyte z;
            public sbyte w;

            public DebuggerProxy(sbyte4 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
                w = v.w;
            }
        }
    }
}