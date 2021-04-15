using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform destination;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null && other.gameObject.name == "PlayerObject")
            player.transform.position = destination.transform.position;
        else
            Destroy(other.gameObject);
    }
}
