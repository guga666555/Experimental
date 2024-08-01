using UnityEngine;
using UnityEngine.EventSystems;

namespace HumanScript
{
    public class HS_Movement : MonoBehaviour, IHumanScript
    {
        private HumanScriptController humanController;

        public Rigidbody HumanRigidBody { get; private set; }

        // Ground checker reference (But im using CharacterController Check? maybe this should be removed).
        [field: SerializeField] public Transform GroundChecker { get; private set; }

        private const float gravity = 9.81f;
        public Vector3 moveDirection;

        public void HS_Start(HumanScriptController controller)
        {
            this.humanController = controller;

            HumanRigidBody = GetComponent<Rigidbody>();
        }

        public void PlayerMoveDirection(Vector2 currentInput)
        {
            moveDirection = humanController.Defines.characterMaxSpeed * ((transform.TransformDirection(Vector3.forward) * currentInput.x)
            + (transform.TransformDirection(Vector3.right) * currentInput.y));

            HumanRigidBody.velocity = new Vector3(moveDirection.x, HumanRigidBody.velocity.y, moveDirection.z);
        }
    }
}