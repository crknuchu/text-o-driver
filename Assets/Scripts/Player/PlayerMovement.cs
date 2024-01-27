using System;
using System.Collections;

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour

{
    enum Lane
    {
        left,
        middle,
        right
    };
    
    private bool isMoving;
    private Vector3 origPos;
    private Vector3 targetPos;
    public float timeToMove = 0.5f;
    private float laneDistance = 3;
    private Lane currentLane = Lane.middle;
    public Health playerHealth;
    public float drinkingTime;
    // private bool isDrinking = false;
    // public Canvas beer;
    
    private void Awake()
    {
        InputManager.instance.SetInputContext(InputContext.InGame);
        // beer.enabled = false;
    }

    private void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        if (InputManager.instance.controls.InGame.OptionC.WasPressedThisFrame())
        {
            DrinkBeer();
        }
        
        switch (currentLane)
        {
            case Lane.left :
                if (InputManager.instance.controls.InGame.Right.WasPressedThisFrame() && !isMoving)
                {
                    StartCoroutine(MovePlayer(Vector3.right * laneDistance));
                    currentLane = Lane.middle;
                }
                break;
            
            case Lane.right :
                if (InputManager.instance.controls.InGame.Left.WasPressedThisFrame() && !isMoving)
                {
                    StartCoroutine(MovePlayer(Vector3.left * laneDistance));
                    currentLane = Lane.middle;
                }
                break;
            
            default:
                if (InputManager.instance.controls.InGame.Left.WasPressedThisFrame() && !isMoving)
                {
                    StartCoroutine(MovePlayer(Vector3.left * laneDistance));
                    currentLane = Lane.left;
                }
                else if (InputManager.instance.controls.InGame.Right.WasPressedThisFrame() && !isMoving)
                {
                    StartCoroutine(MovePlayer(Vector3.right * laneDistance));
                    currentLane = Lane.right;
                }
                break;
        }
        //if (InputManager.instance.controls.InGame.Left.WasPressedThisFrame())
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;
        
        RumbleManager.instance.RumblePulse(0f,0.15f,0.1f);

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos,targetPos,(elapsedTime/timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }
    
    private IEnumerator Countdown(float drinkingTime)
    {
        
        // beer.enabled = true; 
        while(true) {
            yield return new WaitForSeconds(drinkingTime); 
            isMoving = false;
            // beer.enabled = false;
        }
    }

    void DrinkBeer()
    {
        // isMoving = true;
        // isDrinking = true;
        playerHealth.AddHealth(10);
        print(playerHealth.GetCurrentHealth());
        // StartCoroutine(Countdown(3));
        // isDrinking = false;
    }
}