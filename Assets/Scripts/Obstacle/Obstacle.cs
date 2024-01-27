using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public float unloadDistance;
    private Rigidbody rb;

    void FixedUpdate()
    {
        transform.position -= new Vector3(0, 0, speed);
        if (transform.position.z <= -unloadDistance)
        {
            Destroy(gameObject);
        }
    }
}
