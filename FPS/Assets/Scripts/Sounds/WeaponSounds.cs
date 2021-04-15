using UnityEditor;
using UnityEngine;
using Assets.Scripts.Events;


namespace Assets.Scripts.Sounds
{
    public class WeaponSounds : MonoBehaviour
    {
        public AudioClip shotingSound;
        public AudioClip reloadingSound;
        public AudioClip emptyAmmo;
        public float shotingVolume;
        public float reloadVolume;

        AudioSource _soundSource;
        WeaponEvents _weapon;
        public void OnEnable()
        {
            _soundSource = GetComponent<AudioSource>();
            _weapon = GetComponent<WeaponEvents>();
            _weapon.OnSoundWeaponShot += OnSoundWeaponShot;
            _weapon.OnSoundWeaponReload += OnSoundWeaponReload;
            _weapon.OnSoundWeaponEmptyAmmo += OnSoundWeaponEmptyAmmo;
        }

        private void OnSoundWeaponEmptyAmmo()
        {
            if (emptyAmmo != null)
            {
                _soundSource.volume = shotingVolume;
                _soundSource.PlayOneShot(emptyAmmo);
            }               
        }

        public void OnDisable()
        {
            _weapon.OnSoundWeaponShot -= OnSoundWeaponShot;
            _weapon.OnSoundWeaponReload -= OnSoundWeaponReload;
            _weapon.OnSoundWeaponEmptyAmmo -= OnSoundWeaponEmptyAmmo;
        }

        private void OnSoundWeaponReload()
        {
            if (reloadingSound != null)
            {
                _soundSource.volume = shotingVolume;
                _soundSource.PlayOneShot(reloadingSound);
            }
        }

        private void OnSoundWeaponShot()
        {
            if (shotingSound != null)
            {
                _soundSource.volume = shotingVolume;
                _soundSource.PlayOneShot(shotingSound);
            }
        }

       
    }
}