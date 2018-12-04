using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    Scene currentLevel;
    public static int nextLevel;
    public static int pauseLevel;
    public static bool isLevelPassed;
    // Code adapted from: https://answers.unity.com/questions/1127900/get-current-scene-number.html
    // Use this for initialization
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene();
        pauseLevel = currentLevel.buildIndex;
    }

    public void LoadNextLevel(int thisLevel)
    {
        
        if (thisLevel != 6)
        {
            nextLevel = thisLevel + 1;
            SceneManager.LoadScene(nextLevel);
        } else
        {
            // EndGame
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isLevelPassed = true;
            LoadNextLevel(currentLevel.buildIndex);
        }
    }

}
