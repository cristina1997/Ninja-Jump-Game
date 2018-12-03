using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour {
    public Button l2_Button, l3_Button;
    int levelPassed;
    
    // Use this for initialization
    void Start () {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        l2_Button.interactable = false;
        l3_Button.interactable = false;

        switch (levelPassed)
        {
            case 1:
                l2_Button.interactable = true;
                break;
            case 2:
                l2_Button.interactable = true;
                l3_Button.interactable = true;
                break;
        }
    }
	
    public void LevelToLoad (int level)
    {
        SceneManager.LoadScene(level);
    }
}
