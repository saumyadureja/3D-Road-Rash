using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    string lastScene;

    public void Start()
    {
        lastScene = "MainMenu";
    }
    public void GameOverExit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay()
    {
        // lastScene = GameObject.Find("Player").GetComponent<RohitMovePlayer>().GetLastScene();
        SceneManager.LoadScene(lastScene);
    }

    
}
