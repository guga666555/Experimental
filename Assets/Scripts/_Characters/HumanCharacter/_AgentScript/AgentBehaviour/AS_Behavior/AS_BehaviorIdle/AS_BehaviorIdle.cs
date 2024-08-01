using BehaviourTree;

// ***************************************************************************************
// ******************** "BehaviorIdle" FROM "AgentBehavior" BEHAVIORS ********************
// ***************************************************************************************

public class AS_IDLE_ACTION_IdleState : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        state = BHT_NodeState.RUNNING;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}
