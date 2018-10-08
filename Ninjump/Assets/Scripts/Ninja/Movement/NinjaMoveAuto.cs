// Code adapted from:
// - Automatic Movement: https://www.youtube.com/watch?v=3hdx_uNwY2A
// - Wall Collision:
//      -> Collision Types Explained: https://www.youtube.com/watch?v=YQ7Umjp6R10
//      -> Collision Detection: https://www.youtube.com/watch?v=W7ZtCEbeQEA
//              

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
