using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveVector;

    private void Start()
    {
        moveSpeed = 100f;
        moveVector.Set(1, 0, 0);
    }
}
