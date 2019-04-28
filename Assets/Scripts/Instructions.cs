using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public Text instructionsText;
    // Start is called before the first frame update
    void Start()
    {
        instructionsText.text = " Tilt the phone Left Right to steer!!";
        instructionsText.enabled = false;

        Invoke("ShowTiltingInstruction", 3f);
    }

   public void ShowTiltingInstruction()
    {
        instructionsText.text = "Tilt the phone Left Right to steer!!";
        instructionsText.enabled = true;
        Invoke("DisableTiltText", 4.0f);
    }

    public void DisableTiltText()
    {
        instructionsText.enabled = false;
        Invoke("ShowJumpInstruction", 2.0f);
    }

    public void ShowJumpInstruction()
    {
        instructionsText.text = "Press jump button to jump!!";
        instructionsText.enabled = true;
        Invoke("DisableJumpText", 4.0f);
    }

    public void DisableJumpText()
    {
        instructionsText.enabled = false;
        Invoke("ShowCollectInstruction", 2.0f);
    }

    public void ShowCollectInstruction()
    {
        instructionsText.text = "Collect the object to add to sum!!";
        instructionsText.enabled = true;
        Invoke("DisableCollectInstruction", 4.0f);
    }

    public void DisableCollectInstruction()
    {
        instructionsText.enabled = false;
        Invoke("ShowAvoidInstruction", 2.0f);
    }
    public void ShowAvoidInstruction()
    {
        instructionsText.text = "Avoid the ramps and obstacles";
        instructionsText.enabled = true;
        Invoke("DisableAvoidInstruction", 4.0f);
    }

    public void DisableAvoidInstruction()
    {
        instructionsText.enabled = false;
        Invoke("ShowTargetInstruction", 2.0f);
    }
    public void ShowTargetInstruction()
    {
        instructionsText.text = "Go through the target wall!!";
        instructionsText.enabled = true;
        Invoke("DisableTargetInstruction", 4.0f);
    }

    public void DisableTargetInstruction()
    {
        instructionsText.enabled = false;
        Invoke("ShowLastInstruction", 2.0f);
    }

    public void ShowLastInstruction()
    {
        instructionsText.text = "You have finished the demo !!";
        instructionsText.enabled = true;
        Invoke("DisableFinalInstruction", 4.0f);
    }

    public void DisableFinalInstruction()
    {
        instructionsText.enabled = false;
    }
}
