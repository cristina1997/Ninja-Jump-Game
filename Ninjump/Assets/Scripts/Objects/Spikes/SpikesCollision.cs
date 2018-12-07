using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesCollision : MonoBehaviour {
    // Collision variables
    PlayerScript Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If the spikes come into contact with 
        // an object containing the "Player" tag then that object is killed
        if (collision.gameObject.tag == "Player")
        {
            Player.Death();
        }
    }
}
