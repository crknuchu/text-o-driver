using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitComponents();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.controls.Rumble.RumbleAction.WasPressedThisFrame())
        {
            RumbleManager.instance.RumblePulse(0.25f, 0.75f, 0.25f);
        }
    }

    private static void InitComponents()
    {
        Debug.Log("Majmune");
        InputManager.instance.SetInputContext(InputContext.InGame);
        Debug.Log(InputManager.instance.playerInput.currentActionMap);
    }
}
