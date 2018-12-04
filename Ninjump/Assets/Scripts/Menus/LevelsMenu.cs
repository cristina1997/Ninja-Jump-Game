using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour {
    public Button l2_Button, l3_Button, l4_Button, l5_Button;
    private int levelPassed;
    private int currentLevel;

    private void Awake()
    {
        currentLevel = NextLevel.pauseLevel;
    }

    // Use this for initialization
    void Start () {
        levelPassed = PlayerPrefs.GetInt("LevelPassed", currentLevel);
        l2_Button.interactable = false;
        l3_Button.interactable = false;
        l4_Button.interactable = false;
        l5_Button.interactable = false;

    }

    void Update()
    {
        if (NextLevel.isLevelPassed == true)
        {
            switch (levelPassed)
            {
                
                case 2:
                    l2_Button.interactable = true;
                    break;
                case 3:
                    l2_Button.interactable = true;
                    l3_Button.interactable = true;
                    break;
                case 4:
                    l2_Button.interactable = true;
                    l3_Button.interactable = true;
                    l4_Button.interactable = true;
                    break;
                case 5:
                    l2_Button.interactable = true;
                    l3_Button.interactable = true;
                    l4_Button.interactable = true;
                    l5_Button.interactable = true;
                    break;
            }
        }

    }

    public void LevelToLoad (int level)
    {
        SceneManager.LoadScene(level);
    }
}
