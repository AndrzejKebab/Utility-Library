namespace UtilityLibrary.Unity.Runtime.PriorityQueue
{
    public abstract class StablePriorityQueueNode : FastPriorityQueueNode
    {
        public long InsertionIndex { get; internal set; }
    }
}