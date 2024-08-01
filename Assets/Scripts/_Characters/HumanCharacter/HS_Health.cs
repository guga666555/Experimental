using DamageSystem;
using UnityEngine;
using UnityEngine.UI;

namespace HumanScript
{
    public class HS_Health : MonoBehaviour, IHumanScript, IHurtableScript
    {
        private HumanScriptController humanoidController;
        [field: SerializeField] public float CurrentHealth { get; private set; }
        [field: SerializeField] public Slider AgentHealthUI { get; private set; }

        public void HS_Start(HumanScriptController controller)
        {
            this.humanoidController = controller;

            CurrentHealth = humanoidController.Defines.characterMaxHealth;
        }

        public void HT_OnTakeDamage(float damage)
        {
            CurrentHealth -= damage;
        }

        public void Update()
        {
            AgentHealthUI.value = CurrentHealth / humanoidController.Defines.characterMaxHealth;

            this.HS_CheckIsDead();
        }

        private void HS_CheckIsDead()
        {
            if (CurrentHealth <= 0)
            {
                print(gameObject.name + " Has Died!");
                gameObject.SetActive(false);
            }
        }
    }
}