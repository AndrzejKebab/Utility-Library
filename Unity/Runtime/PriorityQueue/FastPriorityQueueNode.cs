namespace UtilityLibrary.Unity.Runtime.PriorityQueue
{
    public class FastPriorityQueueNode
    {
        public float Priority { get; protected internal set; }
        public int QueueIndex { get; internal set; }
#if UNITY_EDITOR
        public object Queue { get; internal set; }
#endif
    }
}