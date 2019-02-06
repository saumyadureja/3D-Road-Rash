using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;

    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = this.transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = lookAt.position + startOffset;
    }
}
