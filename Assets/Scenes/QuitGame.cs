using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitGameNow()
    {
        RumbleManager.instance.RumblePulse(0,0,0);
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #endif
                Application.Quit();
    }
}
