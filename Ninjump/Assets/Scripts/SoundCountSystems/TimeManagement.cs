using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManagement : MonoBehaviour {
    // Time variables
    private float startingTime, totalTime;

    // Fastest completion time variables
    public static float finalTotalTime, newBestTotalTime;

    // Text variable
    private Text timer;

    private void Awake()
    {
        startingTime = 0;
        newBestTotalTime = 0;
    }
    // Use this for initialization
    void Start () {
        timer = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        // if the next level is not won, then the timer won't stop
        // otherwise if the player is dead and the next level is won the timer will be saved for the Win Menu
        if (!NextLevel.isWon)
        {
            totalTime = startingTime + Time.deltaTime;            
        } else if (!PlayerScript.isDead || NextLevel.isWon)
        {
            // the total time is stored and saved in a PlayerPrefs ariable
            finalTotalTime = PlayerPrefs.GetFloat("TotalTimer", totalTime);

            // if the finalTotalTime (the saved timer) is bigger than the new best time then
            // the new best gets the value of the saved timer
            // otherwise if the newBestTotalTime is bigger it gives the finalTotalTime the newer better value
            if (newBestTotalTime < finalTotalTime)
            {
                newBestTotalTime = finalTotalTime;
            } else
            {
                newBestTotalTime = PlayerPrefs.GetFloat("TotalTimer", totalTime);
                finalTotalTime = newBestTotalTime;
            }
        }       
        
        // the timer resets every level
        for (int i = 0; i < NextLevel.pausedLevel; i++)
        {
            startingTime += Time.deltaTime;
        }

        // outputs the timer to the text object in unity
        timer.text = "" + startingTime;
	}
}
