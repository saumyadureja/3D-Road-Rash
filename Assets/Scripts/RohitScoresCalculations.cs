using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RohitScoresCalculations : MonoBehaviour
{
    //private float score = 0.0f;
    public Text scoreText;
    public Text targetText;
    public Text targetAchievedText;

    private int currentSum = 0;
    private int difficultLevel = 0;
    private readonly int maxDifficultLevel = 4;
    private int scoreToNextLevel = 5;

    private int[] targetList;
    private int currentTargetIndex = 0;


    private float startPosition;
    private float currentPosition;

    private Boolean isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        targetAchievedText.text = " Target Achieved!!";
        targetAchievedText.enabled = false;
        startPosition = GetComponent<RohitMovePlayer>().transform.position.z;
        scoreText.text = "Current: 0";
        targetText.text = "Target: 0";

        Invoke("InitialTargetText", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(targetList != null && currentTargetIndex < targetList.Length)
        {
            targetText.text = "Target: " + targetList[currentTargetIndex];
        }  

        if (isDead)
        {
            return;
        }
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

    public string AddSum(GameObject selectedNumber)
    {
        //Debug.Log(selectedNumber.GetComponent<Renderer>().material.mainTexture.name);
        String textureName = selectedNumber.GetComponent<Renderer>().material.mainTexture.name;
        this.currentSum += Convert.ToInt32(textureName);


        if (this.currentSum > targetList[currentTargetIndex])
        {
            // Penalize the player, it has exceeded the target
            this.currentSum -= targetList[currentTargetIndex];
        }
        else
        {
            // Do nothing as of now
        }
        scoreText.text = "Current: " + this.currentSum;

        // Debug.Log("Current Index: " + currentTargetIndex + " Value: " + targetList[currentTargetIndex]);
        return textureName;
    }

    public int getCurrentSum()
    {
        return this.currentSum;
    }

    public void setTargetList(LinkedList<int> targetListIncoming)
    {
        targetList = new int[targetListIncoming.Count];

        int index = 0;
        while(targetListIncoming.Count > 0)
        {
            targetList[index++] = targetListIncoming.First.Value;
            targetListIncoming.RemoveFirst();
        }
        
        Debug.Log("Got the size: " + targetList.Length);        
    }

    void DisableText()
    {
        targetAchievedText.enabled = false;
    }

    public int getNextTarget()
    {
        if(currentTargetIndex < targetList.Length)
        {
            return this.targetList[currentTargetIndex];
        }
        return 100;
    }


    public void displayTargetAchieved(float diff)
    {
        if(currentTargetIndex == targetList.Length - 1)
        {
            Invoke("PlayNextLevel", 2.0f);
        }
        
        if (diff == 0.0f)
        {
            targetAchievedText.text = "Target Achieved !!";
            targetAchievedText.enabled = true;
            Invoke("DisableText", 0.5f);

            Debug.Log("Target Achieved!!!" + this.currentSum);
            // Target achieved level up the speed
            GetComponent<RohitPlayerState>().CyclePowerUp();
        }
        else
        {
            targetAchievedText.text = "Target missed by " + diff;
            targetAchievedText.enabled = true;
            Invoke("DisableText", 0.5f);

            Debug.Log("Target Achieved!!!" + this.currentSum);
        }
        this.currentSum = 0;
        scoreText.text = "Current: " + this.currentSum;
    }

    public void IncrementTargetIndex()
    {
        this.currentTargetIndex++;
    }

    public void InitialTargetText()
    {
        targetAchievedText.text = "Target is: " + this.targetList[0];
        targetAchievedText.enabled = true;
        Invoke("DisableText", 1.0f);
    }

    public void PlayNextLevel()
    {
        SceneManager.LoadScene("NextLevel");
    }
}
