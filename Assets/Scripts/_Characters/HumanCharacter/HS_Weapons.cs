using UnityEngine;
using WeaponController;

namespace HumanScript
{
    public class HS_Weapons : MonoBehaviour, IHumanScript
    {
        private HumanScriptController humanController;

        [field: SerializeField] public WeaponScriptController CurrentWeapon { get; private set; }
        [field: SerializeField] public Transform RecoilTransform { get; private set; }

        // Checks if the player character is holding a weapon.
        public bool IsHoldingWeapon { get { return CurrentWeapon != null; } private set { } }

        // Vectors for the recoil effect script.
        private Vector3 recoilCurrentRotation;
        private Vector3 recoilTargetRotation;
        private bool aimingDownSights;

        #region WeaponHolders

        [field: SerializeField] public Transform PW_CustomPistol { get; set; }
        [field: SerializeField] public Transform PW_CustomPistolADS { get; set; }
        [field: SerializeField] public Transform PW_CustomRifle { get; set; }
        [field: SerializeField] public Transform PW_CustomRifleADS { get; set; }
        [field: SerializeField] public Transform PW_CustomShotgun { get; set; }
        [field: SerializeField] public Transform PW_CustomShotgunADS { get; set; }
        [field: SerializeField] public Transform PW_CustomSniper { get; set; }
        [field: SerializeField] public Transform PW_CustomSniperADS { get; set; }

        #endregion

        public void HS_Start(HumanScriptController controller)
        {
            this.humanController = controller;
        }

        public void Update() 
        {
            this.HS_WeaponRecoilReset();
        }

        public void HS_WeaponActivate(WeaponScriptController CurrentWeapon)
        {
            this.CurrentWeapon = CurrentWeapon;
            this.CurrentWeapon.WS_WeaponActivate(humanController.HS_PlayerInput.PlayerCamera.transform,
              humanController.HS_Audio.WeaponAudioSource);
        }

        public void HS_WeaponDeactivate()
        {
            this.CurrentWeapon = null;
        }

        public void AS_ShootWeapon()
        {
            if (!IsHoldingWeapon) return;

            CurrentWeapon.IsShooting = true;
            HS_WeaponFire();
            if (CurrentWeapon.BulletsLeft <= 0) { HS_WeaponReload(); }
            CurrentWeapon.IsShooting = false;
        }

        public void HS_WeaponReload()
        {
            if (CurrentWeapon.BulletsLeft < CurrentWeapon.WeaponConfig.magazineSize && !CurrentWeapon.IsReloading)
            {
                CurrentWeapon.WS_WeaponReload();
            }
        }

        public void HS_WeaponFire()
        {   
            if (CurrentWeapon.IsShooting && CurrentWeapon.ReadyToShoot && !CurrentWeapon.IsReloading && CurrentWeapon.BulletsLeft > 0)
            {
                CurrentWeapon.BulletsShot = CurrentWeapon.WeaponConfig.bulletsPerBurst;
                CurrentWeapon.WS_WeaponShot();
                Invoke("HS_WeaponRecoilApply", 0.05f);
            }
        }

        public void HS_WeaponADSTrigger(bool inOut)
        {
            this.aimingDownSights = inOut;
            if (inOut)
                this.CurrentWeapon.WS_WeaponADS(humanController.HS_Inventory.InventoryHolders, inOut);
            else
                this.CurrentWeapon.WS_WeaponADS(humanController.HS_Inventory.InventoryHolders, inOut);
        }

        public void HS_WeaponRecoilApply()
        {
            Vector3 finalVector;
            if (!this.aimingDownSights)
            {
                finalVector = new Vector3(CurrentWeapon.WeaponConfig.recoilX,
                Random.Range(-CurrentWeapon.WeaponConfig.recoilY, CurrentWeapon.WeaponConfig.recoilY),
                Random.Range(-CurrentWeapon.WeaponConfig.recoilZ, -CurrentWeapon.WeaponConfig.recoilZ));
            }
            else
            {
                finalVector = new Vector3(CurrentWeapon.WeaponConfig.recoilX,
                Random.Range(-CurrentWeapon.WeaponConfig.recoilY, CurrentWeapon.WeaponConfig.recoilY),
                Random.Range(-CurrentWeapon.WeaponConfig.recoilZ, -CurrentWeapon.WeaponConfig.recoilZ) * 0.1f);
            }

            recoilTargetRotation += finalVector;
        }

        // Applies recoil reset force every frame, ensuring it takes effect even if the character is no longer holding a weapon.
        public void HS_WeaponRecoilReset()
        {
            // Returns if the character is not holding a weapon.
            if (!IsHoldingWeapon) return;

            recoilTargetRotation = Vector3.Lerp(recoilTargetRotation, Vector3.zero, CurrentWeapon.WeaponConfig.returnSpeed * Time.deltaTime);
            recoilCurrentRotation = Vector3.Slerp(recoilCurrentRotation, recoilTargetRotation, CurrentWeapon.WeaponConfig.snappiness * Time.fixedDeltaTime);
            RecoilTransform.localRotation = Quaternion.Euler(recoilCurrentRotation);
        }
    }
}