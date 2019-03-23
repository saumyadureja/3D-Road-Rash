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
    public Image healthProgress;
    // Start is called before the first frame update
    void Start()
    {
        health = 100.0f;
        healthText.text = "Health: 100";
        healthProgress.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            GetComponent<RohitMovePlayer>().isDead = true;
            GetComponent<RohitScoresCalculations>().OnDeathScoreStops();
        }
        
        healthText.text = "Health: " + ((int)health).ToString();
        healthProgress.fillAmount = (health / 100);
    }

    public void ReduceHealth(float reductionAmt)
    {
        this.health -= reductionAmt;
    }
}
