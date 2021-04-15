using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.PowerUp
{
    public class HealthPack :AbstractPowerUp
    {
        public float healthPoint;
  
        private Player.PlayerHealth _playerHealth;

        public override event Action<GameObject> OnActiveEnd;

        public void Start()
        {
            _playerHealth = FindObjectOfType<Player.PlayerHealth>();
        }

        public override string PowerName()
        {
            return "Health Pack";
        }

        public override float PowerDuration()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsReuseable()
        {
            return false;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (_playerHealth.GetCurrentHealth() < _playerHealth.GetMaxHealth())
                {
                    IsActiveOnPlayer = true;
                    _playerHealth.AddHealt(healthPoint);
                    Destroy(gameObject);
                }           
            }
        }

        public override void NotificationVisibility(bool visible)
        {
            throw new NotImplementedException();
        }

        public override void UpdateNotyfication()
        {
            throw new NotImplementedException();
        }
    }
}