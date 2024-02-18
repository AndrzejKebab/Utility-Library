#if ENABLED_UNITY_MATHEMATICS
using Unity.Mathematics;
#endif

namespace UtilityLibrary.Unity.Runtime
{
    public static class MathfExtensions
    {
        #region Min

        public static byte Min(byte a, byte b)
        {
            return a < b ? a : b;
        }

        public static byte Min(params byte[] values)
        {
            var num = values.Length;
            if (num == 0) return 0;

            var num2 = values[0];
            for (var i = 1; i < num; i++)
                if (values[i] < num2)
                    num2 = values[i];

            return num2;
        }

        public static short Min(short a, short b)
        {
            return a < b ? a : b;
        }

        public static short Min(params short[] values)
        {
            var num = values.Length;
            if (num == 0) return 0;

            var num2 = values[0];
            for (var i = 1; i < num; i++)
                if (values[i] < num2)
                    num2 = values[i];

            return num2;
        }

        public static long Min(long a, long b)
        {
            return a < b ? a : b;
        }

        public static long Min(params long[] values)
        {
            var num = values.Length;
            if (num == 0) return 0L;

            var num2 = values[0];
            for (var i = 1; i < num; i++)
                if (values[i] < num2)
                    num2 = values[i];

            return num2;
        }

#if ENABLED_UNITY_MATHEMATICS
        public static half Min(half a, half b)
        {
            return a < b ? a : b;
        }

        public static half Min(params half[] values)
        {
            var num = values.Length;
            if (num == 0) return (half)0;

            var num2 = values[0];
            for (var i = 1; i < num; i++)
                if (values[i] < num2)
                    num2 = values[i];

            return num2;
        }
#endif

        public static decimal Min(decimal a, decimal b)
        {
            return a < b ? a : b;
        }

        public static decimal Min(params decimal[] values)
        {
            var num = values.Length;
            if (num == 0) return 0m;

            var num2 = values[0];
            for (var i = 1; i < num; i++)
                if (values[i] < num2)
                    num2 = values[i];

            return num2;
        }

        public static double Min(double a, double b)
        {
            return a < b ? a : b;
        }

        public static double Min(params double[] values)
        {
            var num = values.Length;
            if (num == 0) return 0f;

            var num2 = values[0];
            for (var i = 1; i < num; i++)
                if (values[i] < num2)
                    num2 = values[i];

            return num2;
        }

        #endregion

        #region Max

        public static byte Max(byte a, byte b)
        {
            return a > b ? a : b;
        }

        public static byte Max(params byte[] values)
        {
            var num = values.Length;
            if (num == 0) return 0;

            var num2 = values[0];
            for (var i = 1; i < num; i++)
                if (values[i] > num2)
                    num2 = values[i];

            return num2;
        }

        public static short Max(short a, short b)
        {
            return a > b ? a : b;
        }

        public static short Max(params short[] values)
        {
            var num = values.Length;
            if (num == 0) return 0;

            var num2 = values[0];
            for (var i = 1; i < num; i++)
                if (values[i] > num2)
                    num2 = values[i];

            return num2;
        }

        public static long Max(long a, long b)
        {
            return a > b ? a : b;
        }

        public static long Max(params long[] values)
        {
            var num = values.Length;
            if (num == 0) return 0L;

            var num2 = values[0];
            for (var i = 1; i < num; i++)
                if (values[i] > num2)
                    num2 = values[i];

            return num2;
        }

#if ENABLED_UNITY_MATHEMATICS
        public static half Max(half a, half b)
        {
            return a > b ? a : b;
        }

        public static half Max(params half[] values)
        {
            var num = values.Length;
            if (num == 0) return (half)0;

            var num2 = values[0];
            for (var i = 1; i < num; i++)
                if (values[i] > num2)
                    num2 = values[i];

            return num2;
        }
#endif

        public static decimal Max(decimal a, decimal b)
        {
            return a > b ? a : b;
        }

        public static decimal Max(params decimal[] values)
        {
            var num = values.Length;
            if (num == 0) return 0m;

            var num2 = values[0];
            for (var i = 1; i < num; i++)
                if (values[i] > num2)
                    num2 = values[i];

            return num2;
        }

        public static double Max(double a, double b)
        {
            return a > b ? a : b;
        }

        public static double Max(params double[] values)
        {
            var num = values.Length;
            if (num == 0) return 0f;

            var num2 = values[0];
            for (var i = 1; i < num; i++)
                if (values[i] > num2)
                    num2 = values[i];

            return num2;
        }

        #endregion
    }
}