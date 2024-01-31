using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class AnimatorExtensions
    {
        #region Parameter
        /// <summary>
        /// Resets all parameters of the animator to their default values.
        /// </summary>
        /// <param name="animator">The animator to reset the parameters of.</param>
        public static void ResetParameters(this Animator animator)
        {
            for (var i = 0; i < animator.parameters.Length; i++)
            {
                var param = animator.parameters[i];
                switch (param.type)
                {
                    case AnimatorControllerParameterType.Bool:
                        animator.SetBool(param.name, param.defaultBool);
                        break;
                    case AnimatorControllerParameterType.Int:
                        animator.SetInteger(param.name, param.defaultInt);
                        break;
                    case AnimatorControllerParameterType.Float:
                        animator.SetFloat(param.name, param.defaultFloat);
                        break;
                    case AnimatorControllerParameterType.Trigger:
                        animator.ResetTrigger(param.name);
                        break;
                }
            }
        }

        /// <summary>
        /// Checks if a parameter with the specified name exists in the animator.
        /// </summary>
        /// <param name="animator">The animator to check the parameter in.</param>
        /// <param name="parameterName">The name of the parameter to check.</param>
        /// <returns>True if the parameter exists, false otherwise.</returns>
        public static bool CheckParameterExist(this Animator animator, string parameterName)
        {
            for (var i = 0; i < animator.parameters.Length; i++)
            {
                var parameter = animator.parameters[i];
                if (parameter.name == parameterName) return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a parameter with the specified name and type exists in the animator.
        /// </summary>
        /// <param name="animator">The animator to check the parameter in.</param>
        /// <param name="parameterName">The name of the parameter to check.</param>
        /// <param name="type">The type of the parameter to check.</param>
        /// <returns>True if the parameter exists and is of the specified type, false otherwise.</returns>
        public static bool CheckParameterExist(this Animator animator, string parameterName, AnimatorControllerParameterType type)
        {
            for (var i = 0; i < animator.parameters.Length; i++)
            {
                var parameter = animator.parameters[i];
                if (parameter.name == parameterName && parameter.type == type) return true;
            }

            return false;
        }
        #endregion

        #region Clip
        /// <summary>
        /// Checks if a clip with the specified name exists in the animator.
        /// </summary>
        /// <param name="animator">The animator to check the clip in.</param>
        /// <param name="clipName">The name of the clip to check.</param>
        /// <returns>True if the clip exists, false otherwise.</returns>
        public static bool CheckClipExist(this Animator animator, string clipName)
        {
            var controller = animator.runtimeAnimatorController;
            if (controller == null) return false;
            var clips = controller.animationClips;
            for (var i = 0; i < clips.Length; i++)
            {
                var clip = clips[i];
                if (clip.name == clipName) return true;
            }

            return false;
        }
        #endregion

        #region Layer
        /// <summary>
        /// Gets the weight of the specified layer in the animator.
        /// </summary>
        /// <param name="animator">The animator to get the layer weight from.</param>
        /// <param name="layerName">The name of the layer to get the weight of.</param>
        /// <returns>The weight of the specified layer.</returns>
        public static float GetLayerWeight(this Animator animator, string layerName)
        {
            var layerIndex = animator.GetLayerIndex(layerName);
            var weight = animator.GetLayerWeight(layerIndex);
            return weight;
        }

        /// <summary>
        /// Sets the weight of the specified layer in the animator.
        /// </summary>
        /// <param name="animator">The animator to set the layer weight in.</param>
        /// <param name="layerName">The name of the layer to set the weight of.</param>
        /// <param name="weight">The weight to set.</param>
        public static void SetLayerWeight(this Animator animator, string layerName, float weight)
        {
            var layerIndex = animator.GetLayerIndex(layerName);
            animator.SetLayerWeight(layerIndex, weight);
        }

        /// <summary>
        /// Checks if a layer with the specified name exists in the animator.
        /// </summary>
        /// <param name="animator">The animator to check the layer in.</param>
        /// <param name="layerName">The name of the layer to check.</param>
        /// <returns>True if the layer exists, false otherwise.</returns>
        public static bool CheckLayerExist(this Animator animator, string layerName)
        {
            for (var i = 0; i < animator.layerCount; i++)
            {
                var name = animator.GetLayerName(i);
                if (name == layerName)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Animator State Info
        /// <summary>
        /// Gets the current state information of the specified layer in the animator.
        /// </summary>
        /// <param name="animator">The animator to get the state information from.</param>
        /// <param name="layerName">The name of the layer to get the state information of.</param>
        /// <returns>The current state information of the specified layer.</returns>
        public static AnimatorStateInfo GetCurrentAnimatorStateInfo(this Animator animator, string layerName)
        {
            var layerIndex = animator.GetLayerIndex(layerName);
            var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
            return animatorStateInfo;
        }
        #endregion
    }
}