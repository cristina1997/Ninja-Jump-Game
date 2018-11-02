// Code adapted from:
// - https://www.youtube.com/watch?v=zc8ac_qUXQY&t=556s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    	
	public void PlayGame () {
        SceneManager.LoadScene(1);
	}

    public void Levels()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
