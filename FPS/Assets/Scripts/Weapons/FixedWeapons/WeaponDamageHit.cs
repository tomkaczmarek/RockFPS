using Assets.Scripts.Enemies;
using Assets.Scripts.Player;
using UnityEditor;
using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Weapons.FixedWeapons
{
    public class WeaponDamageHit : MonoBehaviour
    {
        public int damage;

        WeaponEvents _weapon;
        public void OnEnable()
        {
            _weapon = GetComponent<WeaponEvents>();
            _weapon.OnWeaponHit += OnWeaponHit; 
        }

       
        public void OnDisable()
        {
            _weapon.OnWeaponHit -= OnWeaponHit;
        }

        private void OnWeaponHit(RaycastHit hit)
        {
            EnemyHealth enemy = (EnemyHealth)hit.transform.GetComponent<AbstractHealth>();
            if (enemy != null)
                enemy.TakeDamage(damage);

            _weapon.CallWeaponEndShot(hit);
        }

    }
    
}