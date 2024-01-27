using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    AngryHusband,
    BalkanBoy,
    BendersWitnesses,
    BestFriend,
    BestTel,
    Boss,
    CarMechanic,
    Delievery,
    Mobster,
    Neighbor,
    Prankster,
    TheParty,
    Wife
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

    [Header("Rating")]
    public float addRating = 0f;
    public float removeRating = 0f;

}
