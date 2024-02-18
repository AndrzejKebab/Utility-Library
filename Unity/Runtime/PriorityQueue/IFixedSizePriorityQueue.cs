using System;

namespace UtilityLibrary.Unity.Runtime.PriorityQueue
{
    internal interface IFixedSizePriorityQueue<TItem, in TPriority> : IPriorityQueue<TItem, TPriority>
        where TPriority : IComparable<TPriority>
    {
        int MaxSize { get; }
        void Resize(int maxNodes);
        void ResetNode(TItem node);
    }
}