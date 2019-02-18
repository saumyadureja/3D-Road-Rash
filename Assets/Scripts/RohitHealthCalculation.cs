using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RohitHealthCalculation : MonoBehaviour
{
    private float health;
    private Boolean onHit = false;
    private Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        health = 100.0f;
        healthText.text = "100";
    }

    // Update is called once per frame
    void Update()
    {
        if (onHit)
        {
            health -= 10;
            if (health < 0)
            {
                GetComponent<RohitScoresCalculations>().OnDeathScoreStops();
            }
            onHit = false;
        }

        healthText.text = ((int)health).ToString();
    }

    public void OnHealthReduce()
    {
        Debug.Log("In OnHitTriggered"); 
        onHit = true;
    }
}
