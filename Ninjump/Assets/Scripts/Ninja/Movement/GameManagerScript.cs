// Code adapted from:
// - Automatic Movement: https://www.youtube.com/watch?v=3hdx_uNwY2A

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveVector;
    public static int direction;
    //public string LR_direction;

    private void Start()
    {
        direction = 1;
        moveSpeed = 100f;

        moveVector.Set(direction, 0, 0);
    }

    private void Update()
    {

        if (WallCollision.newDirection != 0)
        {
            direction = WallCollision.newDirection;
        }

        moveVector.Set(direction, 0, 0);
        Debug.Log(direction);
    }

}
