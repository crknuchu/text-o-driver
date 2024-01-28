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
    private int lastUsedMessageIndex = -1;

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
        ShuffleMessages();
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
            int objID = GetNextMessageIndex();
            newObject.GetComponent<MessageController>().ShowMessage(messages[objID]);
        }

        isCoroutineRunning = false;
    }
    
    int GetNextMessageIndex()
    {
        lastUsedMessageIndex++;

        // Check if we reached the end of the array
        if (lastUsedMessageIndex >= messages.Length)
        {
            lastUsedMessageIndex = 0; // Reset index to the beginning
            ShuffleMessages(); // Reshuffle the array
        }

        return lastUsedMessageIndex;
    }
    
    void ShuffleMessages()
    {
        // Fisher-Yates shuffle algorithm
        int n = messages.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Message temp = messages[i];
            messages[i] = messages[j];
            messages[j] = temp;
        }
    }
}
