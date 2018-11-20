// Code adapted from:
// - Automatic Movement: https://www.youtube.com/watch?v=3hdx_uNwY2A 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMoveAuto : MonoBehaviour {
    private GameManagerScript Player;

	// Use this for initialization
	void Start () {
        GameObject gameController = GameObject.FindGameObjectWithTag("Player");
        Player = gameController.GetComponent<GameManagerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        // Debug.Log(GameManager.moveSpeed);

        // player can only move when isMoving is true
        if (Player.isMoving == true)
        {
            transform.Translate(Player.moveVector * Player.moveSpeed * Time.deltaTime);
        }
        

        //if (WallCollision.canMove == true)
        //{
        //    transform.Translate(0 * Player.moveVector * Time.deltaTime);
        //}
	}
}
