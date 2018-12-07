using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    // Scene variable
    Scene currentLevel;
    
    // Level Variables
    public static int nextLevel;
    public static int pausedLevel;

    // Winning variables
    public static bool isLevelPassed, isWon;

    // Code adapted from: 
    // - https://answers.unity.com/questions/1127900/get-current-scene-number.html
    // - https://www.youtube.com/watch?v=VQe-Wd5JTEo
    // Use this for initialization
    void Start()
    {
        isWon = false;
        currentLevel = SceneManager.GetActiveScene();
        pausedLevel = currentLevel.buildIndex;
    }

    public void LoadNextLevel(int thisLevel)
    {
        // if the current level is not the maximum amount of levels available = 5 
        // then load the scene of the next level
        // otherwise if the maximum amount of levels was reached the player won
        if (thisLevel != 5)
        {
            isLevelPassed = true;
            nextLevel = thisLevel + 1;
            SceneManager.LoadScene(nextLevel);
        } else
        {
            isWon = true;
            SceneManager.LoadScene(9);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the door comes into contact with 
        // an object containing the "Player" tag then that means that 
        // the player has passed to the next level and it loads the next level
        if (collision.gameObject.tag == "Player")
        {
            LoadNextLevel(currentLevel.buildIndex);
        }
    }

}
