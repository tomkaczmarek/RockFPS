using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Rifle : AbstractWeapons
    {
        public override string GetName()
        {
            return "Rifle";
        }

        public override void ShootBehavior(Camera startPosition)
        {
            base.ShootBehavior(startPosition);
        }
    }
}