using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public float unloadDistance;
    private Rigidbody rb;
    public float magnitude = 100;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.position -= new Vector3(0, 0, speed);
        if (transform.position.z <= -unloadDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(moveObject());
        StartCoroutine(Rotate(0.2f));
    }
    
    IEnumerator moveObject()
    {
        Random r = new Random();
        Vector3 Destination = new Vector3(transform.position.x + r.Next(-2,2) , 5, transform.position.z - 5);
        float totalMovementTime = 2f; //the amount of time you want the movement to take
        float currentMovementTime = 0f;//The amount of time that has passed
        while (Vector3.Distance(transform.localPosition, Destination) > 0) {
            currentMovementTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.position, Destination, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }
    
    IEnumerator Rotate(float duration)
    {
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;
        while ( t  < duration )
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,yRotation);
            yield return null;
        }
    }
}
