using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RohitHealthCalculation : MonoBehaviour
{
    private float health;
    private Boolean onHit = false;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        health = 100.0f;
        healthText.text = "Health: 100";
    }

    // Update is called once per frame
    void Update()
    {
        if (onHit)
        {
            health -= 5.0f;
            if (health < 0)
            {
                GetComponent<RohitMovePlayer>().isDead = true;
                GetComponent<RohitScoresCalculations>().OnDeathScoreStops();
            }
            onHit = false;
        }

        healthText.text = "Health: " + ((int)health).ToString();
    }

    public void OnHealthReduce()
    {
        onHit = true;
    }
}
