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
    public Image healthDamage;
    private Color healthOpacity;

    // Start is called before the fist frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        radiationNegativeProgress.fillAmount = 0.0f;
        radiationPositiveProgress.fillAmount = 0.0f;
        radiationLocation = playerTransform.position.z - offset;

        healthOpacity = healthDamage.color;
        healthOpacity.a = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<RohitMovePlayer>().isDead)
        {
            return;
        }
        radiationLocation += Time.deltaTime * radiationSpeed;

        // Radiation distance logger
        float distance;
        
        distance = playerTransform.position.z - radiationLocation;

        if(distance < 0)
        {
            // negative
            if(distance < -200.0f)
            {
                radiationLocation = playerTransform.position.z + 200.0f;
            }
            radiationNegativeProgress.fillAmount = (distance*(-1) / 200.0f);
            radiationPositiveProgress.fillAmount = 0.0f;

            GetComponent<RohitHealthCalculation>().ReduceHealth(radiationNegativeProgress.fillAmount * 0.05f);
        }
        else
        {
            if (distance > 200.0f)
            {
                radiationLocation = playerTransform.position.z - 200.0f;
            }
            // positive
            radiationPositiveProgress.fillAmount = (distance / 200.0f);
            radiationNegativeProgress.fillAmount = 0.0f;
            
        }

        healthOpacity.a = 1 + Mathf.Log10(radiationNegativeProgress.fillAmount);
        healthDamage.color = healthOpacity;
        


        //Debug.Log("Distance from radiation is: " + distance + " Fill Amount: " + radiationPositiveProgress.fillAmount);
    }
}
