using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Scenes
{
    public class DumpObject : MonoBehaviour
    {
        public void Start()
        {
            Events.SoundEvents sound = GetComponent<Events.SoundEvents>();
            sound.CallLoseSound();
        }

    }
}