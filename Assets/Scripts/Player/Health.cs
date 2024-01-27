using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void AddHealth(float value)
    {
        if (currentHealth + value > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }    
    public void RemoveHealth(float value)
    {
        currentHealth -= value;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public bool IsPlayerDead()
    {
        return currentHealth <= 0.0f;
    }
    
}
