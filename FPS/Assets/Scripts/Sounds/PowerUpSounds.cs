using UnityEditor;
using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Sounds
{
    public class PowerUpSounds : MonoBehaviour
    {
        public AudioClip powerGet;
        public AudioClip powerLose;
        public float volume;

        private SoundEvents _sounds;

        public void OnEnable()
        {
            _sounds = GetComponent<SoundEvents>();
            _sounds.OnPowerUpGet += OnPowerUpGet;
            _sounds.OnPowerUpLose += OnPowerUpLose;
        }

        public void OnDisable()
        {
            _sounds.OnPowerUpGet -= OnPowerUpGet;
            _sounds.OnPowerUpLose -= OnPowerUpLose;
        }

        private void OnPowerUpGet()
        {
            if (powerGet != null)
                AudioSource.PlayClipAtPoint(powerGet, transform.position, volume);            
        }

        private void OnPowerUpLose()
        {
            if (powerLose != null)
                AudioSource.PlayClipAtPoint(powerLose, transform.position, volume);
        }

      
    }
}