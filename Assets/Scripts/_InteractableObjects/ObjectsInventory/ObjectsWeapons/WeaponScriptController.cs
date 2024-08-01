using ObjectsInventory;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

namespace WeaponController
{
    public class WeaponScriptController : ObjectsInventoryScript, IObjectsInventory
    {
        private AudioSource audioSource = null;
        private Transform aimReference = null;
        private BoxCollider weaponCollider;
        private Rigidbody weaponRB;

        [field: SerializeField] public WeaponScriptConfigs WeaponConfig { get; private set; }
        [field: SerializeField] private Transform foresightPoint;
        [field: SerializeField] private GameObject magazineAnm;
        [field: SerializeField] public ParticleSystem muzzleFlash;

        #region Weapon Info Getters

        public bool IsShooting { get; set; }
        public bool IsReloading { get; set; }
        public int BulletsShot { get; set; }
        public int BulletsLeft { get; private set; }
        public bool ReadyToShoot { get; private set; }

        #endregion

        public ObjectsInventoryScript IS_OnGetObject()
        {
            return this;
        }

        public void IS_OnAddToInventory(Dictionary<string, Transform> holder)
        {
            if (holder.TryGetValue(WeaponConfig.weaponHolderKey, out Transform weaponContainer))
            {
                transform.parent = weaponContainer;
                transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                weaponCollider.isTrigger = true;
                weaponRB.isKinematic = true;
            }
            else
            {
                Debug.LogError(gameObject + " Could not find the given transform key!");
            }
        }

        public void IS_OnRemoveFromInventory()
        {
            transform.parent = null;
        }

        private void Awake()
        {
            weaponCollider = GetComponent<BoxCollider>();
            weaponRB = GetComponent<Rigidbody>();

            this.BulletsLeft = WeaponConfig.magazineSize;
            this.ReadyToShoot = true;
        }

        public void WS_WeaponActivate(Transform aimReference, AudioSource audioSource)
        {
            this.aimReference = aimReference;
            this.audioSource = audioSource;
        }

        public void WS_WeaponADS(Dictionary<string, Transform> holder, bool inOut)
        {
            if (inOut)
            {
                if (holder.TryGetValue(WeaponConfig.weaponHolderKey + "ADS", out Transform weaponContainer))
                {
                    transform.parent = weaponContainer;
                    transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                }
                else
                {
                    Debug.LogError(gameObject + " Could not find the given transform key!");
                }
            }
            else
            {
                if (holder.TryGetValue(WeaponConfig.weaponHolderKey, out Transform weaponContainer))
                {
                    transform.parent = weaponContainer;
                    transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                }
                else
                {
                    Debug.LogError(gameObject + " Could not find the given transform key!");
                }
            }
        }

        public void WS_WeaponShot()
        {
            this.WS_Raycast();
            this.WS_Shot();
        }

        public void WS_WeaponReload()
        {
            // TEMP...
            if (magazineAnm != null) magazineAnm.SetActive(false);

            IsReloading = true;
            Invoke("WS_ReloadFinished", WeaponConfig.reloadTime);
            this.WS_PlaySound(WeaponConfig.weaponSoundReload);
        }

        private void WS_ReloadFinished()
        {
            // TEMP...
            if (magazineAnm != null) magazineAnm.SetActive(true);

            BulletsLeft = WeaponConfig.magazineSize;
            IsReloading = false;
        }

        private void WS_Raycast()
        {
            // Raycast
            float x = Random.Range(-WeaponConfig.bulletSpread, WeaponConfig.bulletSpread);
            float y = Random.Range(-WeaponConfig.bulletSpread, WeaponConfig.bulletSpread);
            Vector3 directionWithoutSpread = aimReference.transform.forward;
            Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

            // Spawn Projectile 
            GameObject currentBullet = Instantiate(WeaponConfig.projectileObject, foresightPoint.position + new Vector3(0f, 0f, 0.1f), Quaternion.identity);
            currentBullet.transform.forward = directionWithSpread.normalized;
            currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * WeaponConfig.projectileSpeed, ForceMode.Impulse);
            currentBullet.GetComponent<WeaponProjectile>().ProjectileActivate(WeaponConfig.bulletDamage, weaponCollider);
            currentBullet.GetComponent<WeaponProjectile>().Invoke("DeathComes", 10f);
            
            // DEBUG raycast
            Ray RaycastShot = new(aimReference.transform.position, directionWithSpread);
            Vector3 targetPoint;

            if (Physics.Raycast(RaycastShot, out RaycastHit hit))
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = RaycastShot.GetPoint(WeaponConfig.maxWeaponRange);
            }

            Debug.DrawLine(aimReference.position, targetPoint, Color.red, 1f);
            Debug.DrawLine(foresightPoint.position, targetPoint, Color.blue, 1f);
        }

        private void WS_Shot()
        {
            // gun fire logic
            BulletsLeft--;
            BulletsShot--;
            ReadyToShoot = false;
            if (!WeaponConfig.IsWeaponMultiShot)
            {
                this.WS_PlaySound(WeaponConfig.weaponSoundFire);
                muzzleFlash.Play();
            }

            // Burst fire mode...
            if (WeaponConfig.IsWeaponBurst)
            {
                if (BulletsShot > 0 && BulletsLeft > 0) 
                {
                    Invoke("WS_WeaponShot", WeaponConfig.timeBetweenBursts);
                }
                else
                {
                    Invoke("WS_ResetShot", (60f / (WeaponConfig.rateOfFire / WeaponConfig.bulletsPerBurst)));
                    if (WeaponConfig.IsWeaponMultiShot)
                    {
                        this.WS_PlaySound(WeaponConfig.weaponSoundFire);
                        muzzleFlash.Play();
                    }
                }
            }

            // Normal firing mode...
            else
            {
                Invoke("WS_ResetShot", (60f / WeaponConfig.rateOfFire));
            }
        }

        private void WS_ResetShot() { ReadyToShoot = true; }

        private void WS_PlaySound(AudioClip[] clip)
        {
            audioSource.PlayOneShot(clip[Random.Range(0, clip.Length - 1)]);
        }
    }
}