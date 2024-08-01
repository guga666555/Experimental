using UnityEngine;

namespace AIAgentScript
{
    [RequireComponent(typeof(AS_AgentBehaviourTree))]
    [RequireComponent(typeof(AS_AgentDebugScripts))]
    [RequireComponent(typeof(AS_AgentMovement))]
    [RequireComponent(typeof(AS_AgentTargetSystem))]

    public class AgentScriptController : MonoBehaviour
    {
        [field: SerializeField] public AgentScriptConfigs AS_AgentConfig { get; private set; }
        public AS_AgentBehaviourTree AS_AgentBehaviour { get; private set; }
        public AS_AgentDebugScripts AS_AgentDebug { get; private set; }
        public AS_AgentMovement AS_AgentMovement { get; private set; }
        public AS_AgentTargetSystem AS_AgentTargeting { get; private set; }

        private void Start()
        {
            AS_AgentBehaviour = GetComponent<AS_AgentBehaviourTree>();
            AS_AgentDebug = GetComponent<AS_AgentDebugScripts>();
            AS_AgentMovement = GetComponent<AS_AgentMovement>();
            AS_AgentTargeting = GetComponent<AS_AgentTargetSystem>();

            foreach (IAgentScript agentScript in gameObject.GetComponents<IAgentScript>())
            {
                agentScript.AS_Start(this);
            }
        }
    }
}
