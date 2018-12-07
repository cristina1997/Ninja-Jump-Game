using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{   // GameObject variable
    public GameObject pauseMenu;

    public void Pause()
    {       
        // if the game is not paused, then it becomes paused
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);          // activate the pause menu
        }
    }

    public void Resume()
    {
        UnPaused();
        pauseMenu.SetActive(false);             // deactivate the pause menu

    }

    public void Controls()
    {
        UnPaused();
        SceneManager.LoadScene(7);
    }

    public void MainMenu()
    {
        UnPaused();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // if the game is paused, then it is unpaused
    private void UnPaused()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
