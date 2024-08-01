using AIAgentScript;
using BehaviourTree;
using UnityEngine;

// *****************************************************************************************
// ******************** "BehaviorCombat" FROM "AgentBehavior" BEHAVIORS ********************
// *****************************************************************************************

public class AS_CB_CONDITION_HasAvailableTargets : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

//        if (agentReference.AgentController.AS_AgentTargeting.Memory.memories.Count > 0 ) 
 //       {
  //          state = BHT_NodeState.SUCCESS;
   //         DEBUGTOOL_GetTick(state);
    //        return state;
   //     }
        state = BHT_NodeState.FAILURE;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

public class AS_CB_CONDITION_HasPickedBestTargets : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        /*
        if (agentReference.AgentController.AS_AgentTargeting.BestTarget != null)
        {
            GameObject currentTarget = agentReference.AgentController.AS_AgentTargeting.BestTarget.gameObject;
            if (GetData("currentTarget") == null) { parent.parent.SetData("currentTarget", currentTarget); }

            state = BHT_NodeState.SUCCESS;
            DEBUGTOOL_GetTick(state);
            return state;
        }
        */
        ClearData("currentTarget");
        state = BHT_NodeState.FAILURE;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

public class AS_CB_CONDITION_HasWeapon : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        /*
        if (agentReference.AgentController.AS_AgentWeapons.IsHoldingWeapon)
        {
            state = BHT_NodeState.SUCCESS;
            DEBUGTOOL_GetTick(state);
            return state;
        }
        */
        state = BHT_NodeState.FAILURE;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}
