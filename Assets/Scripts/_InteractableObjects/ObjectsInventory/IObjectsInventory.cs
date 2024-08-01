using System.Collections.Generic;
using UnityEngine;

namespace ObjectsInventory
{
    public interface IObjectsInventory
    {
        ObjectsInventoryScript IS_OnGetObject();
        void IS_OnAddToInventory(Dictionary<string, Transform> holder);
        void IS_OnRemoveFromInventory();
    }
}