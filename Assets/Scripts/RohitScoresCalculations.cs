using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RohitScoresCalculations : MonoBehaviour
{
    private float score = 0.0f;
    public Text scoreText;
    public Text targetText;

    private int currentSum = 0;
    private int difficultLevel = 0;
    private readonly int maxDifficultLevel = 4;
    private int scoreToNextLevel = 5;

    private float startPosition;
    private float currentPosition;

    private Boolean isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = GetComponent<RohitMovePlayer>().transform.position.z;
        scoreText.text = "0";
        targetText.text = "9";
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (isDead)
    //    {
    //        return;
    //    }
    //    if (score >= scoreToNextLevel)
    //    {
    //        //LevelUp();
    //    }
    //    currentPosition = GetComponent<RohitMovePlayer>().transform.position.z;
    //    score = currentPosition - startPosition;
    //    scoreText.text = "Score: " + ((int)score).ToString();
    //}

    private void LevelUp()
    {
        if (difficultLevel > maxDifficultLevel)
        {
            return;
        }
        difficultLevel++;
        // GetComponent<RohitMovePlayer>().IncreaseSpeedByVal(difficultLevel);
        scoreToNextLevel += 5;
    }

    public void OnDeathScoreStops()
    {
        isDead = true;
        scoreText.text = "Game Over";
    }

    public void AddSum(GameObject selectedNumber)
    {
        this.currentSum += 1;
        scoreText.text = "" + currentSum;
    }
}
