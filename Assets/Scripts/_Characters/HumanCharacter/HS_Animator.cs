using UnityEngine;

namespace HumanScript
{
    public class HS_Animator : MonoBehaviour, IHumanScript
    {
        private HumanScriptController humanController;
        public float BlendTreeSmoothDamp = 0.2f;

        [field: SerializeField] public Animator HumanAnimator { get; private set; }

        // Start is called before the first frame update
        public void HS_Start(HumanScriptController controller)
        {
            humanController = controller;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 localMoveDirection = humanController.transform.InverseTransformDirection(humanController.HS_Movement.moveDirection);

            print(Mathf.Round(localMoveDirection.x));
            print(Mathf.Round(localMoveDirection.z));
            HumanAnimator.SetFloat("MovementX", localMoveDirection.x, BlendTreeSmoothDamp, Time.deltaTime);
            HumanAnimator.SetFloat("MovementY", localMoveDirection.z, BlendTreeSmoothDamp, Time.deltaTime);
        }
    }
}