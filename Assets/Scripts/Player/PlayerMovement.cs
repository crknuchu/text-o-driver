using System;
using System.Collections;

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


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
    public Image beerImage;
    
    private void Awake()
    {
        InputManager.instance.SetInputContext(InputContext.InGame);
        beerImage.enabled = false;
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
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos,targetPos,(elapsedTime/timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }

    void DrinkBeer()
    {
        isMoving = true;
        playerHealth.AddHealth(10);
        beerImage.enabled = true;
        StartCoroutine(StartTimer());
    }
    
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(drinkingTime);
        isMoving = false;
        beerImage.enabled = false;
    }
}