// Code adapted from:
// - Automatic Movement: https://www.youtube.com/watch?v=3hdx_uNwY2A
// - Jump on Ground: https://www.youtube.com/watch?v=QGDeafTx5ug

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Movement Variables
    public float moveSpeed;                             // how fast the player moves
    public Vector2 moveVector;                          // pass positions and directions around.
    public static int direction;                        // representation of 2D vectors and points on two axis x&y.

    // Jump Variables
    Rigidbody2D _rigidbody2D;                           // 2D sprites physics component

    public float jumpHeight;                            // how high player can jump of the player
    private bool isGrounded;                            // detect if character is standing on the ground
    public Transform groundCheck;                       // takes object underneath player's feet to detect if grounded
    public float checkRadius;                           // radius of the circle underneath the player's feet that detects if the player is grounded
    public LayerMask whatIsGround;                      // uses only object with a chosen layer value

    // Set the starting values
    void Awake()
    {
        direction = 1;
        moveSpeed = 150f;

        checkRadius = 0.5f;
        jumpHeight = 30;
    }

    void Start()
    {
        moveVector.Set(direction, 0);                   // set the starting direction of the player (left, right)
        _rigidbody2D = GetComponent<Rigidbody2D>();     // used to adjust player's rigidbody via script

    }

    void FixedUpdate()
    {
        // check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //Debug.Log(isGrounded);

    }

    void Update()
    {
        ChangeDirection();
        Jump();
    }

    private void Jump()
    {
        // player jumps if the space key is pressed and if the player is on the ground
        if (/*Input.GetKey(KeyCode.Space)*/ Input.touchCount == 1 && isGrounded == true)
        {
            // player jumps
            _rigidbody2D.velocity += Vector2.up * jumpHeight;

            // player is no longer on the ground
            isGrounded = false;
        }
    }

    private void ChangeDirection()
    {
        // if the new direction of the player is not 0, then change the player's direction
        if (WallCollision.newDirection != 0)
        {
            // get the new direction of the player from the WallCollision class
            // left or right, depending on whether or not the wall was hit
            direction = WallCollision.newDirection;
        }

        // set the player's current direction to the updated one
        moveVector.Set(direction, 0);
    }


}
