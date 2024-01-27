using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public Vector3 spawnPosition;
    public float repeatRate;
    
    void Start()
    {
        InvokeRepeating("SpawnTile", 0, repeatRate);
    }
    public void SpawnTile()
    {
        Instantiate(tilePrefabs[Random.Range(0, tilePrefabs.Length)], spawnPosition, transform.rotation);
    }
}
