namespace UtilityLibrary.Unity.Runtime.PriorityQueue
{
    public class GenericPriorityQueueNode<TPriority>
    {
        public TPriority Priority { get; protected internal set; }
        public int QueueIndex { get; internal set; }
        public long InsertionIndex { get; internal set; }

#if UNITY_EDITOR
        public object Queue { get; internal set; }
#endif
    }
}