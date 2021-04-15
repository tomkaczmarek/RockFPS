using UnityEditor;
using UnityEngine;
using Assets.Scripts.Events;
using System.Collections.Generic;

namespace Assets.Scripts.Sounds
{
    public class EnemySounds : MonoBehaviour
    {
        public List<AudioClip> enemyAudio;
        public List<AudioClip> playerAudio;
        public GameObject playerTarget;
        public float volume;

        private SoundEvents sound;
        public void OnEnable()
        {
            sound = GetComponent<SoundEvents>();
            sound.OnEnemyDead += Sound_OnEnemyDead1;
        }

        private void Sound_OnEnemyDead1()
        {
            if (enemyAudio != null && enemyAudio.Count > 0)
                AudioSource.PlayClipAtPoint(enemyAudio[Random.Range(0, enemyAudio.Count - 1)], playerTarget.transform.position, volume);

            if (playerAudio != null && playerAudio.Count > 0)
                if (Random.Range(0, 10) == 5)
                    AudioSource.PlayClipAtPoint(playerAudio[Random.Range(0, playerAudio.Count - 1)], playerTarget.transform.position, volume);
        }


        public void OnDisable()
        {
            sound.OnEnemyDead -= Sound_OnEnemyDead1;
        }


    }
}