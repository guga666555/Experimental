using ObjectsInteractable;
using ObjectsInventory;
using UnityEngine;

namespace HumanScript
{
    public class HS_Interaction : MonoBehaviour, IHumanScript
    {
        private HumanScriptController humanoidController;

        // Specifies the origin point for the interaction raycast in the player's UI.
        private Vector3 playerPoint = new(0.5f, 0.5f, 0f);

        // Reference to the current interactable object.
        private IObjectsInteractable currentInteractable;

        public void HS_Start(HumanScriptController controller)
        {
            this.humanoidController = controller;
        }

        public void Update()
        {
            this.PS_CheckInteractions();
        }

        private void PS_CheckInteractions()
        {
            if (!humanoidController.HS_PlayerInput.IsPlayerControlled) return;

            // On raycast detect a current interactable in range.
            if (Physics.Raycast(humanoidController.HS_PlayerInput.PlayerCamera.ViewportPointToRay(playerPoint),
            out RaycastHit hit, humanoidController.Defines.charInteractionDistance,
            humanoidController.Defines.charInteractionLayer))
            {
                // Checks if there is already a reference to a current interactable object.
                if (currentInteractable == null || hit.collider.gameObject.GetInstanceID() !=
                currentInteractable.OI_OnGetObject().gameObject.GetInstanceID())
                {
                    hit.collider.TryGetComponent(out currentInteractable);
                }
                if (currentInteractable != null) currentInteractable.OI_OnLookAt();
            }

            // When the current interactable object is out of raycast range.
            else if (currentInteractable != null)
            {
                currentInteractable.OI_OnLookAway();
                currentInteractable = null;
            }
        }

        public void PS_InteractionTrigger()
        {
            // Checks if the current interactable object is still within raycast range.
            if (Physics.Raycast(humanoidController.HS_PlayerInput.PlayerCamera.ViewportPointToRay(playerPoint),
            humanoidController.Defines.charInteractionDistance,
            humanoidController.Defines.charInteractionLayer))
            {
                // Calls the inventory checker on (HS_Inventory) if the object implements the Inventory interface.
                currentInteractable.OI_OnGetObject().TryGetComponent(out IObjectsInventory inventoryObject);
                if (inventoryObject != null) humanoidController.HS_Inventory.HS_InventoryAddObject(inventoryObject);

                // Calls the function of the current interactable object.
                currentInteractable.OI_OnInteraction();
            }
        }
    }
}