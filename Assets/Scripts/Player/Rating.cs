using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour
{
    [SerializeField] private float maxRating = 100.0f;
    [SerializeField] private float currentRating;

    void Start()
    {
        currentRating = maxRating;
    }

    public void AddRating(float value)
    {
        if (currentRating < maxRating)
            currentRating += value;
        if (currentRating > maxRating)
            currentRating = maxRating;
    }    
    public void RemoveRating(float value)
    {
        if (currentRating > 0)
            currentRating -= value;
    }

    public float GetMaxRating()
    {
        return maxRating;
    }
    public float GetCurrentHealth()
    {
        return currentRating;
    }

    public bool IsPlayerDead()
    {
        return currentRating <= 0.0f;
    }

}
