using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class WeaponFactory 
    {
   public static AbstractWeapons GetWeapon(string objectName)
        {
            switch(objectName)
            {
                case "Shotgun":
                    return new Shotgun();
                case "Pistol":
                    return new Pistol();
                default:
                    return new Rifle();
            }
        }
    }
}