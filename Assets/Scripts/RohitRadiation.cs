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
    public Image radiationPositiveProgress;
    public Image radiationNegativeProgress;
    // Start is called before the fist frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        radiationNegativeProgress.fillAmount = 0.0f;
        radiationPositiveProgress.fillAmount = 0.0f;
        radiationLocation = playerTransform.position.z - offset;
    }

    // Update is called once per frame
    void Update()
    {
        radiationLocation += Time.deltaTime * radiationSpeed;

        // Radiation distance logger
        float distance;
        distance = playerTransform.position.z - radiationLocation;

        if(distance < 0)
        {
            // negative
            radiationNegativeProgress.fillAmount = (distance*(-1) / 200.0f);
            radiationPositiveProgress.fillAmount = 0.0f;
        }
        else
        {
            // positive
            radiationPositiveProgress.fillAmount = (distance / 200.0f);
            radiationNegativeProgress.fillAmount = 0.0f;
        }
       
        //Debug.Log("Distance from radiation is: " + distance + " Fill Amount: " + progressBar.fillAmount);
    }
}
