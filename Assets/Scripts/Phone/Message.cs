using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    Wife,
    Boss,
    CarMechanic,
    Neighbor,
    Mobster,
    BestFriend
}

[CreateAssetMenu]
public class Message : ScriptableObject
{
    [Header("NPC")] 
    public CharacterType charachter;
    public string npcQuestion;
    public string npcPositiveAnswer;
    public string npcNegativeAnswer;
    
    [Header("Player")]
    public string playerPositiveAnswer;
    public string playerNegativeAnswer;
}
