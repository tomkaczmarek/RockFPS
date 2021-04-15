using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.PowerUp
{
    public abstract class AbstractPowerUp : MonoBehaviour
    {
        public abstract event Action<GameObject> OnActiveEnd;

        public bool IsActiveOnPlayer { get; set; }

        public abstract string PowerName();

        public abstract float PowerDuration();

        public abstract bool IsReuseable();

        public abstract void UpdateNotyfication();

        internal string ConvertToTime(float time)
        {
            var t = TimeSpan.FromSeconds(time);
            return $"{t.ToString("hh':'mm':'ss")}";
        }
        public abstract void NotificationVisibility(bool visible);

    }
}