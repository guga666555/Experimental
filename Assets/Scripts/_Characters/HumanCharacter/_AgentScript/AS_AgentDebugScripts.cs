using System.Collections.Generic;
using UnityEngine;

namespace AIAgentScript
{
    public class AS_AgentDebugScripts : MonoBehaviour, IAgentScript
    {
        private AgentScriptController agentController;

        // References for "BEHAVIOR TREE" debugging.
        public List<string> refCurrentFailedNodes = new();
        public List<string> refCurrentRunningNode = new();
        public List<string> refCurrentSuccessNodes = new();

        // References for "DETECTION SYSTEM" debugging.
        public Collider[] refObjectsInRange = new Collider[0];
        public List<GameObject> refVisibleObjects = new();
        public List<AgentScriptController> refHasSpottedTheseAgents = new();
        public List<AgentScriptController> refIsDetectingTheseAgents = new();
        public List<AgentScriptController> refSpottedByTheseAgents = new();
        public List<AgentScriptController> refDetectedByTheseAgents = new();

        // References for "TARGET SYSTEM" debugging.
        public string refHasTarget;
        public string refCurrentTarget;
        public string refCurrentTargetPosition;
        public string refTargetInSight;
        public string refTargetDistance;

        public bool enableFieldOfViewVisualization;
        public bool enableTargetVisualization;

        public void AS_Start(AgentScriptController controller)
        {
            agentController = controller;
        }

        public void Update()
        {
            this.UpdateDebugReferences();
            this.VisualizeAgentVision();
            this.VisualizeAgentTargets();
        }

        public void UpdateDebugReferences()
        {
            refCurrentFailedNodes.Clear();
            refCurrentRunningNode.Clear() ;
            refCurrentSuccessNodes.Clear();

            /*
            AS_AgentTargetSystem ts = agentController.AS_AgentTargeting;
            refHasTarget = ts.HasTarget.ToString();
            refCurrentTarget = ts.HasTarget ? ts.CurrentTarget.ToString() : null;
            refCurrentTargetPosition = ts.HasTarget ? ts.CurrentTargetPosition.ToString() : null;
            refTargetInSight = ts.HasTarget ? ts.TargetInSight.ToString() : null;
            refTargetDistance = ts.HasTarget ? ts.TargetDistance.ToString() + "m": null;
        */
        }

        public void VisualizeAgentTargets()
        {
            /*
            if (!enableTargetVisualization) return;

            float maxScore = float.MinValue;
            foreach (var memory in agentController.AS_AgentTargeting.Memory.memories)
            {
                Color newColor;
                maxScore = Mathf.Max(maxScore, memory.score);
                newColor.a = memory.score / maxScore;

                if (memory == agentController.AS_AgentTargeting.BestTarget)
                    newColor = Color.red;
                else
                    newColor = Color.black;

                DebugExtension.DebugWireSphere(memory.position + new Vector3(0, 2f, 0), newColor, 0.3f, 0.1f);
            }
            */
        }

        public void VisualizeAgentVision()
        {

            /*
            if (!enableFieldOfViewVisualization) return;

            DebugExtension.DebugWireSphere(this.transform.position, Color.blue, agentController.AS_AgentConfig.detectionRange, 0.1f);

            Vector3 fovLine1 = Quaternion.AngleAxis(agentController.AS_AgentConfig.fovSize / 2, agentController.transform.up)
                * agentController.transform.forward * agentController.AS_AgentConfig.detectionRange;

            Vector3 fovLine2 = Quaternion.AngleAxis(-agentController.AS_AgentConfig.fovSize / 2, agentController.transform.up)
                * agentController.transform.forward * agentController.AS_AgentConfig.detectionRange;

            Debug.DrawRay(agentController.AS_AgentDetection.VisorTransform.position, fovLine1, Color.yellow, 0.1f);
            Debug.DrawRay(agentController.AS_AgentDetection.VisorTransform.position, fovLine2, Color.yellow, 0.1f);
        */
        }
    }
}