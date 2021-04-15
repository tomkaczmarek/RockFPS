using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,100f * Time.deltaTime, 0 * Time.deltaTime);
    }
}
