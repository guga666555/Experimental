using UnityEngine;

public class TD_Object : MonoBehaviour
{
    private AudioSource audioSource;
    private Animator animator;
    [field: SerializeField] private AudioClip[] doorOpen;
    [field: SerializeField] private AudioClip[] doorClose;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void AnimationDoorClose()
    {
        audioSource.PlayOneShot(doorClose[Random.Range(0, doorClose.Length - 1)]);
        animator.SetBool("DoorClosed", true);
    }

    public void AnimationDoorOpen()
    {
        if(animator.GetBool("DoorClosed") == false)
           audioSource.PlayOneShot(doorOpen[Random.Range(0, doorOpen.Length - 1)]);
    }
}
