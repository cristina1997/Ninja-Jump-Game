using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenu;

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void Resume()
    {
        StartScene();
        pauseMenu.SetActive(false);

    }

    public void Controls()
    {
        SceneManager.LoadScene(7);
    }

    public void MainMenu()
    {
        StartScene();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void StartScene()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
