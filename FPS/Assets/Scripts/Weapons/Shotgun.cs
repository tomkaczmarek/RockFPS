using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Weapons
{
    public class Shotgun : AbstractWeapons
    {
        public ParticleSystem flash;
        public float maxAmmo;
        public Text ammoInfo;
        public float damage;

        private float _hitAmmo;
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
            return "Shotgun";
        }
        public override string GetAmmoInfo()
        {
            return maxAmmo - _hitAmmo > 0 ? $"ammo {maxAmmo - _hitAmmo} / {maxAmmo}" : $"ammo { maxAmmo - _hitAmmo} / { maxAmmo} (R) Reload";
        }

        public override void ShootBehavior(Camera startPosition, float damage)
        {
            if (Input.GetButtonDown("Fire1") && CheckIfHasAmmo(_hitAmmo, maxAmmo))
            {
                _hitAmmo++;
                flash.Play();
                base.ShootBehavior(startPosition, damage);
                base.ShowAmmo(ammoInfo, GetAmmoInfo());
            }  
            
            if(Input.GetKey(KeyCode.R))
            {
                _hitAmmo = 0;
                base.ShowAmmo(ammoInfo, GetAmmoInfo());
            }
        }
    }
}