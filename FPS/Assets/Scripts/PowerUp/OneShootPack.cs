using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.PowerUp
{
    public class OneShootPack : AbstractPowerUp
    {

        public float powerDuration;
        public Text notification;
        public override event Action<GameObject> OnActiveEnd;

        private float _timeLeft;
        public void Start()
        {
            _timeLeft = powerDuration;
        }

        public void Update()
        {
            if (IsActiveOnPlayer)
            {
                _timeLeft -= Time.deltaTime;
                Invoke(nameof(OnDestroy), powerDuration);
            }
        }
        private void OnDestroy()
        {
            if (OnActiveEnd != null)
                OnActiveEnd(gameObject);
        }

        public override bool IsReuseable()
        {
            return true;
        }

        public override void NotificationVisibility(bool visible)
        {
            if (notification != null)
                notification.gameObject.SetActive(visible);
        }

        public override float PowerDuration()
        {
            return powerDuration;
        }

        public override string PowerName()
        {
            return "one shot power";
        }

        public override void UpdateNotyfication()
        {
            notification.text = $"{PowerName()}: {ConvertToTime(_timeLeft)}";
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                GameManager.PowerUpsManager.Instance.RegisterPower(gameObject);
                IsActiveOnPlayer = true;
            }
        }
    }
}