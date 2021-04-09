using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Pistol : AbstractWeapons
    {
        public override string GetName()
        {
            return "Pistol";
        }
        public override void ShootBehavior(Camera startPosition)
        {
            base.ShootBehavior(startPosition);
        }
    }
}