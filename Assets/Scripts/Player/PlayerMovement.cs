using System;
using System.Collections;

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Random = System.Random;


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
    public Image emptyWheel;
    public Image wheelHand;
    public GameObject wheelHandHolder;
    public Image cig;
    
    private void Awake()
    {
        InputManager.instance.SetInputContext(InputContext.InGame);
        beerImage.enabled = false;
        wheelHand.enabled = true;
        emptyWheel.enabled = false;
        cig.enabled = false;
    }

    private void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        if (InputManager.instance.controls.InGame.OptionC.WasPressedThisFrame() && !isMoving)
        {
            DrinkBeer();
        }
        
        switch (currentLane)
        {
            case Lane.left :
                if (InputManager.instance.controls.InGame.Right.WasPressedThisFrame() && !isMoving)
                {
                    StartCoroutine(MovePlayer(Vector3.right * laneDistance));
                    RotateWheelRight();
                    currentLane = Lane.middle;
                }
                break;
            
            case Lane.right :
                if (InputManager.instance.controls.InGame.Left.WasPressedThisFrame() && !isMoving)
                {
                    RotateWheelLeft();
                    StartCoroutine(MovePlayer(Vector3.left * laneDistance));
                    currentLane = Lane.middle;
                }
                break;
            
            default:
                if (InputManager.instance.controls.InGame.Left.WasPressedThisFrame() && !isMoving)
                {
                    RotateWheelLeft();
                    StartCoroutine(MovePlayer(Vector3.left * laneDistance));
                    currentLane = Lane.left;
                }
                else if (InputManager.instance.controls.InGame.Right.WasPressedThisFrame() && !isMoving)
                {
                    RotateWheelRight();
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

    void RotateWheelLeft()
    {
        Vector3 v1 = new Vector3(0, 0, 0);
        Vector3 v2 = new Vector3(0, 0, 45);
        wheelHandHolder.transform.Rotate(new Vector3(0,0,45));
    }
    
    void RotateWheelRight()
    {
        Vector3 v1 = new Vector3(0, 0, 0);
        Vector3 v2 = new Vector3(10, 0, 0);
        wheelHandHolder.transform.Rotate(new Vector3(0,0,-45));
        // StartCoroutine(StartTimer());
    }

    void DrinkBeer()
    {
        Random r = new Random();
        if (r.Next(100) < 50)
        {
            isMoving = true;
            playerHealth.AddHealth(10);
            beerImage.enabled = true;
            emptyWheel.enabled = true;
            wheelHand.enabled = false;
        }
        else
        {
            isMoving = true;
            playerHealth.AddHealth(10);
            cig.enabled = true;
            emptyWheel.enabled = true;
            wheelHand.enabled = false;
        }
        
        StartCoroutine(StartTimer());
    }
    
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(drinkingTime);
        isMoving = false;
        beerImage.enabled = false;
        emptyWheel.enabled = false;
        wheelHand.enabled = true;
        cig.enabled = false;
    }
}