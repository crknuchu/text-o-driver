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
}
