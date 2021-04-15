using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Sounds
{
    public class PlayerSounds : MonoBehaviour
    {
        public AudioClip jumpSound;
        public AudioClip moveSound;
        public float jumpVolume;
        public float moveVolume;

        Events.SoundEvents _player;
        private AudioSource _source;
        public void OnEnable()
        {
            _source = GetComponent<AudioSource>();
            _player = GetComponent<Events.SoundEvents>();
            _player.OnJumpSound += OnJumpSound;
            _player.OnMoveSound += OnMoveSound;
        }

        private void OnMoveSound()
        {
            if (moveSound != null)
            {
                _source.volume = moveVolume;
                _source.PlayOneShot(moveSound);
            }                   
        }

        public void OnDisable()
        {
            _player.OnJumpSound -= OnJumpSound;
            _player.OnMoveSound -= OnMoveSound;
        }
        private void OnJumpSound()
        {
            if (jumpSound != null)
            {
                _source.volume = jumpVolume;
                _source.PlayOneShot(jumpSound);
            }
        }    
    }
}