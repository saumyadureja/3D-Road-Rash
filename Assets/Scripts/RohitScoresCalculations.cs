 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RohitScoresCalculations : MonoBehaviour
{
    private float score = 0.0f;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
    }
}
