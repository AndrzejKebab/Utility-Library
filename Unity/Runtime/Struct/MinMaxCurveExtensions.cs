using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class MinMaxCurveExtensions
    {
        /// <summary>
        /// Gets the maximum value of a MinMaxCurve.
        /// </summary>
        /// <param name="minMaxCurve">The MinMaxCurve instance.</param>
        /// <returns>The maximum value of the MinMaxCurve.</returns>
        public static float GetMaxValue(this ParticleSystem.MinMaxCurve minMaxCurve)
        {
            switch (minMaxCurve.mode)
            {
                case ParticleSystemCurveMode.Constant:
                    return minMaxCurve.constant;
                case ParticleSystemCurveMode.Curve:
                    return minMaxCurve.curve.GetMaxValue();
                case ParticleSystemCurveMode.TwoConstants:
                    return minMaxCurve.constantMax;
                case ParticleSystemCurveMode.TwoCurves:
                    var ret1 = minMaxCurve.curveMin.GetMaxValue();
                    var ret2 = minMaxCurve.curveMax.GetMaxValue();
                    return ret1 > ret2 ? ret1 : ret2;
            }
            return -1f;
        }

        /// <summary>
        /// Gets the minimum value of a MinMaxCurve.
        /// </summary>
        /// <param name="minMaxCurve">The MinMaxCurve instance.</param>
        /// <returns>The minimum value of the MinMaxCurve.</returns>
        public static float GetMinValue(this ParticleSystem.MinMaxCurve minMaxCurve)
        {
            switch (minMaxCurve.mode)
            {
                case ParticleSystemCurveMode.Constant:
                    return minMaxCurve.constant;
                case ParticleSystemCurveMode.Curve:
                    return minMaxCurve.curve.GetMinValue();
                case ParticleSystemCurveMode.TwoConstants:
                    return minMaxCurve.constantMin;
                case ParticleSystemCurveMode.TwoCurves:
                    var ret1 = minMaxCurve.curveMin.GetMinValue();
                    var ret2 = minMaxCurve.curveMax.GetMinValue();
                    return ret1 < ret2 ? ret1 : ret2;
            }
            return -1f;
        }
    }
}