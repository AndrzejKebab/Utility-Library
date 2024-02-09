using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using System.Reflection;
using UnityEditor.Events;
#endif

namespace UtilityLibrary.Unity.Runtime.Patterns
{
    public class Observer<T>
    {
        [SerializeField] private T value;
        [SerializeField] private UnityEvent<T> onValueChanged;
        
        public T Value
        {
            get => value;
            set => Set(value);
        }
        
        public static implicit operator T(Observer<T> observer) => observer.value;

        public Observer(T value, UnityAction<T> callback = null)
        {
            this.value = value;
            onValueChanged = new UnityEvent<T>();
            if(callback != null) onValueChanged.AddListener(callback);
        }
        
        public void Set(T value)
        {
            if(Equals(this.value, value)) return;
            this.value = value;
            Invoke();
        }
        
        public void Invoke()
        {
            onValueChanged?.Invoke(value);
        }
        
        public void AddListener(UnityAction<T> callback)
        {
            if(callback == null) return;
            onValueChanged ??= new UnityEvent<T>();
#if UNITY_EDITOR
            UnityEventTools.AddPersistentListener(onValueChanged, callback);
#else
            onValueChanged.AddListener(callback);
#endif
        }
        
        public void RemoveListener(UnityAction<T> callback)
        {
            if(callback == null) return;
#if UNITY_EDITOR
            UnityEventTools.RemovePersistentListener(onValueChanged, callback);
#else
            onValueChanged?.RemoveListener(callback);
#endif
        }
        
        public void RemoveAllListeners()
        {
#if UNITY_EDITOR
            FieldInfo field = typeof(UnityEventBase).GetField("m_PersistentCalls", BindingFlags.Instance | BindingFlags.NonPublic);
            object value = field.GetValue(onValueChanged);
            value.GetType().GetMethod("Clear")?.Invoke(value,null);
#else
            onValueChanged?.RemoveAllListeners();
#endif
        }
        public void Dispose()
        {
            onValueChanged?.RemoveAllListeners();
            onValueChanged = null;
            value = default;
        }
    }
}