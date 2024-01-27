using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    private InputManager InputManager;
    
    // Start is called before the first frame update
    void Start()
    {
        var health = gameObject.GetComponent<Health>();
        var rating = gameObject.GetComponent<Rating>();

        if (health != null && rating != null)
        {
            Debug.Log(health.IsPlayerDead() || rating.IsPlayerDead());
        }

        InputManager = gameController.GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (InputManager != null)
            //InputManager.SetInputContext(InputManager.InputContext.Game);
    }
}
