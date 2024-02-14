using System;
using System.Collections;
using System.Collections.Generic;

namespace UtilityLibrary.Core
{
    public static class IDictionaryExtensions
    {
        #region Null / Empty
        public static bool IsNullOrEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary) 
            => dictionary == null || dictionary.Count == 0;

        public static bool IsEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw new NullReferenceException();
            }

            var result = dictionary.Count == 0;
            return result;
        }

        public static bool IsNullOrEmpty(this IDictionary dictionary) => dictionary == null || dictionary.Count == 0;
        
        public static bool IsEmpty(this IDictionary dictionary)
        {
            if (dictionary == null)
            {
                throw new NullReferenceException();
            }

            var result = dictionary.Count == 0;
            return result;
        }
        #endregion

        #region Add T
        public static IDictionary<TKey, TValue> Add<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> pair)
        {
            dictionary.Add(pair.Key, pair.Value);
            return dictionary;
        }

        public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> pair)
        {
            if (dictionary.ContainsKey(pair.Key)) return false;
            dictionary.Add(pair.Key, pair.Value);
            return true;
        }

        public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key)) return false;
            dictionary.Add(key, value);
            return true;
        }

        public static IDictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            dictionary[key] = value;
            return dictionary;
        }

        public static IDictionary<TKey, TValue> AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> values,
            bool replaceExisted)
        {
            foreach (var item in values)
            {
                if (!dictionary.ContainsKey(item.Key) || replaceExisted)
                {
                    dictionary[item.Key] = item.Value;
                }
            }

            return dictionary;
        }
        #endregion

        #region Add
        public static bool TryAdd(this IDictionary dictionary, object key, object value)
        {
            if (dictionary.Contains(key)) return false;
            dictionary.Add(key, value);
            return true;
        }

        public static IDictionary AddOrReplace(this IDictionary dictionary, object key, object value)
        {
            dictionary[key] = value;
            return dictionary;
        }

        public static IDictionary AddRange(this IDictionary dictionary, IDictionary values, bool replaceExisted)
        {
            foreach (var key in values.Keys)
            {
                var value = values[key];
                if (!dictionary.Contains(key) || replaceExisted)
                {
                    dictionary[key] = value;
                }
            }
            return dictionary;
        }
		#endregion

		#region Merge T
		/// <summary>
		/// Merges multiple dictionaries into one.
		/// </summary>
		/// <typeparam name="TKey">The type of the keys in the dictionaries.</typeparam>
		/// <typeparam name="TValue">The type of the values in the dictionaries.</typeparam>
		/// <param name="dictionary">The dictionary to merge other dictionaries into.</param>
		/// <param name="dictionaries">An array of dictionaries to merge into the first dictionary.</param>
		/// <returns>The merged dictionary.</returns>
		public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, params IDictionary<TKey, TValue>[] dictionaries)
		{
			foreach (var dic in dictionaries)
			{
				dictionary.AddRange(dic, true);
			}
			return dictionary;
		}
		#endregion

		#region Get T
		public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            if (key == null) return defaultValue;
            return dictionary.TryGetValue(key, out var ret) ? ret : defaultValue;
        }

        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            if (dictionary.TryGetValue(key, out var ret))
            {
                return ret;
            }

            dictionary.Add(key, defaultValue);
            return defaultValue;
        }
        #endregion

        #region Get
        public static object GetValue(this IDictionary dictionary, object key, object defaultValue = default(object))
        {
            if (key == null) return defaultValue;
            var ret = dictionary[key];
            return ret;
        }

        public static object GetOrAdd(this IDictionary dictionary, object key, object defaultValue = default(object))
        {
            var ret = dictionary[key];
            if (ret != null)
            {
                return ret;
            }

            dictionary.Add(key, defaultValue);
            return defaultValue;
        }
        #endregion

        #region Remove T
        public static bool RemoveValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value)
        {
            var match = false;
            var key = default(TKey);
            foreach (var kv in dictionary)
            {
                if (!kv.Value.Equals(value)) continue;
                key = kv.Key;
                match = true;
                break;
            }

            if (match)
            {
                dictionary.Remove(key);
                return true;
            }

            return false;
        }

        #endregion

        #region Remove
        public static bool RemoveValue<TValue>(this IDictionary dictionary, TValue value)
        {
            var match = false;
            object key = null;
            foreach (var k in dictionary.Keys)
            {
                var v = dictionary[k];
                if (!v.Equals(value)) continue;
                key = k;
                match = true;
                break;
            }

            if (match)
            {
                dictionary.Remove(key);
                return true;
            }

            return false;
        }
        #endregion
    }
}