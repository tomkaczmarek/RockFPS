using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public abstract class AbstractHealth : MonoBehaviour
    {
        public abstract void TakeDamage(int damage);

        public abstract float GetCurrentHealth();

        public abstract float GetMaxHealth();
    }
}