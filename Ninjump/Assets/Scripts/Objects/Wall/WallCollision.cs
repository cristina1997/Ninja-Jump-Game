// - Wall Collision:
//      -> Collision Types Explained: https://www.youtube.com/watch?v=YQ7Umjp6R10
//      -> Collision Detection: https://www.youtube.com/watch?v=W7ZtCEbeQEA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour {
    public static int newDirection;                         // the new direction of the player's movement
    public static bool isWallCollision;                     // true if the player collides with the wall
    public static bool isFacingRight;                       // true if the player is facing right
    //GameManagerScript gameManager;

    // Use this for initialization
    void Start () {
        newDirection = GameManagerScript.direction;         // set new player's direction to 1 (right)
    }
	
	// Update is called once per frame
	void Update () {

        ////GameManagerScript.direction = newDirection;

        //Debug.Log(LR_direction);
        //Debug.Log(GameManagerScript.direction);
        //Debug.Log("New Direction: " + newDirection);
        //Debug.Log(isWallCollision);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if...    the object the wall collided with has the tag "Player"
        //          - then a collision happened between the player and the wall
        //          - player's direction changes
        if (collision.gameObject.tag == "Player")
        {
            // collision between wall and player happened
            isWallCollision = true;
            if (GameManagerScript.direction == 1)
            {
                newDirection = -1;
                isFacingRight = false;
            }
            // else...  change it from -1 (left) to 1 (right)
            //          - and player is facing right
            else
            {
                newDirection = 1;
                isFacingRight = true;
            }
        }
        // else...  no collision happened between the player and the wall
        else
        {
            // collision between wall and player didn't happen
            isWallCollision = false;
        }

        //if(collision.gameObject.tag == "Player")
        //{
        //    Destroy(/*collision.*/gameObject);
        //}
    }
}
