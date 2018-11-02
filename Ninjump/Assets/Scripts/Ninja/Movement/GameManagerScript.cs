// Code adapted from:
// - Automatic Movement: https://www.youtube.com/watch?v=3hdx_uNwY2A
// - Jump on Ground: https://www.youtube.com/watch?v=QGDeafTx5ug
// - Stop player movement: https://answers.unity.com/questions/816848/stopping-my-player-from-moving-when-hitting-a-wall.html
// - Player gravity stops: https://answers.unity.com/questions/767287/chow-to-disable-gravity-from-script.html
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Movement Variables
    public float moveSpeed;                                 // how fast the player moves
    public Vector2 moveVector;                              // pass positions and directions around.
    public static int direction;                            // representation of 2D vectors and points on two axis x&y.
    public static bool isMoving;                            // used to tell if player can or can't move depending on what's colliding with
    public static bool canJump;                             // used to tell if player can or can't move depending on what's colliding with

    // Jump Variables
    Rigidbody2D _rigidbody2D;                               // 2D sprites physics component

    public float jumpHeight;                                // how high player can jump of the player
    private bool isGrounded;                                // detect if character is standing on the ground
    public Transform groundCheck;                           // takes object underneath player's feet to detect if grounded
    public float checkRadius;                               // radius of the circle underneath the player's feet that detects if the player is grounded
    public LayerMask whatIsGround;                          // uses only object with a chosen layer value

    // Set the starting values
    void Awake()
    {
        direction = 1;
        moveSpeed = 150f;

        checkRadius = 0.5f;
        jumpHeight = 40;

        isMoving = true;
        canJump = false;
    }

    void Start()
    {
        moveVector.Set(direction, 0);                           // set the starting direction of the player (left, right)
        _rigidbody2D = GetComponent<Rigidbody2D>();             // used to adjust player's rigidbody via script
                
    }

    void FixedUpdate()
    {
        // check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

    }

    void Update()
    {
        ChangeDirection();
        Jump(); 
    }

    private void Jump()
    {
        // player jumps if the space key is pressed and if the player is on the ground
        if (/*Input.GetKey(KeyCode.Space)*/ Input.touchCount == 1 && (isGrounded == true || canJump == true))
        {
            // player jumps
            _rigidbody2D.velocity += Vector2.up * jumpHeight;
            this._rigidbody2D.gravityScale = 35f;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // when the player hits the wall then it stops moving and it's allowed to jump
        if (collision.gameObject.tag == "Wall")
        {
            isMoving = false;                                   // can't move
            canJump = true;                                     // can jump

            // player's movement stops - see source code above
            _rigidbody2D.velocity = Vector2.zero;

            // player gravity stops - see source code above
            this._rigidbody2D.gravityScale = 0.0f;


        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // when the player dosn't hit the wall then it moves and it can't jump
        isMoving = true;                                    // can move
        canJump = false;                                    // can't jump
    }

}
