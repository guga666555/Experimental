using PlayerController;
using UnityEngine;

namespace HumanScript
{
    public class HS_PlayerInput : MonoBehaviour, IHumanScript, IControllerScript
    {
        private HumanScriptController humanController;

        public Camera PlayerCamera { get; private set; } = null;
        public float CameraXRotation { get; private set; } = 0;
        public float CameraYRotation { get; private set; } = 0;

        public bool IsPlayerControlled
        {
            get => PlayerCamera ? true : false;
            private set { }
        }

        public void HS_Start(HumanScriptController controller)
        {
            this.humanController = controller;
        }

        public void InputDirectControlEnter(Camera playerCamera)
        {
            this.PlayerCamera = playerCamera;
        }

        public void InputDirectControlExit()
        {
            PlayerCamera = null;
        }

        public void InputCamera(PS_PlayerInput input)
        {
            // 3P
            float yawCamera = PlayerCamera.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), 15f * Time.fixedDeltaTime);

            // OLD 1P
            // Controlling
            // CameraYRotation += input.CameraInputX * Time.deltaTime * humanController.Defines.cameraSensibility;
            // CameraXRotation -= input.CameraInputY * Time.deltaTime * humanController.Defines.cameraSensibility;
            // CameraXRotation = Mathf.Clamp(CameraXRotation, -humanController.Defines.maxCameraRotation, humanController.Defines.maxCameraRotation);
            // PlayerCamera.transform.localRotation = Quaternion.Euler(CameraXRotation, 0, 0);
            // this.transform.rotation = Quaternion.Euler(0, CameraYRotation, 0);

            // Camera Sway
            // float swayX = input.CameraInputX * humanController.Defines.swayAnimationMultiplier;
            // float swayY = input.CameraInputY * humanController.Defines.swayAnimationMultiplier;
            // Quaternion rotationX = Quaternion.AngleAxis(-swayY, Vector3.right);
            // Quaternion rotationY = Quaternion.AngleAxis(-swayX, Vector3.up);
            // Quaternion targetRotation = rotationX * rotationY;
            // FP_CameraHolder.localRotation = Quaternion.Slerp(FP_CameraHolder.localRotation, targetRotation,
               // humanController.Defines.swayAnimationSmooth * Time.deltaTime);
        }

        public void InputMovement(PS_PlayerInput input)
        {
            Vector2 currentInput = new(input.MovementInputY, input.MovementInputX);
            humanController.HS_Movement.PlayerMoveDirection(currentInput);
        }

        public void InputInteraction(PS_PlayerInput input)
        {
            if (!input.InputActionInteraction) return;
            humanController.HS_Interaction.PS_InteractionTrigger();

        }

        public void InputSwitchInventorySlot(PS_PlayerInput input)
        {
            if (!input.InputActionInvSwitch || humanController.HS_Inventory.InventorySlots.Count == 0) return;
            humanController.HS_Inventory.HS_InventorySwitchSlots();
        }

        public void InputFireWeapon(PS_PlayerInput input)
        {
            if (!humanController.HS_Weapons.IsHoldingWeapon) return;

            // Updates the weapon script to reflect the player's firing state.
            humanController.HS_Weapons.CurrentWeapon.IsShooting = humanController.HS_Weapons.CurrentWeapon.WeaponConfig.isWeaponAutomatic ?
               input.InputActionFire1_Auto : input.InputActionFire1_Semi;

            // Checks for firing input.
            if (humanController.HS_Weapons.CurrentWeapon.IsShooting)
            {
                humanController.HS_Weapons.HS_WeaponFire();
            }
        }

        public void InputReloadWeapon(PS_PlayerInput input)
        {
            if (!humanController.HS_Weapons.IsHoldingWeapon) return;

            // Checks for reload input.
            if (input.InputActionWeaponReload)
            {
                humanController.HS_Weapons.HS_WeaponReload();
            }
        }

        public void InputADSWeapon(PS_PlayerInput input)
        {
            if (!humanController.HS_Weapons.IsHoldingWeapon) return;

            if (input.InputActionWeaponADS && !humanController.HS_Weapons.CurrentWeapon.IsReloading)
            {
                humanController.HS_Weapons.HS_WeaponADSTrigger(true);
            }
            else
            {
                humanController.HS_Weapons.HS_WeaponADSTrigger(false);
            }
        }
    }
}

