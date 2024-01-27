using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class MessageController : MonoBehaviour
{
    [Header("Message")] [SerializeField] private Message message;
    [Header("Player")] [SerializeField] private GameObject player;
    
    [Header("UI")]
    [SerializeField] private Text question;
    [SerializeField] private Text positiveResponse;
    [SerializeField] private Text negativeResponse;
    [SerializeField] private Button answerPositive;
    [SerializeField] private Button answerNegative;

    public bool isPositiveFirst = true;
    public bool isAnswered = false;

    
    void Start()
    {
        ShowMessage();
    }
    
    void Update()
    {
        if (isAnswered)
        {
            question.enabled = false;
            answerPositive.enabled = false;
            answerNegative.enabled = false;
            StartCoroutine(DestroyMessage(3.5f));
            return;
        }
        HandleInputs();
    }

    void InitUIElements()
    {
        question.text = message.npcQuestion;
        
        negativeResponse.text = message.npcNegativeAnswer;
        negativeResponse.enabled = false;
        positiveResponse.text = message.npcPositiveAnswer;
        positiveResponse.enabled = false;
        
        answerNegative.GetComponentInChildren<Text>().text = message.playerNegativeAnswer;
        answerPositive.GetComponentInChildren<Text>().text = message.playerPositiveAnswer;
        
        if (new Random().Next(20) % 2 == 0)
        {
            isPositiveFirst = true;
        }
        else
        {
            isPositiveFirst = false;
            Vector3 temp = answerPositive.GetComponent<Transform>().position;
            answerPositive.GetComponent<Transform>().position = answerNegative.GetComponent<Transform>().position;
            answerNegative.GetComponent<Transform>().position = temp;
        }
    }

    public void ShowMessage()
    {
        if (message != null)
        {
            InitUIElements();
        }
    }
    
    public void ShowMessage(Message _message)
    {
        message = _message;
        if (message != null)
        {
            InitUIElements();
        }
    }

    void HandleInputs()
    {
        if (isAnswered)
        {
            return;
        }

        if (isPositiveFirst)
        {
            if (InputManager.instance.controls.InGame.OptionA.WasPressedThisFrame())
            {
                //POSITIVE
                BoostPlayer();
                positiveResponse.enabled = true;
                negativeResponse.enabled = false;
                isAnswered = true;
            }
            else if (InputManager.instance.controls.InGame.OptionB.WasPressedThisFrame())
            {
                //NEGATIVE
                HurtPlayer();
                positiveResponse.enabled = false;
                negativeResponse.enabled = true;
                isAnswered = true;
            }
        }
        else
        {
            if (InputManager.instance.controls.InGame.OptionA.WasPressedThisFrame())
            {
                //NEGATIVE
                positiveResponse.enabled = false;
                negativeResponse.enabled = true;
                HurtPlayer();
                isAnswered = true;
            }
            else if (InputManager.instance.controls.InGame.OptionB.WasPressedThisFrame())
            {
                //POSITIVE
                positiveResponse.enabled = true;
                negativeResponse.enabled = false;
                BoostPlayer();
                isAnswered = true;
            }
        }
        

    }

    void HurtPlayer()
    {
        player.GetComponent<Rating>().RemoveRating(message.removeRating);
    }

    void BoostPlayer()
    {
        player.GetComponent<Rating>().AddRating(message.addRating);
    }
    
    IEnumerator DestroyMessage(float After)
    {
        float elapsedTime = 0f;

        while (elapsedTime < After)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        Destroy(gameObject);
    }
}
