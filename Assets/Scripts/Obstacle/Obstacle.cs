using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public float unloadDistance;
    private Rigidbody rb;
    
    // private void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    //     rb.AddForce(0,10,0);
    // }

    void FixedUpdate()
    {
        transform.position -= new Vector3(0, 0, speed);
        if (transform.position.z <= -unloadDistance)
        {
            Destroy(gameObject);
        }
    }
}
