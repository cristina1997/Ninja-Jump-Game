using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{

    public GameObject fireballController;
    private GameObject newFireball;
    Vector2 newPosition;
    public float spawnTime = 5f;

    private void Start()
    {
        fireballController = GameObject.FindGameObjectWithTag("Fireball");
        newPosition = FireballMovement.originalPos;
        InvokeRepeating("SpawnFireBall", spawnTime, spawnTime);
 
    }

    public void SpawnFireBall()
    {
        newFireball.transform.position = newPosition;
        newFireball = Instantiate(fireballController);
    }
}
