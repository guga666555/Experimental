using AIAgentScript;
using UnityEngine;
using UnityEngine.AI;

public class AS_AgentMovement : MonoBehaviour, IAgentScript
{
    private AgentScriptController agentController;

    public void AS_Start(AgentScriptController controller)
    {
        agentController = controller;
    }
}
