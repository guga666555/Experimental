using AIAgentScript;
using BehaviourTree;
using UnityEngine;

// *****************************************************************************************
// ******************** "Engagement" FROM "AS_BehaviorCombat" BEHAVIOR *********************
// *****************************************************************************************

// ################################################# GRENADE COMBAT BEHAVIOR #################################################

public class AS_CB_CONDITION_HasGrenades : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        if (agentReference.agentHasGrenades)
        {
            state = BHT_NodeState.SUCCESS;
            DEBUGTOOL_GetTick(state);
            return state;
        }
        state = BHT_NodeState.FAILURE;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

public class AS_CB_CONDITION_HasMultipleTargets : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        /*
        if (agentReference.AgentController.AS_AgentDetection.HasSpottedTheseAgents.Count > 2)
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

public class AS_CB_CONDITION_IsTargetInCover : AS_Behavior
{
    // NOT IMPLEMENTED

    public override BHT_NodeState Evaluate()
    {
        state = BHT_NodeState.FAILURE;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

public class AS_CB_CONDITION_HasRequestedGrenades : AS_Behavior
{
    // NOT IMPLEMENTED 

    public override BHT_NodeState Evaluate()
    {
        state = BHT_NodeState.FAILURE;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

public class AS_CB_ACTION_EngageFoeGrenades : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        agentReference.grenadesThrowed++;
        agentReference.agentHasGrenades = false;
        state = BHT_NodeState.RUNNING;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

// ################################################# MELEE COMBAT BEHAVIOR #################################################

public class AS_CB_CONDITION_HasMeleeWeapon : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        if (agentReference.agentHasMeleeWeapon)
        {
            state = BHT_NodeState.SUCCESS;
            DEBUGTOOL_GetTick(state);
            return state;
        }
        state = BHT_NodeState.FAILURE;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

public class AS_CB_CONDITION_IsMeleePriority : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        if (agentReference.meleeIsPriority)
        {
            state = BHT_NodeState.SUCCESS;
            DEBUGTOOL_GetTick(state);
            return state;
        }
        state = BHT_NodeState.FAILURE;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

public class AS_CB_CONDITION_IsEnemyClose : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();
        GameObject target = (GameObject)GetData("currentTarget");

        if (Vector3.Distance(target.transform.position, agentReference.transform.position) < agentReference.minMeleeEngageDistance)
        {
            state = BHT_NodeState.SUCCESS;
            DEBUGTOOL_GetTick(state);
            return state;
        }
        state = BHT_NodeState.FAILURE;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

public class AS_CB_ACTION_EngageFoeMelee : AS_Behavior  
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        state = BHT_NodeState.RUNNING;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

// ################################################# RANGED COMBAT BEHAVIOR #################################################

public class AS_CB_CONDITION_HasRangedWeapon : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        /*
        // If weapon has maximum range of 10m
        if (agentReference.AgentController.AS_AgentWeapons.CurrentWeapon.WeaponConfig.maxWeaponRange > 10)
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

public class AS_CB_CONDITION_RangedWeaponHasAmmo : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        /*
        if (agentReference.AgentController.AS_AgentWeapons.CurrentWeapon.WeaponConfig.maxAmmoSize > 0 
            || agentReference.AgentController.AS_AgentWeapons.CurrentWeapon.BulletsLeft > 0)
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


public class AS_CB_CONDITION_RangedWeaponEnemyInRange : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        /*
        AS_AgentBehaviourTree agentReference = GetAgentReference();
        GameObject target = (GameObject)GetData("currentTarget");

        if (Vector3.Distance(target.transform.position, agentReference.transform.position) <
            agentReference.AgentController.AS_AgentWeapons.CurrentWeapon.WeaponConfig.maxWeaponRange)
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

public class AS_CB_CONDITION_RangedWeaponEnemyInSight : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        /*
        if (agentReference.AgentController.AS_AgentTargeting.TargetInSight)
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

public class AS_CB_ACTION_RangedWeaponEngage : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

        /*
        agentReference.AgentController.AS_AgentMovement.AgentMoveStrafe();
        agentReference.AgentController.AS_AgentTargeting.TargetFocus();
        agentReference.AgentController.AS_AgentWeapons.AS_ShootWeapon();
        */

        state = BHT_NodeState.RUNNING;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}

public class AS_CB_ACTION_LostSight : AS_Behavior
{
    public override BHT_NodeState Evaluate()
    {
        AS_AgentBehaviourTree agentReference = GetAgentReference();

       // agentReference.AgentController.AS_AgentTargeting.TargetFocus();

        state = BHT_NodeState.RUNNING;
        DEBUGTOOL_GetTick(state);
        return state;
    }
}