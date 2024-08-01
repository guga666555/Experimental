using AIAgentScript;
using BehaviourTree;

/// <summary>
/// RULES:
/// #1 - NO CONDITIONS IN ACTIONS, ALL CONDITIONS MUST BE INSIDE CONDITION CLASSES.
/// </summary>
public abstract class AS_Behavior : BHT_Node
{
    protected AS_AgentBehaviourTree GetAgentReference()
    {
        return (AS_AgentBehaviourTree)GetData("agentReference");
    }

    protected void DEBUGTOOL_GetTick(BHT_NodeState node)
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        switch (node)
        {
            case BHT_NodeState.SUCCESS:
                agentReference.AgentController.AS_AgentDebug.refCurrentSuccessNodes.Add(this.ToString());
                break;
            case BHT_NodeState.FAILURE:
                agentReference.AgentController.AS_AgentDebug.refCurrentFailedNodes.Add(this.ToString());
                break;
            case BHT_NodeState.RUNNING:
                agentReference.AgentController.AS_AgentDebug.refCurrentRunningNode.Add(this.ToString());
                break;
        }
    }
}