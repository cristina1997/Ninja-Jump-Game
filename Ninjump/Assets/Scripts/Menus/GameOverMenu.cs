using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Levels()
    {
        SceneManager.LoadScene(6);
    }

    public void Controls()
    {
        SceneManager.LoadScene(7);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
