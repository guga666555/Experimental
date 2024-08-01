using UnityEngine;

namespace PlayerController
{
    public class PS_PlayerInput : MonoBehaviour, IPlayerScript
    {
        private PlayerScriptController playerController;

        public PlayerControls PlayerInputControls { get; private set; }
        [field: SerializeField] public Camera PlayerCamera { get; private set; }
        [field: SerializeField] public GameObject UnitGameObject;
        private IControllerScript CurrentlyControlling;

        #region Actions Controls

        public Vector2 InputAxisCamera { get { return PlayerInputControls.Player.Mouse.ReadValue<Vector2>(); } private set { } }
        public Vector2 InputAxisMovement { get { return PlayerInputControls.Player.Movement.ReadValue<Vector2>(); } private set { } }
        public bool InputActionInteraction { get { return PlayerInputControls.Player.InteractionButton.triggered; } private set { } }
        public bool InputActionInvSwitch { get { return PlayerInputControls.Player.InventoryButton.triggered; } private set { } }
        public bool InputActionFire1_Auto { get { return PlayerInputControls.Player.Fire1.ReadValue<float>() > 0; } private set { } }
        public bool InputActionFire1_Semi { get { return PlayerInputControls.Player.Fire1.triggered; } private set { } }
        public bool InputActionWeaponADS { get { return PlayerInputControls.Player.ADS.ReadValue<float>() > 0; } private set { } }
        public bool InputActionWeaponReload { get { return PlayerInputControls.Player.WeaponReload.triggered; } private set { } }

        #endregion

        #region Axis Vectors Reference

        // Stores character camera vectors XY.
        public float CameraInputX { get => InputAxisCamera.x; private set { } }
        public float CameraInputY { get => InputAxisCamera.y; private set { } }

        // Stores character movement vectors XY.
        public float MovementInputX { get => InputAxisMovement.x; private set { } } 
        public float MovementInputY { get => InputAxisMovement.y; private set { } }

        #endregion

        // Creates and initializes the Input system for this character (MUST BE ON AWAKE!).
        private void Awake()
        {
            PlayerInputControls = new();
            PlayerInputControls.Enable();
        }

        public void PS_Start(PlayerScriptController controller)
        {
            this.playerController = controller;
            Invoke("Control", 1f);
        }

        public void Control()
        {
            DirectControlUnitEnter(UnitGameObject.GetComponent<IControllerScript>());
        }

        public void DirectControlUnitEnter(IControllerScript controller)
        {
            CurrentlyControlling = controller;
            CurrentlyControlling.InputDirectControlEnter(PlayerCamera);
            Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;
        }

        public void DirectControlUnitExit()
        {
            CurrentlyControlling.InputDirectControlExit();
            CurrentlyControlling = null;
            Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
        }

        public void Update()
        {
            if (CurrentlyControlling != null)
            {
                CurrentlyControlling.InputCamera(this);
                CurrentlyControlling.InputMovement(this);
                CurrentlyControlling.InputInteraction(this);
                CurrentlyControlling.InputSwitchInventorySlot(this);
                CurrentlyControlling.InputFireWeapon(this);
                CurrentlyControlling.InputReloadWeapon(this);
                CurrentlyControlling.InputADSWeapon(this);
            }
        }
    }
}
