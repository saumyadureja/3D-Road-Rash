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
    public Image healthDamage1;
    public Image healthDamage2;

    private bool flag1 = true;
    private bool flag2 = false;
    // Start is called before the fist frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        radiationNegativeProgress.fillAmount = 0.0f;
        radiationPositiveProgress.fillAmount = 0.0f;
        radiationLocation = playerTransform.position.z - offset;

        healthDamage1.material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        healthDamage2.material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        healthDamage1.enabled = false;
        healthDamage2.enabled = false;

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
            radiationNegativeProgress.fillAmount = (distance*(-1) / 200.0f);
            radiationPositiveProgress.fillAmount = 0.0f;

            GetComponent<RohitHealthCalculation>().ReduceHealth(0.1f);

            if (flag1)
            {
                healthDamage1.enabled = true;
                healthDamage2.enabled = false;
                flag1 = false;
                flag2 = true;
            }
            else
            {
                healthDamage1.enabled = false;
                healthDamage2.enabled = true;
                flag1 = true;
                flag2 = false;
            }
            
        }
        else
        {
            // positive
            radiationPositiveProgress.fillAmount = (distance / 200.0f);
            radiationNegativeProgress.fillAmount = 0.0f;

            healthDamage1.enabled = false;
            healthDamage2.enabled = false;
        }
       
        //Debug.Log("Distance from radiation is: " + distance + " Fill Amount: " + radiationPositiveProgress.fillAmount);
    }
}
