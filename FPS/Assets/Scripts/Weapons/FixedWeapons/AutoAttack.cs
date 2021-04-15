using Assets.Scripts.Events;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Weapons.FixedWeapons
{
    public class AutoAttack : AbstractAttack
    {
        public Camera startPosition;
        public AmmoBase ammoManager;
        public ParticleSystem flash;

        private float nextTimeToFire = 0;
        private float fireRate = 15f;

        WeaponEvents _weaponBase;

        public void OnEnable()
        {
            _weaponBase = GetComponent<WeaponEvents>();
        }
        public override void Attack()
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                if (ammoManager.CheckIfHasAmmo())
                {
                    RaycastHit hit;
                    flash.Play();
                    nextTimeToFire = Time.time + 1f / fireRate;
                    if (Physics.Raycast(startPosition.transform.position, startPosition.transform.forward, out hit, 100))
                    {
                        _weaponBase.CallWeaponHit(hit);
                    }
                    ammoManager.ShotAmmo();
                    _weaponBase.CallSoundWeaponShot();
                }

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _weaponBase.CallWeaponReload();
            }
        }
    }
}