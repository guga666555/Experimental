using UnityEngine;

namespace PlayerController
{
    public interface IControllerScript
    {
        void InputDirectControlEnter(Camera playerCamera);
        void InputDirectControlExit();
        void InputCamera(PS_PlayerInput input);
        void InputMovement(PS_PlayerInput input);
        void InputInteraction(PS_PlayerInput input);
        void InputSwitchInventorySlot(PS_PlayerInput input);
        void InputFireWeapon(PS_PlayerInput input);
        void InputReloadWeapon(PS_PlayerInput input);
        void InputADSWeapon(PS_PlayerInput input);
    }
}
