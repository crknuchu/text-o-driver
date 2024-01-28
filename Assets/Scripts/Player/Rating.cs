using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rating : MonoBehaviour
{
    [SerializeField] private float maxRating = 100.0f;
    [SerializeField] private float currentRating;
    public Image mask;

    void Start()
    {
        currentRating = maxRating;
    }
    
    private void Update()
    {
        if (IsPlayerDead())
        {
            GameStateManager.Instance.SetGameState(GameState.GameOver);
        }
    }

    public void AddRating(float value)
    {
        if (currentRating < maxRating)
            currentRating += value;
        if (currentRating > maxRating)
            currentRating = maxRating;
        mask.fillAmount = currentRating / 100.0f;
    }    
    public void RemoveRating(float value)
    {
        if (currentRating > 0)
            currentRating -= value;
        mask.fillAmount = currentRating / 100.0f;
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
