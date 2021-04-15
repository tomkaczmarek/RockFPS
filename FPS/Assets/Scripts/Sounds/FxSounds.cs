using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Sounds
{
    public class FxSounds : MonoBehaviour
    {
        public AudioClip teleportFx;
        public float volume;
        public GameObject target;

        private Events.SoundEvents sound;

        public void OnEnable()
        {
            sound = GetComponent<Events.SoundEvents>();
            sound.OnTeleportFX += Sound_OnTeleportFX;
        }

        public void OnDisable()
        {
            sound.OnTeleportFX -= Sound_OnTeleportFX;
        }
        public void Start()
        {
            if (target == null)
                target = this.gameObject;
        }

        private void Sound_OnTeleportFX()
        {
            AudioSource.PlayClipAtPoint(teleportFx, target.transform.position, volume);
        }

       
    }
}