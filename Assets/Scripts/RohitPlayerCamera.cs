using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RohitPlayerCamera : MonoBehaviour
{
    // private Transform lookAtPlayer;
    // private Vector3 startOffeset;


    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;
    private float transition = 0.0f;
    private float animationDuration = 2.0f;
    private Vector3 animationOffset =new Vector3(0,5,5);
    // Start is called before the first frame update
    void Start()
    {
        // lookAtPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        // startOffeset = lookAtPlayer.position - transform.position;

        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset=transform.position-lookAt.position;
        print(startOffset);
    }

    // Update is called once per frame
    void Update()
    {


        moveVector= lookAt.position +startOffset;
        //X
        moveVector.x=0;
        //Y
        moveVector.y=Mathf.Clamp(moveVector.y,3,5);
        //camera between 3 and 5
        if (transition > 1.0f)
        {
        transform.position = moveVector;
        }
        else
        {
            //Animation at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset,moveVector,transition);
            transition += Time.deltaTime * 1 /animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        // transform.position = lookAtPlayer.position - startOffeset;
        }
    }
}
