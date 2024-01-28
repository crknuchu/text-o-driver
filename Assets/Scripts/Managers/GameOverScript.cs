using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text timeStopwatch;

    private void Awake()
    {
        timeStopwatch.text = GameStateManager.Instance.stopwatchTime.ToString("0.00");
    }
    
}
