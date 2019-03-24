using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RohitHealthCalculation : MonoBehaviour
{
    private float health;
    public Image healthProgress;
    // Start is called before the first frame update
    void Start()
    {
        health = 100.0f;
        healthProgress.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            this.health = 0;
            GetComponent<RohitMovePlayer>().isDead = true;
            GetComponent<RohitScoresCalculations>().OnDeathScoreStops();
            
        }
       
        healthProgress.fillAmount = (health / 100);
    }

    public void ReduceHealth(float reductionAmt)
    {
        
        this.health -= reductionAmt;
    }


    public void IncreaseHealth(float increaseAmt)
    {
        this.health += increaseAmt;

        if(this.health > 100.0f)
        {
            this.health = 100.0f;
        }

    }
}
