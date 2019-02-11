using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RohitPlayerCamera : MonoBehaviour
{
    private Transform lookAtPlayer;
    private Vector3 startOffeset;
    // Start is called before the first frame update
    void Start()
    {
        lookAtPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        startOffeset = lookAtPlayer.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = lookAtPlayer.position - startOffeset;
    }
}
