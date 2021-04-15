using Assets.Scripts.Events;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Weapons.FixedWeapons
{
    public class SingleAttack : AbstractAttack
    {
        public Camera startPosition;
        public AmmoBase ammoManager;
        public ParticleSystem flash;

        WeaponEvents _weaponBase;

        public void OnEnable()
        {
            _weaponBase = GetComponent<WeaponEvents>();
        }

        public override void Attack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (ammoManager.CheckIfHasAmmo())
                {
                    Shot();
                }
                else
                    _weaponBase.CallSoundWeaponEmptyAmmo();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _weaponBase.CallWeaponReload();
            }
        }
        private void Shot()
        {
            RaycastHit hit;
            flash.Play();
            if (Physics.Raycast(startPosition.transform.position, startPosition.transform.forward, out hit, 100))
            {
                _weaponBase.CallWeaponHit(hit);
            }
            ammoManager.ShotAmmo();
            _weaponBase.CallSoundWeaponShot();
        }
    }
}