using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class BehaviourExtension
    {
        /// <summary>
        /// Enables a Behaviour instance.
        /// </summary>
        /// <param name="behaviour">The Behaviour instance.</param>
        /// <returns>The enabled Behaviour instance.</returns>
        public static T Enable<T>(this T behaviour) where T : Behaviour
        {
            behaviour.enabled = true;
            return behaviour;
        }

        /// <summary>
        /// Disables a Behaviour instance.
        /// </summary>
        /// <param name="behaviour">The Behaviour instance.</param>
        /// <returns>The disabled Behaviour instance.</returns>
        public static T Disable<T>(this T behaviour) where T : Behaviour
        {
            behaviour.enabled = false;
            return behaviour;
        }
    }
}