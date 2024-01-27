using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class MessageSpawner : MonoBehaviour
{
    public static MessageSpawner instance;
    
    public int minimumTime = 10;
    public int maximumTime = 15;
    public bool isMessageActive = false;
    private Message[] messages;

    public GameObject prefab;
    private bool isCoroutineRunning = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        messages = Resources.LoadAll<Message>("Data");
    }

    void Update()
    {
        if(!isMessageActive && !isCoroutineRunning)
        {
            StartCoroutine(SpawnMessage());
        }
    }

    IEnumerator SpawnMessage()
    {
        isCoroutineRunning = true;
        
        int time = Random.Range(minimumTime, maximumTime);
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (!isMessageActive)
        {
            GameObject newObject = Instantiate(prefab);
            int objID = Random.Range(0, messages.Length);
            newObject.GetComponent<MessageController>().ShowMessage(messages[objID]);
        }

        isCoroutineRunning = false;
    }
}
