using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerInput : MonoBehaviour
{
    private float transition = 0.0f;
    private float animationDuration = 3.0f;

    void Update()
    {
        if (GetComponent<RohitMovePlayer>().isDead)
        {
            Destroy(this);
        }

        if (transition > 1.0f)
        {
            transform.Translate(Input.acceleration.x, 0, 0);
        }
        else
        {
            //Animation at the start of the game
            transition += Time.deltaTime * 1 / animationDuration;
        }
        
    }
}