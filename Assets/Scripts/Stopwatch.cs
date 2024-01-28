using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    private float stopwatchTime = 0f;
    public TMP_Text text;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player.GetComponent<Health>().IsPlayerDead() || player.GetComponent<Rating>().IsPlayerDead())
        {
            GameStateManager.Instance.stopwatchTime = stopwatchTime;
        }
        else
        {
            stopwatchTime += Time.deltaTime;
            text.text = stopwatchTime.ToString("0.00");
        }
    }

}
