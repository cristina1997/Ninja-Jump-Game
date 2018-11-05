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
    public static bool canJumpOnWall;                             // used to tell if player can or can't move depending on what's colliding with

    // Jump Variables
    Rigidbody2D _rigidbody2D;                               // 2D sprites physics component

    public float jumpWallHeight;                            // how high player can jump off the wall
    private bool isGrounded;                                // detect if character is standing on the ground
    public Transform groundCheck;                           // takes object underneath player's feet to detect if grounded
    public float checkRadiusGround;                         // radius of the circle underneath the player's feet that detects if the player is grounded
    public LayerMask whatIsGround;                          // uses only object with a chosen layer value

    public float jumpFloorHeight;                           // how high player can jump off the floor
    public float jumpPushForce;                             // the force by which player jumps sideways
    private bool isWalledR;                                 // detect if character is on the right wall
    private bool isWalledL;                                 // detect if character is on the left wall
    private bool isWalledFinal;                             // detect if character is on the left or right wall
    public Transform wallCheckR;                            // takes object at the right of the player to detect if walled
    public Transform wallCheckL;                            // takes object at the left of the player to detect if walled
    public float checkRadiusWall;                           // radius of the circle underneath the player's feet that detects if the player is walled
    public LayerMask whatIsWall;                            // uses only object with a chosen layer value

    // Set the starting values
    void Awake()
    {
        direction = 1;
        moveSpeed = 150f;

        checkRadiusGround = 0.5f;
        jumpWallHeight = 500 * 2;

        checkRadiusWall = 0.5f;
        jumpFloorHeight = 40;
        jumpPushForce = 5;

        isMoving = true;
        canJumpOnWall = false;
    }

    void Start()
    {
        moveVector.Set(direction, 0);                           // set the starting direction of the player (left, right)
        _rigidbody2D = GetComponent<Rigidbody2D>();             // used to adjust player's rigidbody via script
                
    }

    void FixedUpdate()
    {

        // check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadiusGround, whatIsGround);

        // check if the player is on the right wall
        isWalledR = Physics2D.OverlapCircle(wallCheckR.position, checkRadiusWall, whatIsWall);
        // check if the player is on the left wall
        isWalledL = Physics2D.OverlapCircle(wallCheckL.position, checkRadiusWall, whatIsWall);

        // if the player is on either the right or left wall 
        // then the player touched the wall and isWalledFinal comes out true
        if (isWalledL || isWalledR)
        {
            
            isWalledFinal = true;
        }

        
    }
    
    void Update()
    {
        ChangeDirection();
        Jump();
    }

    private void Jump()
    {
        // float move = Input.GetAxis("Horizontal"); 

        // player jumps if the space key is pressed and if the player is on the ground or on the wall
        if (Input.GetKey(KeyCode.Space) /*Input.simulateMouseWithTouches*/ /*Input.touchCount == 1*/)
        {
            if (isGrounded == true)
            {
                FloorJump();

            }
            else if (canJumpOnWall == true/*isWalledFinal == true*/)
            {
                //WallJumping.Jump();

                WallJump();
            }

        }
    }

    private void FloorJump()
    {
        // player jumps
        //_rigidbody2D.velocity = new Vector2(move * moveSpeed, _rigidbody2D.velocity.y);
        //_rigidbody2D.AddForce(new Vector2(jumpSide, jumpHeight));

        _rigidbody2D.velocity += Vector2.up * jumpFloorHeight;
        GravityScale();

    }

 
    private void WallJump()
    {
        if (isGrounded == true)
        {
            FloorJump();
        } else
        {
            if (WallCollision.isFacingRight == true)
            {
                //Debug.Log("Facing Right");
                _rigidbody2D.AddForce(new Vector2(-jumpPushForce, jumpWallHeight));
            }
            else if (WallCollision.isFacingRight == false)
            {
                //Debug.Log("Facing Left");
                _rigidbody2D.AddForce(new Vector2(jumpPushForce, jumpWallHeight));
            }

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
            canJumpOnWall = true;                               // can jump
            PlayerStops();                                      // player stops all movement, gravity included
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // when the player dosn't hit the wall then it moves and it can't jump
        isMoving = true;                                    // can move
        canJumpOnWall = false;                              // can't jump
        GravityScale();

    }

    private void PlayerStops()
    {
        // player's movement stops - see source code above
        _rigidbody2D.velocity = Vector2.zero;

        // player gravity stops - see source code above
        this._rigidbody2D.gravityScale = 0.0f;
    }

    private void GravityScale()
    {
        // player gravity starts again
        this._rigidbody2D.gravityScale = 35f;
    }
    
}
