using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RohitRadiation : MonoBehaviour
{
    public float radiationLocation;
    private Transform playerTransform;
    private readonly float offset = 20.0f;
    private readonly float radiationSpeed = 5.0f;
    // Start is called before the fist frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        radiationLocation = playerTransform.position.z - offset;
    }

    // Update is called once per frame
    void Update()
    {
        radiationLocation += Time.deltaTime * radiationSpeed; 
    }
}
