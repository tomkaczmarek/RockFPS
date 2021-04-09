using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Weapons
{
    public class Rifle : AbstractWeapons
    {
        public ParticleSystem flash;
        private float nextTimeToFire = 0;
        private float fireRate = 15f;
        public float maxAmmo;
        public Text ammoInfo;
        private float _hitAmmo;
        public float damage;

        public override float GetDamage()
        {
            return damage;
        }
        public override float GetMaxAmmo()
        {
            return maxAmmo;
        }
        public override string GetName()
        {
            return "Rifle";
        }
        public override string GetAmmoInfo()
        {
            return maxAmmo - _hitAmmo > 0 ? $"ammo {maxAmmo - _hitAmmo} / {maxAmmo}" : $"ammo { maxAmmo - _hitAmmo} / { maxAmmo} (R) Reload";
        }

        public override void ShootBehavior(Camera startPosition, float damage)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && CheckIfHasAmmo(_hitAmmo, maxAmmo))
            {
                _hitAmmo++;
                nextTimeToFire = Time.time + 1f / fireRate;
                flash.Play();
                base.ShootBehavior(startPosition, damage);
                base.ShowAmmo(ammoInfo, GetAmmoInfo());
            }
            if (Input.GetKey(KeyCode.R))
            {
                _hitAmmo = 0;
                base.ShowAmmo(ammoInfo, GetAmmoInfo());
            }

        }
    }
}