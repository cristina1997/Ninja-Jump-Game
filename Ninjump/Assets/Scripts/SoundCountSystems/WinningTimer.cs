using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinningTimer : MonoBehaviour {
    // Text variable
    private Text finalTimer;

    void Start()
    {
        finalTimer = GetComponent<Text>();
    }

    private void Update()
    {
        // It gets the total best timer from the game and displays it on the Win Menu
       finalTimer.text = "" + TimeManagement.finalTotalTime;
    }

}
