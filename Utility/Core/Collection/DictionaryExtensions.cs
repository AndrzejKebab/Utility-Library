using System.Collections.Generic;
using System.Linq;

namespace UtilityLibrary.Core
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Merges multiple dictionaries into a single dictionary. If keys are duplicated,
        /// values from later dictionaries override values from earlier dictionaries.
        /// </summary>
        /// <typeparam name="T1">The type of keys in the dictionaries.</typeparam>
        /// <typeparam name="T2">The type of values in the dictionaries.</typeparam>
        /// <param name="dicts">An enumerable collection of dictionaries to be merged.</param>
        /// <returns>A merged dictionary containing all key-value pairs from the input dictionaries.</returns>
        public static Dictionary<T1, T2> MergeDictionaries<T1, T2>(IEnumerable<Dictionary<T1, T2>> dicts)
        {
            if (!dicts.Any()) return null;
            if (dicts.Count() == 1) return dicts.First();
            var mergedDict = new Dictionary<T1, T2>(dicts.First());
            foreach (var dict in dicts.Skip(1))
            {
                foreach (var pair in dict)
                {
                    if (!mergedDict.ContainsKey(pair.Key))
                    {
                        mergedDict.Add(pair.Key, pair.Value);
                    }
                    else
                    {
                        mergedDict[pair.Key] = pair.Value;
                    }
                }
            }

            return mergedDict;
        }
    }
}