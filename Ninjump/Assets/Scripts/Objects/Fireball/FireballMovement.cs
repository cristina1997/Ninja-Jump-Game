using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour {
    public static Vector2 originalPos;
    private float speed = 100f;
    PlayerScript Player;

    private void Start()
    {
        originalPos = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If the fireball comes into contact with 
        // an object containing the "Player" tag then that object is killed
        if (collision.gameObject.tag == "Player")
        {
            Player.Death();
        }
    }


}
