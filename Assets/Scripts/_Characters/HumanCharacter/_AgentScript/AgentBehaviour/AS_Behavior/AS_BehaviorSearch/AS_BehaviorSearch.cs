using AIAgentScript;
using BehaviourTree;

// *******************************************************************************************
// ******************** "Search_Enemy" FROM "AS_BehaviorCombat" BEHAVIOR *********************
// *******************************************************************************************

public class AS_CB_CONDITION_HasLostEnemySight : AS_Behavior
{
    // NOT IMPLEMENTED

    public override BHT_NodeState Evaluate()
    {
        state = BHT_NodeState.FAILURE;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

public class AS_CB_ACTION_SearchForEnemy : AS_Behavior
{
    // NOT IMPLEMENTED

    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

   //     agentReference.AgentController.AS_AgentMovement.AgentMoveTo
    //        (agentReference.AgentController.AS_AgentTargeting.BestTarget.position);

        state = BHT_NodeState.RUNNING;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}
