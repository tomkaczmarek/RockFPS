using UnityEditor;
using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Weapons.FixedWeapons
{
    public class Rifle : AbstractWeaponInfo
    {
        public string weaponName;

        WeaponEvents _weapon;


        public void Start()
        {
            _weapon = GetComponent<WeaponEvents>();
        }

        public void Update()
        {
            _weapon.CallPlayerInput();
        }

        public override string GetWeaponName()
        {
            return weaponName;
        }

    }
}