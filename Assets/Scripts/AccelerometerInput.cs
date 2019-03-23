using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerInput : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Input.acceleration.x, Input.acceleration.y, -Input.acceleration.z);
    }
}