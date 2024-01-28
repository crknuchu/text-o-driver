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
    Wife,
    Police,
    UncleJoca,
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
    
    public static string GetName(CharacterType type)
    {
        switch (type)
        {
            case CharacterType.Boss:
                return "Boss";
            case CharacterType.Delievery:
                return "Delievery";
            case CharacterType.Wife:
                return "Wife";
            case CharacterType.Mobster:
                return "Velja Nevolja";
            case CharacterType.Prankster:
                return "Unknown Number";
            case CharacterType.AngryHusband:
                return "Angry Joe";
            case CharacterType.BalkanBoy:
                return "Balkan Boy";
            case CharacterType.BendersWitnesses:
                return "Bender's Witnesses";
            case CharacterType.BestFriend:
                return "Jimmy BFF";
            case CharacterType.BestTel:
                return "BesTel";
            case CharacterType.CarMechanic:
                return "Car Mechanic";
            case CharacterType.TheParty:
                return "THE PARTY";
            case CharacterType.Neighbor:
                return "Will the Neighbor";
            case CharacterType.Police:
                return "Police Department";
            case CharacterType.UncleJoca:
                return "Uncle Joca";
        }

        return "Stojan";
    }

}
