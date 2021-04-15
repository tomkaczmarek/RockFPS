using UnityEditor;
using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Weapons.FixedWeapons
{
    public class WeaponImpact : MonoBehaviour
    {
        public ParticleSystem impact;

        WeaponEvents _weaponBase;
        public void OnEnable()
        {
            _weaponBase = GetComponent<WeaponEvents>();
            _weaponBase.OnWeaponEndShot += OnWeaponEndShot;
        }
        public void OnDisable()
        {
            _weaponBase.OnWeaponEndShot += OnWeaponEndShot;
        }
        private void OnWeaponEndShot(RaycastHit hit)
        {
            ParticleSystem system = Instantiate(impact, hit.transform.position, Quaternion.identity);
            system.Play();
        }

       


        
    }
}