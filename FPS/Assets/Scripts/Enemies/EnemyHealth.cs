using UnityEditor;
using UnityEngine;
using Assets.Scripts.GameManager;
using Assets.Scripts.Player;
using Assets.Scripts.PowerUp;

namespace Assets.Scripts.Enemies
{
    public class EnemyHealth : AbstractHealth
    {
        public float health = 100f;
        private float _currentHealth;

        private Events.SoundEvents sound;

        public void Start()
        {
            sound = GetComponent<Events.SoundEvents>();
            _currentHealth = health;
        }
        private void Die()
        {
            sound.CallEnemyDead();           
            GameManager.GameManager.Instance.DecreaseEnemyUnits();
            GameManager.GameManager.Instance.RaiseEnemyKill();
            Destroy(gameObject);
        }

        public override void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            OneShootPack power = PowerUpsManager.Instance.GetActivePowerByType<OneShootPack>();
            if (_currentHealth <= 0 || power != null)
                Die();
        }

        public override float GetCurrentHealth()
        {
            return _currentHealth;
        }

        public override float GetMaxHealth()
        {
            return health;
        }
    }
}