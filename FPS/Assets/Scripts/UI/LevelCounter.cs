using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class LevelCounter : MonoBehaviour
    {
        public Text counterText;

        public void Update()
        {
            counterText.text = ConvertToTime(GameManager.GameManager.Instance.GetLevelTime());
        }

        private string ConvertToTime(float time)
        {
            var t = TimeSpan.FromSeconds(time);
            return $"time to end level: {t.ToString("hh':'mm':'ss")}";
        }
    }
}