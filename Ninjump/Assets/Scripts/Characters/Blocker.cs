using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    public static bool isJumpingExtra, isBlocked;

    // Use this for initialization
    void Start()
    {
        isJumpingExtra = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isJumpingExtra = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isJumpingExtra = false;
        }
    }
}
