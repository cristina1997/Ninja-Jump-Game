//// Code adapted from:
//// - Automatic Movement: https://www.youtube.com/watch?v=3hdx_uNwY2A
//// - Jump on Ground: https://www.youtube.com/watch?v=QGDeafTx5ug
//// - Stop player movement: https://answers.unity.com/questions/816848/stopping-my-player-from-moving-when-hitting-a-wall.html
//// - Player gravity stops: https://answers.unity.com/questions/767287/chow-to-disable-gravity-from-script.html
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GameManagerScript : MonoBehaviour
//{
//    // Movement Variables
//    public float moveSpeed;                                 // how fast the player moves
//    public Vector2 moveVector;                              // pass positions and directions around.
//    public static int direction;                            // representation of 2D vectors and points on two axis x&y.
//    public bool isMoving;                                   // used to tell if player can or can't move depending on what's colliding with

//    // Jump Variables
//    Rigidbody2D _rigidbody2D;                               // 2D sprites physics component
//    private bool canJumpOnWall;                             // used to tell if player can or can't move depending on what's colliding with
//    private float jumpFloorHeight;                           // how high player can jump off the floor
//    private float jumpWallHeight;                            // how high player can jump off the wall
//    private float jumpPushForce;                             // the force by which player jumps sideways   


//    public bool isGrounded;                                // detect if character is standing on the ground
//    public Transform groundCheck;                           // takes object underneath player's feet to detect if grounded
//    public float checkRadiusGround;                         // radius of the circle underneath the player's feet that detects if the player is grounded
//    public LayerMask whatIsGround;                          // uses only object with a chosen layer value



//    // Set the starting values
//    void Awake()
//    {
//        direction = 1;
//        moveSpeed = 150f;

//        checkRadiusGround = 0.5f;
//        jumpFloorHeight = 40;

//        jumpWallHeight = 500 * 2;
//        jumpPushForce = 5;

//        isMoving = true;
//        canJumpOnWall = false;
//    }

//    void Start()
//    {
//        moveVector.Set(direction, 0);                           // set the starting direction of the player (left, right)
//        _rigidbody2D = GetComponent<Rigidbody2D>();             // used to adjust player's rigidbody via script
                
//    }

//    void FixedUpdate()
//    {

//        // check if the player is on the ground
//        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadiusGround, whatIsGround);
//    }

//    void Update()
//    {
//        ChangeDirection();
//        Jump();  
//    }

//    private void Jump()
//    {

//        // player jumps if the space key is pressed and if the player is on the ground or on the wall
//        if (Input.GetKey(KeyCode.Space) /*Input.simulateMouseWithTouches*/ /*Input.touchCount == 1*/)
//        {
//            if (isGrounded == true)
//            {
//                FloorJump();

//            }
//            else if (canJumpOnWall == true)
//            {
//                WallJump();
//            }

//        }
//    }

//    private void FloorJump()
//    {
//        // player jumps
//        //_rigidbody2D.velocity = new Vector2(move * moveSpeed, _rigidbody2D.velocity.y);
//        //_rigidbody2D.AddForce(new Vector2(jumpSide, jumpHeight));

//        _rigidbody2D.velocity += Vector2.up * jumpFloorHeight;
//        GravityScale();                                        // method that gives gravity scale a value

//    }
 
//    private void WallJump()
//    {
//        if (isGrounded == true)
//        {
//            FloorJump();
//        } else
//        {
//            if (WallCollision.isFacingRight == true)
//            {
//                // if the player is facing left then jump left
//                _rigidbody2D.AddForce(new Vector2(-jumpPushForce, jumpWallHeight));
//            }
//            else if (WallCollision.isFacingRight == false)
//            {
//                // if the player is facing left then jump right
//                _rigidbody2D.AddForce(new Vector2(jumpPushForce, jumpWallHeight));
//            }

//        }

//    }

//    private void ChangeDirection()
//    {
//        // if the new direction of the player is not 0, then change the player's direction
//        if (direction != 0)
//        {
//            // get the  direction of the player from the WallCollision class
//            // according to whether or not the player is facing right or not
//            if (WallCollision.isFacingRight)
//            {
//                direction = -1;
//            }
//            else if (!WallCollision.isFacingRight) {
//                direction = 1;
//            }
//        }

//        // set the player's current direction to the updated one
//        moveVector.Set(direction, 0);
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        // when the player hits the wall then it stops moving and it's allowed to jump
//        if (collision.gameObject.tag == "Wall")
//        {
//            isMoving = false;                                   // can't move
//            canJumpOnWall = true;                               // can jump
//            PlayerStops();                                      // method that stops player movement, gravity included
//        } 
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        // when the player doesn't hit the wall then it moves and it can't jump
//        isMoving = true;                                        // can move
//        canJumpOnWall = false;                                  // can't jump
//        GravityScale();                                        // method that gives gravity scale a value
//    }

//    private void PlayerStops()
//    {
//        // player's movement stops - see source code above
//        _rigidbody2D.velocity = Vector2.zero;

//        // player gravity stops - see source code above
//        this._rigidbody2D.gravityScale = 0.0f;        

//    }

//    private void GravityScale()
//    {
//        // player gravity starts again
//        this._rigidbody2D.gravityScale = 25f;
//    }
    
//}
