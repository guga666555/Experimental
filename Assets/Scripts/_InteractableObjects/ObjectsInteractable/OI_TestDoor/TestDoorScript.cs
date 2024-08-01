using ObjectsInteractable;
using UnityEngine;

public class TestDoorScript : ObjectsInteractableScript, IObjectsInteractable
{
    [field: SerializeField] public DoorSide doorSide;
    [field: SerializeField] private Animator animator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    public ObjectsInteractableScript OI_OnGetObject() { return this; }

    public void OI_OnLookAt() { }

    public void OI_OnLookAway() { }

    public void OI_OnInteraction()
    {
        switch (doorSide)
        {
            case DoorSide.front:
                if (!animator.GetBool("DoorOpenFront"))
                {
                    animator.SetBool("DoorClosed", false);
                    animator.SetBool("DoorOpenFront", true);
                    animator.SetBool("DoorCloseFront", false);
                }
                else
                {
                    animator.SetBool("DoorOpenFront", false);
                    animator.SetBool("DoorCloseFront", true);
                }

                break;
            case DoorSide.back:
                if (!animator.GetBool("DoorOpenBack"))
                {
                    animator.SetBool("DoorClosed", false);
                    animator.SetBool("DoorOpenBack", true);
                    animator.SetBool("DoorCloseBack", false);
                }
                else
                {
                    animator.SetBool("DoorOpenBack", false);
                    animator.SetBool("DoorCloseBack", true);
                }
                break;
        }
    }
}

public enum DoorSide
{
    front,
    back
}