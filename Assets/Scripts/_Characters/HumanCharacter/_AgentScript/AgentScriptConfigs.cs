using UnityEngine;

namespace AIAgentScript
{
    [CreateAssetMenu]
    public class AgentScriptConfigs : ScriptableObject
    {
        [Header("Targeting Definitions")]
        [Tooltip("Duration (in seconds) before a memory is removed once it's out of the agent's sensor range.")]
        public float MemorySpan;

        [Tooltip("Weight of distance in determining the optimal target.")]
        public float DistanceWeight;

        [Tooltip("Weight of the angle between the target and the agent in determining the optimal target.")]
        public float AngleWeight;

        [Tooltip("Weight of the age of a memory in determining the optimal target.")]
        public float AgeWeight;
    }
}