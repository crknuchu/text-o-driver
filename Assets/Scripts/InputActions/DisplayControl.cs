using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayControl : MonoBehaviour
{
    private Image image;
    public EInputAction action;
    public string actionString;
    private EInputDevice device;
    private Text actionText;

    void InitDisplayControl()
    {
        image = GetComponentInChildren<Image>();
        actionText = GetComponentInChildren<Text>();
        actionText.text = actionString;
        device = InputManager.instance.GetInputDevice();
        image.sprite = SpriteManager.instance.GetSprite(action, device);
    }
    void Start()
    {
        InitDisplayControl();
    }

    void Update()
    {
        device = InputManager.instance.GetInputDevice();
        image.sprite = SpriteManager.instance.GetSprite(action, device);
    }
}
