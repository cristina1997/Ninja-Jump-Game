using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    Scene currentLevel;
    private int nextLevel;
    public static int pauseLevel;

    // Code adapted from: https://answers.unity.com/questions/1127900/get-current-scene-number.html
    // Use this for initialization
    void Start () {
        
        currentLevel = SceneManager.GetActiveScene();
        pauseLevel = currentLevel.buildIndex;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void LoadNextLevel(int thisLevel)
    {
        nextLevel = thisLevel + 1;
        SceneManager.LoadScene(nextLevel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LoadNextLevel(currentLevel.buildIndex);
        }
    }
}
