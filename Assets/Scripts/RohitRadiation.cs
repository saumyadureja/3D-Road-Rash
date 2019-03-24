using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RohitRadiation : MonoBehaviour
{
    public float radiationLocation;
    private Transform playerTransform;
    private readonly float offset = 200.0f;
    private readonly float radiationSpeed = 20.0f;
    public Image progressBar;
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

        // Radiation distance logger
        float distance;
        distance = playerTransform.position.z - radiationLocation;
        progressBar.fillAmount = (distance / 200.0f);
        //Debug.Log("Distance from radiation is: " + distance + " Fill Amount: " + progressBar.fillAmount);
    }
}
