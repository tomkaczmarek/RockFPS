using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Events;

namespace Assets.Scripts.Weapons.FixedWeapons
{
    public class DefaultAmmoManager : AmmoBase
    {
        public float maxAmmo;
        public Text ammoInfo;

        private float _hitAmmo;
        WeaponEvents _weaponBase;

        public void OnEnable()
        {
            _weaponBase = GetComponent<WeaponEvents>();
            _weaponBase.OnWeaponReload += OnWeaponReload;
        }

        private void OnWeaponReload()
        {
            _hitAmmo = 0;
            _weaponBase.CallSoundWeaponReload();
            DisplayAmmo();
        }

        public void OnDisable()
        {
            _weaponBase.OnWeaponReload -= OnWeaponReload;
        }

        public override bool CheckIfHasAmmo()
        {
            return maxAmmo - _hitAmmo > 0;
        }

        public override string GetAmmoInfo()
        {
            return maxAmmo - _hitAmmo > 0 ? $"ammo {maxAmmo - _hitAmmo} / {maxAmmo}" : $"ammo { maxAmmo - _hitAmmo} / { maxAmmo} (R) Reload";
        }

        public override float GetMaxAmmo()
        {
            return maxAmmo;
        }

        public override void ShotAmmo()
        {
            _hitAmmo += 1;
            DisplayAmmo();
        }

        public override void DisplayAmmo()
        {
            ammoInfo.text = GetAmmoInfo();
        }



    }
}