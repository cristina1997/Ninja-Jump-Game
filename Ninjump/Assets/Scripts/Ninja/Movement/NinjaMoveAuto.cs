using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMoveAuto : MonoBehaviour {
    GameManagerScript GameManager;

	// Use this for initialization
	void Start () {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<GameManagerScript>();

    }
	
	// Update is called once per frame
	void Update () {
//         Debug.Log(GameManager.moveSpeed);

        transform.Translate(GameManager.moveVector * GameManager.moveSpeed * Time.deltaTime);
	}
}
