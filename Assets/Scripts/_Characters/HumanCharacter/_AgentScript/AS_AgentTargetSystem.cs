using UnityEngine;

namespace AIAgentScript
{
    public class AS_AgentTargetSystem : MonoBehaviour, IAgentScript
    {
        private AgentScriptController agentController;

        // Reference to best/current target.
        //   [field: HideInInspector] public AS_Generics_Memory BestTarget { get; private set; }

        // Initializes the memory list.
        //    [field: HideInInspector] public AS_Generics_SensoryMemory Memory { get; private set; } = new();

        #region Targeting Info Getters

        // Check if there is an available current target.
        //    public bool HasTarget                   { get { return BestTarget != null; } private set { } }

        // Get the GameObject of the current target.
        //        public GameObject CurrentTarget         { get { return BestTarget.gameObject; } private set { } }

        // Get the position of the current target.
        //      public Vector3 CurrentTargetPosition    { get { return BestTarget.position; } private set { } }

        // Check if the target is in sight (based on the age of the memory).
        //    public bool TargetInSight               { get { return BestTarget.Age < 0.5f; } private set { } }

        // Gets the distance from current target.
        //  public float TargetDistance             { get { return BestTarget.distance; } private set { } }

        #endregion

        public void AS_Start(AgentScriptController controller)
        {
            agentController = controller;
        }
    }
}

/*
        public void Update()
        {
            Memory.UpdateSenses(agentController.AS_AgentDetection);
            Memory.ForgetMemories(agentController.AS_AgentConfig.MemorySpan);
            TargetEvaluateScores();
        }

        // Updates all target scores in the agent's memory to ensure the agent always selects the best target to focus on.
        private void TargetEvaluateScores()
        {
            // If agent has no memories, then there's no targets.
            if (Memory.memories.Count <= 0) { BestTarget = null; ; return; }

            foreach (var memory in Memory.memories)
            {
                memory.score = TargetCalculateScore(memory);
                if (BestTarget == null || memory.score > BestTarget.score)
                {
                    BestTarget = memory;
                }
            }
        }

        public void TargetFocus()
        {
            if (!HasTarget) return;
            transform.LookAt(BestTarget.position);
        }

        // Calculates the score for all potential targets.
        private float TargetCalculateScore(AS_Generics_Memory memory)
        {
            float distanceScore = TargetNormalize(memory.distance, agentController.AS_AgentConfig.detectionRange) * agentController.AS_AgentConfig.DistanceWeight;
            float angleScore = TargetNormalize(memory.angle, agentController.AS_AgentConfig.fovSize) * agentController.AS_AgentConfig.AngleWeight;
            float ageScore = TargetNormalize(memory.Age, agentController.AS_AgentConfig.MemorySpan) * agentController.AS_AgentConfig.AgeWeight;
            return distanceScore + angleScore + ageScore;
        }  

        // Helper method that always returns a value less than 1 (for debugging purposes only, not important).
        private float TargetNormalize(float value, float maxValue)
        {
            return 1.0f - (value / maxValue);
        }

    }
}

*/