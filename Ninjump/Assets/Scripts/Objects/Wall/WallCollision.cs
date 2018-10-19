// - Wall Collision:
//      -> Collision Types Explained: https://www.youtube.com/watch?v=YQ7Umjp6R10
//      -> Collision Detection: https://www.youtube.com/watch?v=W7ZtCEbeQEA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour {
    public string LR_direction;
    public static int newDirection;
    //GameManagerScript gameManager;

	// Use this for initialization
	void Start () {
        newDirection = GameManagerScript.direction;
    }
	
	// Update is called once per frame
	void Update () {

        ////GameManagerScript.direction = newDirection;

        //Debug.Log(LR_direction);
        //Debug.Log(GameManagerScript.direction);
        //Debug.Log("New Direction: " + newDirection);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Collision");
        if (collision.gameObject.tag == "Player")
        {
            if (GameManagerScript.direction == 1)
                newDirection = -1;
            else
                newDirection = 1;
       }

        //if(collision.gameObject.tag == "Player")
        //{
        //    Destroy(/*collision.*/gameObject);
        //}
    }
}
