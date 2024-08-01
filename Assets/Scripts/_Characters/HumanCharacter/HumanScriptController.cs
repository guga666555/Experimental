using UnityEngine;

namespace HumanScript
{
    [RequireComponent(typeof(HS_Animator))]
    [RequireComponent(typeof(HS_Audio))]
    [RequireComponent(typeof(HS_Detection))]
    [RequireComponent(typeof(HS_Health))]
    [RequireComponent(typeof(HS_Interaction))]
    [RequireComponent(typeof(HS_Inventory))]
    [RequireComponent(typeof(HS_Movement))]
    [RequireComponent(typeof(HS_PlayerInput))]
    [RequireComponent(typeof(HS_Weapons))]

    public class HumanScriptController : MonoBehaviour
    {
        [field: SerializeField] public HumanDefines Defines { get; private set; }
        public HS_Animator HS_Animator { get; private set; }
        public HS_Audio HS_Audio { get; private set; }
        public HS_Detection HS_Detection { get; private set; }
        public HS_Health HS_Health { get; private set; }
        public HS_Interaction HS_Interaction { get; private set; }
        public HS_Inventory HS_Inventory { get; private set; }
        public HS_Movement HS_Movement { get; private set; }
        public HS_PlayerInput HS_PlayerInput { get; private set; }
        public HS_Weapons HS_Weapons { get; private set; }

        private void Start()
        {
            HS_Animator = GetComponent<HS_Animator>();
            HS_Audio = GetComponent<HS_Audio>();
            HS_Detection = GetComponent<HS_Detection>();
            HS_Health = GetComponent<HS_Health>();
            HS_Interaction = GetComponent<HS_Interaction>();
            HS_Inventory = GetComponent<HS_Inventory>();
            HS_Movement = GetComponent<HS_Movement>();
            HS_PlayerInput = GetComponent<HS_PlayerInput>();
            HS_Weapons = GetComponent<HS_Weapons>();

            foreach (IHumanScript playerScript in gameObject.GetComponents<IHumanScript>())
            {
                playerScript.HS_Start(this);
            }
        }
    }
}