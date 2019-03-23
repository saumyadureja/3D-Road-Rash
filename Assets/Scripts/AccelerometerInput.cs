using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerInput : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<RohitMovePlayer>().isDead)
        {
            Destroy(this);
        }
        transform.Translate(Input.acceleration.x, 0, 0);
    }
}