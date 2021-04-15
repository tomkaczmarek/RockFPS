using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSceneSoundObject : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
