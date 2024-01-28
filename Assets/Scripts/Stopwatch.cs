using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    private float stopwatchTime = 0f;
    public TMP_Text text;
    void Update()
    {
        stopwatchTime += Time.deltaTime;
        text.text = stopwatchTime.ToString("0.00");
    }

}
