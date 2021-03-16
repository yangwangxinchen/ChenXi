using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBySpeed : MonoBehaviour
{
    public float speed = 0.1f;

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        transform.RotateAround(Vector3.up, speed * Time.deltaTime);
    }

    
}
