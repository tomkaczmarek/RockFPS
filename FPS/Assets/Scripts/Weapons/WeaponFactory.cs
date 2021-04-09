using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class WeaponFactory
    {
        public static AbstractWeapons GetWeapon(string objectName, GameObject obj)
        {
            switch (objectName)
            {
                case "Shotgun":
                    return obj.gameObject.GetComponentInChildren<Shotgun>(true);
                case "Pistol":
                    return obj.gameObject.GetComponentInChildren<Pistol>(true);
                default:
                    return obj.gameObject.GetComponentInChildren<Rifle>(true);
            }
        }
    }
}