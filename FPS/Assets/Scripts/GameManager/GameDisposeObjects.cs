using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDisposeObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public int timeToDespose = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(DestroyUnnessaryObjects), timeToDespose);
    }

    private object DestroyUnnessaryObjects()
    {
        return null;
    }
}
