using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class WeaponEvents : MonoBehaviour
    {
        public delegate void WeaponHandler();
        public event WeaponHandler OnWeaponShot;
        public event WeaponHandler OnPlayerInput;
        public event WeaponHandler OnEnemyDamage;
        public event WeaponHandler OnWeaponReload;
        public event WeaponHandler OnEmptyWeapon;

        public event WeaponHandler OnSoundWeaponShot;
        public event WeaponHandler OnSoundWeaponEmptyAmmo;
        public event WeaponHandler OnSoundWeaponReload;

        public delegate void WeaponHitHandler(RaycastHit hit);
        public event WeaponHitHandler OnWeaponHit;
        public event WeaponHitHandler OnWeaponEndShot;

        public void CallWeaponShot()
        {
            if (OnWeaponShot != null)
                OnWeaponShot();
        }

        public void CallPlayerInput()
        {
            if (OnPlayerInput != null)
                OnPlayerInput();
        }

        public void CallWeaponHit(RaycastHit hit)
        {
            if (OnWeaponHit != null)
                OnWeaponHit(hit);
        }

        public void CallEnemyDamage()
        {
            if (OnEnemyDamage != null)
                OnEnemyDamage();
        }

        public void CallWeaponEndShot(RaycastHit hit)
        {
            if (OnWeaponEndShot != null)
                OnWeaponEndShot(hit);
        }

        public void CallWeaponReload()
        {
            if (OnWeaponReload != null)
                OnWeaponReload();
        }

        public void CallEmptyWeapon()
        {
            if (OnEmptyWeapon != null)
                OnEmptyWeapon();
        }
        public void CallSoundWeaponShot()
        {
            if (OnSoundWeaponShot != null)
                OnSoundWeaponShot();
        }
        public void CallSoundWeaponReload()
        {
            if (OnSoundWeaponReload != null)
                OnSoundWeaponReload();
        }
        public void CallSoundWeaponEmptyAmmo()
        {
            if (OnSoundWeaponEmptyAmmo != null)
                OnSoundWeaponEmptyAmmo();
        }
    }
}