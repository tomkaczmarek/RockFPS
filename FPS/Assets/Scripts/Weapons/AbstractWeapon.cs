using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class AbstractWeapons 
    {
        public abstract string GetName();

        public virtual void ShootBehavior(Camera startPosition)
        {
            RaycastHit hit;
            if (Physics.Raycast(startPosition.transform.position, startPosition.transform.forward, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
                Enemy1 enemy = hit.transform.GetComponent<Enemy1>();
                if (enemy != null)
                {
                    enemy.TakeDamage(20);
                    Debug.Log(enemy.GetHealth());
                }
            }
        }
    }
}