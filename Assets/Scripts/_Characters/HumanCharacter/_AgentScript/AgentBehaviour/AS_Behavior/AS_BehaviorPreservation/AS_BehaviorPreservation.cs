using AIAgentScript;
using BehaviourTree;

// *****************************************************************************************************
// ******************** "Behavior Self-Preservation" FROM "AgentBehavior" BEHAVIORS ********************
// *****************************************************************************************************

public class AS_SP_CONDITION_IsDetectedByEnemy : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

      //  if (agentReference.AgentController.AS_AgentDetection.SpottedByTheseAgents.Count > 0)
      //  {
      //      state = BHT_NodeState.SUCCESS;
      //      DEBUGTOOL_GetTick(state);
      //      return state;
     //   }
        state = BHT_NodeState.FAILURE;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

public class AS_SP_CONDITION_HasLowHealth : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

//        float RetreatTolarenceThreshold = 0.9f;
    //    if (agentReference.AgentController.AS_AgentHealth.CurrentHealth < RetreatTolarenceThreshold * agentReference.AgentController.AS_AgentConfig.agentMaxHealth)
     //   {
     //       state = BHT_NodeState.SUCCESS;
     //       DEBUGTOOL_GetTick(state);
       //     return state;
     //   }
        state = BHT_NodeState.FAILURE;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

public class AS_SP_ACTION_Retreat : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        // agentReference.AgentController.AS_AgentMovement.RunAwayFromThreat();

        state = BHT_NodeState.RUNNING;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}
