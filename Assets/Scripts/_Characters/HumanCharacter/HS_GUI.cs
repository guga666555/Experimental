using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HumanScript
{
    public class HS_GUI : MonoBehaviour, IHumanScript
    {
        private HumanScriptController humanoidController;

        // A really messy script, will require a big fix later.
        [field: SerializeField] private List<GameObject> uiElements = new();
        [field: SerializeField] public RawImage FadeGUI { get; private set; }

        public void HS_Start(HumanScriptController controller)
        {
            this.humanoidController = controller;
        }

        public void DisableJoysticks()
        {
            foreach (GameObject go in uiElements)
            {
                if (go.TryGetComponent<Joystick>(out Joystick i))
                {
                    i.gameObject.SetActive(false);
                }
            }
        }

        public void DisableGUI()
        {
            foreach (GameObject i in uiElements) { i.SetActive(false); }
        }

        public void EnableGUI()
        {
            foreach (GameObject i in uiElements) { i.SetActive(true); }
        }
    }
}