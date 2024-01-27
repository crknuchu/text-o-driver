using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private float currentHealth;
    // public Canvas healthBar;
    public Image mask;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void AddHealth(float value)
    {
        if (currentHealth + value > maxHealth)
        {
            currentHealth = maxHealth;
            mask.fillAmount = currentHealth / 100.0f;
        }
        else
        {
            currentHealth += value;
            mask.fillAmount = currentHealth / 100.0f;
        }
    }    
    public void RemoveHealth(float value)
    {
        currentHealth -= value;
        mask.fillAmount = currentHealth / 100.0f;
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
