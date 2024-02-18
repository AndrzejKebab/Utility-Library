using System;
using System.Collections.Generic;

namespace UtilityLibrary.Unity.Runtime.PriorityQueue
{
    public interface IPriorityQueue<TItem, in TPriority> : IEnumerable<TItem>
        where TPriority : IComparable<TPriority>
    {
        int Count { get; }
        TItem First { get; }
        void Enqueue(TItem node, TPriority priority);
        TItem Dequeue();
        void Clear();
        bool Contains(TItem node);
        void Remove(TItem node);
        void UpdatePriority(TItem node, TPriority priority);
    }
}