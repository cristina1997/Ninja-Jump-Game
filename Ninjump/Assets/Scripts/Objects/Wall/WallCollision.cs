﻿// - Wall Collision:
//      -> Collision Types Explained: https://www.youtube.com/watch?v=YQ7Umjp6R10
//      -> Collision Detection: https://www.youtube.com/watch?v=W7ZtCEbeQEA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour {
    public static bool isFacingRight;                       // true if the player is facing right

    // when collision happens  between 2 objects - Player and Wall in this case
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        // collision between this object (the wall) and the object with the "Player" tag
        if (collision.gameObject.tag == "Player")
        {

            // if...    change it from 1 (right) to -1 (left)
            //          - and player is not facing right anymore
            if (PlayerScript.direction == 1)
            {
                isFacingRight = true;
            }
            // else...  change it from -1 (left) to 1 (right)
            //          - and player is facing right
            else
            {
                isFacingRight = false;
            }
        }

    }






}
