using System;
using System.Collections;

using System.Collections.Generic;

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
    private InputAction moveLeft;
    private InputAction moveRight;

    private void Update()
    {
        if (currentLane == Lane.middle)
        {
            if (Input.GetKey(KeyCode.A) && !isMoving)
            {
                StartCoroutine(MovePlayer(Vector3.left * laneDistance));
                currentLane = Lane.left;
            }
            if (Input.GetKey(KeyCode.D) && !isMoving)
            {
                StartCoroutine(MovePlayer(Vector3.right * laneDistance));
                currentLane = Lane.right;
            }
        }
        else if (currentLane == Lane.right)
        {
            if (Input.GetKey(KeyCode.A) && !isMoving)
            {
                StartCoroutine(MovePlayer(Vector3.left * laneDistance));
                currentLane = Lane.middle;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D) && !isMoving)
            {
                StartCoroutine(MovePlayer(Vector3.right * laneDistance));
                currentLane = Lane.middle;
            }
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
}