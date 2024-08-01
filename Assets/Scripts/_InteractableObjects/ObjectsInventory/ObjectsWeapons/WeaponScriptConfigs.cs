using UnityEngine;

namespace WeaponController
{
    [CreateAssetMenu]
    public class WeaponScriptConfigs : ScriptableObject
    {
        [Header("Weapon Settings")]
        [Tooltip("The key name of the transform where the weapon should be attached.")]
        public string weaponHolderKey;

        [Tooltip("The category of the weapon.")]
        public WeaponCategories weaponCategory;

        [Header("Weapon Definitions")]
        [Tooltip("The amount of damage dealt by the weapon.")]
        public int bulletDamage;

        [Tooltip("The size of the weapon's magazine.")]
        public int magazineSize;

        [Tooltip("The maximum amount of ammo the player can carry for this weapon.")]
        public int maxAmmoSize;

        [Tooltip("The rate of fire for the weapon, in bullets per minute.")]
        public float rateOfFire;

        [Tooltip("The time required to fully reload the weapon, in seconds.")]
        public float reloadTime;

        [Tooltip("The maximum range of the weapon's raycast when shooting, in meters.")]
        public float maxWeaponRange;

        [Tooltip("Specifies if the weapon is automatic (true) or semi-automatic (false).")]
        public bool isWeaponAutomatic;

        // Enables burst-fire mode.
        public bool IsWeaponBurst => bulletsPerBurst > 1;

        // If weapon fires all bullets at once (prevents sound overlapping).
        public bool IsWeaponMultiShot => IsWeaponBurst && timeBetweenBursts == 0;

        [Tooltip("The number of bullets fired per burst.")]
        public int bulletsPerBurst;

        [Tooltip("The time interval between bursts, in seconds.")]
        public float timeBetweenBursts;

        // *********************************************************************************
        // *********************************************************************************

        [Header("Weapon Spread & Recoil")]
        [Tooltip("Bullet spread for the weapon")]
        public float bulletSpread;

        [Tooltip("Recoil effect on the X axis")]
        public float recoilX;

        [Tooltip("Recoil effect on the Y axis")]
        public float recoilY;

        [Tooltip("Recoil effect on the Z axis")]
        public float recoilZ;

        [Tooltip("Speed at which the weapon returns to its original position after firing")]
        public float returnSpeed;

        [Tooltip("Responsiveness of the weapon's recoil")]
        public float snappiness;

        // *********************************************************************************
        // *********************************************************************************

        [Header("Projectile Configuration")]
        [Tooltip("The GameObject representing the projectiles.")]
        public GameObject projectileObject;

        [Tooltip("The speed of the projectiles fired by this weapon.")]
        public float projectileSpeed;

        [Tooltip("The gravity effect on the projectiles (i.e., bullet drop).")]
        public float projectileGravity;

        // *********************************************************************************
        // *********************************************************************************

        [Header("Weapon Sounds Configuration")]
        [Tooltip("Audio clips for weapon firing sounds")]
        public AudioClip[] weaponSoundFire = default;

        [Tooltip("Audio clips for weapon reloading sounds")]
        public AudioClip[] weaponSoundReload = default;

        [Tooltip("Audio clips for weapon equipping sounds")]
        public AudioClip[] weaponSoundReady = default;
    }
}