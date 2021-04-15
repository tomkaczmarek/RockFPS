using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Sounds
{
    public class SceneSounds : MonoBehaviour
    {
        public AudioClip win;
        public AudioClip lose;
        public AudioClip intro;
        public float volume;
        public float introVolume;

        private Events.SoundEvents sounds;
        private AudioSource soundSource;
        public void OnEnable()
        {
            soundSource = GetComponent<AudioSource>();
            sounds = GetComponent<Events.SoundEvents>();
            sounds.OnWinSound += Sounds_OnWinSound;
            sounds.OnLoseSound += Sounds_OnLoseSound;
            sounds.OnIntroSound += Sounds_OnIntroSound;
        }

        private void Sounds_OnIntroSound()
        {
            if(intro != null)
            {
                soundSource.clip = intro;
                soundSource.volume = introVolume;
                soundSource.Play();
            }
        }

        private void Sounds_OnLoseSound()
        {
            AudioSource.PlayClipAtPoint(lose, transform.position, volume);
        }

        private void Sounds_OnWinSound()
        {
            AudioSource.PlayClipAtPoint(win, transform.position, volume);
        }

        

        public void OnDisable()
        {
            sounds.OnWinSound -= Sounds_OnWinSound;
            sounds.OnLoseSound -= Sounds_OnLoseSound;
        }

    }
}