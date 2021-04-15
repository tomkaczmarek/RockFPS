using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAction : MonoBehaviour
{

    public Transform destination;
    private SoundEvents sound;
    public void OnEnable()
    {
        sound = GetComponent<SoundEvents>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = destination.position;
            other.gameObject.transform.rotation *= Quaternion.Euler(0, 0, 0);
            if (sound != null)
                sound.CallOnTeleport();
        }
    }
}
