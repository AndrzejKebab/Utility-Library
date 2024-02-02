using UnityEngine;

namespace UtilityLibrary.Unity.Runtime.Patterns
{
    /// <summary>
    /// Persistent Regulator singleton, will destroy any other older components of the same type it finds on awake
    /// </summary>
    public class RegulatorSingleton<T> : MonoBehaviour where T : Component 
    {
        protected static T instance;

        public static bool HasInstance => instance != null;

        public float InitializationTime { get; private set; }

        public static T Instance 
        {
            get 
            {
                if (instance != null) return instance;
                instance = FindAnyObjectByType<T>();
                
                if (instance != null) return instance;
                var go = new GameObject(typeof(T).Name + " Auto-Generated")
                {
                    hideFlags = HideFlags.HideAndDontSave
                };
                instance = go.AddComponent<T>();

                return instance;
            }
        }

        /// <summary>
        /// Make sure to call base.Awake() in override if you need awake.
        /// </summary>
        protected virtual void Awake() 
        {
            InitializeSingleton();
        }

        protected virtual void InitializeSingleton() 
        {
            if (!Application.isPlaying) return;
            InitializationTime = Time.time;
            DontDestroyOnLoad(gameObject);

            var oldInstances = FindObjectsByType<T>(FindObjectsSortMode.None);
            foreach (var old in oldInstances) 
            {
                if (old.GetComponent<RegulatorSingleton<T>>().InitializationTime < InitializationTime)
                {
                    Destroy(old.gameObject);
                }
            }

            if (instance == null) 
            {
                instance = this as T;
            }
        }
    }
}