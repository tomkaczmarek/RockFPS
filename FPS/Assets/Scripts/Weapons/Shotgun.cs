using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Shotgun : AbstractWeapons
    {
        public override string GetName()
        {
            return "Shotgun";
        }

        public override void ShootBehavior(Camera startPosition)
        {
            base.ShootBehavior(startPosition);
        }
    }
}