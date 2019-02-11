using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RohitScoresCalculations : MonoBehaviour
{
    private float score = 0.0f;
    public Text scoreText;

    private int difficultLevel = 0;
    private int maxDifficultLevel = 4;
    private int scoreToNextLevel = 10;

    private Boolean isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (score >= scoreToNextLevel)
        {
            LevelUp();
        }

        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
    }

    private void LevelUp()
    {
        if (difficultLevel > maxDifficultLevel)
        {
            return;
        }
        difficultLevel++;
        GetComponent<RohitMovePlayer>().IncreaseSpeedByVal(difficultLevel);
        scoreToNextLevel += 5;
    }

    public void OnDeathScoreStops()
    {
        isDead = true;
    }
}
