﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningMenu : MonoBehaviour {


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Levels()
    {
        SceneManager.LoadScene(6);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
