using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class CanvasManager : MonoBehaviour
    {
        private Text _timer;

        public void Start()
        {
            _timer = transform.Find("Level Time").GetComponent<Text>();
        }
        public void SetTextMessage(Text target, string message)
        {
            throw new NotImplementedException();
        }

        public void SetPlayerHealth(float health, float maxHealth)
        {
            Slider slider = transform.Find("HeartBar").GetComponent<Slider>();
            slider.maxValue = maxHealth;
            slider.value = health;
        }

        public void SetLevelTime(float time)
        {
            _timer.text = time.ToString();
        }
    }
}