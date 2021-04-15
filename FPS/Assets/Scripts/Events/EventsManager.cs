using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class EventsManager : MonoBehaviour
    {
        public delegate void DamageAction();
        public event DamageAction OnDamage;

        public delegate void DamageHit(RaycastHit hit);
        public event DamageHit OnDamageHit;

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Destroy(transform.gameObject);
                if (OnDamage != null)
                    OnDamage();
            }
        }

        public void CallOnDamageHit(RaycastHit hit)
        {
            if (OnDamageHit != null)
                OnDamageHit(hit);
        }

    }
}