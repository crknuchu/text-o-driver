using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public enum InputContext
{
    Menu = 0,
    InGame
}

public enum EInputAction
{
    OnActionA,
    OnActionB,
    Submit,
    Cancel,
    Quit
}

public enum EInputDevice
{
    Keyboard,
    Controller
}

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [HideInInspector] public Controls controls;
    [HideInInspector] public PlayerInput playerInput;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        controls = new Controls();

        playerInput = GetComponent<PlayerInput>();
        
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    [SerializeField] private InputContext inputContext;
    [SerializeField] private EInputDevice inputDevice;
    void Update()
    {
        
    }

    public void SetInputContext(InputContext value)
    {
        inputContext = value;
        switch (value)
        {
            case InputContext.InGame:
                //playerInput.actions.FindActionMap("InGame").Enable();
                playerInput.SwitchCurrentActionMap("InGame");
                break;
            
            case InputContext.Menu:
                //playerInput.actions.FindActionMap("Menu").Enable();
                playerInput.SwitchCurrentActionMap("Menu");
                break;
        }
    }

    public void SetInputDevice(EInputDevice device)
    {
        inputDevice = device;
    }

    public EInputDevice GetInputDevice()
    {
        return inputDevice;
    }
}
