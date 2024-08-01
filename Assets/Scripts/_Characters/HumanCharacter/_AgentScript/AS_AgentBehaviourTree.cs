using BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIAgentScript
{
    public class AS_AgentBehaviourTree : BHT_Tree, IAgentScript
    {
        public AgentScriptController AgentController { get; private set; }

        #region TemporaryTestVars

        public int grenadesThrowed;
        public bool agentHasGrenades;
        public bool agentHasMeleeWeapon;
        public bool meleeIsPriority;
        public float minMeleeEngageDistance = 3f;

        #endregion

        public void AS_Start(AgentScriptController controller)
        {
            AgentController = controller;   
        }

        protected override BHT_Node SetupTree()
        {
            BHT_Node root = new BHT_Selector(new List<BHT_Node>()
            {    
                // **************************************************************** //
                // ****************** SELF PRESERVATION BEHAVIOR ****************** //
                // **************************************************************** //
  
                BTH_NewBranchSequence("Self-Preservation Behavior Branch",
                    new AS_SP_CONDITION_IsDetectedByEnemy(),
                    new AS_SP_CONDITION_HasLowHealth(),
                    new AS_SP_ACTION_Retreat()
                ),

                // ***************************************************** //
                // ****************** COMBAT BEHAVIOR ****************** //
                // ***************************************************** //

                BTH_NewBranchSequence("Combat Behavior Branch",
                    new AS_CB_CONDITION_HasAvailableTargets(),
                    new AS_CB_CONDITION_HasPickedBestTargets(),
                    new AS_CB_CONDITION_HasWeapon(),
                    BTH_NewBranchSelector("Combat Engagement",
                        BTH_NewBranchSequence("Engage Grenades",
                            new AS_CB_CONDITION_HasGrenades(),
                            BTH_NewBranchSelector("Trigger Requests",
                                new AS_CB_CONDITION_IsTargetInCover(),
                                new AS_CB_CONDITION_HasMultipleTargets(),
                                new AS_CB_CONDITION_HasRequestedGrenades()
                            ),
                            new AS_CB_ACTION_EngageFoeGrenades()
                        ),
                        BTH_NewBranchSequence("Engage Melee",
                            new AS_CB_CONDITION_HasMeleeWeapon(),
                            BTH_NewBranchSelector("Trigger Requests",
                                new AS_CB_CONDITION_IsMeleePriority(),
                                new AS_CB_CONDITION_IsEnemyClose()
                            ),
                            new AS_CB_ACTION_EngageFoeMelee()
                         ),
                        BTH_NewBranchSequence("Engage Ranged",
                            new AS_CB_CONDITION_HasRangedWeapon(),
                            new AS_CB_CONDITION_RangedWeaponHasAmmo(),
                            new AS_CB_CONDITION_RangedWeaponEnemyInRange(),
                            BTH_NewBranchSelector("STARE OR FIGHT",
                                BTH_NewBranchSequence("FIGHT",
                                    new AS_CB_CONDITION_RangedWeaponEnemyInSight(),
                                    new AS_CB_ACTION_RangedWeaponEngage()
                                ),
                                new AS_CB_ACTION_SearchForEnemy()
                            )
                        )
                    )
                ),

                // ***************************************************** //
                // ***************** STAY IDLE BEHAVIOR **************** //
                // ***************************************************** //
            
                new AS_IDLE_ACTION_IdleState()
            });

            // ***************************************************** //
            // ************************ DATA *********************** //
            // ***************************************************** //

            root.SetData("agentReference", this);
            return root;
        }
    }
}