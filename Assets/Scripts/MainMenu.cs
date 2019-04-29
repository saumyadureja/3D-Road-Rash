using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLevel()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayInstructionLevel()
    {
        SceneManager.LoadScene("Instructions");
    }
}
