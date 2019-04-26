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

    private int[] targetArray =new int[] {6, 11 , 17, 22};
    private int currentTargetIndex = 0;

    private float startPosition;
    private float currentPosition;

    private Boolean isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = GetComponent<RohitMovePlayer>().transform.position.z;
        scoreText.text = "0";
        targetText.text = "Target: " + targetArray[currentTargetIndex];
    }

    // Update is called once per frame
    void Update()
    {
        targetText.text = "Target: " + targetArray[currentTargetIndex];
        if (isDead)
        {
            return;
        }
        //    if (score >= scoreToNextLevel)
        //    {
        //        //LevelUp();
        //    }
        //    currentPosition = GetComponent<RohitMovePlayer>().transform.position.z;
        //    score = currentPosition - startPosition;
        //    scoreText.text = "Score: " + ((int)score).ToString();
    }

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
        //Debug.Log(selectedNumber.GetComponent<Renderer>().material.mainTexture.name);
        String textureName = selectedNumber.GetComponent<Renderer>().material.mainTexture.name;
        this.currentSum += Convert.ToInt32(textureName);


        if(this.currentSum == targetArray[currentTargetIndex] || this.currentSum % targetArray[currentTargetIndex] == 0)
        {
            currentTargetIndex++;
            if(currentTargetIndex >= targetArray.Length)
            {
                // Game Finished
                Debug.Log("Game finished");
                // Remove this line afterwards
                isDead = true;
            }

            Debug.Log("Target Achieved!!!" + this.currentSum);
            this.currentSum = 0;
        }
        else if(this.currentSum > targetArray[currentTargetIndex])
        {
            // Penalize the player, it has exceeded the target
            this.currentSum -= targetArray[currentTargetIndex];
        }
        else
        {
            // Do nothing as of now
        }
        scoreText.text = "" + this.currentSum;

        Debug.Log("Current Index: " + currentTargetIndex + " Value: " + targetArray[currentTargetIndex]);
    }
}
