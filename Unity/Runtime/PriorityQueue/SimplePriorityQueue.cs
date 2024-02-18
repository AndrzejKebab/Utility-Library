using System;
using System.Collections;
using System.Collections.Generic;

namespace UtilityLibrary.Unity.Runtime.PriorityQueue
{
    public class SimplePriorityQueue<TItem, TPriority> : IPriorityQueue<TItem, TPriority>
        where TPriority : IComparable<TPriority>
    {
        private const int initialQueueSize = 100;
        private readonly Dictionary<TItem, IList<SimpleNode>> itemToNodesCache;
        private readonly IList<SimpleNode> nullNodesCache;
        private readonly GenericPriorityQueue<SimpleNode, TPriority> queue;

        public int Count
        {
            get
            {
                lock (queue)
                {
                    return queue.Count;
                }
            }
        }

        public TItem First
        {
            get
            {
                lock (queue)
                {
                    if (queue.Count <= 0) throw new InvalidOperationException("Cannot call .First on an empty queue");

                    return queue.First.Data;
                }
            }
        }

        public void Clear()
        {
            lock (queue)
            {
                queue.Clear();
                itemToNodesCache.Clear();
                nullNodesCache.Clear();
            }
        }

        public bool Contains(TItem item)
        {
            lock (queue)
            {
                return item == null ? nullNodesCache.Count > 0 : itemToNodesCache.ContainsKey(item);
            }
        }

        public TItem Dequeue()
        {
            lock (queue)
            {
                if (queue.Count <= 0) throw new InvalidOperationException("Cannot call Dequeue() on an empty queue");

                var node = queue.Dequeue();
                RemoveFromNodeCache(node);
                return node.Data;
            }
        }

        public void Enqueue(TItem item, TPriority priority)
        {
            lock (queue)
            {
                IList<SimpleNode> nodes;
                if (item == null)
                {
                    nodes = nullNodesCache;
                }
                else if (!itemToNodesCache.TryGetValue(item, out nodes))
                {
                    nodes = new List<SimpleNode>();
                    itemToNodesCache[item] = nodes;
                }

                var node = EnqueueNoLockOrCache(item, priority);
                nodes.Add(node);
            }
        }

        public void Remove(TItem item)
        {
            lock (queue)
            {
                SimpleNode removeMe;
                IList<SimpleNode> nodes;
                if (item == null)
                {
                    if (nullNodesCache.Count == 0)
                        throw new InvalidOperationException("Cannot call Remove() on a node which is not enqueued: " +
                                                            item);
                    removeMe = nullNodesCache[0];
                    nodes = nullNodesCache;
                }
                else
                {
                    if (!itemToNodesCache.TryGetValue(item, out nodes))
                        throw new InvalidOperationException("Cannot call Remove() on a node which is not enqueued: " +
                                                            item);
                    removeMe = nodes[0];
                    if (nodes.Count == 1) itemToNodesCache.Remove(item);
                }

                queue.Remove(removeMe);
                nodes.Remove(removeMe);
            }
        }

        public void UpdatePriority(TItem item, TPriority priority)
        {
            lock (queue)
            {
                var updateMe = GetExistingNode(item);
                if (updateMe == null)
                    throw new InvalidOperationException(
                        "Cannot call UpdatePriority() on a node which is not enqueued: " + item);
                queue.UpdatePriority(updateMe, priority);
            }
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            var queueData = new List<TItem>();
            lock (queue)
            {
                foreach (var node in queue) queueData.Add(node.Data);
            }

            return queueData.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private SimpleNode GetExistingNode(TItem item)
        {
            if (item == null) return nullNodesCache.Count > 0 ? nullNodesCache[0] : null;

            return !itemToNodesCache.TryGetValue(item, out IList<SimpleNode> nodes) ? null : nodes[0];
        }

        private void AddToNodeCache(SimpleNode node)
        {
            if (node.Data == null)
            {
                nullNodesCache.Add(node);
                return;
            }

            if (!itemToNodesCache.TryGetValue(node.Data, out IList<SimpleNode> nodes))
            {
                nodes = new List<SimpleNode>();
                itemToNodesCache[node.Data] = nodes;
            }

            nodes.Add(node);
        }

        private void RemoveFromNodeCache(SimpleNode node)
        {
            if (node.Data == null)
            {
                nullNodesCache.Remove(node);
                return;
            }

            if (!itemToNodesCache.TryGetValue(node.Data, out IList<SimpleNode> nodes)) return;
            nodes.Remove(node);
            if (nodes.Count == 0) itemToNodesCache.Remove(node.Data);
        }

        private SimpleNode EnqueueNoLockOrCache(TItem item, TPriority priority)
        {
            var node = new SimpleNode(item);
            if (queue.Count == queue.MaxSize) queue.Resize(queue.MaxSize * 2 + 1);
            queue.Enqueue(node, priority);
            return node;
        }

        public bool EnqueueWithoutDuplicates(TItem item, TPriority priority)
        {
            lock (queue)
            {
                IList<SimpleNode> nodes;
                if (item == null)
                {
                    if (nullNodesCache.Count > 0) return false;
                    nodes = nullNodesCache;
                }
                else if (itemToNodesCache.ContainsKey(item))
                {
                    return false;
                }
                else
                {
                    nodes = new List<SimpleNode>();
                    itemToNodesCache[item] = nodes;
                }

                var node = EnqueueNoLockOrCache(item, priority);
                nodes.Add(node);
                return true;
            }
        }

        public TPriority GetPriority(TItem item)
        {
            lock (queue)
            {
                var findMe = GetExistingNode(item);
                if (findMe == null)
                    throw new InvalidOperationException("Cannot call GetPriority() on a node which is not enqueued: " +
                                                        item);
                return findMe.Priority;
            }
        }

        public bool IsValidQueue()
        {
            lock (queue)
            {
                foreach (IList<SimpleNode> nodes in itemToNodesCache.Values)
                foreach (var node in nodes)
                    if (!queue.Contains(node))
                        return false;

                foreach (var node in queue)
                    if (GetExistingNode(node.Data) == null)
                        return false;

                return queue.IsValidQueue();
            }
        }

        private class SimpleNode : GenericPriorityQueueNode<TPriority>
        {
            public SimpleNode(TItem data)
            {
                Data = data;
            }

            public TItem Data { get; }
        }

        #region Constructors

        public SimplePriorityQueue() : this(Comparer<TPriority>.Default, EqualityComparer<TItem>.Default)
        {
        }

        public SimplePriorityQueue(IComparer<TPriority> priorityComparer) : this(priorityComparer.Compare,
            EqualityComparer<TItem>.Default)
        {
        }

        public SimplePriorityQueue(Comparison<TPriority> priorityComparer) : this(priorityComparer,
            EqualityComparer<TItem>.Default)
        {
        }

        public SimplePriorityQueue(IEqualityComparer<TItem> itemEquality) : this(Comparer<TPriority>.Default,
            itemEquality)
        {
        }

        public SimplePriorityQueue(IComparer<TPriority> priorityComparer, IEqualityComparer<TItem> itemEquality) : this(
            priorityComparer.Compare, itemEquality)
        {
        }

        public SimplePriorityQueue(Comparison<TPriority> priorityComparer, IEqualityComparer<TItem> itemEquality)
        {
            queue = new GenericPriorityQueue<SimpleNode, TPriority>(initialQueueSize, priorityComparer);
            itemToNodesCache = new Dictionary<TItem, IList<SimpleNode>>(itemEquality);
            nullNodesCache = new List<SimpleNode>();
        }

        #endregion

        #region Try methods for multithreading

        public bool TryFirst(out TItem first)
        {
            if (queue.Count > 0)
                lock (queue)
                {
                    if (queue.Count > 0)
                    {
                        first = queue.First.Data;
                        return true;
                    }
                }

            first = default;
            return false;
        }

        public bool TryDequeue(out TItem first)
        {
            if (queue.Count > 0)
                lock (queue)
                {
                    if (queue.Count > 0)
                    {
                        var node = queue.Dequeue();
                        first = node.Data;
                        RemoveFromNodeCache(node);
                        return true;
                    }
                }

            first = default;
            return false;
        }

        public bool TryRemove(TItem item)
        {
            lock (queue)
            {
                SimpleNode removeMe;
                IList<SimpleNode> nodes;
                if (item == null)
                {
                    if (nullNodesCache.Count == 0) return false;
                    removeMe = nullNodesCache[0];
                    nodes = nullNodesCache;
                }
                else
                {
                    if (!itemToNodesCache.TryGetValue(item, out nodes)) return false;
                    removeMe = nodes[0];
                    if (nodes.Count == 1) itemToNodesCache.Remove(item);
                }

                queue.Remove(removeMe);
                nodes.Remove(removeMe);
                return true;
            }
        }

        public bool TryUpdatePriority(TItem item, TPriority priority)
        {
            lock (queue)
            {
                var updateMe = GetExistingNode(item);
                if (updateMe == null) return false;
                queue.UpdatePriority(updateMe, priority);
                return true;
            }
        }

        public bool TryGetPriority(TItem item, out TPriority priority)
        {
            lock (queue)
            {
                var findMe = GetExistingNode(item);
                if (findMe == null)
                {
                    priority = default;
                    return false;
                }

                priority = findMe.Priority;
                return true;
            }
        }

        #endregion
    }
}