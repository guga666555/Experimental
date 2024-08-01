using ObjectsInteractable;
using System.Collections.Generic;
using UnityEngine;

public class TestButtonScript : ObjectsInteractableScript, IObjectsInteractable
{
    [field: SerializeField] private List<GameObject> interactables;

    public ObjectsInteractableScript OI_OnGetObject() { return this; }

    public void OI_OnLookAt() { }

    public void OI_OnLookAway() { }

    public void OI_OnInteraction()
    {
        for (int i = 0; i < interactables.Count; i++)
        {
            interactables[i].gameObject.SetActive(true);
        }
    }
}
