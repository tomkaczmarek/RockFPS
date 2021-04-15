using UnityEditor;
using UnityEngine;
using System;

namespace Assets.Scripts.Weapons.FixedWeapons
{
    public class AmmoBase : MonoBehaviour
    {
        public virtual float GetMaxAmmo() => throw new NotImplementedException();
        public virtual string GetAmmoInfo() => throw new NotImplementedException();
        public virtual bool CheckIfHasAmmo() => throw new NotImplementedException();
        public virtual void ShotAmmo() => throw new NotImplementedException();
        public virtual void DisplayAmmo() => throw new NotImplementedException();

    }
}