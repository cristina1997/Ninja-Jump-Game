using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    private int currentScene;

    private void Start()
    {
        currentScene = NextLevel.pauseLevel;
    }

    public void PlayGame()
    {
        //currentScene = 
        SceneManager.LoadScene(currentScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(6);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
