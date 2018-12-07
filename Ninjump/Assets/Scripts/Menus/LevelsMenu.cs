using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour {
    // Code adapted from: 
    // - https://www.youtube.com/watch?v=Pv1Bi6ao_J8
    // Buttons variables
    public Button l2_Button, l3_Button, l4_Button, l5_Button;

    // Level variables
    public static int levelPassed;
    private int currentLevel;

    private void Awake()
    {
        // get the current level
        currentLevel = NextLevel.pausedLevel;
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
        // if the next level is passed then you can unlock the buttons
        if (NextLevel.isLevelPassed == true)
        {
            // the levelsPassed start from case 2 = level 1
            
            switch (levelPassed)
            {                
                case 2:
                    // if the levelPassed is 1 
                    // you can interract with the level 2 button
                    l2_Button.interactable = true;
                    break;
                case 3:
                    // if the levelPassed is 2
                    // you can interract with the level 2, 3 buttons
                    l2_Button.interactable = true;
                    l3_Button.interactable = true;
                    break;
                case 4:
                    // if the levelPassed is 3
                    // you can interract with the level 2, 3, 4 buttons
                    l2_Button.interactable = true;
                    l3_Button.interactable = true;
                    l4_Button.interactable = true;
                    break;
                case 5:
                    // if the levelPassed is 4
                    // you can interract with the level 2, 3, 4, 5 buttons
                    l2_Button.interactable = true;
                    l3_Button.interactable = true;
                    l4_Button.interactable = true;
                    l5_Button.interactable = true;
                    break;
            }
        }

    }

    // It loads the scene level when pressing the button
    public void LevelToLoad (int level)
    {
        SceneManager.LoadScene(level);
    }
}
