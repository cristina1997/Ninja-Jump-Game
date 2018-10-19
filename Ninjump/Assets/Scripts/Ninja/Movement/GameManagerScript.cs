// Code adapted from:
// - Automatic Movement: https://www.youtube.com/watch?v=3hdx_uNwY2A
// - Jump on Ground: https://www.youtube.com/watch?v=QGDeafTx5ug

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;

    public static int direction;
    public Vector3 moveVector;

    Rigidbody2D _rigidbody2D;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //public string LR_direction;
    private void Awake()
    {
        checkRadius = 0.5f;
        direction = 1;
        moveSpeed = 150f;
        jumpHeight = 30;
    }

    void Start()
    {
        moveVector.Set(direction, 0, 0);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        ChangeDirection();
        Debug.Log(isGrounded);
        //if (WallCollision.facingRight == false && direction > 0)
        //{
        //    Flip();
        //} else if (WallCollision.facingRight == true && direction < 0)
        //{
        //    Flip();
        //}

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            _rigidbody2D.velocity += Vector2.up * jumpHeight;

            isGrounded = false;
        } 

    }

    private void ChangeDirection()
    {
        if (WallCollision.newDirection != 0)
        {
            direction = WallCollision.newDirection;
        }

        moveVector.Set(direction, 0, 0);
    }

    //void Flip()
    //{
    //    Vector3 Scaler = transform.localScale;
    //    Scaler.x *= -1;
    //    transform.localScale = Scaler;

    //}

}
