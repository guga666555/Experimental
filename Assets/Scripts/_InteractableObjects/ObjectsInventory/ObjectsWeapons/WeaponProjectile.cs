using DamageSystem;
using UnityEngine;

namespace WeaponController
{
    public class WeaponProjectile : MonoBehaviour
    {
        private float ProjectileDamage { get; set; }
        private Collider ParentCollider { get; set; }

        public void ProjectileActivate(float projectileDamage, Collider parentCollider)
        {
            this.ProjectileDamage = projectileDamage;
            this.ParentCollider = parentCollider;
        }

        public void OnCollisionEnter(Collision col)
        {
            Debug.Log("TOMI lapada SECA! at: " + col.gameObject);

            var hitBox = col.gameObject.GetComponent<IHurtableScript>();

            if (hitBox != null)
            {
                hitBox.HT_OnTakeDamage(ProjectileDamage);
                Debug.Log("TOMI lapada bonecão!");
            }

            if (col.collider != ParentCollider)
            DeathComes();
        }

        public void DeathComes()
        {
            Destroy(this.gameObject);
        }
    }
}