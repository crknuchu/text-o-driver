using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public CameraShake cameraShake;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(cameraShake.Shake());
        RumbleManager.instance.RumblePulse(0.5f,0.75f,0.4f);
    }
    
}
