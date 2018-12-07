using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    // Collision variable
    public static bool isJumpingExtra;

    // Use this for initialization
    void Start()
    {
        isJumpingExtra = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the spikes come into contact with 
        // an object containing the "Player" tag then that object should have the ability of an extra jump
        if (collision.gameObject.tag == "Player")
        {
            isJumpingExtra = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // If the spikes exits the contact with 
        // an object containing the "Player" tag then that object should lose the ability of an extra jump
        if (collision.gameObject.tag == "Player")
        {
            isJumpingExtra = false;
        }
    }
}
