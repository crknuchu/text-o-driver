using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPosition;
    public float repeatRate;
    private float[] positions = new[] {-2.67f, 0.32f, 3.32f};
    
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 0, repeatRate);
    }
    public void SpawnObstacle()
    {
        float position = positions[Random.Range(0,positions.Length)];
        spawnPosition = new Vector3(position, 1, 100);
        Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], spawnPosition, transform.rotation);
    }
}
