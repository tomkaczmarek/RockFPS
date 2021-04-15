using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class SoundEvents : MonoBehaviour
    {
        public delegate void SoundHandler();
        public event SoundHandler OnJumpSound;
        public event SoundHandler OnMoveSound;
        public event SoundHandler OnPowerUpGet;
        public event SoundHandler OnPowerUpLose;
        public event SoundHandler OnWinSound;
        public event SoundHandler OnLoseSound;
        public event SoundHandler OnIntroSound;
        public event SoundHandler OnTeleportFX;
        public event SoundHandler OnEnemyDead;


        public void CallJumpSound()
        {
            if (OnJumpSound != null)
                OnJumpSound();
        }
        public void CallMoveSound()
        {
            if (OnMoveSound != null)
                OnMoveSound();
        }
        public void CallPowerUpGet()
        {
            if (OnPowerUpGet != null)
                OnPowerUpGet();
        }
        public void CallPowerUpLose()
        {
            if (OnPowerUpLose != null)
                OnPowerUpLose();
        }
        public void CallWinSound()
        {
            if (OnWinSound != null)
                OnWinSound();
        }
        public void CallLoseSound()
        {
            if (OnLoseSound != null)
                OnLoseSound();
        }

        public void CallIntroSound()
        {
            if (OnIntroSound != null)
                OnIntroSound();
        }

        public void CallOnTeleport()
        {
            if (OnTeleportFX != null)
                OnTeleportFX();
        }

        public void CallEnemyDead()
        {
            if (OnEnemyDead != null)
                OnEnemyDead();
        }

    }
}