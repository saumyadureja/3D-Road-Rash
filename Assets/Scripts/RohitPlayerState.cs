using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RohitPlayerState : MonoBehaviour
{
    public Boolean isCycle;
    public Boolean isSkate;

    private int cycleLevel;
    private int skateLevel;
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
        skateLevel++;
        cycleLevel = 0;
        GetComponent<RohitMovePlayer>().IncreaseSpeedByVal(skateLevel);
    }

    private void CyclePowerUpCalculation()
    {
        cycleLevel++;
        skateLevel = 0;
        GetComponent<RohitMovePlayer>().IncreaseSpeedByVal(cycleLevel);

    }

    public void CyclePowerupAdded()
    {
        isCycle = true;
    }

    public void SkatePowerup()
    {
        isSkate = true;
    }
}
