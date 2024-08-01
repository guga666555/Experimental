using UnityEngine;

namespace PlayerController
{
    [RequireComponent(typeof(PS_PlayerInput))]
    public class PlayerScriptController : MonoBehaviour
    {
        public PS_PlayerInput PS_PlayerInput { get; private set; }

        private void Start()
        {
            PS_PlayerInput = GetComponent<PS_PlayerInput>();
            PS_PlayerInput.PS_Start(this);
        }
    }
}