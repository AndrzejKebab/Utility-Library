using System.Collections.Generic;

namespace UtilityLibrary.Core
{
    public static class IEnumeratorExtensions
    {
        #region To Enumerable
        /// <summary>
        /// Converts an IEnumerator<T> to an IEnumerable<T>.
        /// </summary>
        /// <param name="source">An instance of IEnumerator<T>.</param>
        /// <returns>An IEnumerable<T> with the same elements as the input instance.</returns>    
        public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> source) 
        {
            while (source.MoveNext()) 
            {
                yield return source.Current;
            }
        }
        #endregion
    }
}