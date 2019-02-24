using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RohitPlayerState : MonoBehaviour
{
    public Boolean isCycle;
    public Boolean isSkate;

    private readonly int levelLimit = 4;
    private int cycleLevel;
    private int skateLevel;

    private float[] cycleSpeeds = { 5.0f, 10.0f, 15.0f, 20.0f };
    private float[] skateSpeeds = { 2.0f, 9.0f, 17.0f, 30.0f };
    // Start is called before the first frame update
    void Start()
    {
        isCycle = false;
        isSkate = false;

        cycleLevel = 0;
        skateLevel = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(isCycle)
        {
            CyclePowerUpCalculation();
            isCycle = false;
        }

        if (isSkate)
        {
            SkatePowerUpCalculation();
            isSkate = false;
        }
    }

    private void SkatePowerUpCalculation()
    {
        if (skateLevel < levelLimit)
        {
            GetComponent<RohitMovePlayer>().UpdateSpeedByPowerup(skateSpeeds[skateLevel]);
            skateLevel++;
            cycleLevel = 0;
        }

    }

    private void CyclePowerUpCalculation()
    {
        if (cycleLevel < levelLimit)
        {
            GetComponent<RohitMovePlayer>().UpdateSpeedByPowerup(cycleSpeeds[cycleLevel]);
            cycleLevel++;
            skateLevel = 0;
        }
    }

    public void CyclePowerUp()
    {
        isCycle = true;
    }

    public void SkatePowerUp()
    {
        isSkate = true;
    }
}
