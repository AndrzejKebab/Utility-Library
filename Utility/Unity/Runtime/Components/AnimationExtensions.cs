using System;
using UnityEngine;
using UtilityLibrary.Core.LinqReplacement;

namespace UtilityLibrary.Unity.Runtime
{
    public static class AnimationExtensions
    {
        #region Event
        /// <summary>
        /// Adds an event to the specified animation clip.
        /// </summary>
        /// <param name="animation">The animation to add the event to.</param>
        /// <param name="clipName">The name of the clip to add the event to.</param>
        /// <param name="methodName">The name of the method to be called when the event is triggered.</param>
        /// <param name="time">The time at which the event should be triggered.</param>
        /// <returns>The animation with the added event.</returns>
        public static Animation AddEvent(this Animation animation, string clipName, string methodName, float time)
        {
            var clip = animation[clipName].clip;
            var animationEvent = new AnimationEvent
            {
                functionName = methodName,
                time = time
            };
            clip.AddEvent(animationEvent);
            return animation;
        }

        /// <summary>
        /// Removes an event from the specified animation clip.
        /// </summary>
        /// <param name="animation">The animation to remove the event from.</param>
        /// <param name="clipName">The name of the clip to remove the event from.</param>
        /// <param name="methodName">The name of the method associated with the event to be removed.</param>
        /// <returns>The animation with the removed event.</returns>
        public static Animation RemoveEvent(this Animation animation, string clipName, string methodName)
        {
            var clip = animation[clipName].clip;
            var list = clip.events.ToList();
            for (var i = 0; i < list.Count; i++)
            {
                var e = list[i];
                if (e.functionName != methodName) continue;
                list.Remove(e);
                break;
            }

            clip.events = list.ToArray();
            return animation;
        }
        #endregion

        /// <summary>
        /// Sets the speed of the animation.
        /// </summary>
        /// <param name="animation">The animation to set the speed of.</param>
        /// <param name="speed">The speed to set.</param>
        /// <returns>The animation with the set speed.</returns>
        public static Animation SetSpeed(this Animation animation, float speed)
        {
            animation[animation.clip.name].speed = speed;
            return animation;
        }

        /// <summary>
        /// Sets the time of the animation.
        /// </summary>
        /// <param name="animation">The animation to set the time of.</param>
        /// <param name="time">The time to set.</param>
        /// <returns>The animation with the set time.</returns>
        public static Animation SetTime(this Animation animation, float time)
        {
            var clip = animation[animation.clip.name].clip;
            clip.SampleAnimation(animation.gameObject, time);
            return animation;
        }

        /// <summary>
        /// Sets the progress of the animation.
        /// </summary>
        /// <param name="animation">The animation to set the progress of.</param>
        /// <param name="progress">The progress to set.</param>
        /// <returns>The animation with the set progress.</returns>
        public static Animation SetProgress(this Animation animation, float progress)
        {
            var clip = animation[animation.clip.name].clip;
            var time = clip.length * progress;
            clip.SampleAnimation(animation.gameObject, time);
            return animation;
        }

        /// <summary>
        /// Gets the currently playing clip of the animation.
        /// </summary>
        /// <param name="animation">The animation to get the playing clip from.</param>
        /// <returns>The currently playing clip.</returns>
        public static AnimationClip GetPlayingClip(this Animation animation)
        {
            AnimationClip clip = null;
            var weight = 0f;
            var enumerator = animation.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    var current = (AnimationState) enumerator.Current;
                    if (current == null) continue;
                    if (!current.enabled || (!(weight < current.weight))) continue;
                    weight = current.weight;
                    clip = current.clip;
                }
            }
            finally
            {
                if (enumerator is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }

            return clip;
        }
    }
}