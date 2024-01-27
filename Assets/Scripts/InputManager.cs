using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] public enum InputContext
    {
        Menu = 0,
        Game
    }

    [SerializeField] private InputContext inputContext;
    void Update()
    {
        switch (inputContext)
        {
            //IN MENUS CONTEXT
            case InputContext.Menu:
                if (Input.GetButtonDown("Submit"))
                {
                    Debug.Log("AcceptAction");
                }
                else if (Input.GetButtonDown("Cancel"))
                {
                    Debug.Log("Cancel Action");
                }
                break;
            //IN GAME CONTEXT
            case InputContext.Game:
                break;
            
            //WHILE DRINKING CONTEXT
        }
    }

    public void SetInputContext(InputContext value)
    {
        inputContext = value;
    }
}
