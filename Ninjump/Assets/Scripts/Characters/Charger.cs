using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour {
    public float speed;                                     // how fast the player moves
    public Vector2 moveVector;                              // pass positions and directions around.
    private int direction;

                                                            // Use this for initialization
    void Start () {
        direction = 1;
	}
	
	// Update is called once per frame
	void Update () {
        moveVector.Set(direction, 0);
        transform.Translate(moveVector * speed * Time.deltaTime);
    }
}
