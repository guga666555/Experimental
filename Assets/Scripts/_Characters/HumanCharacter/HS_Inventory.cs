using ObjectsInventory;
using System.Collections.Generic;
using UnityEngine;
using WeaponController;

namespace HumanScript
{
    public class HS_Inventory : MonoBehaviour, IHumanScript
    {
        private HumanScriptController humanController;

        // Reference to the current inventory object the player is interacting with.
        [field: SerializeField] public IObjectsInventory CurrentSlot { get; private set; }

        // The list where all inventory objects references will be stored.
        [field: SerializeField] public List<IObjectsInventory> InventorySlots { get; private set; } = new();

        // Index reference to the current inventory object.
        private int currentSlotIndex;

        // Dictionary of weapon holders, keyed by weapon type name.
        [field: SerializeField] public Dictionary<string, Transform> InventoryHolders { get; private set; } = new();

        public void HS_Start(HumanScriptController controller)
        {
            this.humanController = controller;

            this.HS_InventoryRegisterContainers();
            this.HS_InventoryStartCheck();
        }

        // Keymap and start the dictionary container dictionary.
        private void HS_InventoryRegisterContainers()
        {
            InventoryHolders.Add("CustomPistol", humanController.HS_Weapons.PW_CustomPistol);
            InventoryHolders.Add("CustomPistolADS", humanController.HS_Weapons.PW_CustomPistolADS);
            InventoryHolders.Add("CustomRifle", humanController.HS_Weapons.PW_CustomRifle);
            InventoryHolders.Add("CustomRifleADS", humanController.HS_Weapons.PW_CustomRifleADS);
            InventoryHolders.Add("CustomShotgun", humanController.HS_Weapons.PW_CustomShotgun);
            InventoryHolders.Add("CustomShotgunADS", humanController.HS_Weapons.PW_CustomShotgunADS);
            InventoryHolders.Add("CustomSniper", humanController.HS_Weapons.PW_CustomSniper);
            InventoryHolders.Add("CustomSniperADS", humanController.HS_Weapons.PW_CustomSniperADS);
        }

        // Checks the character starting inventory.
        private void HS_InventoryStartCheck()
        {
            IObjectsInventory[] array = GetComponentsInChildren<IObjectsInventory>();
            foreach (var i in array) { HS_InventoryAddObject(i); }
        }

        // Adds an interactable item to inventory (Called from HS_Interaction).
        public void HS_InventoryAddObject(IObjectsInventory inventoryObject)
        {
            inventoryObject.IS_OnAddToInventory(InventoryHolders);
            InventorySlots.Add(inventoryObject);

            // When getting a new object it should aways be deactivated
            inventoryObject.IS_OnGetObject().gameObject.SetActive(false);
        }
        
        // Receives the request and activates the current object.
        private void HS_InventoryActivateObject(IObjectsInventory inventoryObject)
        {
            inventoryObject.IS_OnGetObject().gameObject.SetActive(true);

            // Checks if current equipped object is a weapon.
            if (inventoryObject.IS_OnGetObject().GetComponent<WeaponScriptController>())
            {
                humanController.HS_Weapons.HS_WeaponActivate(
                    inventoryObject.IS_OnGetObject().GetComponent<WeaponScriptController>());
            }
        }

        public void HS_InventorySwitchSlots()
        {
            // Linearly interpolates between inventory list.
            currentSlotIndex = (currentSlotIndex + 1) % InventorySlots.Count;
            CurrentSlot = InventorySlots[currentSlotIndex];

            // Calls the inventory method to equip the current object.
            this.HS_InventoryDeactivateObjects(CurrentSlot);
            this.HS_InventoryActivateObject(CurrentSlot);
        }

        private void HS_InventoryDeactivateObjects(IObjectsInventory inventoryObject)
        {
            if (InventorySlots.Count < 2) return;

            // Deactivates the other objects (As it can have only one activated per hand!).
            for (int i = 0; i < InventorySlots.Count; i++)
            {
                if (InventorySlots[i] == inventoryObject) continue;

                InventorySlots[i].IS_OnGetObject().gameObject.SetActive(false);

                // Checks if the previous equipped object was a weapon.
                if (humanController.HS_Weapons.CurrentWeapon == null)
                {
                    humanController.HS_Weapons.HS_WeaponDeactivate();
                }
            }
        }
    }
}