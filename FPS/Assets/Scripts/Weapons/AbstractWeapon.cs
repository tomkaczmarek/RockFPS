using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Weapons
{
    public abstract class AbstractWeapons : MonoBehaviour
    {
        public abstract string GetName();
        public abstract float GetDamage();
        public abstract float GetMaxAmmo();

        public virtual void ShootBehavior(Camera startPosition, float damage)
        {
            RaycastHit hit;
            if (Physics.Raycast(startPosition.transform.position, startPosition.transform.forward, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
                Enemy1 enemy = hit.transform.GetComponent<Enemy1>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    Debug.Log(enemy.GetHealth());
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * 100);
                }
            }
        }

        public virtual bool CheckIfHasAmmo(float leftAmmo, float maxAmmo)
        {
            return maxAmmo - leftAmmo > 0;
        }

        public virtual void ShowAmmo(Text textControl, string ammoInfo)
        {
            textControl.text = ammoInfo;
        }

        public abstract string GetAmmoInfo();
    }
}