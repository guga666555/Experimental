using HumanScript;
using ObjectsInteractable;

namespace ObjectsInventory
{
    public abstract class ObjectsInventoryScript : ObjectsInteractableScript, IObjectsInteractable
    {
        public bool Equipped => GetComponentInParent<HumanScriptController>();

        public ObjectsInteractableScript OI_OnGetObject() { return this; }
        public void OI_OnLookAt() { }
        public void OI_OnLookAway() { }
        public void OI_OnInteraction() { }
    }
}