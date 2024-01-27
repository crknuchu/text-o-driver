using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class CharachterToSprite
{
    public CharacterType type;
    public Sprite sprite;
}

[System.Serializable]
public class InputActionToSprite
{
    public EInputAction action;
    public Sprite spriteKeyboard;
    public Sprite spriteController;
}
public class SpriteManager : MonoBehaviour
{
    public static SpriteManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public CharachterToSprite[] charachterToSprite;
    public InputActionToSprite[] InputActionToSprites;
}