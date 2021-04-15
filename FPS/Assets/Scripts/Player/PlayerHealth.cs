using Assets.Scripts.GameManager;
using Assets.Scripts.PowerUp;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerHealth : AbstractHealth
    {
        public float maxPlayerHealh;
        public float minPlayerHealth;
        private float _currentHealth;

        public void Start()
        {
            maxPlayerHealh -= GameManager.GameManager.Instance.GetLevelModification(maxPlayerHealh);
            if (maxPlayerHealh < minPlayerHealth)
                maxPlayerHealh = minPlayerHealth;
            _currentHealth = maxPlayerHealh;
        }


        //public void TakeDamageToPlayer(int damage)
        //{
        //    GodPack power = PowerUpsManager.Instance.GetActivePowerByType<GodPack>();
        //    if (power != null && power.IsActiveOnPlayer)
        //    { }//god mode
        //    else
        //        _currentHealth -= damage;
        //}

        //public float GetPlayerCurrentHealth()
        //{
        //    return _currentHealth;
        //}

        public void AddHealt(float health)
        {
            _currentHealth += health;
            if (_currentHealth > maxPlayerHealh)
                _currentHealth = maxPlayerHealh;
        }

        public override void TakeDamage(int damage)
        {
            GodPack power = PowerUpsManager.Instance.GetActivePowerByType<GodPack>();
            if (power != null && power.IsActiveOnPlayer)
            { }//god mode
            else
                _currentHealth -= damage;
        }

        public override float GetCurrentHealth()
        {
            return _currentHealth;
        }

        public override float GetMaxHealth()
        {
            return maxPlayerHealh;
        }
    }
}