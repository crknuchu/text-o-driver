using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    public int damage;
    private Health playerHealth;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerHealth.RemoveHealth(damage);
        // print(playerHealth.GetCurrentHealth());
    }
}
