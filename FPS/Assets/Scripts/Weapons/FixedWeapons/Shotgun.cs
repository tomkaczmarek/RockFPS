using UnityEditor;
using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Weapons.FixedWeapons
{
    public class Shotgun : AbstractWeaponInfo
    {
        public string weaponName;

        WeaponEvents _weapon;

        public override string GetWeaponName()
        {
            return weaponName;
        }

        public void Start()
        {
            _weapon = GetComponent<WeaponEvents>();
        }

        public void Update()
        {
            _weapon.CallPlayerInput();
        }
    }
}