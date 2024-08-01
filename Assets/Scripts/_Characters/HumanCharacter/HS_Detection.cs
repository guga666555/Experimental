using System.Collections.Generic;
using UnityEngine;

namespace HumanScript
{
    public class HS_Detection : MonoBehaviour, IHumanScript
    {
        private HumanScriptController humanController;

        // Transform reference used for generating the character's field of view (FOV).
        [field: SerializeField] public Transform VisorTransform { get; private set; }

        // The number of objects currently detected by the character.
        public int DetectedObjectsArraySize { get; private set; }

        // The maximum number of objects this character can detect.
        public Collider[] ObjectsInRange { get; private set; }

        // Objects that are currently visible to this character.
        public List<GameObject> VisibleObjects { get; private set; } = new();

        public float DetectionRange
        {
            // Assuming that player can always see further, player range multiplies the AI range by 5.
            get => humanController.HS_PlayerInput.IsPlayerControlled ? 
                humanController.Defines.detectionFOV_AI * 5f : humanController.Defines.detectionFOV_AI;
            private set { }
        }

        public float DetectionFov
        {
            get => humanController.HS_PlayerInput.IsPlayerControlled ? humanController.HS_PlayerInput.PlayerCamera.fieldOfView
                : humanController.Defines.detectionFOV_AI;
            private set { }
        }

        #region Character Detection Getters

        // Displays currently detected agents that are visible to the agent.
        public List<HumanScriptController> HasSpottedTheseAgents { get; private set; } = new();

        // ========================================================================================== \\

        // Displays currently detected agents that are NOT visible to the agent.
        public List<HumanScriptController> IsDetectingTheseAgents { get; private set; } = new();

        // ========================================================================================== \\

        // Indicates if other agents have detected and can see this agent.
        public List<HumanScriptController> SpottedByTheseAgents { get; private set; } = new();

        // ========================================================================================== \\

        // Indicates if other agents have detected this agent but cannot see it.
        public List<HumanScriptController> DetectedByTheseAgents { get; private set; } = new();

        #endregion

        public void HS_Start(HumanScriptController controller)
        {
            humanController = controller;
            ObjectsInRange = new Collider[humanController.Defines.MaxDetectionArraySize];
        }

        public void Update()
        {
            // REMINDER: must find a better alternative for these list clearing mess...
            HasSpottedTheseAgents.Clear();
            IsDetectingTheseAgents.Clear();
            SpottedByTheseAgents.Clear();
            DetectedByTheseAgents.Clear();
            VisibleObjects.Clear();

            this.HS_ObjectDetection();
        }

        private void HS_ObjectDetection()
        {
            // Generates a sphere collider around the agent.
            DetectedObjectsArraySize =
            Physics.OverlapSphereNonAlloc(
                transform.position, DetectionRange,
                ObjectsInRange,
                humanController.Defines.detectionTargetLayer
            );

            // Iterates through each collider target detected by the sphere collider.
            for (int i = 0; i < DetectedObjectsArraySize; i++)
            {
                Collider obj = ObjectsInRange[i];
                if (obj == null || obj.gameObject == this.gameObject) continue;

                // Retrieves the direction to the detected object.
                Vector3 directionToObject = (obj.transform.position - VisorTransform.transform.position).normalized;

                // Checks if the detected object is within the character field of view (FOV).
                if (Vector3.Angle(VisorTransform.transform.forward, directionToObject) < DetectionFov / 2)
                {
                    // Checks the distance between the character and the detected object.
                    float distanceToObject = Vector3.Distance(VisorTransform.transform.position, obj.transform.position);

                    // checks if the direction to the object is unobstructed.
                    if (!Physics.Raycast(VisorTransform.transform.position, directionToObject, distanceToObject, humanController.Defines.detectionObstructionLayer))
                        VisibleObjects.Add(obj.gameObject);
                }

                // Functions to find specific objects within the array of detected objects.
                this.HS_FindAgentsInRange(obj.gameObject);
            }
        }

        // Function to check if the object is an character.
        private void HS_FindAgentsInRange(GameObject obj)
        {
            if (!obj.GetComponent<HumanScriptController>()) return;

            HumanScriptController target = obj.GetComponent<HumanScriptController>();

            // Target is within sensor range and visible.
            if (VisibleObjects.Contains(target.gameObject))
            {
                HasSpottedTheseAgents.Add(target);
            }

            // Target is within sensor range but NOT visible.
            else
            {
                IsDetectingTheseAgents.Add(target);
            }

            // Notifies the target character that it is within this sensor range and is visible.
            if (target.HS_Detection.HasSpottedTheseAgents.Contains(humanController))
            {
                SpottedByTheseAgents.Add(target);
            }

            // Notifies the target character that it is within this sensor range but is NOT visible.
            if (target.HS_Detection.IsDetectingTheseAgents.Contains(humanController))
            {
                DetectedByTheseAgents.Add(target);
            }
        }
    }
}