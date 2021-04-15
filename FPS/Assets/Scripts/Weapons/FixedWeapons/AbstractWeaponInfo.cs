using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Weapons.FixedWeapons
{
    public abstract class AbstractWeaponInfo : MonoBehaviour
    {
         public abstract string GetWeaponName();
    }
}