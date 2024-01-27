using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float speed;
    public float unloadDistance;

    void Update()
    {
        transform.position -= new Vector3(0, 0, speed);
        if (transform.position.z <= -unloadDistance)
        {
            Destroy(gameObject);
        }
    }
}
