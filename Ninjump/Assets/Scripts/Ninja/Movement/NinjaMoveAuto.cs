// Code adapted from:
// - Automatic Movement: https://www.youtube.com/watch?v=3hdx_uNwY2A 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMoveAuto : MonoBehaviour {
    GameManagerScript Player;

	// Use this for initialization
	void Start () {
        GameObject gameController = GameObject.FindGameObjectWithTag("Player");
        Player = gameController.GetComponent<GameManagerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        // Debug.Log(GameManager.moveSpeed);

        transform.Translate(Player.moveVector * Player.moveSpeed * Time.deltaTime);
	}
}
