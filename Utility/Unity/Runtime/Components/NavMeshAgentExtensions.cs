using UnityEngine.AI;

namespace UtilityLibrary.Unity.Runtime
{
    public static class NavMeshAgentExtensions
    {
        /// <summary>
        /// Checks if the NavMeshAgent has arrived at its destination.
        /// </summary>
        /// <param name="agent">The NavMeshAgent instance.</param>
        /// <returns>
        /// Returns true if the agent is active, on the NavMesh, not pending a path, and within stopping distance of its destination.
        /// Returns false otherwise.
        /// </returns>
        public static bool IsArrive(this NavMeshAgent agent)
        {
            // Check if the agent is active and on the NavMesh
            if (!agent.isActiveAndEnabled || !agent.isOnNavMesh) return false;

            // Check if the agent is not pending a path and is within stopping distance of its destination
            return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
        }
    }
}