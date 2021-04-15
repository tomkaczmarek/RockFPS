using UnityEditor;
using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Weapons.FixedWeapons
{
    public class WeaponInput : MonoBehaviour
    {
        public AbstractAttack attackMode;
        WeaponEvents _weaponBase;

        public void OnEnable()
        {
            _weaponBase = GetComponent<WeaponEvents>();
            _weaponBase.OnPlayerInput += OnWeaponShoot;
        }
        public void OnDisable()
        {
            _weaponBase.OnPlayerInput -= OnWeaponShoot;
        }

        private void OnWeaponShoot()
        {
            attackMode.Attack();
        }
    }
}