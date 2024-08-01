using System.Collections.Generic;
using UnityEngine;

/*
 
namespace AIAgentScript
{
    public class AS_Generics_Memory
    {
        // The duration the target will remain in memory after leaving the agent's sensor.
        public float Age { get { return Time.time - lastSeen; } }

        // Representing the memory GameObject.
        public GameObject gameObject;

        // The position of the memory..
        public Vector3 position;

        // The direction from the agent to the memory.
        public Vector3 direction;

        // The distance from the agent to the memory.
        public float distance;

        // The angle between the agent and the memory.
        public float angle;

        // The time when the memory was last seen.
        public float lastSeen;

        // The memory score in agent targeting system.
        public float score;
    }

    public class AS_Generics_SensoryMemory
    {
        // Initializes the memory list.
        public List<AS_Generics_Memory> memories = new();
        
        // Updates each memory within the agent's sensor range.
        public void UpdateSenses(AS_AgentDetectionSystem sensor)
        {
            int targets = sensor.HasSpottedTheseAgents.Count;
            for (int i = 0; i < targets; i++)
            {
                GameObject target = sensor.HasSpottedTheseAgents[i].gameObject;
                RefreshMemory(sensor.gameObject, target);
            }
        }

        // Updates the memory in memories list.
        public void RefreshMemory(GameObject agent, GameObject target)
        {
            AS_Generics_Memory memory = FetchMemory(target);
            memory.gameObject = target;
            memory.position = target.transform.position;
            memory.direction = target.transform.position - agent.transform.position;
            memory.distance = memory.direction.magnitude;
            memory.angle = Vector3.Angle(agent.transform.forward, memory.direction);
            memory.lastSeen = Time.time;
        }

        // Adds the target to the memory list (or if it's already included, prevent duplicates).
        public AS_Generics_Memory FetchMemory(GameObject gameObject)
        {
            AS_Generics_Memory memory = memories.Find(x => x.gameObject == gameObject);
            if (memory == null)
            {
                memory = new AS_Generics_Memory();
                memories.Add(memory);
            }
            return memory;
        }

        // Removes memories from the list if they have exceeded the maximum age threshold.
        public void ForgetMemories(float olderThan)
        {
            memories.RemoveAll(m => m.Age > olderThan);
            memories.RemoveAll(m => m == null);
        }
    }
}

*/