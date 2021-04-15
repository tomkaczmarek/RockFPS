using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class BackgroundSound : MonoBehaviour
    {
        public List<AudioClip> sounds;
        public float volume;

        private AudioSource source;
        private bool _isStop;

        public void Start()
        {
            source = GetComponent<AudioSource>();
        }

        public void Update()
        {
            if (!source.isPlaying)
                PlayBackground();

            Mute();
        }

        private void PlayBackground()
        {
            source.clip = sounds[UnityEngine.Random.Range(0, sounds.Count - 1)];
            source.Play();
            source.volume = volume;
        }

        private void Mute()
        {
            if (Input.GetKeyDown(KeyCode.M))
                if (source.volume == 0)
                    source.volume = volume;
                else
                    source.volume = 0;
        }
    }
}