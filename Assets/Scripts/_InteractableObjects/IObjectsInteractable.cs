namespace ObjectsInteractable
{
    public interface IObjectsInteractable
    {
        ObjectsInteractableScript OI_OnGetObject();
        void OI_OnLookAt();
        void OI_OnLookAway();
        void OI_OnInteraction();
    }
}