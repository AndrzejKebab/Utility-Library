namespace UtilityLibrary.Unity.Runtime.Values
{
    public static partial class DoubleExtensions
    {
        public static double AtLeast(this double value, double min) => MathfExtensions.Max(value, min);
        public static double AtMost(this double value, double min) => MathfExtensions.Min(value, min);
    }
}