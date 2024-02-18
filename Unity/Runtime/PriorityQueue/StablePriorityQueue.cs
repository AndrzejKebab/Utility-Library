using System;
using System.Collections;
using System.Collections.Generic;

namespace UtilityLibrary.Unity.Runtime.PriorityQueue
{
    public sealed class StablePriorityQueue<T> : IFixedSizePriorityQueue<T, float>
        where T : StablePriorityQueueNode
    {
        private T[] nodes;
        private long numberOfNodesEverEnqueued;
        public int Count { get; private set; }
        public int MaxSize => nodes.Length - 1;

        public StablePriorityQueue(int maxNodes)
        {
#if UNITY_EDITOR
            if (maxNodes <= 0) throw new InvalidOperationException("New queue size cannot be smaller than 1");
#endif

            Count = 0;
            nodes = new T[maxNodes + 1];
            numberOfNodesEverEnqueued = 0;
        }

        public void Clear()
        {
            Array.Clear(nodes, 1, Count);
            Count = 0;
        }

        public bool Contains(T node)
        {
#if UNITY_EDITOR
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (node.Queue != null && !Equals(node.Queue))
                throw new InvalidOperationException(
                    "node.Contains was called on a node from another queue.  Please call originalQueue.ResetNode() first");
            if (node.QueueIndex < 0 || node.QueueIndex >= nodes.Length)
                throw new InvalidOperationException("node.QueueIndex has been corrupted. Did you change it manually?");
#endif

            return nodes[node.QueueIndex] == node;
        }

        public void Enqueue(T node, float priority)
        {
#if UNITY_EDITOR
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (Count >= nodes.Length - 1)
                throw new InvalidOperationException("Queue is full - node cannot be added: " + node);
            if (node.Queue != null && !Equals(node.Queue))
                throw new InvalidOperationException(
                    "node.Enqueue was called on a node from another queue.  Please call originalQueue.ResetNode() first");
            if (Contains(node)) throw new InvalidOperationException("Node is already enqueued: " + node);
            node.Queue = this;
#endif

            node.Priority = priority;
            Count++;
            nodes[Count] = node;
            node.QueueIndex = Count;
            node.InsertionIndex = numberOfNodesEverEnqueued++;
            CascadeUp(node);
        }

        private void CascadeUp(T node)
        {
            int parent;
            if (node.QueueIndex > 1)
            {
                parent = node.QueueIndex >> 1;
                var parentNode = nodes[parent];
                if (HasHigherPriority(parentNode, node))
                    return;

                nodes[node.QueueIndex] = parentNode;
                parentNode.QueueIndex = node.QueueIndex;

                node.QueueIndex = parent;
            }
            else
            {
                return;
            }

            while (parent > 1)
            {
                parent >>= 1;
                var parentNode = nodes[parent];
                if (HasHigherPriority(parentNode, node))
                    break;

                nodes[node.QueueIndex] = parentNode;
                parentNode.QueueIndex = node.QueueIndex;

                node.QueueIndex = parent;
            }

            nodes[node.QueueIndex] = node;
        }


        private void CascadeDown(T node)
        {
            var finalQueueIndex = node.QueueIndex;
            var childLeftIndex = 2 * finalQueueIndex;

            if (childLeftIndex > Count) return;

            var childRightIndex = childLeftIndex + 1;
            var childLeft = nodes[childLeftIndex];
            if (HasHigherPriority(childLeft, node))
            {
                if (childRightIndex > Count)
                {
                    node.QueueIndex = childLeftIndex;
                    childLeft.QueueIndex = finalQueueIndex;
                    nodes[finalQueueIndex] = childLeft;
                    nodes[childLeftIndex] = node;
                    return;
                }

                var childRight = nodes[childRightIndex];
                if (HasHigherPriority(childLeft, childRight))
                {
                    childLeft.QueueIndex = finalQueueIndex;
                    nodes[finalQueueIndex] = childLeft;
                    finalQueueIndex = childLeftIndex;
                }
                else
                {
                    childRight.QueueIndex = finalQueueIndex;
                    nodes[finalQueueIndex] = childRight;
                    finalQueueIndex = childRightIndex;
                }
            }
            else if (childRightIndex > Count)
            {
                return;
            }
            else
            {
                var childRight = nodes[childRightIndex];
                if (HasHigherPriority(childRight, node))
                {
                    childRight.QueueIndex = finalQueueIndex;
                    nodes[finalQueueIndex] = childRight;
                    finalQueueIndex = childRightIndex;
                }
                else
                {
                    return;
                }
            }

            while (true)
            {
                childLeftIndex = 2 * finalQueueIndex;

                if (childLeftIndex > Count)
                {
                    node.QueueIndex = finalQueueIndex;
                    nodes[finalQueueIndex] = node;
                    break;
                }

                childRightIndex = childLeftIndex + 1;
                childLeft = nodes[childLeftIndex];
                if (HasHigherPriority(childLeft, node))
                {
                    if (childRightIndex > Count)
                    {
                        node.QueueIndex = childLeftIndex;
                        childLeft.QueueIndex = finalQueueIndex;
                        nodes[finalQueueIndex] = childLeft;
                        nodes[childLeftIndex] = node;
                        break;
                    }

                    var childRight = nodes[childRightIndex];
                    if (HasHigherPriority(childLeft, childRight))
                    {
                        childLeft.QueueIndex = finalQueueIndex;
                        nodes[finalQueueIndex] = childLeft;
                        finalQueueIndex = childLeftIndex;
                    }
                    else
                    {
                        childRight.QueueIndex = finalQueueIndex;
                        nodes[finalQueueIndex] = childRight;
                        finalQueueIndex = childRightIndex;
                    }
                }
                else if (childRightIndex > Count)
                {
                    node.QueueIndex = finalQueueIndex;
                    nodes[finalQueueIndex] = node;
                    break;
                }
                else
                {
                    var childRight = nodes[childRightIndex];
                    if (HasHigherPriority(childRight, node))
                    {
                        childRight.QueueIndex = finalQueueIndex;
                        nodes[finalQueueIndex] = childRight;
                        finalQueueIndex = childRightIndex;
                    }
                    else
                    {
                        node.QueueIndex = finalQueueIndex;
                        nodes[finalQueueIndex] = node;
                        break;
                    }
                }
            }
        }


        private static bool HasHigherPriority(T higher, T lower)
        {
            return higher.Priority < lower.Priority ||
                   (higher.Priority == lower.Priority && higher.InsertionIndex < lower.InsertionIndex);
        }


        public T Dequeue()
        {
#if UNITY_EDITOR
            if (Count <= 0) throw new InvalidOperationException("Cannot call Dequeue() on an empty queue");

            if (!IsValidQueue())
                throw new InvalidOperationException(
                    "Queue has been corrupted (Did you update a node priority manually instead of calling UpdatePriority()?" +
                    "Or add the same node to two different queues?)");
#endif

            var returnMe = nodes[1];
            if (Count == 1)
            {
                nodes[1] = null;
                Count = 0;
                return returnMe;
            }

            var formerLastNode = nodes[Count];
            nodes[1] = formerLastNode;
            formerLastNode.QueueIndex = 1;
            nodes[Count] = null;
            Count--;

            CascadeDown(formerLastNode);
            return returnMe;
        }

        public void Resize(int maxNodes)
        {
#if UNITY_EDITOR
            if (maxNodes <= 0) throw new InvalidOperationException("Queue size cannot be smaller than 1");

            if (maxNodes < Count)
                throw new InvalidOperationException("Called Resize(" + maxNodes + "), but current queue contains " +
                                                    Count + " nodes");
#endif

            var newArray = new T[maxNodes + 1];
            var highestIndexToCopy = Math.Min(maxNodes, Count);
            Array.Copy(nodes, newArray, highestIndexToCopy + 1);
            nodes = newArray;
        }

        public T First
        {
            get
            {
#if UNITY_EDITOR
                if (Count <= 0) throw new InvalidOperationException("Cannot call .First on an empty queue");
#endif
                return nodes[1];
            }
        }


        public void UpdatePriority(T node, float priority)
        {
#if UNITY_EDITOR
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (node.Queue != null && !Equals(node.Queue))
                throw new InvalidOperationException("node.UpdatePriority was called on a node from another queue");
            if (!Contains(node))
                throw new InvalidOperationException("Cannot call UpdatePriority() on a node which is not enqueued: " +
                                                    node);
#endif
            node.Priority = priority;
            OnNodeUpdated(node);
        }


        private void OnNodeUpdated(T node)
        {
            var parentIndex = node.QueueIndex >> 1;
            if (parentIndex > 0 && HasHigherPriority(node, nodes[parentIndex]))
                CascadeUp(node);
            else
                CascadeDown(node);
        }

        public void Remove(T node)
        {
#if UNITY_EDITOR
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (node.Queue != null && !Equals(node.Queue))
                throw new InvalidOperationException("node.Remove was called on a node from another queue");
            if (!Contains(node))
                throw new InvalidOperationException("Cannot call Remove() on a node which is not enqueued: " + node);
#endif

            if (node.QueueIndex == Count)
            {
                nodes[Count] = null;
                Count--;
                return;
            }

            var formerLastNode = nodes[Count];
            nodes[node.QueueIndex] = formerLastNode;
            formerLastNode.QueueIndex = node.QueueIndex;
            nodes[Count] = null;
            Count--;

            OnNodeUpdated(formerLastNode);
        }


        public void ResetNode(T node)
        {
#if UNITY_EDITOR
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (node.Queue != null && !Equals(node.Queue))
                throw new InvalidOperationException("node.ResetNode was called on a node from another queue");
            if (Contains(node))
                throw new InvalidOperationException("node.ResetNode was called on a node that is still in the queue");

            node.Queue = null;
#endif
            node.QueueIndex = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 1; i <= Count; i++)
                yield return nodes[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsValidQueue()
        {
            for (var i = 1; i < nodes.Length; i++)
                if (nodes[i] != null)
                {
                    var childLeftIndex = 2 * i;
                    if (childLeftIndex < nodes.Length && nodes[childLeftIndex] != null &&
                        HasHigherPriority(nodes[childLeftIndex], nodes[i]))
                        return false;

                    var childRightIndex = childLeftIndex + 1;
                    if (childRightIndex < nodes.Length && nodes[childRightIndex] != null &&
                        HasHigherPriority(nodes[childRightIndex], nodes[i]))
                        return false;
                }

            return true;
        }
    }
}