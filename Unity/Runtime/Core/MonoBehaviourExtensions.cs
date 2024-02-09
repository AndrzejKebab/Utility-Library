using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
public static class MonoBehaviourExtension
    {
        #region Active
        
        /// <summary>
        /// Sets the active state of the GameObject associated with the MonoBehaviour.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="active">The active state to set.</param>
        public static void SetActive(this MonoBehaviour monoBehaviour, bool active)
        {
            monoBehaviour.gameObject.SetActive(active);
        }
        
        #endregion
        
        #region Prefab
        
        /// <summary>
        /// Checks if the GameObject associated with the MonoBehaviour is a prefab.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <returns>True if the GameObject is a prefab, false otherwise.</returns>
        public static bool IsPrefab(this MonoBehaviour monoBehaviour)
        {
            var result = monoBehaviour.gameObject.IsPrefab();
            return result;
        }
        
        #endregion

        #region Coroutine
        #region When
        /// <summary>
        /// Executes an action when a condition is met.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="condition">The condition to check.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteWhen(this MonoBehaviour monoBehaviour, Action action, Func<bool> condition)
        {
            return monoBehaviour.StartCoroutine(ExecuteWhenCoroutine(action, condition));
        }
        
        /// <summary>
        /// Coroutine that waits until a condition is met to execute an action.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="condition">The condition to check.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteWhenCoroutine(Action action, Func<bool> condition)
        {
            while (condition != null && !condition())
            {
                yield return null;
            }
        
            action();
        }
        #endregion
        
        #region Until
        /// <summary>
        /// Executes an action until a condition is met.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="condition">The condition to check.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteUntil(this MonoBehaviour monoBehaviour, Action action, Func<bool> condition)
        {
            return monoBehaviour.StartCoroutine(ExecuteUntilCoroutine(action, condition));
        }
        
        /// <summary>
        /// Coroutine that executes an action until a condition is met.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="condition">The condition to check.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteUntilCoroutine(Action action, Func<bool> condition)
        {
            while (condition != null && !condition())
            {
                action();
                yield return null;
            }
        }
        #endregion
        
        #region Count Until
        /// <summary>
        /// Executes an action a certain number of times or until a condition is met.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="count">The maximum number of times to execute the action.</param>
        /// <param name="condition">The condition to check.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteCountUntil(this MonoBehaviour monoBehaviour, Action action, int count, Func<bool> condition)
        {
            return monoBehaviour.StartCoroutine(ExecuteCountUntilCoroutine(action, count, condition));
        }
        
        /// <summary>
        /// Coroutine that executes an action a certain number of times or until a condition is met.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="count">The maximum number of times to execute the action.</param>
        /// <param name="condition">The condition to check.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteCountUntilCoroutine(Action action, int count, Func<bool> condition)
        {
            var counter = 0;
            while (condition != null && !condition() && counter < count)
            {
                action();
                counter++;
                yield return null;
            }
        }
        #endregion
        
        #region Interval Until
        /// <summary>
        /// Executes an action at a certain interval a certain number of times or until a condition is met.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval in seconds between each execution.</param>
        /// <param name="count">The maximum number of times to execute the action.</param>
        /// <param name="condition">The condition to check.</param>
        /// <param name="timeScale">Whether to use scaled or unscaled time.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteIntervalUntil(this MonoBehaviour monoBehaviour, Action action, float interval, int count, Func<bool> condition, bool timeScale = true)
        {
            return monoBehaviour.StartCoroutine(ExecuteIntervalUntilCoroutine(action, count, interval, condition, timeScale));
        }
        
        /// <summary>
        /// Coroutine that executes an action at a certain interval a certain number of times or until a condition is met.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="count">The maximum number of times to execute the action.</param>
        /// <param name="interval">The interval in seconds between each execution.</param>
        /// <param name="condition">The condition to check.</param>
        /// <param name="timeScale">Whether to use scaled or unscaled time.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteIntervalUntilCoroutine(Action action, int count, float interval, Func<bool> condition, bool timeScale)
        {
            var counter = 0;
            while (condition != null && !condition() && counter < count)
            {
                action();
                counter++;
                if (timeScale)
                {
                    yield return WaitForSeconds(interval);
                }
                else
                {
                    yield return WaitForSecondsRealtime(interval);
                }
            }
        }
        
        /// <summary>
        /// Executes an action at a certain interval until a condition is met.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval in seconds between each execution.</param>
        /// <param name="condition">The condition to check.</param>
        /// <param name="timeScale">Whether to use scaled or unscaled time.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteIntervalUntil(this MonoBehaviour monoBehaviour, Action action, float interval, Func<bool> condition, bool timeScale = true)
        {
            return monoBehaviour.StartCoroutine(ExecuteIntervalUntilCoroutine(action, interval, condition, timeScale));
        }
        
        /// <summary>
        /// Coroutine that executes an action at a certain interval until a condition is met.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval in seconds between each execution.</param>
        /// <param name="condition">The condition to check.</param>
        /// <param name="timeScale">Whether to use scaled or unscaled time.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteIntervalUntilCoroutine(Action action, float interval, Func<bool> condition, bool timeScale)
        {
            while (condition != null && !condition())
            {
                action();
                if (timeScale)
                {
                    yield return WaitForSeconds(interval);
                }
                else
                {
                    yield return WaitForSecondsRealtime(interval);
                }
            }
        }
        #endregion
        
        #region If Until
        /// <summary>
        /// Executes an action if a certain condition is met until another condition is met.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="executeCondition">The condition to check for executing the action.</param>
        /// <param name="finishCondition">The condition to check for finishing the execution.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteIfUntil(this MonoBehaviour monoBehaviour, Action action, Func<bool> executeCondition, Func<bool> finishCondition)
        {
            return monoBehaviour.StartCoroutine(ExecuteIfUntilCoroutine(action, executeCondition, finishCondition));
        }
        
        /// <summary>
        /// Coroutine that executes an action if a certain condition is met until another condition is met.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="executeCondition">The condition to check for executing the action.</param>
        /// <param name="finishCondition">The condition to check for finishing the execution.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteIfUntilCoroutine(Action action, Func<bool> executeCondition, Func<bool> finishCondition)
        {
            while (finishCondition != null && !finishCondition())
            {
                if (executeCondition())
                {
                    action();
                }
        
                yield return null;
            }
        }
        #endregion
        
        #region Delay
        /// <summary>
        /// Executes an action after a certain delay.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="seconds">The delay in seconds before executing the action.</param>
        /// <param name="timeScale">Whether to use scaled or unscaled time.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteDelay(this MonoBehaviour monoBehaviour, Action action, float seconds, bool timeScale = true)
        {
            return monoBehaviour.StartCoroutine(ExecuteDelayCoroutine(action, seconds, timeScale));
        }
        
        /// <summary>
        /// Coroutine that executes an action after a certain delay.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="seconds">The delay in seconds before executing the action.</param>
        /// <param name="timeScale">Whether to use scaled or unscaled time.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteDelayCoroutine(Action action, float seconds, bool timeScale)
        {
            if (timeScale)
            {
                yield return WaitForSeconds(seconds);
            }
            else
            {
                yield return WaitForSecondsRealtime(seconds);
            }
        
            action();
        }
        #endregion
        
        #region Count
        /// <summary>
        /// Executes an action a certain number of times.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="count">The number of times to execute the action.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteCount(this MonoBehaviour monoBehaviour, Action action, int count)
        {
            return monoBehaviour.StartCoroutine(ExecuteCountCoroutine(action, count));
        }
        
        /// <summary>
        /// Coroutine that executes an action a certain number of times.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="count">The number of times to execute the action.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteCountCoroutine(Action action, int count)
        {
            for (var i = 0; i < count; i++)
            {
                action();
                yield return null;
            }
        }
        #endregion

        #region Interval
        /// <summary>
        /// Executes an action at a certain interval indefinitely.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval in seconds between each execution.</param>
        /// <param name="timeScale">Whether to use scaled or unscaled time.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteInterval(this MonoBehaviour monoBehaviour, Action action, float interval, bool timeScale = true)
        {
            return monoBehaviour.StartCoroutine(ExecuteIntervalCoroutine(action, interval, timeScale));
        }
        
        /// <summary>
        /// Coroutine that executes an action at a certain interval indefinitely.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval in seconds between each execution.</param>
        /// <param name="timeScale">Whether to use scaled or unscaled time.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteIntervalCoroutine(Action action, float interval, bool timeScale)
        {
            while (true)
            {
                action();
                if (timeScale)
                {
                    yield return WaitForSeconds(interval);
                }
                else
                {
                    yield return WaitForSecondsRealtime(interval);
                }
            }
        }
        
        /// <summary>
        /// Executes an action at a certain interval for a certain duration.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval in seconds between each execution.</param>
        /// <param name="duration">The duration in seconds for the execution.</param>
        /// <param name="timeScale">Whether to use scaled or unscaled time.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteInterval(this MonoBehaviour monoBehaviour, Action action, float interval, float duration, bool timeScale = true)
        {
            return monoBehaviour.StartCoroutine(ExecuteIntervalCoroutine(action, interval, duration, timeScale));
        }
        
        /// <summary>
        /// Coroutine that executes an action at a certain interval for a certain duration.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval in seconds between each execution.</param>
        /// <param name="duration">The duration in seconds for the execution.</param>
        /// <param name="timeScale">Whether to use scaled or unscaled time.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteIntervalCoroutine(Action action, float interval, float duration, bool timeScale)
        {
            var timer = 0f;
            var executeTimer = 0f;
            while (timer <= duration)
            {
                var deltaTime = timeScale ? Time.deltaTime : Time.unscaledTime;
                timer += deltaTime;
                executeTimer += deltaTime;
                if (executeTimer >= interval)
                {
                    action();
                    executeTimer -= interval;
                }
        
                yield return null;
            }
        }
        #endregion
        
        #region Interval Count
        /// <summary>
        /// Executes an action at a certain interval a certain number of times.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="count">The number of times to execute the action.</param>
        /// <param name="interval">The interval in seconds between each execution.</param>
        /// <param name="timeScale">Whether to use scaled or unscaled time.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteIntervalCount(this MonoBehaviour monoBehaviour, Action action, int count, float interval, bool timeScale = true)
        {
            return monoBehaviour.StartCoroutine(ExecuteIntervalCoroutine(action, count, interval, timeScale));
        }
        
        /// <summary>
        /// Coroutine that executes an action at a certain interval a certain number of times.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="count">The number of times to execute the action.</param>
        /// <param name="interval">The interval in seconds between each execution.</param>
        /// <param name="timeScale">Whether to use scaled or unscaled time.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteIntervalCountCoroutine(Action action, int count, float interval, bool timeScale)
        {
            for (var i = 0; i < count; i++)
            {
                action();
                if (timeScale)
                {
                    yield return WaitForSeconds(interval);
                }
                else
                {
                    yield return WaitForSecondsRealtime(interval);
                }
            }
        }
        #endregion
        
        #region Next Frame
        /// <summary>
        /// Executes an action on the next frame.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteNextFrame(this MonoBehaviour monoBehaviour, Action action)
        {
            return monoBehaviour.StartCoroutine(ExecuteNextFrameCoroutine(action));
        }
        
        /// <summary>
        /// Coroutine that executes an action on the next frame.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteNextFrameCoroutine(Action action)
        {
            yield return null;
            action();
        }
        #endregion
        
        #region End Of Frame
        /// <summary>
        /// Executes an action at the end of the frame.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteEndOfFrame(this MonoBehaviour monoBehaviour, Action action)
        {
            return monoBehaviour.StartCoroutine(ExecuteEndOfFrameCoroutine(action));
        }
        
        private static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
        
        /// <summary>
        /// Coroutine that executes an action at the end of the frame.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteEndOfFrameCoroutine(Action action)
        {
            yield return WaitForEndOfFrame;
            action();
        }
        #endregion
        
        #region After Frames
        /// <summary>
        /// Executes an action after a certain number of frames.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="frames">The number of frames to wait before executing the action.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteAfterFrames(this MonoBehaviour monoBehaviour, Action action, int frames)
        {
            return monoBehaviour.StartCoroutine(ExecuteAfterFramesCoroutine(action, frames));
        }
        
        /// <summary>
        /// Coroutine that executes an action after a certain number of frames.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="frames">The number of frames to wait before executing the action.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteAfterFramesCoroutine(Action action, int frames)
        {
            var count = 0;
            while (count < frames)
            {
                count++;
                yield return null;
            }
        
            action();
        }
        #endregion

        #region Next When Fixed Update
        /// <summary>
        /// Executes an action when the next FixedUpdate is called.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="action">The action to execute.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine ExecuteWhenFixedUpdate(this MonoBehaviour monoBehaviour, Action action)
        {
            return monoBehaviour.StartCoroutine(ExecuteWhenFixedUpdateCoroutine(action));
        }
        
        private static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();
        
        /// <summary>
        /// Coroutine that waits for the next FixedUpdate to execute an action.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ExecuteWhenFixedUpdateCoroutine(Action action)
        {
            yield return WaitForFixedUpdate;
            action();
        }
        #endregion
        
        #region Restart
        /// <summary>
        /// Restarts a Coroutine.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="methodName">The name of the Coroutine method.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine RestartCoroutine(this MonoBehaviour monoBehaviour, string methodName)
        {
            monoBehaviour.StopCoroutine(methodName);
            return monoBehaviour.StartCoroutine(methodName);
        }
        #endregion
        
        #region Sync
        /// <summary>
        /// Starts a Coroutine in a synchronized manner.
        /// </summary>
        /// <param name="monoBehaviour">The MonoBehaviour instance.</param>
        /// <param name="enumerator">The IEnumerator to run.</param>
        /// <returns>A Coroutine running the execution.</returns>
        public static Coroutine StartCoroutineSync(this MonoBehaviour monoBehaviour, IEnumerator enumerator)
        {
            return monoBehaviour.StartCoroutine(ToFixedCoroutine(enumerator));
        }
        
        /// <summary>
        /// Converts an IEnumerator to a synchronized IEnumerator.
        /// </summary>
        /// <param name="enumerator">The IEnumerator to convert.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        private static IEnumerator ToFixedCoroutine(IEnumerator enumerator)
        {
            var parentsStack = new Stack<IEnumerator>();
            var currentEnumerator = enumerator;
            parentsStack.Push(currentEnumerator);
            while (parentsStack.Count > 0)
            {
                currentEnumerator = parentsStack.Pop();
                while (currentEnumerator.MoveNext())
                {
                    if (currentEnumerator.Current is IEnumerator subEnumerator)
                    {
                        parentsStack.Push(currentEnumerator);
                        currentEnumerator = subEnumerator;
                    }
                    else
                    {
                        if (currentEnumerator.Current is bool check && check) continue;
                        yield return currentEnumerator.Current;
                    }
                }
            }
        }
        #endregion
        
        #region Wait For
        /// <summary>
        /// Waits for a certain amount of time.
        /// </summary>
        /// <param name="second">The amount of time to wait in seconds.</param>
        /// <param name="timeScale">Whether to use scaled or unscaled time.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        internal static IEnumerator WaitForSeconds(float second, bool timeScale)
        {
            if (timeScale)
            {
                yield return WaitForSeconds(second);
            }
            else
            {
                yield return WaitForSecondsRealtime(second);
            }
        }
        
        /// <summary>
        /// Waits for a certain amount of time using scaled time.
        /// </summary>
        /// <param name="second">The amount of time to wait in seconds.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        internal static IEnumerator WaitForSeconds(float second)
        {
            var timer = 0f;
            do
            {
                timer += Time.deltaTime;
                yield return null;
            } while (timer < second);
        }
        
        /// <summary>
        /// Waits for a certain amount of time using unscaled time.
        /// </summary>
        /// <param name="second">The amount of time to wait in seconds.</param>
        /// <returns>An IEnumerator to be used in a Coroutine.</returns>
        internal static IEnumerator WaitForSecondsRealtime(float second)
        {
            var timer = 0f;
            do
            {
                timer += Time.unscaledDeltaTime;
                yield return null;
            } while (timer < second);
        }
        #endregion
        #endregion
    }
}